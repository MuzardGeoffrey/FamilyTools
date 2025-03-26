using System.ComponentModel.DataAnnotations;
using EasyCompta.Server.IModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace EasyCompta.Server.Model
{
    [Table("Users")]
    public class User : BaseModel, IUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string SurName { get; set; }
    }
}
