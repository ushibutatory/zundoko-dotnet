using Zundoko.Web.Models.Abstracts;

namespace Zundoko.Web.Models
{
    public class ErrorViewModel : BaseViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
