using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbApp.DAL.Interfaces
{
    interface ISearchableRepository<T>: IRepository<T>, ISearchable<T> where T : class
    {
    }
}
