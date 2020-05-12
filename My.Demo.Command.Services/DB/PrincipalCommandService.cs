using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using My.Demo.Data;
using My.Demo.Data.Postgres;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace My.Demo.Command.Services.DB
{
    public class PrincipalCommandService : IPrincipalCommandService
    {
        private readonly MovieDbContext db;
        private readonly ILogger<PrincipalCommandService> logger;

        public PrincipalCommandService(MovieDbContext db, ILogger<PrincipalCommandService> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task<Principal> Create(Principal model)
        {
            try
            {
                db.Principals.Add(model);
                await db.SaveChangesAsync();
            }
            catch(PostgresException pe)
            {
                logger.LogError($"[!!!{nameof(Create)}!!!] {pe.Message}");
                return null;
            }
            return model;
        }

        public async Task<Principal> Delete(int id)
        {
            var principal = await db.Principals.FindAsync(id);
            if (principal == null)
            {
                return null;
            }
            else
            {
                try
                {
                    logger.LogInformation($"[{nameof(Delete)}] - Deleting Principal #{id}, {principal.Name}");
                    db.Remove(principal);
                    await db.SaveChangesAsync();
                    return principal;
                }
                catch(PostgresException pe)
                {
                    logger.LogError($"[!!!{nameof(Delete)}!!!] {pe.Message}");
                    return null;
                }
            }
        }

        public async Task<Principal> Update(Principal model)
        {
            if (model == null)
            {
                return null;
            }
            var principal = await db.Principals.FindAsync(model.Id);
            if (principal == null)
            {
                return null;
            }
            else
            {
                try
                {
                    db.Principals.Update(model);
                    await db.SaveChangesAsync();
                    return principal;
                }
                catch (PostgresException pe)
                {
                    logger.LogError($"[!!!{nameof(Update)}!!!] {pe.Message}");
                    return null;
                }
            }
        }
    }
}
