namespace ironman2018.Models.Environments
{
    public class ProductionEnvironmentsService : IEnvironmentsService
    {
        public string GetEnvironmentName()
        {
            return "Production";
        }
    }
}