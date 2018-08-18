namespace SocialNetwork.Configurations
{
    public interface IDatabaseScriptsOption
    {
        bool InitialRemove { get; set; }
        bool IntitialFill { get; set; }
    }
}