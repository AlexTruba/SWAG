namespace SWAG.Operation
{ 
    using System.Threading.Tasks;

    public interface IOperation
    {
        Task<double> Calc(double left, double right);
    }
}
