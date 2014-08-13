using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.BasicContract
{
    /// <summary>
    /// Zdefinniowane sa tu podstawowe atrybuty kazdej encji
    /// </summary>
    /// <typeparam name="TKey">Okresla typ klucza. Np. int, long, guid</typeparam>
    public abstract class BaseEntity<TKey>
    {
        public virtual TKey Id { get; set; }
        public virtual byte DataState { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime EditDate { get; set; }

        public BaseEntity()
        {
            this.CreateDate = DateTime.Now;
            this.DataState = 1;
        }
    }
}
