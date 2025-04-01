using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCompta.Server.Model
{
    [Table("AccountPages")]
    public class AccountPage : BaseModel
    {
        public string Name { get; set; }
        
        public List<AccountLine> Lines { get; set; }

        [NotMapped]
        public Dictionary<bool, User> PaymentDone { get; set; }

        public bool IsClosing { get; set; }

        public DateTime Date { get; set; }

    }
}
