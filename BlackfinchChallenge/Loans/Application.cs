namespace BlackfinchChallenge.Loans
{
    public class Application
    {
        public decimal Value { get; }
        public decimal AssetValue { get; }
        public decimal Ltv
        {
            get
            {
                var diff = AssetValue - Value;
                return (diff / Value) * 100;
            }
        }

        public int CreditScore { get; }
        public bool Successfull { get; private set; }

        public Application(decimal value, decimal assetValue, int creditScore)
        {
            Value = value;
            AssetValue = assetValue;
            CreditScore = Math.Clamp(creditScore, 1, 999);
        }

        public void Accept()
        {
            Successfull = true;
        }

        public void Decline()
        {
            Successfull = false;
        }
    }
}

