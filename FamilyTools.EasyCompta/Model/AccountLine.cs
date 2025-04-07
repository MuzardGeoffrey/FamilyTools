using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Model
{
    [Table("AccountLines")]
    public class AccountLine: BaseModel
    {

        public string Name { get; set; }

        public User UserLink { get; set; }

        public float Value { get; set; }

    }
}
