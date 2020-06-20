using System.Collections.Generic;
using System.Linq;
using Zundoko.Core.Models.Abstracts;

namespace Zundoko.Core.Models
{
    public class PlayResult
    {
        private PlayResult(Builder builder)
        {
            Song = builder.Song;
            SingerPhrases = builder.SingerPhrases ?? Enumerable.Empty<string>();
            AudiencePhrase = builder.AudienceShout ?? string.Empty;
            Message = builder.Message ?? string.Empty;
        }

        public ISong Song { get; }

        public IEnumerable<string> SingerPhrases { get; }

        public string AudiencePhrase { get; }

        public bool IsSucceed => !string.IsNullOrEmpty(AudiencePhrase);

        public string Message { get; }

        public class Builder
        {
            public ISong Song { get; set; }

            public IEnumerable<string> SingerPhrases { get; set; }

            public string AudienceShout { get; set; }

            public string Message { get; set; }

            public PlayResult Build()
                => new PlayResult(this);
        }
    }
}
