using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using AutoMapper;
using MVC.Budget.DataAccess.Model;
using System.Data.Entity;

namespace Repositories
{
    public class OperationTypeRepo : IOperationTypeRepo<OperationTypeDto>
    {
        public async Task<int> Add(OperationTypeDto item)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toAdd = Mapper.Map<OperationTypeDto, OperationType>(item);
                context.OperationTypes.Add(toAdd);
                await context.SaveChangesAsync();

                return toAdd.Id;
            }
        }
        public async Task<List<OperationTypeDto>> All()
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<OperationType> fromDb = await context.OperationTypes.ToListAsync();
                return Mapper.Map<List<OperationType>, List<OperationTypeDto>>(fromDb);
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toDelete = await context.OperationTypes.FirstOrDefaultAsync(d => d.Id == id);
                if (toDelete == null)
                {
                    return false;
                }

                context.OperationTypes.Remove(toDelete);
                await context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<OperationTypeDto> Get(int i)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toGet = await context.OperationTypes.FirstOrDefaultAsync(d => d.Id == i);
                if (toGet == null)
                {
                    return null;
                }
                return Mapper.Map<OperationType, OperationTypeDto>(toGet);
            }
        }
        public async Task Update(OperationTypeDto t)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                OperationType toUpdate = Mapper.Map<OperationTypeDto, OperationType>(t);

                context.OperationTypes.Attach(toUpdate);
                context.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
