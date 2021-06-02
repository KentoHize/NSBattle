
namespace MazeResearch
{
    partial class MainForm
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
            this.btnClick = new System.Windows.Forms.Button();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.pnlPersonal = new System.Windows.Forms.Panel();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.picT1 = new System.Windows.Forms.PictureBox();
            this.btnCrossTest = new System.Windows.Forms.Button();
            this.txtCrossX = new System.Windows.Forms.TextBox();
            this.txtCrossY = new System.Windows.Forms.TextBox();
            this.pnlCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picT1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(1189, 12);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(157, 45);
            this.btnClick.TabIndex = 0;
            this.btnClick.Text = "讀取資料";
            this.btnClick.UseVisualStyleBackColor = true;
            this.btnClick.Click += new System.EventHandler(this.btnClick_Click);
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.White;
            this.pnlCanvas.Controls.Add(this.picT1);
            this.pnlCanvas.Location = new System.Drawing.Point(12, 12);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(904, 842);
            this.pnlCanvas.TabIndex = 1;
            // 
            // pnlPersonal
            // 
            this.pnlPersonal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlPersonal.Location = new System.Drawing.Point(922, 449);
            this.pnlPersonal.Name = "pnlPersonal";
            this.pnlPersonal.Size = new System.Drawing.Size(424, 405);
            this.pnlPersonal.TabIndex = 2;
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(1189, 63);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(157, 45);
            this.btnStartSearch.TabIndex = 3;
            this.btnStartSearch.Text = "開始探索";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(1146, 175);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(62, 57);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(1146, 298);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(62, 57);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(1214, 238);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(62, 57);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(1078, 238);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(62, 57);
            this.btnLeft.TabIndex = 7;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Location = new System.Drawing.Point(1214, 298);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(62, 57);
            this.btnRotateRight.TabIndex = 8;
            this.btnRotateRight.Text = "⊙";
            this.btnRotateRight.UseVisualStyleBackColor = true;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // picT1
            // 
            this.picT1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picT1.Location = new System.Drawing.Point(14, 16);
            this.picT1.Name = "picT1";
            this.picT1.Size = new System.Drawing.Size(80, 80);
            this.picT1.TabIndex = 0;
            this.picT1.TabStop = false;
            // 
            // btnCrossTest
            // 
            this.btnCrossTest.Location = new System.Drawing.Point(1214, 386);
            this.btnCrossTest.Name = "btnCrossTest";
            this.btnCrossTest.Size = new System.Drawing.Size(110, 57);
            this.btnCrossTest.TabIndex = 9;
            this.btnCrossTest.Text = "視線測試";
            this.btnCrossTest.UseVisualStyleBackColor = true;
            this.btnCrossTest.Click += new System.EventHandler(this.btnCrossTest_Click);
            // 
            // txtCrossX
            // 
            this.txtCrossX.Location = new System.Drawing.Point(1014, 401);
            this.txtCrossX.Name = "txtCrossX";
            this.txtCrossX.Size = new System.Drawing.Size(61, 27);
            this.txtCrossX.TabIndex = 10;
            this.txtCrossX.Text = "3";
            // 
            // txtCrossY
            // 
            this.txtCrossY.Location = new System.Drawing.Point(1110, 401);
            this.txtCrossY.Name = "txtCrossY";
            this.txtCrossY.Size = new System.Drawing.Size(61, 27);
            this.txtCrossY.TabIndex = 11;
            this.txtCrossY.Text = "5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 866);
            this.Controls.Add(this.txtCrossY);
            this.Controls.Add(this.txtCrossX);
            this.Controls.Add(this.btnCrossTest);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.pnlPersonal);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.btnClick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.pnlCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picT1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Panel pnlPersonal;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.PictureBox picT1;
        private System.Windows.Forms.Button btnCrossTest;
        private System.Windows.Forms.TextBox txtCrossX;
        private System.Windows.Forms.TextBox txtCrossY;
    }
}

