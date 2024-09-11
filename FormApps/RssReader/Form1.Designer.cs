namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbRssUrl = new System.Windows.Forms.TextBox();
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.tbRssSearch = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btOkini = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRssUrl
            // 
            this.tbRssUrl.Location = new System.Drawing.Point(26, 12);
            this.tbRssUrl.Name = "tbRssUrl";
            this.tbRssUrl.Size = new System.Drawing.Size(884, 19);
            this.tbRssUrl.TabIndex = 0;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(916, 10);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(130, 23);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "URL検索";
            this.btGet.UseVisualStyleBackColor = true;
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(26, 96);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(1020, 172);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(26, 274);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1020, 417);
            this.webView21.TabIndex = 5;
            this.webView21.ZoomFactor = 1D;
            // 
            // tbRssSearch
            // 
            this.tbRssSearch.Location = new System.Drawing.Point(26, 68);
            this.tbRssSearch.Name = "tbRssSearch";
            this.tbRssSearch.Size = new System.Drawing.Size(884, 19);
            this.tbRssSearch.TabIndex = 6;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(916, 68);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(130, 19);
            this.btSearch.TabIndex = 7;
            this.btSearch.Text = "キーワード検索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(26, 42);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(884, 20);
            this.cbCategory.TabIndex = 8;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // btOkini
            // 
            this.btOkini.Location = new System.Drawing.Point(916, 39);
            this.btOkini.Name = "btOkini";
            this.btOkini.Size = new System.Drawing.Size(130, 23);
            this.btOkini.TabIndex = 9;
            this.btOkini.Text = "お気に入り登録";
            this.btOkini.UseVisualStyleBackColor = true;
            this.btOkini.Click += new System.EventHandler(this.btOkini_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1072, 757);
            this.Controls.Add(this.btOkini);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbRssSearch);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.tbRssUrl);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRssUrl;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.TextBox tbRssSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btOkini;
    }
}

