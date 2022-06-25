namespace TriangleBlazor.Model
{
    public class Triangle
    {
        // sides
        public double SideA;
        public double SideB;
        public double SideC;

        // degrees
        public double AngleA;
        public double AngleB;
        public double AngleC;

        public Triangle(double sideA = 0, double sideB = 0, double sideC = 0)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            CalculateDegrees();
        }

        // general side validation
        public bool IsValid() => IsAB_C() && IsAC_B() && IsBC_A();

        // break down to allow specific side errors for index page
        public bool IsAB_C() => ValidateSides(SideA, SideB, SideC);
        public bool IsAC_B() => ValidateSides(SideC, SideA, SideB);
        public bool IsBC_A() => ValidateSides(SideB, SideC, SideA);

        // use math to validate a side
        private bool ValidateSides(double A, double B, double C) => A + B > C;


        // generate a description for an angle
        public string CurrentAngleType()
        {
            // order the sides so that longest is always last
            List<double> Sides = new() { SideA * SideA, SideB * SideB, SideC * SideC };
            Sides.Sort();

            // pre calculation
            double ShortSum = Sides[0] + Sides[1];
            double longestSide = Sides[2];

            // check what type of angle is it
            if (ShortSum == longestSide)
                return "Right";
            else if (ShortSum > longestSide)
                return "Acute";
            else
                return "Obtuse";
        }

        // once validated, create degrees
        public void CalculateDegrees()
        {
            if(IsValid())
            {
                AngleA = ToDegree(SideB, SideC, SideA);
                AngleB = ToDegree(SideA, SideC, SideB);
                AngleC = ToDegree(SideA, SideB, SideC);
            }
            else
            {
                // if submit button clicks and fails validation, reset to 0
                AngleA = 0;
                AngleB = 0;
                AngleC = 0;
            }
        }
        
        private double ToDegree(double A, double B, double C) => Math.Round(Math.Acos( (A * A + B * B - C * C) / (2 * A * B) ) * (180d / Math.PI), 2);

        public string CurrentSideType()
        {
            if (IsEquilateral())
                return "Equilateral";
            else if (IsIsosceles())
                return "Isosceles";
            else
                return "Scalene";
        }


        // boolean helpers to maintain flexibility and readability
        private bool IsEquilateral() => SideA == SideB && SideB == SideC;
        private bool IsIsosceles() => SideA == SideB || SideA == SideC || SideB == SideC;
    }
}
