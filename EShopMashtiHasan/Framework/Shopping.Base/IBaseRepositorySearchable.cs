using System.Collections.Generic;

namespace Framework.Shopping.Base
{
    public interface IBaseRepositorySearchable<TModel, Tkey, TSearchModel, TSearchResult> : IBaseRepository<TModel, Tkey>
    {
        TSearchResult Search(TSearchModel sm, out int RecordCount);
    }
}
