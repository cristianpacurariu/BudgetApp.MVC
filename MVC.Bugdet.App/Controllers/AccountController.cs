using AutoMapper;
using Domain;
using Infrastructure;
using MVC.Bugdet.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Bugdet.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepo<AccountDto, AccountDtoFilter> _accountRepo;
        private readonly ICurrencyRepo<CurrencyDto> _currencyRepo;
        public AccountController(
            IAccountRepo<AccountDto, AccountDtoFilter> accountRepo,
            ICurrencyRepo<CurrencyDto> currencyRepo)
        {
            _accountRepo = accountRepo;
            _currencyRepo = currencyRepo;
        }

        public async Task<ActionResult> Index()
        {
            List<AccountDto> accountDtos = await _accountRepo.All();
            return View(accountDtos);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            AccountViewModel vm = new AccountViewModel();

            if (id != null)
            {
                AccountDto dto = await _accountRepo.Get(id.Value);
                if (dto == null)
                {
                    return RedirectToAction("Index");
                }

                vm = Mapper.Map<AccountDto, AccountViewModel>(dto);
            }

            await AddCurrencies(vm);

            return View(vm);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Edit(AccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _accountRepo.Update(Mapper.Map<AccountViewModel, AccountDto>(vm));
                return RedirectToAction("Index");
            }
            else
            {
                await AddCurrencies(vm);
                return View(vm);
            }
        }
        private async Task AddCurrencies(AccountViewModel vm)
        {
            //add currencies
            List<CurrencyDto> currencies = await _currencyRepo.All();
            vm.Currencies = currencies.Select(d => new SelectListItem()
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();
        }
    }
}