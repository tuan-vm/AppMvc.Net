using AppMVC01.Models;
using System.Collections.Generic;

namespace AppMVC01.Services
{
    public class ProductServices : List<ProductModel>
    {
        public ProductServices() 
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() { Id = 1, Name = "Iphone X" , Price = 1000},
                new ProductModel() { Id = 2, Name = "Samsung" , Price = 900},
                new ProductModel() { Id = 3, Name = "Sony" , Price = 800},
                new ProductModel() { Id = 4, Name = "Nokia" , Price = 700},
            });
        }    
    }
}
