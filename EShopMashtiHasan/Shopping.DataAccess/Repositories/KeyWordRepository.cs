using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.DTO.KeyWord;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DataAccess.Repositories
{
    public class KeyWordRepository : IKeyWordsRepository
    {

        #region Fields

        private readonly EshopMashtiHasanContext db;

        #endregion

        #region Ctor
        public KeyWordRepository(EshopMashtiHasanContext db)
        {
            this.db = db; 
        }
        #endregion

        #region Events
        public OperationResult AddNew(KeyWord current)
        {
            OperationResult op = new OperationResult("Add KeyWord");
            try
            {
                db.KeyWords.Add(current);
                db.SaveChanges();
                return op.Succeed("Add Successfully", current.KeyWordID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.KeyWordID);
            }
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete Keyword", id);
            var p = db.KeyWords.FirstOrDefault(x => x.KeyWordID == id);
            if (p == null)
                return op.Failed("KeyWordID does not Exist", id);
            try
            {
                db.KeyWords.Remove(p);
                db.SaveChanges();
                return op.Succeed("Delete Successfully", id);
            }
            catch (Exception ex)
            {
                return op.Failed("delete failed " + ex.Message, id);
            }
        }

        public bool ExitsKeyWordText(string KeyWordName)
        {
            return db.KeyWords.Any(x => x.KeyWordText == KeyWordName);
        }

        public bool ExitsKeyWordText(string KeyWordName, int KeyWordID)
        {
            return db.KeyWords.Any(x => x.KeyWordText == KeyWordName&&x.KeyWordID==KeyWordID);
        }

        public KeyWord Get(int id)
        {
            return db.KeyWords.FirstOrDefault(x => x.KeyWordID == id);
        }

        public List<KeyWord> GetAll()
        {
           return db.KeyWords.ToList();
        }

        public List<KeyWord> Search(KeyWordSearchModel sm, out int RecordCount)
        {

            var q = from item in db.KeyWords select item;
            if (!string.IsNullOrEmpty(sm.KeyWordText))
            {
                q = q.Where(x => x.KeyWordText.StartsWith(sm.KeyWordText));
            }

            RecordCount = q.Count();
            return q.OrderByDescending(x => x.KeyWordID).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
        }

        public List<KeyWord> SearchKeywordName(string search)
        {
            var q = from item in db.KeyWords select item;
            if (!string.IsNullOrEmpty(search))
            {

                q = q.Where(x => x.KeyWordText.Contains(search));
                return q.ToList();
            }

            else return q.ToList();
        }

        public OperationResult Update(KeyWord current)
        {
            OperationResult op = new OperationResult("Update KeyWord", current.KeyWordID);
            try
            {
                db.KeyWords.Attach(current);
                db.Entry(current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Successfully", current.KeyWordID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, current.KeyWordID);
            }
        }
        #endregion
    }
}
