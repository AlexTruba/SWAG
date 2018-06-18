using SWAG.Operation;
using System;
using Xunit;

namespace SWAG.Tests
{
    public class FactoryTest
    {
        [Fact]
        public void GetAddOperationService_WhenSendAddOperation()
        {
            string operation = "+";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            Assert.NotNull(operService);
            Assert.IsType<AddOperation>(operService);
        }

        [Fact]
        public void GetSubOperationService_WhenSendSubOperation()
        {
            string operation = "-";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            Assert.NotNull(operService);
            Assert.IsType<SubOperation>(operService);
        }
        [Fact]
        public void MultiOperationService_WhenSendSubOperation()
        {
            string operation = "*";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            Assert.NotNull(operService);
            Assert.IsType<MultiOperation>(operService);
        }

        [Fact]
        public void DivisionOperationService_WhenSendSubOperation()
        {
            string operation = "/";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            Assert.NotNull(operService);
            Assert.IsType<DivisionOperation>(operService);
        }
        [Fact]
        public void ExpOperationService_WhenSendSubOperation()
        {
            string operation = "^";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            Assert.NotNull(operService);
            Assert.IsType<ExpOperation>(operService);
        }
        [Fact]
        public void NotFoundService_WhenSendUnknownOperation()
        {
            string operation = "h2";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            Assert.Null(operService);
        }
    }
}
