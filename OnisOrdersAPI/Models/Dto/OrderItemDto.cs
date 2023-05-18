namespace OnisOrdersAPI.Models.Dto
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }

        public int CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public int Units { get; set; }
        public int UnitPrice { get; set; }
        public int OrderId { get; set; }
    }
}
