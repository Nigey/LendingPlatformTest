using BlackfinchChallenge.Loans;

class Program
{
    static void Main(string[] args)
    {
        var applicationService = new ApplicationService();
        var applicationHandler = new ApplicationsHandler(applicationService);

        applicationHandler.Apply(new Application(500000, 500000, 500)); // Should fail
        applicationHandler.Apply(new Application(500000, 500000, 500)); // Should pass
        applicationHandler.Apply(new Application(1600000, 500000, 500)); // Should fail
        applicationHandler.Apply(new Application(1500000, 500000, 500)); // Should pass

        Console.WriteLine(applicationService.GetAll().First().Successfull);
    }
}
