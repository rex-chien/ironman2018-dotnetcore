using System;

namespace ironman2018.Models.Environments
{
    public class DevelopmentEnvironmentsService : IEnvironmentsService
    {
        public string GetEnvironmentName()
        {
            return "Development";
        }
    }
}