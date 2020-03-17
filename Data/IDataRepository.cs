using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public interface IDataRepository<T> where T : class
    {
        /// <summary>
        /// Method called by HttpPost api to add T(BlogPost) item to the database context
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Method called by HttpPut api to update T(BlogPost) item in the database context
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Method called by HttpDelete api to remove T(BlogPost) item from the database context
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Method called by HttpPost and HttpPut to save changes and finalise transaction
        /// </summary>
        /// <param name="entity"></param>
        Task<T> SaveAsync(T entity);
    }
}
