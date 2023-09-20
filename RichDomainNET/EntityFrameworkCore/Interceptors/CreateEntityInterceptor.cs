using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichDomainNET.Abstractions;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace RichDomainNET.EntityFrameworkCore.Interceptors
{
    public class CreateEntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            SetContextToRichModels(eventData);

            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            SetContextToRichModels(eventData);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void SetContextToRichModels(DbContextEventData eventData)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added && entry.Entity is RichDomainModel model)
                {
                    model.SetContext(eventData.Context.Database.GetDbConnection());
                }
            }
        }
    }
}
