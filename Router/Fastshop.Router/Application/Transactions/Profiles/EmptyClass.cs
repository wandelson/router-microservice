using System;
using AutoMapper;

namespace Fastshop.Router.Application.Transactions.Profiles
{
    public class CommandToDomainProfile : Profile
    {
        public CommandToDomainProfile()
        {
            CreateMap<Tra, UserViewModel>();
        }
    }
}
