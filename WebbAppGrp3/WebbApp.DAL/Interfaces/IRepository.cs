using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbApp.DAL.DB.Models;

namespace WebbApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        bool Delete(T entity);
        bool Delete(Guid id);
        void AddImage(Image entity);
    }
}
