namespace SWAG.OperationFactory
{
    using SWAG.Operation;

    public interface IOperationFactory
    {
        IOperation GetOperation(string name);
    }
}
