﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<User>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _repositoryWrapper.User
                .FindByCondition(x => x.UId == id);
            return user.First();
        }

        public async Task Create (User model)
        {
            if(model == null)
                throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrEmpty(model.UName))
            {
                throw new ArgumentException(nameof(model.UName));
            }

            await _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(User model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }


        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.UId == id);
            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }


        public async Task<User> Login(string email, string password)
        {
            var user = await
                _repositoryWrapper.User.GetByEP(email, password);

            return user;
        }
    }
}
