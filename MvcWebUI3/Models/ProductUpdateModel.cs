namespace MvcWebUI3.Models
{
    public class ProductUpdateModel
    {
        public int ProductId { get; set; }
        public string PName { get; set; }
        public decimal Uprice { get; set; }

        public short UStock { get; set; }

        public int CId { get; set; }

        public int SId { get; set; }

        public bool Discontinued { get; set; }
    }
}
