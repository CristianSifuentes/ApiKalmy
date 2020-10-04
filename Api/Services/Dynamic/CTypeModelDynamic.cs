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
            var query = from order in context.Car
                          group order by order.Type into g
                          select new
                          {
                              CategoryName = g.Key,
                              Count = g.Count()
                          };


            //var query = from item in context.Car
            //             group item by item.Type into g
            //             select new { CategoryName = g.Key, Count = g.Count() };


            //var query2 = from item in context.Car  where item.Type == "small"
            //            group item by item.Model into g 
            //            select new { CategoryName = g.Key, Count = g.Count() };



            JArray jObject =
               new JArray(from p in query
                          orderby p.CategoryName
                          select new JObject(
                              new JProperty("name", p.CategoryName),
                              new JProperty("value", p.Count)));



            /*
             const data = [
  {
    name: 'axis',
    children: [
      { name: 'Axes', size: 1302 },
      { name: 'Axis', size: 24593 },
      { name: 'AxisGridLine', size: 652 },
      { name: 'AxisLabel', size: 636 },
      { name: 'CartesianAxes', size: 6703 },
    ],
  },
  {
    name: 'controls',
    children: [
      { name: 'AnchorControl', size: 2138 },
      { name: 'ClickControl', size: 3824 },
      { name: 'Control', size: 1353 },
      { name: 'ControlList', size: 4665 },
      { name: 'DragControl', size: 2649 },
      { name: 'ExpandControl', size: 2832 },
      { name: 'HoverControl', size: 4896 },
      { name: 'IControl', size: 763 },
      { name: 'PanZoomControl', size: 5222 },
      { name: 'SelectionControl', size: 7862 },
      { name: 'TooltipControl', size: 8435 },
    ],
  },
             */

            return jObject;
        }
    }
}
