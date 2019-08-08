using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using Domain;
using MVC.Budget.DataAccess.Model;
using AutoMapper;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repositories
{
    public class CurrencyRepo : ICurrencyRepo<CurrencyDto>
    {
        public async Task<List<CurrencyDto>> All()
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                List<Currency> fromDb = await context.Currencies.ToListAsync();
                return Mapper.Map<List<Currency>, List<CurrencyDto>>(fromDb);
            }
        }
        public async Task<CurrencyDto> Get(int i)
        {
            using (SpendingsDBContext context = new SpendingsDBContext())
            {
                Currency fromDb = await context.Currencies.FirstOrDefaultAsync(d => d.Id == i);
                if (fromDb == null)
                {
                    return null;
                }

                return Mapper.Map<Currency, CurrencyDto>(fromDb);
            }
        }
    }
}
