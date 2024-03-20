using Microsoft.EntityFrameworkCore;

using RichDomainNET.Abstractions;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RichDomainNET.EntityFrameworkCore.RichCollections
{
    public abstract class EfRichDomainModelCollection<TContext, TModel> : IEnumerable<TModel>, IEnumerator<TModel>
        where TContext : DbContext, new()
        where TModel : EfRichDomainModel<TContext>
    {       
        public EfRichDomainModelCollection(TContext dbContext, Func<TModel, bool> filter = null)
        {
            Context = dbContext;

            elements = new Lazy<TModel[]>(() =>
            {
                return GetData(filter);
            });
        }

        #region Private properties

        protected readonly TContext Context;
        Lazy<TModel[]> elements;
        int position = -1;
        object IEnumerator.Current { get => elements.Value[position]; }

        #endregion

        #region Public properties

        public TModel this[int index]
        {
            get => elements.Value[index];
            set => elements.Value[index] = value;
        }

        public TModel Current { get => ((IEnumerator)this).Current as TModel; }

        #endregion

        #region Public methods

        public virtual void Insert(TModel model)
        {
            Context.Set<TModel>().Add(model);
            Context.SaveChanges();

            elements = new Lazy<TModel[]>(() =>
            {
                return GetData();
            });
        }

        public virtual void Insert(params TModel[] models)
        {
            Context.Set<TModel>().AddRange(models);
            Context.SaveChanges();

            elements = new Lazy<TModel[]>(() =>
            {
                return GetData();
            });
        }

        public virtual void Remove(TModel model)
        {
            Context.Set<TModel>().Remove(model);
            Context.SaveChanges();

            elements = new Lazy<TModel[]>(() =>
            {
                return GetData();
            });
        }

        public virtual void RemoveAll(Func<TModel, bool> filter = null)
        {            
            var elementsToRemove = filter == null ? elements.Value.ToArray() : elements.Value.Where(filter).ToArray();
            var set = Context.Set<TModel>();
            set.RemoveRange(elementsToRemove);            
            Context.SaveChanges();

            elements = new Lazy<TModel[]>(() =>
            {
                return GetData();
            });
        }

        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();            
        }

        public IEnumerator<TModel> GetEnumerator()
        {
            return this;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(elements.Value);
        }

        #endregion

        #region Private methods

        bool IEnumerator.MoveNext()
        {
            if (position < elements.Value.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                ((IEnumerator)this).Reset();
                return false;
            }
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        TModel[] GetData(Func<TModel, bool> filter = null)
        {
            var set = Context.Set<TModel>();
            TModel[] data = filter == null ? set.ToArray() : set.Where(filter).ToArray();            
            return data;
        }

        #endregion
    }
}
