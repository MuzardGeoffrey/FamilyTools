using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Models
{
    [Table("Templates")]
    public class Template : BaseModel
    {
        public string Name { get; set; }

        public List<AccountEnter> Enters { get; set; }

        public DateTime Date { get; set; }
    }
}
