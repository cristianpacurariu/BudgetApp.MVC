using AutoMapper;
using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Bugdet.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountRepo<AccountDto, AccountDtoFilter> _accountRepo;
        private readonly ICurrencyRepo<CurrencyDto> _currencyRepo;
        private readonly IOperationRepo<OperationDto, OperationDtoFilter> _operationRepo;
        private readonly IOperationTypeRepo<OperationTypeDto> _operationTypeRepo;

        public HomeController(IAccountRepo<AccountDto, AccountDtoFilter> accountRepo,
                              ICurrencyRepo<CurrencyDto> currencyRepo, 
                              IOperationRepo<OperationDto, OperationDtoFilter> operationRepo, 
                              IOperationTypeRepo<OperationTypeDto> operationTypeRepo)
        {
            _accountRepo = accountRepo;
            _currencyRepo = currencyRepo;
            _operationRepo = operationRepo;
            _operationTypeRepo = operationTypeRepo;
        }

        public ActionResult Index()
        {
            List<AccountDto> accountDtos = _accountRepo.All();
            return View(accountDtos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}