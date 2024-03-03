namespace VehicleConfigurator02.DbRepos
{
    public class SubCompPrice
    {
      
            private string subType;
            private double deltaPrice;
            private int altId;

            public SubCompPrice(string subType, double deltaPrice, int altId)
            {
                this.subType = subType;
                this.deltaPrice = deltaPrice;
                this.altId = altId;
            }

            public string SubType
            {
                get { return subType; }
                set { subType = value; }
            }

            public double DeltaPrice
            {
                get { return deltaPrice; }
                set { deltaPrice = value; }
            }

            public int AltId
            {
                get { return altId; }
                set { altId = value; }
            }
        
    }

}

