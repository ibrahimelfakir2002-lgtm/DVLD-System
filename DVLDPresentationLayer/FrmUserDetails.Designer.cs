namespace DVLDPresentationLayer
{
    partial class FrmUserDetails
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
            this.ctrlPersonInfoCard3 = new DVLDPresentationLayer.ctrlPersonInfoCard();
            this.ctrlPersonInfoCard1 = new DVLDPresentationLayer.ctrlPersonInfoCard();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbIsActive = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LbUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LbUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BntClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonInfoCard3
            // 
            this.ctrlPersonInfoCard3.Location = new System.Drawing.Point(104, 11);
            this.ctrlPersonInfoCard3.Name = "ctrlPersonInfoCard3";
            this.ctrlPersonInfoCard3.Size = new System.Drawing.Size(20, 9);
            this.ctrlPersonInfoCard3.TabIndex = 2;
            // 
            // ctrlPersonInfoCard1
            // 
            this.ctrlPersonInfoCard1.Location = new System.Drawing.Point(37, 26);
            this.ctrlPersonInfoCard1.Name = "ctrlPersonInfoCard1";
            this.ctrlPersonInfoCard1.Size = new System.Drawing.Size(775, 376);
            this.ctrlPersonInfoCard1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbIsActive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LbUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LbUserID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(37, 431);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // LbIsActive
            // 
            this.LbIsActive.AutoSize = true;
            this.LbIsActive.Location = new System.Drawing.Point(750, 45);
            this.LbIsActive.Name = "LbIsActive";
            this.LbIsActive.Size = new System.Drawing.Size(117, 29);
            this.LbIsActive.TabIndex = 5;
            this.LbIsActive.Text = "Is Active ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Is Active :";
            // 
            // LbUserName
            // 
            this.LbUserName.AutoSize = true;
            this.LbUserName.Location = new System.Drawing.Point(473, 45);
            this.LbUserName.Name = "LbUserName";
            this.LbUserName.Size = new System.Drawing.Size(96, 29);
            this.LbUserName.TabIndex = 3;
            this.LbUserName.Text = " Name ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name :";
            // 
            // LbUserID
            // 
            this.LbUserID.AutoSize = true;
            this.LbUserID.Location = new System.Drawing.Point(230, 45);
            this.LbUserID.Name = "LbUserID";
            this.LbUserID.Size = new System.Drawing.Size(45, 29);
            this.LbUserID.TabIndex = 1;
            this.LbUserID.Text = " ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID :";
            // 
            // BntClose
            // 
            this.BntClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BntClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntClose.Image = global::DVLDPresentationLayer.Properties.Resources.icons8_close_30;
            this.BntClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntClose.Location = new System.Drawing.Point(792, 537);
            this.BntClose.Name = "BntClose";
            this.BntClose.Size = new System.Drawing.Size(122, 39);
            this.BntClose.TabIndex = 14;
            this.BntClose.Text = "   Close";
            this.BntClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntClose.UseVisualStyleBackColor = true;
            this.BntClose.Click += new System.EventHandler(this.BntClose_Click);
            // 
            // FrmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 664);
            this.Controls.Add(this.BntClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlPersonInfoCard1);
            this.Controls.Add(this.ctrlPersonInfoCard3);
            this.Name = "FrmUserDetails";
            this.Text = "FrmUserDetails";
            this.Load += new System.EventHandler(this.FrmUserDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonInfoCard ctrlPersonInfoCard3;
        private ctrlPersonInfoCard ctrlPersonInfoCard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LbIsActive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BntClose;
    }
}