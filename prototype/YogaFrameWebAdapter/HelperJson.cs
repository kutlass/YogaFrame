﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using System.Diagnostics;

namespace YogaFrameWebAdapter
{
    class HelperJson
    {
        public static void JsonSerialize()
        {

        }

        public static YogaFrame.Characters JsonDeserialize1(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            YogaFrame.Characters characters = JsonConvert.DeserializeObject<YogaFrame.Characters>(strJson);

            return characters;
        }

        public static YogaFrame.Games JsonDeserialize2(string strJson)
        {
            Trace.WriteLine("JsonDeserialize: Calling JsonConvert.DeserializeObject...");
            YogaFrame.Games games = JsonConvert.DeserializeObject<YogaFrame.Games>(strJson);

            return games;
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
