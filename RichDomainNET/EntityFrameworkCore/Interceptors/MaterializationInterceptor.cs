using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using RichDomainNET.Abstractions;

namespace RichDomainNET.EntityFrameworkCore.Interceptors
{
    public class MaterializationInterceptor : IMaterializationInterceptor
    {
        public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
        {
            if (instance is RichDomainModel)
            {
                var convertedInstance = (RichDomainModel)instance;
                convertedInstance.SetContext(materializationData.Context.Database.GetDbConnection());
                return convertedInstance;
            }

            return instance;
        }
    }
}
