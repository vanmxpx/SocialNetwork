using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SocialNetwork.Repositories;
using SocialNetwork.Repositories.GenericRepository;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.SignalRChatHub
{
    [Authorize]
    public class ConnectionHub : Hub<INotifyHubClient>
    {
        private readonly static ConnectionMapping connectionClients =
            new ConnectionMapping();
        private readonly IUnitOfWork unitOfWork;

        public ConnectionHub(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public override async Task OnConnectedAsync()
        {
            int id = Convert.ToInt32(Context.User.Identity.Name);
            var profileClient = await unitOfWork.ProfileRepository.GetById(id);
            var subscribers = await unitOfWork.ProfileRepository.GetSubscribersById(id);
            var bloggers = await unitOfWork.ProfileRepository.GetBloggersById(id);

            connectionClients.Add(profileClient.Login, Context.ConnectionId);

            foreach (var profile in subscribers)
            {
                if (connectionClients.ClientOnline(profile.Login))
                {
                    var connectionsId = connectionClients.GetConnections(profile.Login);
                    foreach (var connectionId in connectionsId)
                        await Groups.AddToGroupAsync(connectionId, profileClient.Login);
                }
            }

            foreach (var profile in bloggers)
            {
                if (connectionClients.ClientOnline(profile.Login))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, profile.Login);
                }
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            int id = Convert.ToInt32(Context.User.Identity.Name);
            var profileClient = await unitOfWork.ProfileRepository.GetById(id);
            var subscribers = await unitOfWork.ProfileRepository.GetSubscribersById(id);
            var bloggers = await unitOfWork.ProfileRepository.GetBloggersById(id);

            connectionClients.Add(profileClient.Login, Context.ConnectionId);

            foreach (var profile in subscribers)
            {
                if (connectionClients.ClientOnline(profile.Login))
                {
                    var connectionsId = connectionClients.GetConnections(profile.Login);
                    foreach (var connectionId in connectionsId)
                        await Groups.RemoveFromGroupAsync(Context.ConnectionId, profile.Login);
                }
            }

            foreach (var profile in bloggers)
            {
                if (connectionClients.ClientOnline(profile.Login))
                {
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, profile.Login);
                }
            }

            connectionClients.Remove(profileClient.Login, Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}