using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace SocialNetwork.SignalRChatHub
{
    public interface INotifyHubClient
    {
        Task AddNewPostToNews(PostDto post);
    }
}