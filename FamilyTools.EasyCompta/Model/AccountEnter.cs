using EasyCompta.Server.IModel;

namespace EasyCompta.Server.Model
{
    public class AccountEnter : BaseModel, IAccountEnter
    {
        public List<AccountLine> Lines { get; set; }

        public AccountTag Tag { get; set; }

        public string Name { get; set; }

        public float TotalValue { get; set; }

        public DateOnly LifeTime { get; set; }
    }
}
