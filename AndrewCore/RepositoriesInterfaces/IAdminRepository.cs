using AndrewCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewCore.RepositoriesInterfaces
{
    public interface IAdminRepository
    {
        Task CreateAdmin(int id);
        Task DeleteAdmin(int id);
        AdminUserDto GetAdmin(int id);
        List<AdminUserDto> GetAdmins();
        Task<bool> UpdateAdmin(AdminUserDto adminUserDto);
    }
}
