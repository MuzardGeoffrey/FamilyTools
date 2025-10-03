
namespace FamilyTools.EasyCompta.IBusiness
{
    public interface IImportCSVBusiness
    {
        Task ImportCSVFile(IFormFile csvFile);
    }
}
