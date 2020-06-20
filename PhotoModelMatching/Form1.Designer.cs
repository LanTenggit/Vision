namespace PhotoModelMatching
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PicDest = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bn_setFaild = new System.Windows.Forms.Button();
            this.bn_setSuccess = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PicSrc1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PicSrc = new System.Windows.Forms.PictureBox();
            this.gr_info = new System.Windows.Forms.GroupBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.bn_operate = new System.Windows.Forms.Button();
            this.bn_save = new System.Windows.Forms.Button();
            this.bn_check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).BeginInit();
            this.gr_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicDest
            // 
            this.PicDest.Image = ((System.Drawing.Image)(resources.GetObject("PicDest.Image")));
            this.PicDest.Location = new System.Drawing.Point(35, 92);
            this.PicDest.Name = "PicDest";
            this.PicDest.Size = new System.Drawing.Size(688, 520);
            this.PicDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicDest.TabIndex = 14;
            this.PicDest.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bn_setFaild);
            this.groupBox1.Controls.Add(this.bn_setSuccess);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.gr_info);
            this.groupBox1.Location = new System.Drawing.Point(753, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 520);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模板";
            // 
            // bn_setFaild
            // 
            this.bn_setFaild.Location = new System.Drawing.Point(14, 302);
            this.bn_setFaild.Name = "bn_setFaild";
            this.bn_setFaild.Size = new System.Drawing.Size(129, 33);
            this.bn_setFaild.TabIndex = 9;
            this.bn_setFaild.Text = "设置失败模板";
            this.bn_setFaild.UseVisualStyleBackColor = true;
            this.bn_setFaild.Click += new System.EventHandler(this.bn_setFaild_Click);
            // 
            // bn_setSuccess
            // 
            this.bn_setSuccess.Location = new System.Drawing.Point(14, 157);
            this.bn_setSuccess.Name = "bn_setSuccess";
            this.bn_setSuccess.Size = new System.Drawing.Size(129, 33);
            this.bn_setSuccess.TabIndex = 8;
            this.bn_setSuccess.Text = "设置成功模板";
            this.bn_setSuccess.UseVisualStyleBackColor = true;
            this.bn_setSuccess.Click += new System.EventHandler(this.bn_setSuccess_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PicSrc1);
            this.groupBox4.Location = new System.Drawing.Point(6, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 100);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "过站失败";
            // 
            // PicSrc1
            // 
            this.PicSrc1.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc1.Image")));
            this.PicSrc1.Location = new System.Drawing.Point(8, 20);
            this.PicSrc1.Name = "PicSrc1";
            this.PicSrc1.Size = new System.Drawing.Size(167, 50);
            this.PicSrc1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSrc1.TabIndex = 6;
            this.PicSrc1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PicSrc);
            this.groupBox3.Location = new System.Drawing.Point(6, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 116);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "过站成功";
            // 
            // PicSrc
            // 
            this.PicSrc.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc.Image")));
            this.PicSrc.Location = new System.Drawing.Point(6, 20);
            this.PicSrc.Name = "PicSrc";
            this.PicSrc.Size = new System.Drawing.Size(180, 75);
            this.PicSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSrc.TabIndex = 5;
            this.PicSrc.TabStop = false;
            // 
            // gr_info
            // 
            this.gr_info.Controls.Add(this.LblInfo);
            this.gr_info.Location = new System.Drawing.Point(6, 362);
            this.gr_info.Name = "gr_info";
            this.gr_info.Size = new System.Drawing.Size(235, 152);
            this.gr_info.TabIndex = 7;
            this.gr_info.TabStop = false;
            this.gr_info.Text = "匹配信息";
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Location = new System.Drawing.Point(6, 29);
            this.LblInfo.MaximumSize = new System.Drawing.Size(230, 0);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(41, 12);
            this.LblInfo.TabIndex = 6;
            this.LblInfo.Text = "提示：";
            // 
            // bn_operate
            // 
            this.bn_operate.Location = new System.Drawing.Point(240, 63);
            this.bn_operate.Name = "bn_operate";
            this.bn_operate.Size = new System.Drawing.Size(75, 23);
            this.bn_operate.TabIndex = 18;
            this.bn_operate.Text = "处理";
            this.bn_operate.UseVisualStyleBackColor = true;
            this.bn_operate.Click += new System.EventHandler(this.bn_operate_Click);
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(130, 63);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 17;
            this.bn_save.Text = "保存图片";
            this.bn_save.UseVisualStyleBackColor = true;
            this.bn_save.Click += new System.EventHandler(this.bn_save_Click);
            // 
            // bn_check
            // 
            this.bn_check.Location = new System.Drawing.Point(35, 63);
            this.bn_check.Name = "bn_check";
            this.bn_check.Size = new System.Drawing.Size(75, 23);
            this.bn_check.TabIndex = 16;
            this.bn_check.Text = "选择图片";
            this.bn_check.UseVisualStyleBackColor = true;
            this.bn_check.Click += new System.EventHandler(this.bn_check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 785);
            this.Controls.Add(this.bn_operate);
            this.Controls.Add(this.bn_save);
            this.Controls.Add(this.bn_check);
            this.Controls.Add(this.PicDest);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "图片模板匹配";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).EndInit();
            this.gr_info.ResumeLayout(false);
            this.gr_info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicDest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bn_setFaild;
        private System.Windows.Forms.Button bn_setSuccess;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox PicSrc1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox PicSrc;
        private System.Windows.Forms.GroupBox gr_info;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Button bn_operate;
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.Button bn_check;
    }
}

