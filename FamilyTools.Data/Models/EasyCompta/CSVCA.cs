namespace FamilyTools.Data.Models.EasyCompta
{
    public class CSVCA
    {
        public DateTime Date {get;set;}
        public string Libelle { get; set; } = "";
        public float Debit {get;set;} = 0;
        public float Credit { get; set; } = 0;

    }
}
