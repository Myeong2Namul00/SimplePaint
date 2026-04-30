namespace SimplePaint
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {

        enum ToolType
        {
            Line,
            Rectangle,
            Circle,
            Curve
        }

        private Bitmap canvasBitmap;
        private Graphics canvasGraphics;

        private bool isDrawing = false;
        private Point startPoint;
        private Point endPoint;

        private int curveState = 0;
        private Point curveP1, curveP2, curveP3, curveP4;

        private ToolType currentTool = ToolType.Line;
        private Color currentColor = Color.Black;
        private int currentLineWidth = 2;

        public Form1()
        {
            InitializeComponent();

            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);

            picCanvas.Image = canvasBitmap;

            // Set up event handlers
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;

            picCanvas.Paint += PicCanvas_Paint;

            btnLine.Click += btnLine_Click;
            btnSquare.Click += btnSquare_Click;
            btnCircle.Click += btnCircle_Click;
            btnCurve.Click += btnCurve_Click;

            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;

            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 10;
            trbLineWidth.Value = currentLineWidth;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;

            lblLineWidth.Text = "Width : " + currentLineWidth.ToString();
        }

        // Event Handlers

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentTool == ToolType.Curve)
            {
                if (curveState == 0)
                {
                    isDrawing = true;
                    startPoint = e.Location;
                    curveP1 = e.Location;
                    curveP2 = e.Location;
                    curveState = 1;
                }
                else if (curveState == 2)
                {
                    isDrawing = true;
                    curveP3 = e.Location;
                    curveP4 = e.Location;
                    curveState = 3;
                }
                else if (curveState == 4)
                {
                    isDrawing = true;
                    curveP4 = e.Location;
                    curveState = 5;
                }
            }
            else
            {
                isDrawing = true;
                startPoint = e.Location;
            }
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            if (currentTool == ToolType.Curve)
            {
                if (curveState == 1)
                {
                    endPoint = e.Location;
                    curveP2 = e.Location;
                }
                else if (curveState == 3)
                {
                    curveP3 = e.Location;
                    curveP4 = e.Location;
                }
                else if (curveState == 5)
                {
                    curveP4 = e.Location;
                }
            }
            else
            {
                endPoint = e.Location;
            }
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;

            if (currentTool == ToolType.Curve)
            {
                if (curveState == 1)
                {
                    endPoint = e.Location;
                    curveP2 = e.Location;
                    curveState = 2;
                    picCanvas.Invalidate();
                }
                else if (curveState == 3)
                {
                    curveP3 = e.Location;
                    curveP4 = e.Location;
                    curveState = 4;
                    picCanvas.Invalidate();
                }
                else if (curveState == 5)
                {
                    curveP4 = e.Location;
                    using (Pen pen = new Pen(currentColor, currentLineWidth))
                    {
                        DrawShape(canvasGraphics, pen, startPoint, endPoint);
                    }
                    curveState = 0;
                    picCanvas.Invalidate();
                }
            }
            else
            {
                endPoint = e.Location;

                using (Pen pen = new Pen(currentColor, currentLineWidth))
                {
                    DrawShape(canvasGraphics, pen, startPoint, endPoint);
                }

                picCanvas.Invalidate();
            }
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(canvasBitmap, Point.Empty);

            bool isCurvePreview = (currentTool == ToolType.Curve && curveState > 0);
            if (!isDrawing && !isCurvePreview) return;

            Color previewColor = currentColor;

            previewColor = Color.FromArgb(128, getPreviewColor(previewColor.R), getPreviewColor(previewColor.G), getPreviewColor(previewColor.B));

            using (Pen previewPen = new Pen(previewColor, currentLineWidth))
            {
                //previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, startPoint, endPoint);
            }
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0:
                    currentColor = Color.Black;
                    break;
                case 1:
                    currentColor = Color.Red;
                    break;
                case 2:
                    currentColor = Color.Green;
                    break;
                case 3:
                    currentColor = Color.Blue;
                    break;
                default:
                    currentColor = Color.Black;
                    break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
            lblLineWidth.Text = "Width : " + currentLineWidth.ToString();
        }


        // tool buttons
        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
            curveState = 0;
            picCanvas.Invalidate();
            refreshButtons();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
            curveState = 0;
            picCanvas.Invalidate();
            refreshButtons();
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
            curveState = 0;
            picCanvas.Invalidate();
            refreshButtons();
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Curve;
            curveState = 0;
            picCanvas.Invalidate();
            refreshButtons();
        }

        // functions

        private int getPreviewColor(int color)
        {
            if (color <= 64) return (int)(color + 32);
            else
            {
                return 0;
            }
        }

        private void refreshButtons()
        {
            btnLine.BackColor = Color.White;
            btnSquare.BackColor = Color.White;
            btnCircle.BackColor = Color.White;
            btnCurve.BackColor = Color.White;

            switch (currentTool)
            {
                case ToolType.Line:
                    btnLine.BackColor = Color.Gray;
                    break;
                case ToolType.Rectangle:
                    btnSquare.BackColor = Color.Gray;
                    break;
                case ToolType.Circle:
                    btnCircle.BackColor = Color.Gray;
                    break;
                case ToolType.Curve:
                    btnCurve.BackColor = Color.Gray;
                    break;
                default:
                    break;
            }
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);
            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
                case ToolType.Curve:
                    Point cp1 = p1;
                    Point cp2 = p2;
                    if (curveState >= 3) cp1 = curveP3;
                    if (curveState == 3 || curveState == 4) cp2 = curveP3;
                    else if (curveState >= 5) cp2 = curveP4;
                    g.DrawBezier(pen, p1, cp1, cp2, p2);
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }
    }
}
