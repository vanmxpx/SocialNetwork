using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SocialNetwork.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.Services.Cron
{
    public class ProfileRemoveProvider
    {
        int counter = 0;
        private IUnitOfWork unitOfWork;
        public ProfileRemoveProvider(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Do(CancellationToken cancellationToken)
        {
            try
            {
                int i = 0;
                IQueryable<Credential> df = unitOfWork.CredentialRepository.GetAll();
                foreach (var a in df)
                {
                    if (a.DateRegistration == DateTime.MinValue)
                    {
                        unitOfWork.CredentialRepository.Delete(a);            
                        i++;            
                    }
                }
                await unitOfWork.Save();
                Console.WriteLine("Deletions: " + i);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fuck");
            }


        }
    }
}