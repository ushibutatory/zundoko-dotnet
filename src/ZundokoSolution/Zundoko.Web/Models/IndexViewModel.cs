using System.Collections.Generic;
using Zundoko.Core.Models.Abstracts;
using Zundoko.Web.Models.Abstracts;

namespace Zundoko.Web.Models
{
    public class IndexViewModel : ILayoutViewModel
    {
        public string Title { get; set; }

        public IEnumerable<ISong> Songs { get; set; }
    }
}
