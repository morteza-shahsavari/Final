using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.KeyWord;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace shopping.Buessiness.Impelements
{
    public class KeyWordBuss : IKeyWordBuss
    {
        #region Fields
        private readonly IKeyWordsRepository repo;
        #endregion

        #region Ctor
        public KeyWordBuss(IKeyWordsRepository repo)
        {
            this.repo = repo;
        }
        #endregion

        #region Events
        public OperationResult AddNew(KeyWord current)
        {
            if (repo.ExitsKeyWordText(current.KeyWordText))
            {
                return new OperationResult("Register KeyWord")
                      .Failed("KeyWordText Already Exist");
            }
            return repo.AddNew(current);
        }

        public OperationResult Delete(int id)
        {
            return repo.Delete(id);
        }

        public KeyWord Get(int id)
        {
            return repo.Get(id);
        }

        public List<KeyWord> GetAll()
        {
            return repo.GetAll();
        }

        public List<KeyWord> Search(KeyWordSearchModel sm, out int RecordCount)
        {
            return repo.Search(sm, out RecordCount);
        }

        public List<KeyWord> SearchKeywordName(string search)
        {
            return repo.SearchKeywordName(search);
        }

        public OperationResult Update(KeyWord current)
        {

            if (repo.ExitsKeyWordText(current.KeyWordText,current.KeyWordID))
            {
                return new OperationResult("Update KeyWord")
                      .Failed("KeyWordText Already Exist");
            }
            return  repo.Update(current);
        }
        #endregion
    }
}
