using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.Data.Models.EasyCompta
{
    [Table("AccountPages")]
    public class AccountPage : BaseModel
    {
        public string Name { get; set; }

        public ICollection<AccountEnter> Enters { get; set; } = new List<AccountEnter>();

        public ICollection<PaymentDone> PaymentDones { get; set; } = new List<PaymentDone>();

        public bool IsClosing { get; set; }

        public DateOnly Date { get; set; }

        public float Total { get; set; }

        public AccountPage()
        {
            if (Enters?.Count > 0)
            {
                Total = Enters.Sum(enter => enter.TotalValue);
            }
        }

        public AccountPage(List<AccountEnter> enters, DateOnly date) : this()
        {
            Name = $"Page {date.Month}/{date.Year}";
            Enters = enters;
            Date = date;
            IsClosing = false;
        }
    }
}
