using BargainHunterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace BargainHunter.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            
            return View();
        }
        //private Products CallAPI()
        //{
        //    List<Products> ProductList = new List<Products>;
        //    string URL = "http://localhost:55499/API/Products";
        //    string urlParameters = "?search=milk";

        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(URL);

        //    // Add an Accept header for JSON format.
        //    client.DefaultRequestHeaders.Accept.Add(
        //    new MediaTypeWithQualityHeaderValue("application/json"));

        //    // List data response.
        //    HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Parse the response body.
        //        var dataObjects = response.Content.ReadAsAsync<IEnumerable<Products>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
        //        foreach (var d in dataObjects)
        //        {
        //            ProductList.Add(d);
                  
        //        }
        //    }
            

        //    //Make any other calls using HttpClient here.

        //    //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        //    client.Dispose();
        //    return ProductList;
        //}
    }
}