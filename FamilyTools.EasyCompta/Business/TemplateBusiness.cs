using EasyCompta.Server.Data;
using EasyCompta.Server.IBusiness;
using EasyCompta.Server.Model;

namespace EasyCompta.Server.Business
{
    public class TemplateBusiness(AccountContext context) : BaseBusiness<Template>(context), ITemplateBusiness
    {
    }
}
