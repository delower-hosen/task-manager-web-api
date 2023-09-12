namespace TaskManager.Infrastructure.DatabaseSettings
{
    public interface IDatabaseSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
