﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL.Interfaces;
using WebbApp.Mockup.Models;

namespace WebbApp.Mockup.Repo
{
    public class TestRepository : IRepository<TestModel>, ISearchable<TestModel>
    {
        private List<TestModel> TestModels;

        public TestRepository()
        {
            

        }
        public void Add(TestModel entity)
        {
            throw new NotImplementedException();
        }

        public void AddImage(Image entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TestModel entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TestModel> FilteredSearch(TestModel Searchable)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TestModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TestModel GetById(Guid id)
        {
            var model = new TestModel();
            model.id = Guid.NewGuid();
            model.Message = "Testing";
            return model;
        }

        public List<Item> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TestModel> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void Update(TestModel entity)
        {
            throw new NotImplementedException();
        }
    }
}