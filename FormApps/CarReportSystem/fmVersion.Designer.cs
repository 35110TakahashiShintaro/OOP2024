namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVersionOK = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btVersionOK
            // 
            btVersionOK.Location = new Point(337, 203);
            btVersionOK.Name = "btVersionOK";
            btVersionOK.Size = new Size(75, 23);
            btVersionOK.TabIndex = 0;
            btVersionOK.Text = "OK";
            btVersionOK.UseVisualStyleBackColor = true;
            btVersionOK.Click += btVersionOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("メイリオ", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(192, 31);
            label1.TabIndex = 1;
            label1.Text = "CarReportSystem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("メイリオ", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(130, 75);
            label2.Name = "label2";
            label2.Size = new Size(74, 23);
            label2.TabIndex = 2;
            label2.Text = "Ver.0.0.1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("メイリオ", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(130, 115);
            label3.Name = "label3";
            label3.Size = new Size(40, 23);
            label3.TabIndex = 3;
            label3.Text = "会社";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("メイリオ", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(131, 155);
            label4.Name = "label4";
            label4.Size = new Size(39, 23);
            label4.TabIndex = 4;
            label4.Text = "Mail";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 256);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btVersionOK);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVersionOK;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}