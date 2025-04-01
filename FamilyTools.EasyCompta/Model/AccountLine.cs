using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCompta.Server.Model
{
    [Table("AccountLines")]
    public class AccountLine: BaseModel
    {

        public string Name { get; set; }

        public User UserLink { get; set; }

        public float Value { get; set; }

    }
}
