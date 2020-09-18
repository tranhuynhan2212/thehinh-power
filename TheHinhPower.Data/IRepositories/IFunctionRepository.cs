using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheHinhPower.Data.Entities;
using TheHinhPower.Infrastructure;

namespace TheHinhPower.Data.IRepositories
{
    public interface IFunctionRepository : IRepository<Function, string>
    {
        IQueryable GetAllByOrder();
    }
}
