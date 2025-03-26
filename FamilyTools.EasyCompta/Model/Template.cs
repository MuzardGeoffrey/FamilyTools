using EasyCompta.Server.IModel;

namespace EasyCompta.Server.Model
{
    public class Template : BaseModel, ITemplate
    {
        public string Name { get; set; }

        public List<AccountLine> Lines { get; set; }

        public DateOnly LifeTime { get; set; }
    }
}
