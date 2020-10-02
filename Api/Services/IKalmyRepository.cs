using Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IKalmyRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> Save();


        Task<Car[]> GetCars();
        Task<Car> GetCar(long CarId);

        Task<dynamic> SearchByDate();


    }
}
