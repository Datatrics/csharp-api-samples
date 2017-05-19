using System;
using System.Collections.Generic;
using Datatrics;
using Datatrics.Objects;
using Newtonsoft.Json.Linq;

namespace csharp_api_samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("[apikey]", 1234567890);

            ProfileTest(client);
            ContentTest(client);
            SalesTest(client);

            Console.ReadLine();
        }

        static async void ContentTest(Client client)
        {
            // Create content
            Content contentItem = new Content("content-0", "product", "item", "MyWebShop")
            {
                Attributes = new JObject
                {
                    ["name"] = "Item 1",
                    ["description"] = "I am a description",
                    ["content"] = "Example of content",
                    ["url"] = "www.mywebshop.com/product/content-0",
                    ["image"] = "www.mywebshop.com/images/content-0",
                    ["price"] = "24,99",
                    ["stock"] = "12"
                }
            };
            JObject response = await client.Content.Create(contentItem);
            Console.WriteLine(response.ToString());

            // Get Content by id
            ListResult<Content> getContent = await client.Content.GetList(new Dictionary<string, object>() { { "page", "21" }, { "limit", "10" } });
            Console.WriteLine(getContent);
        }

        static async void ProfileTest(Client client)
        {
            Profile profile = new Profile("profile-0", "MyWebShop")
            {
                Attributes = new JObject
                {
                    ["created"] = "2017-05-10 22:30:01",
                    ["updated"] = "2017-05-10 22:30:01",
                    ["company"] = "MyCompany",
                    ["dateofbirth"] = "1980-01-01",
                    ["firstname"] = "David",
                    ["lastname"] = "Brown",
                    ["zip"] = "8234KJ",
                    ["city"] = "Oldenzaal",
                    ["country"] = "The Netherlands",
                    ["address"] = "Vogelstraat 42",
                    ["phone"] = "0383381249",
                    ["nationality"] = "Dutch",
                    ["mobile"] = "062415629",
                    ["email"] = "davidbrown@example.com",
                    ["lang"] = "NL",
                    ["gender"] = "Male",
                }
            };

            JObject response = await client.Profile.Create(profile);
            Console.WriteLine(response);

            ListResult<Profile> getResult  = await client.Profile.GetList(new Dictionary<string, object>() { {"limit", "10"} });
            Console.WriteLine(getResult);
        }

        static async void SalesTest(Client client)
        {
            Sale sale = new Sale("conversion-0", "conversion", "MyWebShop")
            {
                Attributes = new JObject
                {
                    ["profileid"] = "profile-0",
                    ["total"] = 49.98,
                    ["status"] = "payment confirmed",
                    ["items"] = new JArray
                    {
                        new JObject
                        {
                            ["itemid"] = "content-0",
                            ["sku"] = "sku-content-0",
                            ["name"] = "Item 1",
                            ["quantity"] = 2,
                            ["price"] = 24.99,
                            ["total"] = 48.98
                        }
                    }
                }
            };

            JObject response = await client.Sale.Create(sale);
            Console.WriteLine(response);

            ListResult<Sale> getResult = await client.Sale.GetList();
            Console.WriteLine(getResult);
        }
    }
}
