using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
   public interface ISpecification<T>
    {
       Expression<Func<T,bool>> Criteria { get; }
       List< Expression<Func<T, object>>> Includes { get; }
       Expression<Func<T, object>> Ordery { get; }
       Expression<Func<T, object>> OrderyDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
