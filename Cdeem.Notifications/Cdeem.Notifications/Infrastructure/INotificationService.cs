namespace Cdeem.API.Infrastructure
{ 
    public interface INotificationService
    {
        Task Send(IEmailTemplate template);
    }
}
