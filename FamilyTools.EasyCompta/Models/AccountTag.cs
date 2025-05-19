using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FamilyTools.EasyCompta.Models
{
    [Table("AccountTags")]
    public class AccountTag : BaseModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
