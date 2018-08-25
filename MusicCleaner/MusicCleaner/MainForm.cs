using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MusicCleaner
{
    public partial class MainForm : Form
    {
        private readonly ICaseChanger caseChanger;
        private readonly ITagChanger tagChanger;

        public MainForm(ICaseChanger caseChanger, ITagChanger tagChanger)
        {
            this.caseChanger = caseChanger ?? throw new ArgumentNullException(nameof(caseChanger));
            this.tagChanger = tagChanger ?? throw new ArgumentNullException(nameof(tagChanger));

            InitializeComponent();

            Text += " " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            MinimumSize = new Size(300, 275);

            comboBoxNaming.Items.Add(CaseType.CamelCase);
            comboBoxNaming.Items.Add(CaseType.LowerCase);
            comboBoxNaming.Items.Add(CaseType.UpperCase);

            comboBoxNaming.SelectedIndex = 0;
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "\nSelect folder";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            var folder = textBoxFolder.Text;

            if (string.IsNullOrWhiteSpace(folder))
            {
                ShowError("No folder selected.");
                return;
            }

            if (!Directory.Exists(folder))
            {
                ShowError("Selected folder not exists.");
                return;
            }

            var files = Directory.GetFiles(folder, "*.mp3", SearchOption.AllDirectories);

            progressBarFiles.Maximum = files.Length;
            progressBarFiles.Minimum = 0;
            progressBarFiles.Value = 0;
            progressBarFiles.Step = 1;

            var caseType = (CaseType)comboBoxNaming.SelectedItem;

            foreach (var file in files)
            {
                var newFile = caseChanger.ChangeCase(file, caseType);

                if (checkBoxTags.Checked)
                {
                    try
                    {
                        tagChanger.ChangeTags(newFile);
                    }
                    catch (InvalidOperationException exception)
                    {
                        ShowError(exception.Message);
                        return;
                    }
                }

                progressBarFiles.PerformStep();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
