using System;
namespace BlackfinchChallenge.Loans
{
    public class Application
    {
        public decimal Value { get; }
        public decimal AssetValue { get; }
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

