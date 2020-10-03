using Api.Context;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Dynamic
{
    class CBrandDynamic : BaseDynamic
    {
        public CBrandDynamic() : base()
        {

        }
        public override dynamic Request(KalmyContext context)
        {

            var query = from item in context.Car
                         group item by item.Brand into g
                         select new { CategoryName = g.Key, Count = g.Count() };

            JArray jObject =
               new JArray(from p in query
                          orderby p.CategoryName
                          select new JObject(
                              new JProperty("name", p.CategoryName),
                              new JProperty("value", p.Count)));


            return jObject;
        }
    }
}
