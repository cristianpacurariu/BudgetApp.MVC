using Antlr.Runtime.Misc;
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
    public class OperationsController : Controller
    {
        private readonly IOperationRepo<OperationDto, OperationDtoFilter> _operationRepo;
        private readonly IAccountRepo<AccountDto, AccountDtoFilter> _accountRepo;
        private readonly IOperationTypeRepo<OperationTypeDto> _operationTypeRepo;
        public OperationsController(
            IOperationRepo<OperationDto, OperationDtoFilter> operationRepo,
            IAccountRepo<AccountDto, AccountDtoFilter> accountRepo,
            IOperationTypeRepo<OperationTypeDto> operationTypeRepo
            )
        {
            _operationRepo = operationRepo;
            _accountRepo = accountRepo;
            _operationTypeRepo = operationTypeRepo;
        }
        public async Task<ActionResult> Index()
        {
            List<OperationDto> all = await _operationRepo.All();
            List<OperationViewModel> vm = Mapper.Map<List<OperationDto>, List<OperationViewModel>>(all);
            return View(vm);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            OperationViewModel vm = new OperationViewModel();
            if (id != null)
            {
                OperationDto toEdit = await _operationRepo.Get(id.Value);
                if (toEdit != null)
                {
                    vm = Mapper.Map<OperationDto, OperationViewModel>(toEdit);
                }
            }
            await AddAccountsAndCategories(vm);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OperationViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await AddAccountsAndCategories(vm);
                return View(vm);
            }
            OperationDto dto = Mapper.Map<OperationViewModel, OperationDto>(vm);

            if (vm.Id == 0)
            {
                await _operationRepo.Add(dto);
            }
            else
            {
                await _operationRepo.Update(dto);
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id != null)
            {
                OperationDto toGet = await _operationRepo.Get(id.Value);
                if (toGet != null)
                {
                    OperationViewModel vm = Mapper.Map<OperationDto, OperationViewModel>(toGet);
                    return View(vm);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id != null)
            {
                OperationDto toDelete = await _operationRepo.Get(id.Value);
                if (toDelete != null)
                {
                    OperationViewModel vm = Mapper.Map<OperationDto, OperationViewModel>(toDelete);
                    return View(vm);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(OperationViewModel vm)
        {
            await _operationRepo.Delete(vm.Id);
            return RedirectToAction("Index");
        }

        private async Task AddAccountsAndCategories(OperationViewModel vm)
        {
            List<AccountDto> accountDtos = await _accountRepo.All();
            vm.Accounts = accountDtos.Select(d => new SelectListItem()
            {
                Text = d.Name + ' ' + d.Currency.Name,
                Value = d.Id.ToString(),
            }).ToList();

            List<OperationTypeDto> operationTypeDtos = await _operationTypeRepo.All();
            vm.Categories = operationTypeDtos.Select(d => new SelectListItem()
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();
        }

    }
}
