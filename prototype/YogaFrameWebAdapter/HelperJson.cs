using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Diagnostics;

namespace YogaFrameWebAdapter
{
    public class HelperJson
    {
        public static string JsonSerialize(Characters characters)
        {
            string strSerializedCharacters = String.Empty;
            strSerializedCharacters = JsonConvert.SerializeObject(characters);
            
            return strSerializedCharacters;
        }
        public static string JsonSerialize(Games games)
        {
            string strSerializedGames = String.Empty;
            strSerializedGames = JsonConvert.SerializeObject(games);

            return strSerializedGames;
        }
        public static YogaFrameWebAdapter.Characters JsonDeserialize1(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            YogaFrameWebAdapter.Characters characters = JsonConvert.DeserializeObject<YogaFrameWebAdapter.Characters>(strJson);

            return characters;
        }

        public static YogaFrameWebAdapter.Games JsonDeserialize2(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            YogaFrameWebAdapter.Games games = JsonConvert.DeserializeObject<YogaFrameWebAdapter.Games>(strJson);

            return games;
        }

        public static YogaFrameWebAdapter.Dapplers JsonDeserialize3(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            YogaFrameWebAdapter.Dapplers dapplers = JsonConvert.DeserializeObject<YogaFrameWebAdapter.Dapplers>(strJson);

            return dapplers;
        }

        public static void DoThangs()
        {
            Product product = new Product();
 
            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };
 
            string output = JsonConvert.SerializeObject(product);
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}

            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
            Trace.WriteLine(deserializedProduct.Name);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
