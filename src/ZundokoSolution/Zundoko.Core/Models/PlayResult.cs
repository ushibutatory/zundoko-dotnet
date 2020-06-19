using System.Collections.Generic;

namespace Zundoko.Core.Models
{
    public class PlayResult
    {
        public IEnumerable<string> SingerPhrases { get; }

        public string AudiencePhrase { get; }

        public string Message { get; }

        public PlayResult(IEnumerable<string> singerPhrases, string audiencePhrase, string message)
        {
            SingerPhrases = singerPhrases;
            AudiencePhrase = audiencePhrase;
            Message = message;
        }
    }
}
