using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using RichDomainNET.Abstractions;

namespace RichDomainNET.EntityFrameworkCore.Interceptors
{
    public class MaterializationInterceptor : IMaterializationInterceptor
    {
        public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
        {
            if (instance is IRichDomainModel)
            {
                var itemId = GetKey(instance, materializationData.EntityType.ClrType, materializationData.Context);

                var convertedInstance = (RichDomainModel)instance;
                convertedInstance.SetContext(materializationData.Context.Database.GetDbConnection(), itemId);
                return convertedInstance;
            }

            return instance;
        }

        object GetKey(object entity, Type type, DbContext context)
        {
            var elementType = context.Model.FindEntityType(type);
            var keyName = elementType.FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            return entity.GetType().GetProperty(keyName).GetValue(entity, null);
        }
    }
}
