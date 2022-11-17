using Microsoft.AspNetCore.Mvc.Rendering;
using VidlyWeb.Models;

namespace VidlyWeb.ViewModels
{
    public class AddCustomerViewModel
    {
        public List<SelectListItem> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
