using Api.Context;
using Api.Data.Entities;
using Api.Data.Util;
using Api.Services.Dynamic;
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
        private readonly KalmyContext _kalmyContext;
        private readonly ILogger<KalmyRepository> _logger;
        private BaseDynamic baseDynamic;

        public KalmyRepository(KalmyContext kalmyContext, ILogger<KalmyRepository> logger)
        {
            _kalmyContext = kalmyContext;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _kalmyContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _kalmyContext.Remove(entity);
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return (await _kalmyContext.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _kalmyContext.Update(entity);
        }



        public async Task<Car> GetCar(long CarId)
        {
            _logger.LogInformation($"Getting Car for id {CarId}");

            var query = _kalmyContext.Car
                        .Where(c => c.Id == CarId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Car[]> GetCars()
        {
            _logger.LogInformation($"Getting all Cars");
            var query = _kalmyContext.Car
                        .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }


        public async Task<dynamic> SearchByQuery(string parameter1, string parameter2)
        {
            _logger.LogInformation($"Getting SearchByQuery");


            if (parameter1 == SeparatorChars.Type && parameter2 == "")
                baseDynamic = new CTypeDynamic();
            else if (parameter1 == SeparatorChars.Type && parameter2 == SeparatorChars.Model)
                baseDynamic = new CTypeModelDynamic();
            else if (parameter1 == SeparatorChars.Type && parameter2 == SeparatorChars.Brand)
                baseDynamic = new CTypeBrandDynamic();
            else if (parameter1 == SeparatorChars.Model && parameter2 == "")
                baseDynamic = new CModelDynamic();
            else if (parameter1 == SeparatorChars.Model && parameter2 == SeparatorChars.Type)
                baseDynamic = new CModelTypeDynamic();
            else if (parameter1 == SeparatorChars.Model && parameter2 == SeparatorChars.Brand)
                baseDynamic = new CModelBrandDynamic();
            else if (parameter1 == SeparatorChars.Brand && parameter2 == "")
                baseDynamic = new CBrandDynamic();
            else if (parameter1 == SeparatorChars.Brand && parameter2 == SeparatorChars.Type)
                baseDynamic = new CBrandTypeDynamic();
            else if (parameter1 == SeparatorChars.Brand && parameter2 == SeparatorChars.Model)
                baseDynamic = new CBrandModelDynamic();

            var result = baseDynamic.Request(_kalmyContext);

            return result;

        }

    }


    

}
