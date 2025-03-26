using System.ComponentModel.DataAnnotations.Schema;

using EasyCompta.Server.IModel;

namespace EasyCompta.Server.Model
{
    public class AccountPage : BaseModel, IAccountPage
    {
        public string Name { get; set; }
        
        public List<AccountLine> Lines { get; set; }

        [NotMapped]
        public Dictionary<bool, User> PaymentDone { get; set; }

        public bool IsClosing { get; set; }

        public DateTime Date { get; set; }

    }
}
