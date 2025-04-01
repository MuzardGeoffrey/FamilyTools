namespace EasyCompta.Server.Model
{
    public class BaseModel
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
