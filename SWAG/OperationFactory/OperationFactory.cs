namespace SWAG.OperationFactory
{
    using SWAG.Operation;
    public class OperationFactory: IOperationFactory
    {
        public IOperation GetOperation(string name)
        {
            IOperation operation = GetOperationByName(name);

            return operation;
        }

        private IOperation GetOperationByName(string name)
        {
            IOperation operation = null; 
            switch (name)
            {
                case "+":
                    operation = new AddOperation();
                    break;
                case "-":
                    operation = new SubOperation();
                    break;
                case "*":
                    operation = new MultiOperation();
                    break;
                case "/":
                    operation = new DivisionOperation();
                    break;
                case "^":
                    operation = new ExpOperation();
                    break;
                default:
                    break;
            }

            return operation;
        }
    }
}
