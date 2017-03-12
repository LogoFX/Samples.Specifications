using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NDatabase;
using NDatabase.Api;

namespace Samples.Specifications.Tests.Steps
{
    /// <summary>
    /// Represents simple persistable object storage.
    /// </summary>
    /// <remarks>Please pay attention, the class implements IDisposable interface.</remarks>
    internal sealed class Storage : IDisposable
    {
        private readonly IOdb _db;

        public Storage()
        {
            try
            {
                _db = OdbFactory.Open("objects.ndb");
            }

            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                throw;
            }
        }

        [SuppressMessage("ReSharper", "EmptyDestructor")]
        ~Storage()
        {

        }

        public IQueryable<T> Get<T>()
        {
            return _db.AsQueryable<T>();
        }

        public void Store(object item)
        {
            _db.Store(item);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                }
            }
        }
    }
}