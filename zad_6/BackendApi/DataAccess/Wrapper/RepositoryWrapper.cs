using Domain.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        mshopContext _repContext;
        private mshopContext _repoContext;
        private IUserRepository _user;
        IFilterRepository _filter;
        IProductRepository _product;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(_repContext);
                return _product;
            }
        }

        public IFilterRepository Filter
        {
            get
            {
                if (_filter == null)
                    _filter = new FilterRepository(_repContext);
                return _filter;
            }
        }

        public RepositoryWrapper(mshopContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }

        Task IRepositoryWrapper.Save()
        {
            throw new NotImplementedException();
        }
    }
}
