using System.Collections.Generic;

namespace Domain
{
    public class CurrencyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<AccountDto> Accounts { get; set; }
    }
}
