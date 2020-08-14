using System;
using System.Collections.Generic;
using System.Text;

namespace TheHinhPower.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
