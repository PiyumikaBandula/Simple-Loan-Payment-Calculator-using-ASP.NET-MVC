using System.ComponentModel; // Importing the namespace for component model attributes
using System.ComponentModel.DataAnnotations; // Importing the namespace for data annotations
using System.Runtime.ConstrainedExecution; // Importing the namespace for constrained execution

namespace Assignment1_C0900440.Models
{
    public class LoanPaymentCalModel
    {
        // Principal property with validation attributes
        [Required(ErrorMessage = "Please enter value for principal amount.")]
        [Range(200, 2000, ErrorMessage = "The principal must be between 200 and 2000.")]
        public int? Principal { get; set; }

        // YearlyInterestRate property with validation attributes
        [Required(ErrorMessage = "Please enter value for interest rate.")]
        [Range(1, 100, ErrorMessage = "The interest rate must be between 1 and 100.")]
        public int? YearlyInterestRate { get; set; }

        // NumberOfPaymentsPerYear property with validation attributes
        [Required(ErrorMessage = "Please enter value for number of payments per year.")]
        [Range(1, 12, ErrorMessage = "The number of payments per year must be between 1 and 12.")]
        public int? NumberOfPaymentsPerYear { get; set; }

        // Method to calculate loan payment per period
        public decimal CalculateLoanPaymentPerPeriod()
        {
            /* 
             * Calculation formula:
             * loan payment per period = principal * interest rate / (100 * number of payments per year)
            */
            decimal PaymentPerPeriod = Convert.ToDecimal(Principal * YearlyInterestRate / (100 * NumberOfPaymentsPerYear));
            return PaymentPerPeriod; // Returning the calculated payment per period
        }
    }
}
