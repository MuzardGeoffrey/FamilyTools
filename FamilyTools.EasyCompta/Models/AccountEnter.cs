using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTools.EasyCompta.Models
{
    [Table("AccountEnters")]
    public class AccountEnter : BaseModel
    {
        public List<AccountLine> Lines { get; set; }
        public AccountTag Tag { get; set; }
        public int TagId { get; set; }
        public string Name { get; set; }
        public float TotalValue { get; set; }
        public DateOnly Date { get; set; }
        public int PageId { get; set; }
        public AccountPage Page { get; set; } = null!;

        public AccountEnter()
        {
            if (this.Lines?.Count > 0)
            {
                this.TotalValue = this.Lines.Sum(line => line.Value);
            }
        }
    }
}
