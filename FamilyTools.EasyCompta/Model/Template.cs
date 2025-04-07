using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Model
{
    [Table("Templates")]
    public class Template : BaseModel
    {
        public string Name { get; set; }

        public List<AccountLine> Lines { get; set; }

        public DateOnly LifeTime { get; set; }
    }
}
