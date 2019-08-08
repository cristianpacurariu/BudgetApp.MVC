using System;

namespace Domain
{
    public class OperationDtoFilter
    {
        public int? IdAccount { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdOperationType { get; set; }

        public decimal? AmmountFrom { get; set; }
        public decimal? AmmountTo { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}
