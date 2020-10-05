using Api.Context;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Dynamic
{

    class CTypeModelDynamic : BaseDynamic
    {
        public CTypeModelDynamic() : base()
        {

        }
        public override dynamic Request(KalmyContext context)
        {

            var testdates = (from o in context.Car
                             select new
                             {
                                 Type = o.Type
                             }).Distinct().OrderBy(x => x.Type);

            JArray jArray = new JArray();
            foreach (var x in testdates)
            {
                JObject jObject = new JObject();
                string type = x.Type.ToString();
                JProperty property = new JProperty("name", type);
                JArray jArray2 = new JArray();
                var query = from item in context.Car
                            where item.Type == type
                            group item by item.Model into g
                            select new { CategoryName = g.Key, Count = g.Count() };

                foreach (var z in query)
                {
                    JObject jObjectx = new JObject();
                    jObjectx.Add(new JProperty("name", z.CategoryName));
                    jObjectx.Add(new JProperty("size", z.Count));
                    jArray2.Add(jObjectx);
                }
                JProperty propertyc = new JProperty("children", jArray2);
                jObject.Add(property);
                jObject.Add(propertyc);
                jArray.Add(jObject);
            }
            return jArray;
        }
    }
}
