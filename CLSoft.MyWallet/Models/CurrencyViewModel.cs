using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CLSoft.MyWallet.Models
{
    public class CurrencyViewModel
    {
        [Required, RegularExpression(@"\d+(?:(,|\.)\d{1,2})?", ErrorMessage = "The value of {0} must be numeric and with max two decimal digits.")]
        [Display(Name = "Amount")]
        public string Value { get; set; }

        public string Currency { get; set; }

        public CurrencyViewModel()
        {
            Currency = CultureInfo.GetCultureInfo("it-IT").NumberFormat.CurrencySymbol;
        }
    }
}