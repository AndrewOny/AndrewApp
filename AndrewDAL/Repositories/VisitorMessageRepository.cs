using AndrewCore.DTOs;
using AndrewCore.RepositoriesInterfaces;
using AndrewDAL.Migrations;
using AndrewDAL.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AndrewDAL.Repositories.VisitorMessageRepository;

namespace AndrewDAL.Repositories
{
    public class VisitorMessageRepository
    {
        public class EmailRepository : IVisitorMessageRepository
        {
            private readonly SqLiteContext _context;
            private readonly IMapper _mapper;

            public EmailRepository(SqLiteContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task SendEmailAsync(VisitorMessageDto emailMessage)
            {
                var visitorMessage = new VisitorMessage
                {
                    Name = emailMessage.Name,
                    Title = emailMessage.Title,
                    Email = emailMessage.Email,
                    Message = emailMessage.Message
                };

                _context.VisitorMessages.Add(visitorMessage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
