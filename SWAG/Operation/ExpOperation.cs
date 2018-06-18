namespace SWAG.Operation
{
    using System.Threading.Tasks;
    using static System.Math;

    public class ExpOperation: IOperation
    {
        public Task<double> Calc(double left, double right)
        {
            return Task.Run(() =>
            {
                try
                {
                    return Pow(left, right);
                }
                catch (System.Exception e)
                {

                    throw e;
                }
                
            });
        }
    }
}
