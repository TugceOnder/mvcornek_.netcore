namespace MvcWebUI3.Models
{
    public class ProductNewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<Supplier> SupplierList { get; set; }

        public string OperationMessage {get;set;}
    }
}
