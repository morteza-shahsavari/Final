

namespace Framework.BaseModel
{
   public interface IComplexObjectResult<TModel,TErrorList>
   {
        TModel MainResults { set; get; }
        TErrorList Errors { get; set; }
   }
}
