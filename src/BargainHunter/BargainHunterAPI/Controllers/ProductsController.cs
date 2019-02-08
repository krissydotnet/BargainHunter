using BargainHunterAPI.Models;
using BargainHunterAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BargainHunterAPI.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public IEnumerable<Products> Get()
        {
            return ProductsRepository.GetProductList();
        }

        // GET: api/Products/5
        public Products Get(int id)
        {
            return ProductsRepository.GetProduct();
        }

        // POST: api/Products
        
    }
}
