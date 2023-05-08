using Framework.Shopping.Base;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.KeyWord;
using Shopping.DomainModel.Models;
using System.Collections.Generic;


namespace DataAccessServiceContract.Services
{
    public interface IKeyWordsRepository : IBaseRepository<KeyWord, int>
    {
        List<KeyWord> Search(KeyWordSearchModel sm, out int RecordCount);

        List<KeyWord> SearchKeywordName(string search);


        bool ExitsKeyWordText(string KeyWordName);
        bool ExitsKeyWordText(string KeyWordName, int KeyWordID);
    }

}
