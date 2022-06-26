using System;
namespace BlackfinchChallenge.Loans
{
    public class ApplicantionsView
    {
        private readonly IApplicationService _applicationService;

        public ApplicantionsView(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public void ViewMetrics()
        {
            var applications = _applicationService.GetAll();

            
        }
    }
}

