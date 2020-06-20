using Zundoko.Core.Models;
using Zundoko.Core.Models.Abstracts;
using Zundoko.Web.Models.Abstracts;

namespace Zundoko.Web.Models
{
    public class PlayViewModel : ILayoutViewModel
    {
        public string Title { get; set; }

        public ISong Song { get; set; }

        public PlayResult PlayResult { get; set; }
    }
}
