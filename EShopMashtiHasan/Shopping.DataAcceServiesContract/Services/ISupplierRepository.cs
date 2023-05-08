using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Shopping.Base;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;

namespace DataAccessServiceContract.Services
{
   public interface ISupplierRepository:IBaseRepositorySearchable<Supplier,int,SupplierSearchModel,SupplierComplexResult>
   {
       bool HasRelatedProduct(int id);
       bool HasDuplicateName(string Name);
       bool CheckSupplierNameExistForOtherID(int id, string SupplierName);
       Task<List<Supplier>> TestAsync();
   }
}
