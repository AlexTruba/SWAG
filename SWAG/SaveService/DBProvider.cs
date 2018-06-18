namespace SWAG.SaveService
{
    using SWAG.DB;
    using SWAG.DB.Entity;
    using SWAG.OperationFactory;
    using System;
    using System.Threading.Tasks;

    public class DBProvider : ISaveProvider
    {
        IDBRepository _dBRepository;
        public IOperationFactory _operationFactory;

        public DBProvider(IDBRepository dBRepository, IOperationFactory operationFactory)
        {
            _dBRepository = dBRepository;
            _operationFactory = operationFactory;
        }
        public double? GetResult(Guid id)
        {
            return _dBRepository.FindResultById(id);
        }

        public async Task<Guid> Save(OperationDTO data)
        {
            var operationService = _operationFactory.GetOperation(data.Operation);
            var result = await operationService.Calc(data.Right, data.Left);
            var id = SaveToStorage(result);
            return id;
        }
        private Guid SaveToStorage(double value)
        {
            Result result = new Result
            {
                Id = Guid.NewGuid(),
                CreateAt = DateTimeOffset.Now,
                Value = value
            };

            _dBRepository.SaveResult(result);

            return result.Id;
        }
    }
}
