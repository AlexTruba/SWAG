using System.Threading.Tasks;

namespace SWAG.Operation
{
    public class AddOperation : IOperation
    {
        public Task<double> Calc(double left, double right)
        {
            return Task.Run(() =>
            {
                return left + right;
            });
        }
    }
}
