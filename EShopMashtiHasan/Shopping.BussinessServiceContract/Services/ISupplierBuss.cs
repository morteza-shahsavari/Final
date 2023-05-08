
using Framework.BaseModel;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Shopping.BusinessServiceContract.Services
{
   public interface ISupplierBuss
   {
       OperationResult Delete(int id);
       OperationResult Update(SupplierAddEditModel current);
       OperationResult AddNew(SupplierAddEditModel current);
       SupplierAddEditModel Get(int id);
       List<Supplier> GetAll();
       List<SupplierListItem> Search(SupplierSearchModel sm, out int RecordCount);
       Task<List<Supplier>> TestAsync();

    }
}
