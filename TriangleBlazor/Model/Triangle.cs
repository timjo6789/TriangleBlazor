namespace TriangleBlazor.Model
{
    public class Triangle
    {
        public int SideA;
        public int SideB;
        public int SideC;

        public Triangle(int sideA = 0, int sideB = 0, int sideC = 0)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
        public bool IsValid()
        {
            // verify combinations of each side
            bool AB_C = ValidateSides(SideA, SideB, SideC);
            bool AC_B = ValidateSides(SideC, SideA, SideB);
            bool BC_A = ValidateSides(SideB, SideC, SideA);

            // only return true if all sides are validated
            return AB_C && AC_B && BC_A;
        }

        //public string ClassifyTriangle()
        //{
        //    return "";
        //}

        private bool ValidateSides(int a, int b, int c) => a + b > c;
    }
}
