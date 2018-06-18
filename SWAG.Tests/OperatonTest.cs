using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SWAG.Tests
{
    public class OperatonTest
    {
        [Theory]
        [InlineData(5, 1, 6)]
        [InlineData(7, 1, 8)]
        [InlineData(7.02, -0.544, 6.476)]
        public async Task GetCorrectResult_AddOperation(double left, double right, double result)
        {
            string operation = "+";
            
            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            var operRes = await operService.Calc(left, right);

            Assert.Equal(operRes, result,5);
        }

        [Theory]
        [InlineData(5, 1, 4)]
        [InlineData(7, 1, 6)]
        [InlineData(7.02, 0.544, 6.476)]
        public async Task GetCorrectResult_SubOperation(double left, double right, double result)
        {
            string operation = "-";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);
            var operRes = await operService.Calc(left, right);

            Assert.Equal(operRes, result,5);
        }

        [Theory]
        [InlineData(5, 1, 5)]
        [InlineData(7, 4, 28)]
        public async Task GetCorrectResult_MultiOperation(double left, double right, double result)
        {
            string operation = "*";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);
            var operRes = await operService.Calc(left, right);

            Assert.Equal(operRes, result,5);
        }

        [Theory]
        [InlineData(5, 1, 5)]
        [InlineData(8, 4, 2)]
        public async Task GetCorrectResult_DivisionOperation(double left, double right, double result)
        {
            string operation = "/";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);
            var operRes = await operService.Calc(left, right);

            Assert.Equal(operRes, result,5);
        }

        [Theory]
        [InlineData(5, 1, 5)]
        [InlineData(8, 2, 64)]
        [InlineData(8, 0, 1)]
        public async Task GetCorrectResult_ExpOperation(double left, double right, double result)
        {
            string operation = "^";

            var factory = new OperationFactory.OperationFactory();
            var operService = factory.GetOperation(operation);

            var operRes = await operService.Calc(left, right);

            Assert.Equal(operRes, result,5);
        }
    }
}
