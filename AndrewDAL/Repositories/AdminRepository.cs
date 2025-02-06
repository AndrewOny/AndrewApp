using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndrewCore.DTOs;
using AndrewCore.RepositoriesInterfaces;

namespace AndrewDAL.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public Task CreateAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public AdminUserDto GetAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public List<AdminUserDto> GetAdmins()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAdmin(AdminUserDto adminUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
