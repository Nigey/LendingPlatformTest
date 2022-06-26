using System;
namespace BlackfinchChallenge.Loans
{
    public class ApplicationService : IApplicationService
    {
        private readonly List<Application> _applications;

        public ApplicationService()
        {
            this._applications = new List<Application>();
        }

        public IReadOnlyCollection<Application> GetAll()
        {
            return _applications;
        }

        public void Add(Application application)
        {
            if (!_applications.Contains(application))
            {
                _applications.Add(application);
            }
        }
    }
}

