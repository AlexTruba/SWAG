namespace SWAG.SaveService
{
    using System;
    using System.Threading.Tasks;

    public interface ISaveProvider
    {
        Task<Guid> Save(OperationDTO data);
        double? GetResult(Guid id);
    }
}
