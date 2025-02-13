using AndrewCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewCore.RepositoriesInterfaces
{
    public interface IVisitorMessageRepository
    {
        Task SendEmailAsync(VisitorMessageDto emailMessage);
    }
}
