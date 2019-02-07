using BargainHunterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BargainHunterAPI.Repository
{
    public class ProductsRepository
    {
        public static List<Products> GetProductList()
        {
            List<Products> prod_list = new List<Products>()
            {
                new Products ()
                {
                ID = 12312,
                BrandName = "Bear Brand",
                DetailsUrl = "google.cl",
                Name = "Scissors",
                Price = 25
                },
                new Products()
            {
                ID = 12312,
                BrandName = "Bear Brand",
                DetailsUrl = "google.cl",
                Name = "Scissors",
                Price = 25
            },
                new Products()
                   {
                       ID = 12312,
                       BrandName = "Bear Brand",
                       DetailsUrl = "google.cl",
                       Name = "Hair Trimmer",
                       Price = 20
                   },
                new Products()
            {
                ID = 12312,
                BrandName = "Bear Brand",
                DetailsUrl = "google.cl",
                Name = "Beard oil",
                Price = 30
            }
            };

            return prod_list;
        }
    }
}