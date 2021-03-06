﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbApp.DAL.Interfaces
{
    public interface ISearchable<T>
    {
        IQueryable<T> Search(string searchTerm);
        IQueryable<T> FilteredSearch(T Searchable);

    }
}
