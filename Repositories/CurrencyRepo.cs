using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using Domain;
using MVC.Budget.DataAccess.Model;
using AutoMapper;

namespace Repositories
{
    public class CurrencyRepo : ICurrencyRepo<CurrencyDto>
    {
        public List<CurrencyDto> All()
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<Currency> fromDb = context.Currencies.ToList();
                return Mapper.Map<List<Currency>, List<CurrencyDto>>(fromDb);
            }
        }
        public CurrencyDto Get(int i)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Currency fromDb = context.Currencies.FirstOrDefault(d => d.Id == i);
                if (fromDb == null)
                {
                    return null;
                }

                return Mapper.Map<Currency, CurrencyDto>(fromDb);
            }
        }
    }
}
