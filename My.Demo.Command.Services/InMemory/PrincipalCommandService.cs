using My.Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Demo.Command.Services.InMemory
{
    public class PrincipalCommandService : IPrincipalCommandService
    {
        public Task<Principal> Create(Principal model)
        {
            model.Id = InMemoryData.Principals.Max(p => p.Id) + 1;
            InMemoryData.Principals.Add(model);
            return Task.FromResult(model);
        }

        public Task<Principal> Delete(int id)
        {
            var participant = InMemoryData.Principals.SingleOrDefault(m => m.Id == id);
            if (participant == null)
            {
                return null;
            }
            else
            {
                InMemoryData.Principals.Remove(participant);
                return Task.FromResult(participant);
            }
        }

        public Task<Principal> Update(Principal model)
        {
            if (model == null)
            {
                return null;
            }
            var participant = InMemoryData.Principals.SingleOrDefault(p => p.Id == model.Id);
            if (participant == null)
            {
                return null;
            }
            else
            {
                participant.Name = model.Name;
                participant.ImageUrl = model.ImageUrl;
                return Task.FromResult(participant);
            }
        }
    }
}
