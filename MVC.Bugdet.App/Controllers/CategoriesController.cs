using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using Infrastructure;
using MVC.Bugdet.App.Models;
using Repositories;

namespace MVC.Bugdet.App.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IOperationTypeRepo<OperationTypeDto> _operationTypeRepo;
        public CategoriesController(OperationTypeRepo operationTypeRepo)
        {
            _operationTypeRepo = operationTypeRepo;
        }
        public async Task<ActionResult> Index()
        {
            List<OperationTypeDto> all = await _operationTypeRepo.All();
            List<OperationTypeViewModel> vm =
                Mapper.Map<List<OperationTypeDto>, List<OperationTypeViewModel>>(all);
            return View(vm);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            OperationTypeViewModel vm = new OperationTypeViewModel();

            if (id != null)
            {
                OperationTypeDto toGet = await _operationTypeRepo.Get(id.Value);
                if (toGet == null)
                {
                    return RedirectToAction("Index");
                }
                vm = Mapper.Map<OperationTypeDto, OperationTypeViewModel>(toGet);
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OperationTypeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            OperationTypeDto dto = Mapper.Map<OperationTypeViewModel, OperationTypeDto>(vm);
            if (vm.Id == 0)
            {
                await _operationTypeRepo.Add(dto);
            }
            else
            {
                await _operationTypeRepo.Update(dto);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id != null)
            {
                OperationTypeDto toGet = await _operationTypeRepo.Get(id.Value);
                if (toGet != null)
                {
                    OperationTypeViewModel vm = Mapper.Map<OperationTypeDto, OperationTypeViewModel>(toGet);
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
                OperationTypeDto toDelete = await _operationTypeRepo.Get(id.Value);
                if (toDelete != null)
                {
                    OperationTypeViewModel vm =
                        Mapper.Map<OperationTypeDto, OperationTypeViewModel>(toDelete);
                    return View(vm);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(OperationTypeViewModel vm)
        {
            OperationTypeDto toDelete = Mapper.Map<OperationTypeViewModel, OperationTypeDto>(vm);
            await _operationTypeRepo.Delete(toDelete.Id);
            return RedirectToAction("Index");
        }
    }
}