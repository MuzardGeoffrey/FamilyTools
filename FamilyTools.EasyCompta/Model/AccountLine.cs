using EasyCompta.Server.IModel;

namespace EasyCompta.Server.Model
{
    public class AccountLine: BaseModel, IAccountLine
    {

        public string Name { get; set; }

        public User UserLink { get; set; }

        public float Value { get; set; }

    }
}
