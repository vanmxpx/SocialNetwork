using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace SocialNetwork.SignalRChatHub
{
    public interface INotifyHubClient
    {
        Task SendPost(PostDto post);
        Task ReceivePost(PostDto post);
        Task OnConnectedAsync();
        Task OnDisconnectedAsync();
    }
}