using FamilyTools.Data.Context;

namespace FamilyTools.Data.Seed.EasyCompta
{
    public class ContextInitializer
    {
        public async Task Seed(EasyComptaContext context)
        {
            List<IContextSeed> listSeed =
            [
                new AccountTagSeed(context),
            ];

            foreach (IContextSeed contextSeed in listSeed)
            {
                await contextSeed.Execute();
            }
        }
    }
}
