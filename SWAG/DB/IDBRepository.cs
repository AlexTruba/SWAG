namespace SWAG.DB
{
    using SWAG.DB.Entity;
    using System;

    public interface IDBRepository
    {
        void SaveResult(Result item);
        double? FindResultById(Guid id);
    }
}
