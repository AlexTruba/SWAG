using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWAG.Operation
{
    public class DivisionOperation: IOperation
    {
        public Task<double> Calc(double left, double right)
        {
            return Task.Run(() =>
            {
                try
                {
                    return left / right;
                }
                catch (DivideByZeroException e)
                {
                    // TODO logging Error
                    throw e;
                }
                
            });
        }
    }
}
