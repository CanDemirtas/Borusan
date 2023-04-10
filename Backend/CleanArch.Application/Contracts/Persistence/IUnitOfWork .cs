using CleanArch.Application.Contracts.Persistence;
using System;

namespace CleanArch.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository _orderRepository { get; }
        IMaterialRepository _materialRepository { get; }
        int Complete();
    }
}