using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplicationEonix.Models;

namespace WebApplicationEonix.DataAccess
{
    public class UowProvider : IUowProvider
    {
        public UowProvider()
        { }

        public UowProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public IUnitOfWork CreateUnitOfWork(bool trackChanges = true, bool enableLogging = false)
        {
            var _context = (DbContext)_serviceProvider.GetService(typeof(EonixContext));

            //if (!trackChanges)
            //    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var uow = new UnitOfWork(_context, _serviceProvider);
            return uow;
        }

        public IUnitOfWork CreateUnitOfWork<TEntityContext>(bool trackChanges = true, bool enableLogging = false) where TEntityContext : DbContext
        {
            var _context = (TEntityContext)_serviceProvider.GetService(typeof(EonixContext));

            //if (!trackChanges)
            //    _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var uow = new UnitOfWork(_context, _serviceProvider);
            return uow;
        }
    }
}
