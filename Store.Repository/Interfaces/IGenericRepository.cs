﻿using Store.Data.Entity;
using Store.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey? id);
        Task<IReadOnlyList<TEntity>> GetAll();
        Task<int> GetCountWithSpecification(ISpecification<TEntity> specs);
        Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity>specs);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecification(ISpecification<TEntity> specs);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);


    }
}
