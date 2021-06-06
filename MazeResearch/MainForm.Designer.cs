
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
            this.picT1 = new System.Windows.Forms.PictureBox();
            this.pnlMiniCanvas = new System.Windows.Forms.Panel();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnCrossTest = new System.Windows.Forms.Button();
            this.txtCrossX = new System.Windows.Forms.TextBox();
            this.txtCrossY = new System.Windows.Forms.TextBox();
            this.lblw = new System.Windows.Forms.Label();
            this.lblh = new System.Windows.Forms.Label();
            this.btnClearVisibleBlocks = new System.Windows.Forms.Button();
            this.btnGoTo = new System.Windows.Forms.Button();
            this.txtTargetX = new System.Windows.Forms.TextBox();
            this.txtTargetY = new System.Windows.Forms.TextBox();
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
            // picT1
            // 
            this.picT1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picT1.Location = new System.Drawing.Point(14, 16);
            this.picT1.Name = "picT1";
            this.picT1.Size = new System.Drawing.Size(80, 80);
            this.picT1.TabIndex = 0;
            this.picT1.TabStop = false;
            // 
            // pnlMiniCanvas
            // 
            this.pnlMiniCanvas.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlMiniCanvas.Location = new System.Drawing.Point(922, 449);
            this.pnlMiniCanvas.Name = "pnlMiniCanvas";
            this.pnlMiniCanvas.Size = new System.Drawing.Size(424, 405);
            this.pnlMiniCanvas.TabIndex = 2;
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
            this.txtCrossX.Location = new System.Drawing.Point(951, 104);
            this.txtCrossX.Name = "txtCrossX";
            this.txtCrossX.Size = new System.Drawing.Size(61, 27);
            this.txtCrossX.TabIndex = 10;
            this.txtCrossX.Text = "3";
            this.txtCrossX.Visible = false;
            // 
            // txtCrossY
            // 
            this.txtCrossY.Location = new System.Drawing.Point(1040, 104);
            this.txtCrossY.Name = "txtCrossY";
            this.txtCrossY.Size = new System.Drawing.Size(61, 27);
            this.txtCrossY.TabIndex = 11;
            this.txtCrossY.Text = "5";
            this.txtCrossY.Visible = false;
            // 
            // lblw
            // 
            this.lblw.AutoSize = true;
            this.lblw.Location = new System.Drawing.Point(951, 140);
            this.lblw.Name = "lblw";
            this.lblw.Size = new System.Drawing.Size(17, 20);
            this.lblw.TabIndex = 12;
            this.lblw.Text = "0";
            this.lblw.Visible = false;
            // 
            // lblh
            // 
            this.lblh.AutoSize = true;
            this.lblh.Location = new System.Drawing.Point(1040, 140);
            this.lblh.Name = "lblh";
            this.lblh.Size = new System.Drawing.Size(17, 20);
            this.lblh.TabIndex = 13;
            this.lblh.Text = "0";
            this.lblh.Visible = false;
            // 
            // btnClearVisibleBlocks
            // 
            this.btnClearVisibleBlocks.Location = new System.Drawing.Point(1098, 386);
            this.btnClearVisibleBlocks.Name = "btnClearVisibleBlocks";
            this.btnClearVisibleBlocks.Size = new System.Drawing.Size(110, 57);
            this.btnClearVisibleBlocks.TabIndex = 14;
            this.btnClearVisibleBlocks.Text = "清除已視";
            this.btnClearVisibleBlocks.UseVisualStyleBackColor = true;
            this.btnClearVisibleBlocks.Click += new System.EventHandler(this.btnClearVisibleBlocks_Click);
            // 
            // btnGoTo
            // 
            this.btnGoTo.Location = new System.Drawing.Point(951, 386);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(110, 57);
            this.btnGoTo.TabIndex = 15;
            this.btnGoTo.Text = "移動開始";
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // txtTargetX
            // 
            this.txtTargetX.Location = new System.Drawing.Point(951, 340);
            this.txtTargetX.Name = "txtTargetX";
            this.txtTargetX.Size = new System.Drawing.Size(61, 27);
            this.txtTargetX.TabIndex = 16;
            this.txtTargetX.Text = "3";
            this.txtTargetX.Visible = false;
            // 
            // txtTargetY
            // 
            this.txtTargetY.Location = new System.Drawing.Point(1018, 340);
            this.txtTargetY.Name = "txtTargetY";
            this.txtTargetY.Size = new System.Drawing.Size(61, 27);
            this.txtTargetY.TabIndex = 17;
            this.txtTargetY.Text = "3";
            this.txtTargetY.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 866);
            this.Controls.Add(this.txtTargetY);
            this.Controls.Add(this.txtTargetX);
            this.Controls.Add(this.btnGoTo);
            this.Controls.Add(this.btnClearVisibleBlocks);
            this.Controls.Add(this.lblh);
            this.Controls.Add(this.lblw);
            this.Controls.Add(this.txtCrossY);
            this.Controls.Add(this.txtCrossX);
            this.Controls.Add(this.btnCrossTest);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.pnlMiniCanvas);
            this.Controls.Add(this.pnlCanvas);
            this.Controls.Add(this.btnClick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "小地圖研究";
            this.pnlCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picT1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Panel pnlMiniCanvas;
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
        private System.Windows.Forms.Label lblw;
        private System.Windows.Forms.Label lblh;
        private System.Windows.Forms.Button btnClearVisibleBlocks;
        private System.Windows.Forms.Button btnGoTo;
        private System.Windows.Forms.TextBox txtTargetX;
        private System.Windows.Forms.TextBox txtTargetY;
    }
}

