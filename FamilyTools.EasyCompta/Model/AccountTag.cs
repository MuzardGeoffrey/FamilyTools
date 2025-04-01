using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCompta.Server.Model
{
    [Table("AccountTags")]
    public class AccountTag : BaseModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
