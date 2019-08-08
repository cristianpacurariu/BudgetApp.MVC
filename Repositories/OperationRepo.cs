using Domain;
using Infrastructure;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MVC.Budget.DataAccess.Model;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Repositories
{
    public class OperationRepo : IOperationRepo<OperationDto, OperationDtoFilter>
    {
        public async Task<int> Add(OperationDto item)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Operation toAdd = Mapper.Map<OperationDto, Operation>(item);
                context.Operations.Add(toAdd);
                await context.SaveChangesAsync();

                return toAdd.Id;
            }
        }
        public async Task<List<OperationDto>> All()
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<Operation> fromDb = await context.Operations.ToListAsync();
                return Mapper.Map<List<Operation>, List<OperationDto>>(fromDb);
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Operation toDelete = await context.Operations.FirstOrDefaultAsync(d => d.Id == id);
                if (toDelete == null)
                {
                    return false;
                }
                else
                {
                    context.Operations.Remove(toDelete);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
        }
        public async Task<List<OperationDto>> Filter(OperationDtoFilter filter)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                IQueryable<Operation> query = context.Operations;

                if (filter.IdAccount != null)
                {
                    query = query.Where(d => d.IdAccount == filter.IdAccount);
                }

                if (filter.IdCurrency != null)
                {
                    query = query.Where(d => d.Account.IdCurrency == filter.IdCurrency);
                }

                if (filter.IdOperationType != null)
                {
                    query = query.Where(d => d.IdOperationType == filter.IdOperationType);
                }

                if (filter.AmmountFrom != null)
                {
                    query = query.Where(d => d.Ammount >= filter.AmmountFrom);
                }

                if (filter.AmmountTo != null)
                {
                    query = query.Where(d => d.Ammount <= filter.AmmountTo);
                }

                if (filter.DateFrom != null)
                {
                    query = query.Where(d => d.Date >= filter.DateFrom);
                }

                if (filter.DateTo != null)
                {
                    query = query.Where(d => d.Date <= filter.DateTo);
                }

                return Mapper.Map<List<Operation>,List<OperationDto>>(await query.ToListAsync());
            }
        }
        public async Task<OperationDto> Get(int i)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Operation fromDb = await context.Operations.FirstOrDefaultAsync(d => d.Id == i);
                if (fromDb == null)
                {
                    return null;
                }

                return Mapper.Map<Operation, OperationDto>(fromDb);
            }
        }
        public async Task Update(OperationDto t)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Operation toUpdate = Mapper.Map<OperationDto, Operation>(t);

                context.Operations.Attach(toUpdate);
                context.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}
