using System;
using System.Windows.Forms;

namespace MusicCleaner
{
    public sealed class OptionsWrapper
    {
        private readonly CheckedListBox checkedListBox;

        public OptionsWrapper(CheckedListBox checkedListBox)
        {
            this.checkedListBox = checkedListBox ?? throw new ArgumentNullException(nameof(checkedListBox));

            checkedListBox.Leave += (s, e) =>
            {
                if (s is CheckedListBox clb) clb.SelectedItem = null;
            };

            checkedListBox.Items.Add("Include Subfolders");
            checkedListBox.Items.Add("Create Tags");
            checkedListBox.Items.Add("Album Mode");

            checkedListBox.SetItemChecked(0, true);
            checkedListBox.SetItemChecked(1, false);
            checkedListBox.SetItemChecked(2, false);
        }

        public bool IncludeSubfolders => checkedListBox.GetItemChecked(0);
        public bool CreateTags => checkedListBox.GetItemChecked(1);
        public bool AlbumMode => checkedListBox.GetItemChecked(2);
    }
}
