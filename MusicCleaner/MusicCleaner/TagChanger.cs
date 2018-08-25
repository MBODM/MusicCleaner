using System;
using System.IO;
using System.Linq;
using TagLib;

namespace MusicCleaner
{
    public sealed class TagChanger : ITagChanger
    {
        public void ChangeTags(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                throw new ArgumentException(file.NoeMsg(), nameof(file));
            }

            var name = Path.GetFileNameWithoutExtension(file).Trim();

            var parts = name.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Count() != 2)
            {
                throw new InvalidOperationException($"File '{Path.GetFileName(file)}' violates the naming conventions.");
            }

            using (var tagLibFile = TagLib.File.Create(file))
            {
                tagLibFile.RemoveTags(TagTypes.AllTags);

                tagLibFile.Save();
            }

            using (var tagLibFile = TagLib.File.Create(file))
            {
                // Todo: Use this field too ?
                // tagLibFile.Tag.AlbumArtists = new string[] { parts.First().Trim() };

                tagLibFile.Tag.Performers = new string[] { parts.First().Trim() };
                tagLibFile.Tag.Title = parts.Last().Trim();

                tagLibFile.Save();
            }
        }
    }
}
