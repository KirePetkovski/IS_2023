using Domashna.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domashna.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<AplicationUser> GetAll();
        AplicationUser Get(string id);
        void Insert(AplicationUser entity);
        void Update(AplicationUser entity);
        void Delete(AplicationUser entity);
    }
}
