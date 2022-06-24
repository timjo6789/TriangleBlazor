namespace TriangleBlazor.Model
{
    public class Triangle
    {
        // sides
        public int SideA;
        public int SideB;
        public int SideC;

        // degrees
        public double AngleA;
        public double AngleB;
        public double AngleC;

        public Triangle(int sideA = 0, int sideB = 0, int sideC = 0)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            CalculateDegrees();
        }
        public bool IsValid() => IsAB_C() && IsAC_B() && IsBC_A();

        public bool IsAB_C() => ValidateSides(SideA, SideB, SideC);
        public bool IsAC_B() => ValidateSides(SideC, SideA, SideB);
        public bool IsBC_A() => ValidateSides(SideB, SideC, SideA);

        private bool ValidateSides(int A, int B, int C) => A + B > C;

        public string CurrentAngleType()
        {
            // order the sides so that longest is always last
            List<int> Sides = new() { SideA * SideA, SideB * SideB, SideC * SideC };
            Sides.Sort();

            // pre calculation
            int ShortSum = Sides[0] + Sides[1];
            int longestSide = Sides[2];

            // check what type of angle is it
            if (ShortSum == longestSide)
                return "Right";
            else if (ShortSum > longestSide)
                return "Acute";
            else
                return "Obtuse";
        }

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
