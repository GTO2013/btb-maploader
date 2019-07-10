namespace BirtdaysWorldEditor
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browse_Button = new System.Windows.Forms.Button();
            this.gamePath_Text = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.browseImageButton = new System.Windows.Forms.Button();
            this.imagePathText = new System.Windows.Forms.TextBox();
            this.savePanel = new System.Windows.Forms.Panel();
            this.maxHeightControl = new System.Windows.Forms.NumericUpDown();
            this.minHeightControl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHeightControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browse_Button);
            this.groupBox1.Controls.Add(this.gamePath_Text);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Installation Folder";
            // 
            // browse_Button
            // 
            this.browse_Button.AutoSize = true;
            this.browse_Button.Location = new System.Drawing.Point(176, 16);
            this.browse_Button.Name = "browse_Button";
            this.browse_Button.Size = new System.Drawing.Size(100, 23);
            this.browse_Button.TabIndex = 1;
            this.browse_Button.Text = "Browse";
            this.browse_Button.UseVisualStyleBackColor = true;
            this.browse_Button.Click += new System.EventHandler(this.browse_Button_Click);
            // 
            // gamePath_Text
            // 
            this.gamePath_Text.Location = new System.Drawing.Point(6, 19);
            this.gamePath_Text.Name = "gamePath_Text";
            this.gamePath_Text.ReadOnly = true;
            this.gamePath_Text.Size = new System.Drawing.Size(164, 20);
            this.gamePath_Text.TabIndex = 0;
            this.gamePath_Text.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.browseImageButton);
            this.groupBox2.Controls.Add(this.imagePathText);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 52);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Height Map (.png)";
            // 
            // browseImageButton
            // 
            this.browseImageButton.Location = new System.Drawing.Point(176, 16);
            this.browseImageButton.Name = "browseImageButton";
            this.browseImageButton.Size = new System.Drawing.Size(95, 23);
            this.browseImageButton.TabIndex = 1;
            this.browseImageButton.Text = "Browse";
            this.browseImageButton.UseVisualStyleBackColor = true;
            this.browseImageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // imagePathText
            // 
            this.imagePathText.Location = new System.Drawing.Point(6, 19);
            this.imagePathText.Name = "imagePathText";
            this.imagePathText.ReadOnly = true;
            this.imagePathText.Size = new System.Drawing.Size(164, 20);
            this.imagePathText.TabIndex = 0;
            this.imagePathText.TabStop = false;
            // 
            // savePanel
            // 
            this.savePanel.AutoScroll = true;
            this.savePanel.Location = new System.Drawing.Point(13, 128);
            this.savePanel.Name = "savePanel";
            this.savePanel.Size = new System.Drawing.Size(169, 170);
            this.savePanel.TabIndex = 3;
            // 
            // maxHeightControl
            // 
            this.maxHeightControl.Location = new System.Drawing.Point(191, 147);
            this.maxHeightControl.Maximum = new decimal(new int[] {
            124,
            0,
            0,
            0});
            this.maxHeightControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxHeightControl.Name = "maxHeightControl";
            this.maxHeightControl.Size = new System.Drawing.Size(92, 20);
            this.maxHeightControl.TabIndex = 4;
            this.maxHeightControl.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // minHeightControl
            // 
            this.minHeightControl.Location = new System.Drawing.Point(191, 196);
            this.minHeightControl.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.minHeightControl.Minimum = new decimal(new int[] {
            125,
            0,
            0,
            -2147483648});
            this.minHeightControl.Name = "minHeightControl";
            this.minHeightControl.Size = new System.Drawing.Size(92, 20);
            this.minHeightControl.TabIndex = 5;
            this.minHeightControl.Value = new decimal(new int[] {
            6,
            0,
            0,
            -2147483648});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Highest Point:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lowest Point:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 310);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minHeightControl);
            this.Controls.Add(this.maxHeightControl);
            this.Controls.Add(this.savePanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "BTB World Editor by GeneralLee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHeightControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browse_Button;
        private System.Windows.Forms.TextBox gamePath_Text;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseImageButton;
        private System.Windows.Forms.TextBox imagePathText;
        private System.Windows.Forms.Panel savePanel;
        private System.Windows.Forms.NumericUpDown maxHeightControl;
        private System.Windows.Forms.NumericUpDown minHeightControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

