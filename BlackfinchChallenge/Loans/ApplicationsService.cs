using System;
namespace BlackfinchChallenge.Loans
{
    public class ApplicationsService : IApplicationService
    {
        private List<Application> applications;

        public ApplicationsService()
        {
            this.applications = new List<Application>();
        }

        public IReadOnlyCollection<Application> GetAll()
        {
            return applications;
        }

        public void Add(Application application)
        {
            if (!applications.Contains(application))
            {
                applications.Add(application);
            }
        }
    }
}

