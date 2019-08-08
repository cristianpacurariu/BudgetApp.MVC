using System.Collections.Generic;

namespace Domain
{
    public class OperationTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCredit { get; set; }
        public virtual List<OperationDto> Operations { get; set; }
    }
}
