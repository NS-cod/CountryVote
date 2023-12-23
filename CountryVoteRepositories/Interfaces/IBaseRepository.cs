﻿using CountryVoteModels.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CountryVoteRepositories.Interfaces
{
    public interface IBaseRepository <T> where T  : BaseModel
    {
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(T entity);
        public Task<ICollection<T>> GetAll();
        public Task<ICollection<T>> GetAll(Expression<Func<T, bool>> predicated);
        public Task<T> Get(int id);
    }
}
