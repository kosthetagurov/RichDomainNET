using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichDomainNET.Abstractions
{
    public abstract class AdvancedRichDomainModel<T> : RichDomainModel
        where T : RichViewModel, new()
    {
        public T AsViewModel()
        {
            var model = new T();

            model.SetContext(RichDomainModelContext, EntityId);
            model.Initialize();

            return model;
        }
    }
}
