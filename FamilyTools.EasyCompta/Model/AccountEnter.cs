using System.ComponentModel.DataAnnotations.Schema;

using FamilyTools.EasyCompta.Model;

namespace FamilyTools.EasyCompta.Model
{
    [Table("AccountEnters")]
    public class AccountEnter : BaseModel
    {
        public List<AccountLine> Lines { get; set; }

        public AccountTag Tag { get; set; }

        public string Name { get; set; }

        public float TotalValue { get; set; }

        public DateOnly LifeTime { get; set; }

        public AccountEnter()
        {
            if (this.Lines?.Count > 0)
            {
                this.TotalValue = this.Lines.Sum(line => line.Value);
            }
        }
    }
}
