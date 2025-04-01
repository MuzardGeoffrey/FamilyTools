using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCompta.Server.Model
{
    [Table("Templates")]
    public class Template : BaseModel
    {
        public string Name { get; set; }

        public List<AccountLine> Lines { get; set; }

        public DateOnly LifeTime { get; set; }
    }
}
