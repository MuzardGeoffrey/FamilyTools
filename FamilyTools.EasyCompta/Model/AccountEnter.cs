using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCompta.Server.Model
{
    [Table("AccountEnters")]
    public class AccountEnter : BaseModel
    {
        public List<AccountLine> Lines { get; set; }

        public AccountTag Tag { get; set; }

        public string Name { get; set; }

        public float TotalValue { get; set; }

        public DateOnly LifeTime { get; set; }
    }
}
