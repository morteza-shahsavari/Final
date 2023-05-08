using Framework.BaseModel;
using System.Collections.Generic;


namespace Framework.Shopping.Base
{
   public interface IBaseRepository<TModel,Tkey>
   {
       OperationResult Delete(Tkey id);
       OperationResult Update(TModel current);
       OperationResult AddNew(TModel current);
       TModel Get(Tkey id);
       List<TModel> GetAll();
   }
}
