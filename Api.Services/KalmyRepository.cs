using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Services
{
    public class KalmyRepository : IKalmyRepository
    {

        private readonly Api KalmyContext _eventContext;
        private readonly ILogger<EventRepository> _logger;

        public KalmyRepository(KalmyContext eventContext, ILogger<EventRepository> logger)
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

    }
}
