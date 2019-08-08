using AutoMapper;
using Domain;
using MVC.Budget.DataAccess.Model;

namespace Repositories
{
    public class RepoMapper:Profile
    {
        public RepoMapper()
        {
            this.CreateMap<AccountDto, Account>().ReverseMap();
            this.CreateMap<OperationDto, Operation>().ReverseMap();
            this.CreateMap<OperationTypeDto, OperationType>().ReverseMap();
            this.CreateMap<CurrencyDto, Currency>().ReverseMap();
        }
    }
}
