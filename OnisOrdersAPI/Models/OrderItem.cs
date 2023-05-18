﻿namespace OnisOrdersAPI.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public CatalogItemOrdered ItemOrdered { get; private set; }//Owns to CatalogItemOrdered- Configure in dbcontext
        public int Units { get; set; }
        public int UnitPrice { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }//FK


    }
}
