using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        Task Save();
        IUserRepository User { get; }
        IProductRepository Product { get; }

        IFilterRepository Filter { get; }
    }
}
