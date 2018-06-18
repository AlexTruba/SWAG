namespace SWAG.Operation
{
    using System.Threading.Tasks;

    public class MultiOperation: IOperation
    {
        public Task<double> Calc(double left, double right)
        {
            return Task.Run(() =>
            {
                return left * right;
            });
        }
    }
}
