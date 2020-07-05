using Microsoft.EntityFrameworkCore;
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
            using var db = new DataContext();
            bool created = db.Database.EnsureCreated();

            db.Add(inputObject);
            db.SaveChanges();

            return Task.FromResult(new ActionResponse { Result = (int)HttpStatusCode.OK });
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Extension method")]
        public static IQueryable<T> GenericQueryableInvoke<T>(this IGenericCRUD i, T inputObject, Func<DataContext, IQueryable<T>> filterFunction, Action<T> formatFunction)
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Extension method")]
        public static void GenericInvoke<T>(this IGenericCRUD i, T inputObject, Action<DataContext> insertFunction) 
        {
            using DataContext db = new DataContext();
            insertFunction.Invoke(db);
            db.SaveChanges();
        }
    }
}
