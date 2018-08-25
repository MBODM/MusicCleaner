namespace MusicCleaner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelFiles = new System.Windows.Forms.Label();
            this.labelFolder = new System.Windows.Forms.Label();
            this.progressBarFiles = new System.Windows.Forms.ProgressBar();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.labelNaming = new System.Windows.Forms.Label();
            this.comboBoxNaming = new System.Windows.Forms.ComboBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.checkBoxTags = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.Location = new System.Drawing.Point(9, 127);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(51, 13);
            this.labelFiles.TabIndex = 5;
            this.labelFiles.Text = "Progress:";
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(9, 27);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(39, 13);
            this.labelFolder.TabIndex = 1;
            this.labelFolder.Text = "Folder:";
            // 
            // progressBarFiles
            // 
            this.progressBarFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarFiles.Location = new System.Drawing.Point(12, 143);
            this.progressBarFiles.Name = "progressBarFiles";
            this.progressBarFiles.Size = new System.Drawing.Size(360, 23);
            this.progressBarFiles.TabIndex = 6;
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.Location = new System.Drawing.Point(12, 43);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(360, 20);
            this.textBoxFolder.TabIndex = 2;
            // 
            // buttonFolder
            // 
            this.buttonFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFolder.Location = new System.Drawing.Point(297, 12);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(75, 25);
            this.buttonFolder.TabIndex = 0;
            this.buttonFolder.Text = "Select...";
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // labelNaming
            // 
            this.labelNaming.AutoSize = true;
            this.labelNaming.Location = new System.Drawing.Point(9, 77);
            this.labelNaming.Name = "labelNaming";
            this.labelNaming.Size = new System.Drawing.Size(46, 13);
            this.labelNaming.TabIndex = 3;
            this.labelNaming.Text = "Naming:";
            // 
            // comboBoxNaming
            // 
            this.comboBoxNaming.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxNaming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNaming.FormattingEnabled = true;
            this.comboBoxNaming.Location = new System.Drawing.Point(12, 93);
            this.comboBoxNaming.Name = "comboBoxNaming";
            this.comboBoxNaming.Size = new System.Drawing.Size(360, 21);
            this.comboBoxNaming.TabIndex = 4;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(297, 199);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 25);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcess.Location = new System.Drawing.Point(216, 199);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 25);
            this.buttonProcess.TabIndex = 8;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // checkBoxTags
            // 
            this.checkBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxTags.AutoSize = true;
            this.checkBoxTags.Location = new System.Drawing.Point(12, 207);
            this.checkBoxTags.Name = "checkBoxTags";
            this.checkBoxTags.Size = new System.Drawing.Size(50, 17);
            this.checkBoxTags.TabIndex = 7;
            this.checkBoxTags.Text = "Tags";
            this.checkBoxTags.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 236);
            this.Controls.Add(this.checkBoxTags);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.progressBarFiles);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.buttonFolder);
            this.Controls.Add(this.labelNaming);
            this.Controls.Add(this.comboBoxNaming);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonProcess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicCleaner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.ProgressBar progressBarFiles;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.Label labelNaming;
        private System.Windows.Forms.ComboBox comboBoxNaming;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.CheckBox checkBoxTags;
    }
}

