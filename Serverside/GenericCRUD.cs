using Models;
using ServiceProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Serverside
{
    public interface IGenericCRUD
    {
    }

    public static class GenericCRUDExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Extension method")]
        public static Task<ActionResponse> GenericCreate<T>(this IGenericCRUD i, T inputObject)
        {
            try
            {
                using var db = new DataContext();
                bool created = db.Database.EnsureCreated();

                db.Add(inputObject);
                db.SaveChanges();

                return Task.FromResult(new ActionResponse { Result = (int)HttpStatusCode.OK });
            }
            catch
            {
                return Task.FromResult(new ActionResponse { Result = (int)HttpStatusCode.Forbidden });
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Extension method")]
        public static IQueryable<T> GenericWrappedInvoke<T>(this IGenericCRUD i, T inputObject, Func<DataContext, IQueryable<T>> filterFunction, Action<T> formatFunction)
        {
            try
            {
                using DataContext db = new DataContext();
                IQueryable<T> q = filterFunction.Invoke(db);
                q.ToList().ForEach(formatFunction);
                return q;
            }
            catch
            {
                return null;
            }
        }
    }
}
