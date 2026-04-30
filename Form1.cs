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
            Curve,
            Pen
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

        private float zoomFactor = 1.0f;
        private Panel canvasPanel;

        public Form1()
        {
            InitializeComponent();

            canvasPanel = new Panel();
            canvasPanel.Location = picCanvas.Location;
            canvasPanel.Size = picCanvas.Size;
            canvasPanel.AutoScroll = true;
            canvasPanel.BorderStyle = BorderStyle.FixedSingle;

            this.Controls.Remove(picCanvas);
            canvasPanel.Controls.Add(picCanvas);
            this.Controls.Add(canvasPanel);

            picCanvas.Location = new Point(0, 0);
            picCanvas.BorderStyle = BorderStyle.None;

            canvasBitmap = new Bitmap(canvasPanel.Width, canvasPanel.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);

            picCanvas.Size = canvasBitmap.Size;
            picCanvas.Image = null; // We are drawing it in Paint

            // Set up event handlers
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;
            picCanvas.MouseWheel += PicCanvas_MouseWheel;

            picCanvas.Paint += PicCanvas_Paint;

            picColor.BackColor = currentColor;

            btnLine.Click += btnLine_Click;
            btnSquare.Click += btnSquare_Click;
            btnCircle.Click += btnCircle_Click;
            btnCurve.Click += btnCurve_Click;
            btnPen.Click += btnPen_Click;
            btnPalette.Click += btnPalette_Click;
            btnOpenFile.Click += btnOpenFile_Click;
            btnSaveFile.Click += btnSaveFile_Click;
            btnReset.Click += btnReset_Click;
            if (btnSizeUp != null) btnSizeUp.Click += btnSizeUp_Click;
            if (btnSizeDown != null) btnSizeDown.Click += btnSizeDown_Click;

            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;

            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 10;
            trbLineWidth.Value = currentLineWidth;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;

            lblLineWidth.Text = "Width : " + currentLineWidth.ToString();
        }

        private Point GetImagePoint(Point p)
        {
            return new Point((int)(p.X / zoomFactor), (int)(p.Y / zoomFactor));
        }

        // Event Handlers

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Point imgPt = GetImagePoint(e.Location);

            if (currentTool == ToolType.Curve)
            {
                if (curveState == 0)
                {
                    isDrawing = true;
                    startPoint = imgPt;
                    curveP1 = imgPt;
                    curveP2 = imgPt;
                    curveState = 1;
                }
                else if (curveState == 2)
                {
                    isDrawing = true;
                    curveP3 = imgPt;
                    curveP4 = imgPt;
                    curveState = 3;
                }
                else if (curveState == 4)
                {
                    isDrawing = true;
                    curveP4 = imgPt;
                    curveState = 5;
                }
            }
            else
            {
                isDrawing = true;
                startPoint = imgPt;
            }
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            Point imgPt = GetImagePoint(e.Location);

            if (currentTool == ToolType.Curve)
            {
                if (curveState == 1)
                {
                    endPoint = imgPt;
                    curveP2 = imgPt;
                }
                else if (curveState == 3)
                {
                    curveP3 = imgPt;
                    curveP4 = imgPt;
                }
                else if (curveState == 5)
                {
                    curveP4 = imgPt;
                }
            }
            else if (currentTool == ToolType.Pen)
            {
                endPoint = imgPt;
                using (Pen pen = new Pen(currentColor, currentLineWidth))
                {
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                    canvasGraphics.DrawLine(pen, startPoint, endPoint);
                }
                startPoint = endPoint;
            }
            else
            {
                endPoint = imgPt;
            }
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;
            Point imgPt = GetImagePoint(e.Location);

            if (currentTool == ToolType.Curve)
            {
                if (curveState == 1)
                {
                    endPoint = imgPt;
                    curveP2 = imgPt;
                    curveState = 2;
                    picCanvas.Invalidate();
                }
                else if (curveState == 3)
                {
                    curveP3 = imgPt;
                    curveP4 = imgPt;
                    curveState = 4;
                    picCanvas.Invalidate();
                }
                else if (curveState == 5)
                {
                    curveP4 = imgPt;
                    using (Pen pen = new Pen(currentColor, currentLineWidth))
                    {
                        DrawShape(canvasGraphics, pen, startPoint, endPoint);
                    }
                    curveState = 0;
                    picCanvas.Invalidate();
                }
            }
            else if (currentTool == ToolType.Pen)
            {
                return;
            }
            else
            {
                endPoint = imgPt;

                using (Pen pen = new Pen(currentColor, currentLineWidth))
                {
                    DrawShape(canvasGraphics, pen, startPoint, endPoint);
                }

                picCanvas.Invalidate();
            }
        }

        private void UpdateZoom(float multiplier)
        {
            zoomFactor *= multiplier;
            zoomFactor = Math.Max(0.1f, Math.Min(10.0f, zoomFactor));
            picCanvas.Size = new Size((int)(canvasBitmap.Width * zoomFactor), (int)(canvasBitmap.Height * zoomFactor));
            picCanvas.Invalidate();
        }

        private void PicCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.Delta > 0) UpdateZoom(1.2f);
                else UpdateZoom(1.0f / 1.2f);
            }
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(zoomFactor, zoomFactor);
            e.Graphics.DrawImage(canvasBitmap, Point.Empty);

            bool isCurvePreview = (currentTool == ToolType.Curve && curveState > 0);
            if (!isDrawing && !isCurvePreview) return;
            if (currentTool == ToolType.Pen) return;

            Color previewColor = currentColor;


            previewColor = Color.FromArgb(128, 64, 64, 64);

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

            picColor.BackColor = currentColor;
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

        private void btnPen_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Pen;
            curveState = 0;
            picCanvas.Invalidate();
            refreshButtons();
        }

        private ColorPalette colorPaletteForm;

        private void btnPalette_Click(object sender, EventArgs e)
        {
            if (colorPaletteForm == null || colorPaletteForm.IsDisposed)
            {
                colorPaletteForm = new ColorPalette();
                colorPaletteForm.StartPosition = FormStartPosition.Manual;
                colorPaletteForm.Location = new Point(this.Right, this.Top);
                colorPaletteForm.ColorSelected += (color) =>
                {
                    currentColor = color;
                    picColor.BackColor = currentColor;
                    cmbColor.Text = "Custom";
                };
                colorPaletteForm.Show(this);
            }
            else
            {
                colorPaletteForm.Focus();
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                saveFileDialog.Title = "이미지 저장하기";
                saveFileDialog.FileName = "Untitled";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName != "")
                    {
                        ImageFormat format = ImageFormat.Jpeg;
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1:
                                format = ImageFormat.Jpeg;
                                break;
                            case 2:
                                format = ImageFormat.Png;
                                break;
                            case 3:
                                format = ImageFormat.Bmp;
                                break;
                        }

                        canvasBitmap.Save(saveFileDialog.FileName, format);
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "이미지 열기";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Image img = Image.FromFile(openFileDialog.FileName))
                    {
                        canvasBitmap = new Bitmap(img);
                    }

                    if (canvasGraphics != null) canvasGraphics.Dispose();
                    canvasGraphics = Graphics.FromImage(canvasBitmap);

                    zoomFactor = 1.0f;
                    picCanvas.Size = canvasBitmap.Size;
                    curveState = 0;
                    isDrawing = false;
                    picCanvas.Invalidate();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            canvasGraphics.Clear(Color.White);
            curveState = 0;
            isDrawing = false;
            picCanvas.Invalidate();
        }

        private void btnSizeUp_Click(object sender, EventArgs e)
        {
            UpdateZoom(1.2f);
        }

        private void btnSizeDown_Click(object sender, EventArgs e)
        {
            UpdateZoom(1.0f / 1.2f);
        }

        // functions

        private void refreshButtons()
        {
            btnLine.BackColor = Color.White;
            btnSquare.BackColor = Color.White;
            btnCircle.BackColor = Color.White;
            btnCurve.BackColor = Color.White;
            if (btnPen != null) btnPen.BackColor = Color.White;

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
                case ToolType.Pen:
                    if (btnPen != null) btnPen.BackColor = Color.Gray;
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
