using BlackfinchChallenge.Loans;

class Program
{
    static void Main(string[] args)
    {
        var applicationService = new ApplicationService();
        var applicationHandler = new ApplicationsHandler(applicationService);
        var applicationsViewer = new ApplicantionsView(applicationService);

        // Affirming logic for basic loan thresholds.
        applicationHandler.Apply(new Application(500000, 500000, 500)); // Should fail
        applicationHandler.Apply(new Application(500000, 500000, 500)); // Should pass
        applicationHandler.Apply(new Application(1600000, 500000, 500)); // Should fail
        applicationHandler.Apply(new Application(1500000, 500000, 500)); // Should pass

        applicationsViewer.ViewMetrics();
    }
}
