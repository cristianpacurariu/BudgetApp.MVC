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
    public class AccountsController : Controller
    {
        private readonly IAccountRepo<AccountDto, AccountDtoFilter> _accountRepo;
        private readonly ICurrencyRepo<CurrencyDto> _currencyRepo;
        public AccountsController(
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
            if (!ModelState.IsValid)
            {
                await AddCurrencies(vm);
                return View(vm);
            }

            AccountDto dto = Mapper.Map<AccountViewModel, AccountDto>(vm);

            if (vm.Id == 0)
            {
                await _accountRepo.Add(dto);
            }
            else
            {
                await _accountRepo.Update(dto);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
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

            return View(vm);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id != null)
            {
                AccountDto toDelete = await _accountRepo.Get(id.Value);
                if (toDelete != null)
                {
                    AccountViewModel vm = Mapper.Map<AccountDto, AccountViewModel>(toDelete);
                    return View(vm);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(AccountViewModel vm)
        {
            AccountDto toDelete = Mapper.Map<AccountViewModel, AccountDto>(vm);
            await _accountRepo.Delete(toDelete.Id);
            return RedirectToAction("Index");
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