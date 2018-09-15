using System;
using System.IO;

namespace MusicCleaner
{
    public sealed class CaseChanger : ICaseChanger
    {
        public string ChangeCase(string file, CaseType caseType)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                throw new ArgumentException(file.NoeMsg(), nameof(file));
            }

            var name = Path.GetFileNameWithoutExtension(file);
            var ext = Path.GetExtension(file);

            var newName = name.Trim().ReplaceWhiteSpaces(' ');

            switch (caseType)
            {
                case CaseType.Unchanged:
                    break;
                case CaseType.CamelCase:
                    newName = newName.ToCamel();
                    break;
                case CaseType.LowerCase:
                    newName = newName.ToLower();
                    break;
                case CaseType.UpperCase:
                    newName = newName.ToUpper();
                    break;
            }

            var newFile = Path.Combine(Path.GetDirectoryName(file), newName + ext.ToLower());
            var tmpFile = Path.Combine(Path.GetDirectoryName(file), newName + ".tmp");

            if (newFile != file)
            {
                File.Move(file, tmpFile);
                File.Move(tmpFile, newFile);
            }

            return newFile;
        }
    }
}
