using System;
namespace BlackfinchChallenge.Loans
{
    public class ApplicationsHandler
    {
        private readonly IApplicationService _applicationService;
        private readonly Dictionary<decimal, int> ltvToCreditScoreRating;

        public ApplicationsHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public void Apply(Application application)
        {
            if (!LoanWithinStaticThreshold(application.Value))
            {
                Decline(application, "Was outside of threshold");
                return;
            }

            if (IsLoanBeyondLtvThreshold(application.Value, application.Ltv))
            {
                if(application.Ltv > 60)
                {
                    Decline(application, "Was above ltv.");
                    return;
                }

                if(application.CreditScore < 950)
                {
                    Decline(application, "Credit score too low.");
                    return;
                }
            }
            else
            {
                if(application.Ltv < 60)
                {
                    if(!ValidateCreditScore(application, 750))
                    {
                        return;
                    }
                }
                else if(application.Ltv < 80)
                {
                    if (!ValidateCreditScore(application, 800))
                    {
                        return;
                    }
                }
                else if (application.Ltv < 90)
                {
                    if (!ValidateCreditScore(application, 900))
                    {
                        return;
                    }
                }
                else
                {
                    Decline(application, $"Ltv of {application.Ltv} is too high.");
                }
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

        private void Decline(Application application, string reason)
        {
            application.Decline(reason);
            _applicationService.Add(application);
        }

        private bool ValidateCreditScore(Application application, int requiredCreditScore)
        {
            if (application.CreditScore < requiredCreditScore)
            {
                Decline(application, $"Credit score of " +
                    $"{requiredCreditScore} was required, but was " +
                    $"{application.CreditScore}.");
                return false;
            }
            return true;
        }
    }
}

