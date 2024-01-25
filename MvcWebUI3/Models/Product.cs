namespace MvcWebUI3.Models
{
    public class Product
    {
        //entityframework data base ile bağlantı sağlamak için oluşturduğumuz yapıdır.
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
      

    
}
