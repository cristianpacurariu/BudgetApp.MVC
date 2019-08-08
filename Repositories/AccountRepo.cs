using Domain;
using Infrastructure;
using MVC.Budget.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repositories
{
    public class AccountRepo : IAccountRepo<AccountDto, AccountDtoFilter>
    {
        public async Task<int> Add(AccountDto toMap)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Account toAdd = Mapper.Map<AccountDto, Account>(toMap);
                context.Accounts.Add(toAdd);
                await context.SaveChangesAsync();

                return toAdd.Id;
            }
        }
        public async Task<List<AccountDto>> All()
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<Account> accountsToMap = await context.Accounts.ToListAsync();
                return Mapper.Map<List<Account>, List<AccountDto>>(accountsToMap);
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Account toDelete = await context.Accounts.FirstOrDefaultAsync(d => d.Id == id);

                if (toDelete == null)
                {
                    return false;
                }
                else
                {
                    context.Accounts.Remove(toDelete);
                    await context.SaveChangesAsync();

                    return true;
                }
            }
        }
        public async Task<List<AccountDto>> Filter(AccountDtoFilter filter)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<Account> fromDb = new List<Account>();

                if (filter.IdCurrency != null)
                {
                    fromDb = await context.Accounts.Where(d => d.IdCurrency == filter.IdCurrency).ToListAsync();
                }

                return Mapper.Map<List<Account>, List<AccountDto>>(fromDb);
            }
        }
        public async Task<AccountDto> Get(int i)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Account fromDb = await context.Accounts.FirstOrDefaultAsync(d => d.Id == i);

                if (fromDb == null)
                {
                    return null;
                }

                return Mapper.Map<Account, AccountDto>(fromDb);
            }
        }
        public async Task Update(AccountDto t)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                //Account toUpdate = context.Accounts.FirstOrDefault(d => d.Id == t.Id);
                //toUpdate.Name = t.Name;
                //toUpdate.IdCurrency = t.IdCurrency;
                

                Account toUpdate = Mapper.Map<AccountDto, Account>(t);
                context.Accounts.Attach(toUpdate);
                context.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}
