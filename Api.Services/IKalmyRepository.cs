using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    interface IKalmyRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> Save();
    }
}
