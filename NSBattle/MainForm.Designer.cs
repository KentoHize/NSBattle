
namespace NSBattle
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMap = new System.Windows.Forms.Panel();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnLoadArea1 = new System.Windows.Forms.Button();
            this.pnlMiniMap = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlMap
            // 
            this.pnlMap.Location = new System.Drawing.Point(12, 12);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(1000, 1000);
            this.pnlMap.TabIndex = 0;
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(1222, 563);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(205, 43);
            this.btnStartTest.TabIndex = 1;
            this.btnStartTest.Text = "開始測試";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // btnLoadArea1
            // 
            this.btnLoadArea1.Location = new System.Drawing.Point(1222, 514);
            this.btnLoadArea1.Name = "btnLoadArea1";
            this.btnLoadArea1.Size = new System.Drawing.Size(205, 43);
            this.btnLoadArea1.TabIndex = 2;
            this.btnLoadArea1.Text = "讀取Area1";
            this.btnLoadArea1.UseVisualStyleBackColor = true;
            this.btnLoadArea1.Click += new System.EventHandler(this.btnLoadArea1_Click);
            // 
            // pnlMiniMap
            // 
            this.pnlMiniMap.Location = new System.Drawing.Point(1027, 612);
            this.pnlMiniMap.Name = "pnlMiniMap";
            this.pnlMiniMap.Size = new System.Drawing.Size(400, 400);
            this.pnlMiniMap.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 1020);
            this.Controls.Add(this.pnlMiniMap);
            this.Controls.Add(this.btnLoadArea1);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.pnlMap);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnLoadArea1;
        private System.Windows.Forms.Panel pnlMiniMap;
    }
}

