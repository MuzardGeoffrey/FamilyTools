using FamilyTools.EasyCompta.Models;

namespace FamilyTools.EasyCompta.Models
{
    public class PaymentDone : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public bool PaymentIsDone { get; set; }
        public float Total { get; set; }
        public int PageId { get; set; }
        public AccountPage Page { get; set; } = null!;

    }
}