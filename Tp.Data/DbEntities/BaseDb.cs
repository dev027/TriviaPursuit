using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tp.Models.BaseModels;

namespace Tp.Data.DbEntities
{
    public class BaseDb
    {
        protected static IQueryable<T> IsTracked<T>(bool isTracked, IQueryable<T> read) where T : BaseModel
        {
            return isTracked ? read : read.AsNoTracking();
        }
    }
}