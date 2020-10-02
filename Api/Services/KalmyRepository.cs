using Api.Context;
using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class KalmyRepository: IKalmyRepository
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



        public async Task<Car> GetCar(int CarId)
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

        
    }
}
