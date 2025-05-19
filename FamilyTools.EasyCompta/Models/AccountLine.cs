using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Models
{
    [Table("AccountLines")]
    public class AccountLine: BaseModel
    {

        public string Name { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; } = null!;
        public float Value { get; set; }
        public int EnterId { get; set; }
        public AccountEnter Enter { get; set; } = null!;

    }
}
