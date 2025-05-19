using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Models
{
    [Table("AccountPages")]
    public class AccountPage : BaseModel
    {
        public string Name { get; set; }

        public List<AccountEnter> Enters { get; set; }

        public List<PaymentDone> PaymentDones { get; set; }

        public bool IsClosing { get; set; }

        public DateTime Date { get; set; }

        public float Total { get; set; }

        public AccountPage()
        {
            if (Enters?.Count > 0)
            {
                Total = Enters.Sum(enter => enter.TotalValue);
            }
        }
    }
}
