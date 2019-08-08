﻿namespace Domain
{
    public class OperationDto
    {
        public int Id { get; set; }
        public int IdAccount { get; set; }
        public int IdOperationType { get; set; }
        public decimal Ammount { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual AccountDto Account { get; set; }
        public virtual OperationTypeDto OperationType { get; set; }
    }
}
