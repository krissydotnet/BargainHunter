using HtmlAgilityPack;
using BargainHunterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;

namespace BargainHunterAPI.Repository
{
    public class ProductsRepository
    {
        public static Products GetProduct()
        {
            return GetProductInfoFromWalmart();
        }
        public static List<Products> GetProductList()
        {
            return GetProductsListFromWalmart();
        }

        private static Products GetProductInfoFromWalmart()
        {
            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = "https://www.walmart.com/ip/Great-Value-1-Low-fat-Milk-1-Gallon-128-Fl-Oz/10450116";
            HtmlDocument Doc = website.Load(url);

            int item_id;
            string[] ID = Doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'wm-item-number')]").InnerText.Split();
            Int32.TryParse(ID[ID.Count() - 1], out item_id);
            var product_title = Doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'ProductTitle')]/h2/div").InnerText;
            var product_brand = Doc.DocumentNode.SelectSingleNode("//a[contains(@class, 'prod-brandName')]/span").InnerText;
            decimal price;
            decimal.TryParse(Doc.DocumentNode.SelectSingleNode("//span[contains(@class, 'price-characteristic')]").Attributes["content"].Value, out price);
            int count = 1;
            var product_image = Doc.DocumentNode.SelectSingleNode("//img[contains(@class, 'prod-hero-image-carousel-image')]").Attributes["src"].Value;
                

            Products prod = new Products()
            {
                ID = item_id,
                BrandName = product_brand,
                DetailsUrl = url,
                Name = product_title,
                Price = price, 
                Quantity = count,
                ImageUrl = product_image
            };

            return prod;
        }
        
        private static Products GetProductInfoFromWalmart(string productUrl)
        {
            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = "https://www.walmart.com/ip/Great-Value-1-Low-fat-Milk-1-Gallon-128-Fl-Oz/10450116";
                HtmlDocument Doc = website.Load(productUrl);

                int item_id;
                string[] ID = Doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'wm-item-number')]").InnerText.Split();
                Int32.TryParse(ID[ID.Count() - 1], out item_id);
                var product_title = Doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'ProductTitle')]/h2/div").InnerText;
                var product_brand = Doc.DocumentNode.SelectSingleNode("//a[contains(@class, 'prod-brandName')]/span").InnerText;
                decimal price;
                try
                {
                    decimal.TryParse(Doc.DocumentNode.SelectSingleNode("//span[contains(@class, 'price-characteristic')]").Attributes["content"].Value, out price);
                }
                catch
                {
                    price = 0;
                }

                int count = 1;
                var product_image = Doc.DocumentNode.SelectSingleNode("//img[contains(@class, 'prod-hero-image-carousel-image')]").Attributes["src"].Value;


                Products prod = new Products()
                {
                    ID = item_id,
                    BrandName = product_brand,
                    DetailsUrl = url,
                    Name = product_title,
                    Price = price,
                    Quantity = count,
                    ImageUrl = product_image
                };
                return prod;
            
            
        }

        private static List<Products> GetProductsListFromWalmart()
        {

            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;
            string site_url = "https://www.walmart.com";
            //string url = "https://www.walmart.com/search/?query=1%25%20milk%201%20gallon";
            string url = "https://www.walmart.com/search/?query=2%25%20milk";
            HtmlDocument Doc = website.Load(url);


            //get the first node that fit the table type that has a product-list class attribute
            var results = Doc.DocumentNode.SelectSingleNode("//ul[contains(@class, 'search-result-gridview-items')]");
            HtmlNodeCollection childNodes = results.ChildNodes;


            //create the product list
            List<Products> prod_list = new List<Products>();


            foreach (var tr in childNodes)
            {
                if (tr != null && tr.HasChildNodes)
                {
                    var product_url = site_url + tr.Descendants("a").First().Attributes["href"].Value;
                    Products productInfo = GetProductInfoFromWalmart(product_url);
                    if (productInfo.Price != 0)
                    {
                        prod_list.Add(productInfo);
                    }
                }
            }

            return prod_list;
        }


        private static  List<Products> GetProductsListFromTestSite()
        {

            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;
            HtmlDocument Doc = website.Load("http://localhost:57418/");

            //get the first node that fit the table type that has a product-list class attribute
            var tabla = Doc.DocumentNode.Descendants("table").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("product-list")).First();

            //then, get all the tr nodes of the first tbody node (from the table variable obtained in the last Linq query)
            var rows = tabla.Descendants("tbody").First().Descendants("tr");

            //create the product list
            List<Products> prod_list = new List<Products>();

            //go over each tr

            foreach (var tr in rows)
            {
                //get the list of td nodes from the tr
                var fields = tr.Descendants("td");

                //generates the URL variables from the fifth td element. Then, search first attribute with the name “href” and gets the value.
                string url = fields.ElementAt(5).FirstChild.Attributes.Where(e => e.Name.Contains("href")).First().Value;

                //add a new product with the content of every td inner text

                prod_list.Add(new Products()
                {
                    ID = Convert.ToInt16(fields.ElementAt(0).InnerText),
                    BrandName = fields.ElementAt(1).InnerText,
                    Name = fields.ElementAt(2).InnerText,
                    Price = Convert.ToInt16(fields.ElementAt(3).InnerText.Replace("$", "")), //cleans the price, replacing the $ for an empty space, so it can  be converted to a Int value
                    Quantity = Convert.ToInt16(fields.ElementAt(4).InnerText),
                });

            }

            return prod_list;
        }

    }
}