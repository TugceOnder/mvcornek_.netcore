namespace MvcWebUI3.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //her kategoriye ait birden fazla ürün vardır 
        public List<Product> Products { get; set; }


    }
}
