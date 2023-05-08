using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServiceContract.Services;
using Shopping.DomainModel.DTO.Supplier;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.Models;

namespace Shopping.DataAccess.Repositories
{
   public class SupplierRepository:ISupplierRepository
   {
        #region Filds
       
        private readonly EshopMashtiHasanContext db;
        #endregion

        #region Ctor
        public SupplierRepository(EshopMashtiHasanContext db)
       {
           this.db = db;
       }


        #endregion

        #region Events
        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete",id);
            var sup = db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
            if (sup==null)
            {
                return op.Failed("Supplier ID no Exist", id);
            }

            
            try
            {
                db.Suppliers.Remove(sup);
                db.Suppliers.Remove(sup);

                db.SaveChanges();
                return op.Succeed("Supplier Deleted Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("Supplier Fialed " + ex.Message, id);
            }
        }

        public OperationResult Update(Supplier current)
        {
            OperationResult op = new OperationResult("Update",current.SupplierID);
            try
            {
                db.Suppliers.Attach(current);
                db.Entry(current).State = EntityState.Modified;
                //var sup = db.Suppliers.FirstOrDefault(x => x.SupplierID == current.SupplierID);
                //sup.SupplierName = current.SupplierName;
                //sup.Tel = current.Tel;
                //sup.Address = current.Address;
                //sup.Mobile=current.Mobile;

                db.SaveChanges();
                return op.Succeed("Update Successfully", current.SupplierID);
            }
            catch (Exception e)
            {
                return op.Failed("Update Failed ", current.SupplierID);
            }

        }

        public OperationResult AddNew(Supplier current)
        {
            OperationResult op = new OperationResult("Add New Supplier");
            try
            {
                db.Suppliers.Add(current);
                db.SaveChanges();
                return op.Succeed("Supplier Added Successfully", current.SupplierID);
            }
            catch (Exception ex)
            {
                return op.Failed("Supplier Add Failed " + ex.Message, null);
            }
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public SupplierComplexResult Search(SupplierSearchModel sm, out int RecordCount)
        {
            try
            {
                var Suppliers = from item in db.Suppliers select item;
                if (!string.IsNullOrEmpty(sm.SupplierName))
                {
                    Suppliers = Suppliers.Where(x => x.SupplierName.StartsWith(sm.SupplierName));
                }
                if (!string.IsNullOrEmpty(sm.Mobile))
                {
                    Suppliers = Suppliers.Where(x => x.Mobile.StartsWith(sm.Mobile));
                }
                if (!string.IsNullOrEmpty(sm.Tel))
                {
                    Suppliers = Suppliers.Where(x => x.Tel.StartsWith(sm.Tel));
                }

                var q = from item in Suppliers
                    select new SupplierListItem
                    {
                        SupplierID = item.SupplierID
                        ,Tel = item.Tel
                        ,Mobile = item.Mobile
                        ,SupplierName = item.SupplierName
                        ,ProductCount = item.Products.Count
                    };
                RecordCount = q.Count();
                var r =  q.OrderByDescending(x=>x.SupplierID).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
                return new SupplierComplexResult
                {
                    MainResults = r,Errors = null
                };
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add("خطا در بازیابی" +  ex.Message);
                RecordCount = 0;
                return new SupplierComplexResult
                {
                    MainResults = null,
                    Errors = errors
                };
            }

        }

        public bool HasRelatedProduct(int id)
        {
            return db.Products.Any(x => x.SupplierID == id);
        }

        public bool HasDuplicateName(string Name)
        {
            return db.Suppliers.Any(x => x.SupplierName == Name);
        }

        public bool CheckSupplierNameExistForOtherID(int id, string SupplierName)
        {
            return db.Suppliers.Any(x => x.SupplierID != id && x.SupplierName == SupplierName);
        }

        public async Task<List<Supplier>> TestAsync()
        {
            var rs = await db.Suppliers.ToListAsync();
            return rs;
        }
        #endregion
    }
}
