using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace DataPOC.Models
{
    public class ProductViewModel
    {
        [DisplayName("Product")]
        public string ProductId { get; set; }
        public List<SelectListItem> Listofproducts { get; set; }
    }
}
