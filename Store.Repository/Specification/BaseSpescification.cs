﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Store.Repository.Specification
{
    public class BaseSpescification<T> : ISpecification<T>
    {
        public BaseSpescification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }

        public bool IsPaginated { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeEx)
        {
            Includes.Add(includeEx);
        }
        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        =>OrderBy = OrderByExpression;
        protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescendingExpression)
       => OrderBy = OrderByDescendingExpression;

        protected void ApplyPagination (int take,int skip)
        {
            Take = take;
            Skip = skip;
            IsPaginated = true;
        }
    }
}
