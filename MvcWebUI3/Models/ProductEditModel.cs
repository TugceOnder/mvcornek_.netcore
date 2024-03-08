namespace MvcWebUI3.Models
{
    public class ProductEditModel
    {
        public List<Category> CategoryList { get; set; }
        public List<Supplier> SupplierList { get; set; }
        public Product ProductToUpdate { get; set; }
    }
}
