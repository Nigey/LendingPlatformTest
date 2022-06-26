using BlackfinchChallenge.Loans;

class Program
{
    static void Main(string[] args)
    {
        var application = new Application(500000, 500000, 500);

        var applicationHandler = new ApplicationHandler(new ApplicationsService());

        applicationHandler.Apply(application);
    }
}
