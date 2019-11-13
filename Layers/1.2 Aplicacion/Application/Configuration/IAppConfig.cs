namespace Coworking.Application.Configuration
{
    public interface IAppConfig
    {
        int MaxTrys { get; }
        int SecondsToWait { get; }
        string ServiceUrl { get; }
    }
}