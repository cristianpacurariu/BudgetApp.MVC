using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using Infrastructure;
using MVC.Bugdet;
using Repositories;

namespace MVC.Bugdet.App
{
    public static class RepoProvider
    {
        public static IAccountRepo<AccountDto, AccountDtoFilter> GetAccountRepo()
        {
            return new AccountRepo();
        }

        public static ICurrencyRepo<CurrencyDto> GetCurrencyRepo()
        {
            return new CurrencyRepo();
        }

        public static IOperationRepo<OperationDto, OperationDtoFilter> GetOperationRepo()
        {
            return new OperationRepo();
        }

        public static IOperationTypeRepo<OperationTypeDto> GetOperationTypeRepo()
        {
            return new OperationTypeRepo();
        }
    }
}