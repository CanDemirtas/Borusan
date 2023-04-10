using CleanArch.Application.Contracts.Persistence;
using CleanArch.Persistence.Context;
using System;

namespace CleanArch.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IOrderRepository _orderRepository { get; }
        public IMaterialRepository _materialRepository { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext,
            IOrderRepository orderRepository,
            IMaterialRepository materialRepository)
        {
            this._context = applicationDbContext;
            this._orderRepository = orderRepository;
            this._materialRepository = materialRepository;

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}