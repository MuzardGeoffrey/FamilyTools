namespace FamilyTools.Data.Models.EasyCompta
{
    public class PaymentDone : BaseModel
    {
        public User User { get; set; } = null!;
        public bool PaymentIsDone { get; set; }
        public float Total { get; set; }
        public int PageId { get; set; }
        public AccountPage Page { get; set; } = null!;

    }
}