namespace HR_management.Domain.Commons.Interfaces
{
    public interface IUserTracking
    {
        DateTimeOffset CreatedBy { get; set; }

        DateTimeOffset? LastModifiedBy { get; set; }
    }
}
