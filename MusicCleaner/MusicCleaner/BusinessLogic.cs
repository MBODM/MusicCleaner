using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicCleaner
{
    public sealed class BusinessLogic
    {
        private readonly ICaseChanger caseChanger;
        private readonly ITagChanger tagChanger;

        public BusinessLogic(ICaseChanger caseChanger, ITagChanger tagChanger)
        {
            this.caseChanger = caseChanger ?? throw new ArgumentNullException(nameof(caseChanger));
            this.tagChanger = tagChanger ?? throw new ArgumentNullException(nameof(tagChanger));
        }

        public async Task Process(IEnumerable<string> files, CaseType caseType, bool createTags, bool albumMode, IProgress<string> progress)
        {
            await Task.Run(() =>
            {
                foreach (var file in files)
                {
                    var newFile = caseChanger.ChangeCase(file, caseType);

                    if (createTags)
                    {
                        tagChanger.ChangeTags(newFile, albumMode);
                    }

                    progress?.Report(file);
                }
            });
        }
    }
}
