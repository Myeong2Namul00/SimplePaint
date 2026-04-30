namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            boxShape = new GroupBox();
            btnCurve = new Button();
            btnCircle = new Button();
            btnSquare = new Button();
            btnLine = new Button();
            boxColor = new GroupBox();
            picColor = new PictureBox();
            btnPalette = new Button();
            cmbColor = new ComboBox();
            boxLineWidth = new GroupBox();
            lblLineWidth = new Label();
            trbLineWidth = new TrackBar();
            lblAppName = new Label();
            picCanvas = new PictureBox();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            boxPen = new GroupBox();
            btnPen = new Button();
            btnReset = new Button();
            boxSizeControl = new GroupBox();
            btnSizeDown = new Button();
            btnSizeUp = new Button();
            boxShape.SuspendLayout();
            boxColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picColor).BeginInit();
            boxLineWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            boxPen.SuspendLayout();
            boxSizeControl.SuspendLayout();
            SuspendLayout();
            // 
            // boxShape
            // 
            boxShape.Controls.Add(btnCurve);
            boxShape.Controls.Add(btnCircle);
            boxShape.Controls.Add(btnSquare);
            boxShape.Controls.Add(btnLine);
            boxShape.FlatStyle = FlatStyle.Flat;
            boxShape.Font = new Font("나눔고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            boxShape.Location = new Point(123, 97);
            boxShape.Name = "boxShape";
            boxShape.Size = new Size(443, 137);
            boxShape.TabIndex = 0;
            boxShape.TabStop = false;
            boxShape.Text = "도형 그리기";
            // 
            // btnCurve
            // 
            btnCurve.BackColor = SystemColors.Control;
            btnCurve.FlatStyle = FlatStyle.Flat;
            btnCurve.Image = (Image)resources.GetObject("btnCurve.Image");
            btnCurve.ImageAlign = ContentAlignment.TopCenter;
            btnCurve.Location = new Point(338, 25);
            btnCurve.Name = "btnCurve";
            btnCurve.Size = new Size(89, 101);
            btnCurve.TabIndex = 3;
            btnCurve.Text = "곡선";
            btnCurve.TextAlign = ContentAlignment.BottomCenter;
            btnCurve.UseVisualStyleBackColor = false;
            // 
            // btnCircle
            // 
            btnCircle.BackColor = SystemColors.Control;
            btnCircle.FlatStyle = FlatStyle.Flat;
            btnCircle.Image = (Image)resources.GetObject("btnCircle.Image");
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(232, 25);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(89, 101);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = false;
            // 
            // btnSquare
            // 
            btnSquare.BackColor = SystemColors.Control;
            btnSquare.FlatStyle = FlatStyle.Flat;
            btnSquare.Image = (Image)resources.GetObject("btnSquare.Image");
            btnSquare.ImageAlign = ContentAlignment.TopCenter;
            btnSquare.Location = new Point(126, 25);
            btnSquare.Name = "btnSquare";
            btnSquare.Size = new Size(89, 101);
            btnSquare.TabIndex = 1;
            btnSquare.Text = "사각형";
            btnSquare.TextAlign = ContentAlignment.BottomCenter;
            btnSquare.UseVisualStyleBackColor = false;
            // 
            // btnLine
            // 
            btnLine.BackColor = SystemColors.Control;
            btnLine.FlatStyle = FlatStyle.Flat;
            btnLine.Image = (Image)resources.GetObject("btnLine.Image");
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(17, 25);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(89, 101);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = false;
            // 
            // boxColor
            // 
            boxColor.Controls.Add(picColor);
            boxColor.Controls.Add(btnPalette);
            boxColor.Controls.Add(cmbColor);
            boxColor.FlatStyle = FlatStyle.Flat;
            boxColor.Font = new Font("나눔고딕", 12F, FontStyle.Bold);
            boxColor.Location = new Point(572, 97);
            boxColor.Name = "boxColor";
            boxColor.Size = new Size(161, 137);
            boxColor.TabIndex = 1;
            boxColor.TabStop = false;
            boxColor.Text = "색 선택";
            // 
            // picColor
            // 
            picColor.BorderStyle = BorderStyle.FixedSingle;
            picColor.Location = new Point(124, 94);
            picColor.Name = "picColor";
            picColor.Size = new Size(29, 28);
            picColor.TabIndex = 8;
            picColor.TabStop = false;
            // 
            // btnPalette
            // 
            btnPalette.BackColor = Color.White;
            btnPalette.FlatStyle = FlatStyle.Flat;
            btnPalette.Font = new Font("나눔고딕", 12F, FontStyle.Bold);
            btnPalette.Location = new Point(10, 87);
            btnPalette.Name = "btnPalette";
            btnPalette.Size = new Size(108, 39);
            btnPalette.TabIndex = 7;
            btnPalette.Text = "팔레트 열기";
            btnPalette.UseVisualStyleBackColor = false;
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black", "Red", "Green", "Blue" });
            cmbColor.Location = new Point(10, 44);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(141, 27);
            cmbColor.TabIndex = 0;
            // 
            // boxLineWidth
            // 
            boxLineWidth.Controls.Add(lblLineWidth);
            boxLineWidth.Controls.Add(trbLineWidth);
            boxLineWidth.FlatStyle = FlatStyle.Flat;
            boxLineWidth.Font = new Font("나눔고딕", 12F, FontStyle.Bold);
            boxLineWidth.Location = new Point(739, 97);
            boxLineWidth.Name = "boxLineWidth";
            boxLineWidth.Size = new Size(196, 137);
            boxLineWidth.TabIndex = 2;
            boxLineWidth.TabStop = false;
            boxLineWidth.Text = "선 두께";
            // 
            // lblLineWidth
            // 
            lblLineWidth.AutoSize = true;
            lblLineWidth.Font = new Font("나눔고딕", 20F, FontStyle.Bold);
            lblLineWidth.Location = new Point(18, 87);
            lblLineWidth.Name = "lblLineWidth";
            lblLineWidth.Size = new Size(140, 31);
            lblLineWidth.TabIndex = 1;
            lblLineWidth.Text = "Width : 0";
            lblLineWidth.TextAlign = ContentAlignment.TopCenter;
            // 
            // trbLineWidth
            // 
            trbLineWidth.BackColor = SystemColors.AppWorkspace;
            trbLineWidth.Location = new Point(18, 39);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(161, 45);
            trbLineWidth.TabIndex = 0;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("나눔고딕", 42F, FontStyle.Bold);
            lblAppName.ForeColor = Color.Blue;
            lblAppName.Location = new Point(12, 21);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(352, 65);
            lblAppName.TabIndex = 3;
            lblAppName.Text = "Simple Paint";
            // 
            // picCanvas
            // 
            picCanvas.BackColor = SystemColors.Control;
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(11, 243);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(1240, 667);
            picCanvas.TabIndex = 4;
            picCanvas.TabStop = false;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.FromArgb(255, 255, 192);
            btnOpenFile.FlatStyle = FlatStyle.Flat;
            btnOpenFile.Font = new Font("나눔고딕", 14F, FontStyle.Bold);
            btnOpenFile.Location = new Point(941, 105);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(147, 49);
            btnOpenFile.TabIndex = 5;
            btnOpenFile.Text = "이미지 열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.FromArgb(192, 255, 192);
            btnSaveFile.FlatStyle = FlatStyle.Flat;
            btnSaveFile.Font = new Font("나눔고딕", 14F, FontStyle.Bold);
            btnSaveFile.Location = new Point(1094, 105);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(157, 49);
            btnSaveFile.TabIndex = 6;
            btnSaveFile.Text = "파일로 저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // boxPen
            // 
            boxPen.Controls.Add(btnPen);
            boxPen.Font = new Font("나눔고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            boxPen.Location = new Point(14, 97);
            boxPen.Name = "boxPen";
            boxPen.Size = new Size(101, 137);
            boxPen.TabIndex = 7;
            boxPen.TabStop = false;
            boxPen.Text = "펜";
            // 
            // btnPen
            // 
            btnPen.BackColor = SystemColors.Control;
            btnPen.FlatStyle = FlatStyle.Flat;
            btnPen.Image = (Image)resources.GetObject("btnPen.Image");
            btnPen.ImageAlign = ContentAlignment.TopCenter;
            btnPen.Location = new Point(6, 25);
            btnPen.Name = "btnPen";
            btnPen.Size = new Size(89, 101);
            btnPen.TabIndex = 4;
            btnPen.Text = "그리기";
            btnPen.TextAlign = ContentAlignment.BottomCenter;
            btnPen.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(255, 192, 192);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("나눔고딕", 18F, FontStyle.Bold);
            btnReset.Location = new Point(1094, 174);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(157, 60);
            btnReset.TabIndex = 8;
            btnReset.Text = "초기화";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // boxSizeControl
            // 
            boxSizeControl.Controls.Add(btnSizeDown);
            boxSizeControl.Controls.Add(btnSizeUp);
            boxSizeControl.Font = new Font("나눔고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            boxSizeControl.Location = new Point(941, 166);
            boxSizeControl.Name = "boxSizeControl";
            boxSizeControl.Size = new Size(147, 69);
            boxSizeControl.TabIndex = 9;
            boxSizeControl.TabStop = false;
            boxSizeControl.Text = "이미지 확대/축소";
            // 
            // btnSizeDown
            // 
            btnSizeDown.BackColor = Color.White;
            btnSizeDown.FlatStyle = FlatStyle.Flat;
            btnSizeDown.Font = new Font("나눔고딕", 12F, FontStyle.Bold);
            btnSizeDown.Location = new Point(87, 24);
            btnSizeDown.Name = "btnSizeDown";
            btnSizeDown.Size = new Size(36, 36);
            btnSizeDown.TabIndex = 10;
            btnSizeDown.Text = "-";
            btnSizeDown.UseVisualStyleBackColor = false;
            // 
            // btnSizeUp
            // 
            btnSizeUp.BackColor = Color.White;
            btnSizeUp.FlatStyle = FlatStyle.Flat;
            btnSizeUp.Font = new Font("나눔고딕", 12F, FontStyle.Bold);
            btnSizeUp.Location = new Point(25, 24);
            btnSizeUp.Name = "btnSizeUp";
            btnSizeUp.Size = new Size(36, 36);
            btnSizeUp.TabIndex = 9;
            btnSizeUp.Text = "+";
            btnSizeUp.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1264, 921);
            Controls.Add(boxSizeControl);
            Controls.Add(btnReset);
            Controls.Add(boxPen);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(picCanvas);
            Controls.Add(lblAppName);
            Controls.Add(boxLineWidth);
            Controls.Add(boxColor);
            Controls.Add(boxShape);
            Name = "Form1";
            Text = "Simple Paint";
            boxShape.ResumeLayout(false);
            boxColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picColor).EndInit();
            boxLineWidth.ResumeLayout(false);
            boxLineWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            boxPen.ResumeLayout(false);
            boxSizeControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox boxShape;
        private GroupBox boxColor;
        private GroupBox boxLineWidth;
        private Label lblAppName;
        private PictureBox picCanvas;
        private Button btnLine;
        private Button btnCircle;
        private Button btnSquare;
        private ComboBox cmbColor;
        private Label lblLineWidth;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private Button btnCurve;
        private Button btnPalette;
        private PictureBox picColor;
        private GroupBox boxPen;
        private Button btnPen;
        private Button btnReset;
        private GroupBox boxSizeControl;
        private Button btnSizeDown;
        private Button btnSizeUp;
    }
}
