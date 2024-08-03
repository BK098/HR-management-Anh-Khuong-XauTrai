namespace HR_management.Domain.Commons.Interfaces
{
    public interface IAuditBase<T> : IUserTracking, IDateTracking
    {
        T Id { get; set; }
    }
}
