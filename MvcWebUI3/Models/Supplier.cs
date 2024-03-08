using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MvcWebUI3.Models
{
    public class Supplier
    {

        public int SupplierId { get; set; }

        public string  CompanyName { get; set;}

        public string ContactName { get;set; }

        public string Country { get; set; }

        public string City { get; set; }
        public List<Product> Products { get; set; }
    }
}
