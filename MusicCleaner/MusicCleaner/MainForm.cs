using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MusicCleaner
{
    public partial class MainForm : Form
    {
        private readonly BusinessLogic businessLogic;
        private readonly OptionsWrapper optionsWrapper;

        public MainForm()
        {
            InitializeComponent();

            Text = "MusicCleaner " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            MinimumSize = new Size(Width, Height);

            comboBoxRenaming.Items.Add(CaseType.Unchanged);
            comboBoxRenaming.Items.Add(CaseType.CamelCase);
            comboBoxRenaming.Items.Add(CaseType.LowerCase);
            comboBoxRenaming.Items.Add(CaseType.UpperCase);
            comboBoxRenaming.SelectedIndex = 0;

            businessLogic = new BusinessLogic(new CaseChanger(), new TagChanger());
            optionsWrapper = new OptionsWrapper(checkedListBoxOptions);
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

        private async void buttonProcess_Click(object sender, EventArgs e)
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

            SetControls(false);

            var files = Directory.GetFiles(folder, "*.mp3", optionsWrapper.IncludeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            progressBarProgress.Maximum = files.Length;
            progressBarProgress.Minimum = 0;
            progressBarProgress.Value = 0;
            progressBarProgress.Step = 1;

            var caseType = (CaseType)comboBoxRenaming.SelectedItem;

            var progress = new Progress<string>(x => progressBarProgress.PerformStep());

            try
            {
                await businessLogic.Process(files.AsEnumerable(), caseType, optionsWrapper.CreateTags, optionsWrapper.AlbumMode, progress);
            }
            catch (Exception exception)
            {
                ShowError(exception.Message);
                return;
            }
            finally
            {
                SetControls(true);
            }

            ShowInfo("Successfully finished.");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetControls(bool enabled)
        {
            buttonFolder.Enabled = enabled;
            labelFolder.Enabled = enabled;
            textBoxFolder.Enabled = enabled;
            labelRenaming.Enabled = enabled;
            comboBoxRenaming.Enabled = enabled;
            labelOptions.Enabled = enabled;
            checkedListBoxOptions.Enabled = enabled;
            buttonProcess.Enabled = enabled;
            buttonClose.Enabled = enabled;
        }

        private void ShowInfo(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
