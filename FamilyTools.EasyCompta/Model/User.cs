using System.ComponentModel.DataAnnotations.Schema;


namespace EasyCompta.Server.Model
{
    [Table("Users")]
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Username { get; set; }
    }
}
