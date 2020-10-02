using Api.Context;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class KalmyRepository : IKalmyRepository
    {
        private readonly KalmyContext _eventContext;
        private readonly ILogger<KalmyRepository> _logger;

        public KalmyRepository(KalmyContext eventContext, ILogger<KalmyRepository> logger)
        {
            _eventContext = eventContext;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _eventContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _eventContext.Remove(entity);
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return (await _eventContext.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _eventContext.Update(entity);
        }



        public async Task<Car> GetCar(long CarId)
        {
            _logger.LogInformation($"Getting Car for id {CarId}");

            var query = _eventContext.Car
                        .Where(c => c.Id == CarId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Car[]> GetCars()
        {
            _logger.LogInformation($"Getting all Cars");
            var query = _eventContext.Car
                        .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }


        public async Task<dynamic> SearchByDate()
        {
            _logger.LogInformation($"Getting all Cars");
            //var query = _eventContext.Car
            //            .OrderBy(c => c.Id);

            //return await query.ToArrayAsync();

            var query = _eventContext.Car
                 .GroupBy(item => item.Type)
                 .Select(g => new
                 {
                     CategoryName = g.Key,
                     Count = g.Sum(item => item.Type.Count())
                 });

            var query2 = from item in _eventContext.Car
                         group item by item.Type into g
                         select new { CategoryName = g.Key, Count = g.Count() };

            //foreach (var item in query2)
            //{
            //    var tmp = item.CategoryName + " " + item.Count;
            //}

            //dynamic flexible = new ExpandoObject();
            //flexible.Int = 3;
            //flexible.String = "hi";

            //var dictionary = (IDictionary<string, object>)flexible;
            //dictionary.Add("Bool", false);

            //var serialized = JsonConvert.SerializeObject(dictionary); // {"Int":3,"String":"hi","Bool":false}

            //dynamic jsonObjectx = new JObject();
            //jsonObjectx.Date = DateTime.Now;
            //jsonObjectx.Album = "Me Against the world";

            //dynamic jsonObject = new JObject();
            //jsonObject.Date = DateTime.Now;
            //jsonObject.Album = "Me Against the world";
            //jsonObject.Year = 1995;
            //jsonObject.Artist = "2Pac";
            //jsonObject.Oher = jsonObjectx;


            //        JObject rss =
            //new JObject(
            //    new JProperty("channel",
            //        new JObject(
            //            new JProperty("title", "James Newton-King"),
            //            new JProperty("link", "http://james.newtonking.com"),
            //            new JProperty("description", "James Newton-King's blog."),
            //            new JProperty("Type",
            //                new JArray(
            //                    from p in query2
            //                    orderby p.CategoryName
            //                    select new JObject(
            //                        new JProperty(p.CategoryName.ToString(), p.Count)
            //                     ))))));



            JArray rss =
               new JArray(
                        from p in query2
                        orderby p.CategoryName
                        select new JObject(
                            new JProperty(p.CategoryName.ToString(), p.Count)
                         ));

            return rss;

        }

    }
}
