using BelediyeCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BelediyeCore.Specification
{
    public interface ISpecification<Tender>      
    {
        Expression<Func<Tender, bool>> Criteria { get; } 
        List<Expression<Func<Tender,Object>>> Includes { get; }
       // Expression<Func<T,Object>> IncludesExpression { get; }
    }
}
