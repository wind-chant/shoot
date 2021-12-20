namespace shoot.UI
{
    partial class FrmStart
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnContinue.Location = new System.Drawing.Point(136, 100);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(183, 70);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "继续游戏";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.restore_game);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(136, 246);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(183, 70);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始游戏";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRank
            // 
            this.btnRank.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRank.Location = new System.Drawing.Point(136, 401);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(183, 70);
            this.btnRank.TabIndex = 2;
            this.btnRank.Text = "排行榜";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnOut
            // 
            this.btnOut.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOut.Location = new System.Drawing.Point(136, 556);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(183, 70);
            this.btnOut.TabIndex = 3;
            this.btnOut.Text = "登出";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 802);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnContinue);
            this.Name = "FrmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStart_FormClosing);
            this.Load += new System.EventHandler(this.FrmStart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnOut;
    }
}