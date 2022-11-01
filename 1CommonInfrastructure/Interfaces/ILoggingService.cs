namespace _1CommonInfrastructure.Interfaces
{
    public interface ILoggingService
    {
        void WriteLog(string keyArea, string message, object additionalInfo = null, Exception ex = null);
    }
}