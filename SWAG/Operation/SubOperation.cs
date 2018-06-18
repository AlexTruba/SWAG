namespace SWAG.Operation
{
    using System.Threading.Tasks;

    public class SubOperation: IOperation
    {
        public Task<double> Calc(double left, double right)
        {
            return Task.Run(() =>
            {
                return left - right;
            });
        }
    }
}
