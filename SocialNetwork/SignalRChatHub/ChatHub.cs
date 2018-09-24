using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.SignalRChatHub
{
    public class ChatHub : Hub<INotifyHubClient>
    {
        private readonly static ConnectionMapping connectionClients =
            new ConnectionMapping();
        private readonly IUnitOfWork unitOfWork;

        public ChatHub(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task AddNewClient(int id)
        {
            var profileClient = await unitOfWork.ProfileRepository.GetById(id);
            var subscribers = await unitOfWork.ProfileRepository.GetSubscribersById(id);

            connectionClients.Add(profileClient.Login, Context.ConnectionId);

            foreach (var profile in subscribers)
            {
                if (connectionClients.ClientOnline(profile.Login))
                {
                    var connectionsId = connectionClients.GetConnections(profile.Login);
                    foreach (var connectionId in connectionsId)
                        await Groups.AddToGroupAsync(connectionId, profileClient.Login);
                    await Groups.AddToGroupAsync(Context.ConnectionId, profile.Login);
                }
            }
        }
        public void DeleteClient(string userName)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, userName);
        }
    }
}