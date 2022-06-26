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

            for(int i=0; i < applications.Count; i++)
            {
                var application = applications.ElementAt(i);
                Console.WriteLine($"Application {i}: Accepted={application.Successfull}, Reason:{application.Reason}");
            }
        }
    }
}

