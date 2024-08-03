namespace HR_management.Domain.Commons.Interfaces
{
    public interface IDateTracking
    {
        DateTimeOffset CreatedDate { get; set; }

        DateTimeOffset? LastModifiedDate { get; set; }
    }
}
