using Domain;
using Infrastructure;
using MVC.Budget.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Repositories
{
    public class AccountRepo : IAccountRepo<AccountDto, AccountDtoFilter>
    {
        public int Add(AccountDto toMap)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Account toAdd = Mapper.Map<AccountDto, Account>(toMap);
                context.Accounts.Add(toAdd);
                context.SaveChanges();

                return toAdd.Id;
            }
        }
        public List<AccountDto> All()
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<Account> accountsToMap = context.Accounts.ToList();
                return Mapper.Map<List<Account>, List<AccountDto>>(accountsToMap);
            }
        }
        public bool Delete(int id)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Account toDelete = context.Accounts.FirstOrDefault(d => d.Id == id);

                if (toDelete == null)
                {
                    return false;
                }
                else
                {
                    context.Accounts.Remove(toDelete);
                    context.SaveChanges();

                    return true;
                }
            }
        }
        public List<AccountDto> Filter(AccountDtoFilter filter)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<Account> fromDb = new List<Account>();

                if (filter.IdCurrency != null)
                {
                    fromDb = context.Accounts.Where(d => d.IdCurrency == filter.IdCurrency).ToList();
                }

                return Mapper.Map<List<Account>, List<AccountDto>>(fromDb);
            }
        }
        public AccountDto Get(int i)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Account fromDb = context.Accounts.FirstOrDefault(d => d.Id == i);

                if (fromDb == null)
                {
                    return null;
                }

                return Mapper.Map<Account, AccountDto>(fromDb);
            }
        }
        public void Update(AccountDto t)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                //Account toUpdate = context.Accounts.FirstOrDefault(d => d.Id == t.Id);
                //toUpdate.Name = t.Name;
                //toUpdate.IdCurrency = t.IdCurrency;
                

                Account toUpdate = Mapper.Map<AccountDto, Account>(t);
                context.Accounts.Attach(toUpdate);
                context.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
