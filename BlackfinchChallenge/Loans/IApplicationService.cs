using System;
namespace BlackfinchChallenge.Loans
{
    public interface IApplicationService
    {
        IReadOnlyCollection<Application> GetAll();

        void Add(Application application);
    }
}

