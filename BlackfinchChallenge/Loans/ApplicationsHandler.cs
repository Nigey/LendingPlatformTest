using System;
namespace BlackfinchChallenge.Loans
{
    public class ApplicationsHandler
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public void Apply(Application application)
        {
            if (!LoanWithinStaticThreshold(application.Value))
            {
                application.Decline();
                _applicationService.Add(application);
                return;
            }

            if (IsLoanBeyondLtvThreshold(application.Value, application.Ltv))
            {
                if(application.Ltv > 60)
                {
                    Decline(application);
                    return;
                }

                if(application.CreditScore < 950)
                {
                    Decline(application);
                    return;
                }
            }
            else
            {
                Decline(application);
                return;
            }

            Accept(application);
        }

        private bool LoanWithinStaticThreshold(decimal amount)
        {
            return amount >= 100000 && amount <= 1500000;
        }

        private bool IsLoanBeyondLtvThreshold(decimal amount, decimal ltv)
        {
            return (amount - ltv) > 1000000;
        }

        private void Accept(Application application)
        {
            application.Accept();
            _applicationService.Add(application);
        }

        private void Decline(Application application)
        {
            application.Decline();
            _applicationService.Add(application);
        }
    }
}

