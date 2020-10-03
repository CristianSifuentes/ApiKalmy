using Api.Context;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Dynamic
{
    class CModelTypeDynamic : BaseDynamic
    {
        public CModelTypeDynamic() : base()
        {

        }
        public override dynamic Request(string parameter1, string parameter2, KalmyContext context)
        {

            var query = from item in context.Car
                         group item by item.Model into g
                         select new { CategoryName = g.Key, Count = g.Count() };

           JObject jObject =
            new JObject(
            new JProperty("channel",
            new JObject(
                new JProperty("item",
                    new JArray(
                        from p in query
                        orderby p.CategoryName
                        select new JObject(
                            new JProperty("name", p.CategoryName),
                            new JProperty("value", p.Count)))))));

            return jObject;
        }
    }
}
