using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Model
{
    [Table("AccountPages")]
    public class AccountPage : BaseModel
    {
        public string Name { get; set; }

        public List<AccountEnter> Enters { get; set; }

        [NotMapped]
        public Dictionary<User, bool> PaymentDone { get; set; }

        public bool IsClosing { get; set; }

        public DateTime Date { get; set; }

        public float Total { get; set; }

        public AccountPage()
        {
            if (Enters?.Count > 0)
            {
                Total = Enters.Sum(enter => enter.TotalValue);

                PaymentDone ??= [];

                PaymentDone = Enters.SelectMany(enter => enter.Lines)
                        .Select(line => line.UserLink)
                        .Distinct()
                        .ToDictionary(
                        user => user,
                        user => PaymentDone != null && PaymentDone.ContainsKey(user) ? PaymentDone[user] : false
                    );
            }
        }
    }
}
