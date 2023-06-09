﻿namespace InnovaCatalogWeb.Models
{
    public class CatalogDto
    {
        
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }
        
        public int CatalogBrandId { get; set; }
        
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }

        public bool OnReorder { get; set; }
       
    }
}
