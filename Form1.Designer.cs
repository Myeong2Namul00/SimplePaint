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
            btnCircle = new Button();
            btnSquare = new Button();
            btnLine = new Button();
            boxColor = new GroupBox();
            cmbColor = new ComboBox();
            boxLineWidth = new GroupBox();
            lblLineWidth = new Label();
            trbLineWidth = new TrackBar();
            lblAppName = new Label();
            picCanvas = new PictureBox();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            boxShape.SuspendLayout();
            boxColor.SuspendLayout();
            boxLineWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // boxShape
            // 
            boxShape.Controls.Add(btnCircle);
            boxShape.Controls.Add(btnSquare);
            boxShape.Controls.Add(btnLine);
            boxShape.FlatStyle = FlatStyle.Flat;
            boxShape.Font = new Font("나눔고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            boxShape.Location = new Point(12, 98);
            boxShape.Name = "boxShape";
            boxShape.Size = new Size(443, 137);
            boxShape.TabIndex = 0;
            boxShape.TabStop = false;
            boxShape.Text = "도형 그리기";
            // 
            // btnCircle
            // 
            btnCircle.BackColor = SystemColors.Control;
            btnCircle.FlatStyle = FlatStyle.Flat;
            btnCircle.Image = (Image)resources.GetObject("btnCircle.Image");
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(207, 25);
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
            btnSquare.Location = new Point(112, 25);
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
            boxColor.Controls.Add(cmbColor);
            boxColor.FlatStyle = FlatStyle.Flat;
            boxColor.Font = new Font("나눔고딕", 12F, FontStyle.Bold);
            boxColor.Location = new Point(461, 98);
            boxColor.Name = "boxColor";
            boxColor.Size = new Size(161, 137);
            boxColor.TabIndex = 1;
            boxColor.TabStop = false;
            boxColor.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black", "Red", "Green", "Blue" });
            cmbColor.Location = new Point(10, 57);
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
            boxLineWidth.Location = new Point(628, 98);
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
            btnOpenFile.Font = new Font("나눔고딕", 18F, FontStyle.Bold);
            btnOpenFile.Location = new Point(1010, 185);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(105, 49);
            btnOpenFile.TabIndex = 5;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.FromArgb(192, 255, 192);
            btnSaveFile.FlatStyle = FlatStyle.Flat;
            btnSaveFile.Font = new Font("나눔고딕", 18F, FontStyle.Bold);
            btnSaveFile.Location = new Point(1133, 185);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(105, 49);
            btnSaveFile.TabIndex = 6;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1264, 921);
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
            boxLineWidth.ResumeLayout(false);
            boxLineWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
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
    }
}
