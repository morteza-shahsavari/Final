using DataAccessServiceContract.Services;
using Shopping.DomainModel.DTO.Supplier;
using Framework.BaseModel;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shopping.Buessiness.Impelements
{
    public class SupplierBus : ISupplierBuss
    {
        private SupplierAddEditModel ToAddEditModel(Supplier sup)
        {
            //return new SupplierAddEditModel
            //{

            //    SupplierName = sup.SupplierName
            //    ,
            //    Address = sup.Address
            //    ,
            //    Mobile = sup.Mobile
            //    ,
            //    SupplierID = sup.SupplierID
            //    ,
            //    Tel = sup.Tel
            //};
            var S = new SupplierAddEditModel
            {
                SupplierName = sup.SupplierName
                ,
                Address = sup.Address
                ,
                Mobile = sup.Mobile
                ,
                SupplierID = sup.SupplierID
                ,
                Tel = sup.Tel
            };
            return S;
        }
        private Supplier ToModel(SupplierAddEditModel sup)
        {
            return new Supplier
            {
                SupplierName = sup.SupplierName
                ,
                Address = sup.Address
                ,
                Mobile = sup.Mobile
                ,
                SupplierID = sup.SupplierID
                ,
                Tel = sup.Tel
            };
        }
        private readonly ISupplierRepository repo;
        public SupplierBus(ISupplierRepository _repo)
        {
            this.repo = _repo;
        }   
        public OperationResult AddNew(SupplierAddEditModel current)
        {
            OperationResult op = new OperationResult("Add Supplier");
            if (repo.HasDuplicateName(current.SupplierName))
            {
                return op.Failed("this supplier name already exist",null);
            }

            var sup = ToModel(current);
            return repo.AddNew(sup);

        }

        public OperationResult Delete(int id)
        {
            if (repo.HasRelatedProduct(id))
            {
                return new OperationResult("Delete Supplier").Failed("this Supplier has related product",id);
            }

            return repo.Delete(id);
        }

        public SupplierAddEditModel Get(int id)
        {
            return ToAddEditModel(repo.Get(id));
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public List<SupplierListItem> Search(SupplierSearchModel sm, out int RecordCount)
        {
         
            return repo.Search(sm, out RecordCount).MainResults;
        }

        public async Task<List<Supplier>> TestAsync()
        {
            var rs = await repo.TestAsync();
            return rs;
        }

        public OperationResult Update(SupplierAddEditModel current)
        {
            if (repo.CheckSupplierNameExistForOtherID(current.SupplierID,current.SupplierName))
            {
                return new OperationResult("Update supplier").Failed("Supplier Name already exists",current.SupplierID);
            }
            var sup = ToModel(current);
            return repo.Update(sup);
        }
    }
}
