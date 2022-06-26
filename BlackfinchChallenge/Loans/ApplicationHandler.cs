using System;
namespace BlackfinchChallenge.Loans
{
    public class ApplicationHandler
    {
        private readonly IApplicationService _applicationService;

        public ApplicationHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public bool Apply(Application application)
        {
            if (!LoanWithinStaticThreshold(application.Value))
            {
                application.Decline();
                _applicationService.Add(application);
                return false;
            }

            return true;
        }

        private bool LoanWithinStaticThreshold(decimal amount)
        {
            return amount >= 100000 && amount <= 1500000;
        }

        private bool IsCreditValidByValue()
        {
            return false;
        }
    }
}

