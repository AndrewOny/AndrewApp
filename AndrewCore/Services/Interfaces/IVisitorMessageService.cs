using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewCore.Services.Interfaces
{
    public interface IVisitorMessageService
    {
        Task SendEmailAsync(string name, string email, string title, string message);
    }
}
