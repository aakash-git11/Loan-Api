using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApi.Models
{
    public class LoanDetails
    {
        [Key]
        public int LoanId { get; set; }
        public string LoanNumber { get; set; }
        public string LoanAccountHolderFirstName { get; set; }
        public string LoanAccountHolderLastName { get; set; }
        public string PropertyAddress { get; set; }
        public string LoanType { get; set; }
        public string LoanTerm { get; set; }
        public double LoanAmmount { get; set; }
        public bool LoanStatus { get; set; }
    }
}
