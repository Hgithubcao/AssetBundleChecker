﻿namespace AssetBundleChecker
{
    partial class AssetBundleChecker
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.BundleIdxUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CdnUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "BundleIdxUrl";
            // 
            // BundleIdxUrl
            // 
            this.BundleIdxUrl.Location = new System.Drawing.Point(94, 9);
            this.BundleIdxUrl.Name = "BundleIdxUrl";
            this.BundleIdxUrl.Size = new System.Drawing.Size(331, 21);
            this.BundleIdxUrl.TabIndex = 1;
            this.BundleIdxUrl.TextChanged += new System.EventHandler(this.Url_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Download";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(24, 96);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(597, 241);
            this.Result.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "CdnUrl";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CdnUrl
            // 
            this.CdnUrl.Location = new System.Drawing.Point(94, 49);
            this.CdnUrl.Name = "CdnUrl";
            this.CdnUrl.Size = new System.Drawing.Size(331, 21);
            this.CdnUrl.TabIndex = 5;
            // 
            // AssetBundleChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 350);
            this.Controls.Add(this.CdnUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BundleIdxUrl);
            this.Controls.Add(this.label1);
            this.Name = "AssetBundleChecker";
            this.Text = "AssetBundleChecker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BundleIdxUrl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CdnUrl;
    }
}
