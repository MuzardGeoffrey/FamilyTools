using System.ComponentModel.DataAnnotations;

using EasyCompta.Server.IModel;

using Microsoft.EntityFrameworkCore;

namespace EasyCompta.Server.Model
{
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
