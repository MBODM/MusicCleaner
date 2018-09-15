using System;
using System.IO;
using System.Linq;
using TagLib;

namespace MusicCleaner
{
    public sealed class TagChanger : ITagChanger
    {
        public void ChangeTags(string file, bool albumMode)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                throw new ArgumentException(file.NoeMsg(), nameof(file));
            }

            var songData = GetSongData(file, albumMode);

            // There must be 2 using blocks and 2 saves, otherwise it will not work. 

            using (var tagLibFile = TagLib.File.Create(file))
            {
                tagLibFile.RemoveTags(TagTypes.AllTags);
                tagLibFile.Save();
            }

            using (var tagLibFile = TagLib.File.Create(file))
            {
                tagLibFile.Tag.Performers = new string[] { songData.Artist };
                tagLibFile.Tag.Title = songData.Title;

                // Todo: Use this field too ?
                // tagLibFile.Tag.AlbumArtists = new string[] { parts.First().Trim() };

                if (albumMode == true) tagLibFile.Tag.Album = songData.Album;
                if (albumMode == true) tagLibFile.Tag.Track = songData.Track;

                tagLibFile.Save();
            }
        }

        private SongData GetSongData(string file, bool albumMode)
        {
            var songData = new SongData();

            if (albumMode)
            {
                var folderName = new DirectoryInfo(Path.GetDirectoryName(file)).Name.Trim();

                var folderNameParts = folderName.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (folderNameParts.Count() != 2)
                {
                    throw new InvalidOperationException($"Folder '{folderName}' violates the naming conventions.");
                }

                songData.Artist = folderNameParts.First().Trim();
                songData.Album = folderNameParts.Last().Trim();

                var fileName = Path.GetFileNameWithoutExtension(file).Trim();

                if (fileName.Length < 4 || fileName.Substring(2, 1) != " ")
                {
                    ThrowException(file);
                }

                if (!byte.TryParse(fileName.Substring(0, 2), out byte track))
                {
                    ThrowException(file);
                }

                songData.Track = track;
                songData.Title = fileName.Substring(2, fileName.Length - 2).Trim();
            }
            else
            {
                var fileName = Path.GetFileNameWithoutExtension(file).Trim();

                var fileNameParts = fileName.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (fileNameParts.Count() != 2)
                {
                    ThrowException(file);
                }

                songData.Artist = fileNameParts.First().Trim();
                songData.Title = fileNameParts.Last().Trim();
            }

            return songData;
        }

        private void ThrowException(string file)
        {
            throw new InvalidOperationException($"File '{Path.GetFileName(file)}' violates the naming conventions.");
        }
    }
}
