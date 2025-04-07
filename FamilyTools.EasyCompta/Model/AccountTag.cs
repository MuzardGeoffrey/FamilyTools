using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Model
{
    [Table("AccountTags")]
    public class AccountTag : BaseModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
