using BargainHunterAPI.Models;
using BargainHunterAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BargainHunterAPI.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        //public IEnumerable<Products> Get()
        //{
        //    return ProductsRepository.GetProductList();
        //}

        // GET: api/Products/5
        //public Products Get(int id)
        //{
        //    return ProductsRepository.GetProduct();
        //}

        // GET: api/Products/5
        public HttpResponseMessage Get(string query)
        {

            List<Products> productList = ProductsRepository.GetProductList(HttpUtility.UrlDecode(query));

            //checking fetched or not with the help of NULL or NOT.  
            if (productList != null)
            {
                //sending response as status code OK with memberdetail entity.  
                return Request.CreateResponse(HttpStatusCode.OK, productList);
            }
            else
            {
                //sending response as error status code NOT FOUND with meaningful message.  
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid search or Product Not Found");
            }
            
        }

    }
}
