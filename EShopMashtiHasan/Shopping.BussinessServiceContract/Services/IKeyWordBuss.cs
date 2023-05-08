using Framework.BaseModel;
using Shopping.DomainModel.DTO.KeyWord;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace Shopping.BusinessServiceContract.Services
{
    public interface IKeyWordBuss
    {
        OperationResult Delete(int id);
        OperationResult Update(KeyWord current);
        OperationResult AddNew(KeyWord current);
        KeyWord Get(int id);
        List<KeyWord> GetAll();
        List<KeyWord> Search(KeyWordSearchModel sm, out int RecordCount);

        public List<KeyWord> SearchKeywordName(string search);
    }
}
