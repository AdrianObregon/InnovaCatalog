﻿namespace InnovaCatalog.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Nombres { get; set; }
        public string Password { get; set; }

        public string Rol { get; set; }
    }
}
