using System.Collections.Generic;

namespace Zundoko.Core.Models
{
    public class PlayResult
    {
        public IEnumerable<string> Phrases { get; }

        public string Message { get; }

        public PlayResult(IEnumerable<string> phrases, string message)
        {
            Phrases = phrases;
            Message = message;
        }
    }
}
