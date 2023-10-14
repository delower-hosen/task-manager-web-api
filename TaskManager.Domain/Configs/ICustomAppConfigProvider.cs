namespace TaskManager.Domain.Configs
{
    public interface ICustomAppConfigProvider
    {
        string GetJwtTokenSecret();
    }
}
