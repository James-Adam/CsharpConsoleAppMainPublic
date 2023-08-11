using System.Diagnostics.Contracts;

namespace AuthenticatedSchoolSystem.Back_End.LogAndTrace
{
    public class CodeContracts
    {
        [PureAttribute]
        public double Divide(double dividend, double divisor)
        {
            Contract.Requires(divisor != 0);
            return dividend / divisor;
        }
    }
}