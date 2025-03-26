using EasyCompta.Server.IModel;

namespace EasyCompta.Server.Model
{
    public class AccountTag : BaseModel, IAccountTag
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
