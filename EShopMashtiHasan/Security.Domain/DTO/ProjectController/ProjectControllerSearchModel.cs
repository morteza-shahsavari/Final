using Framework.BaseModel;


namespace Security.Domain.DTO.ProjectController
{
    public class ProjectControllerSearchModel:PageModel
    {
        public int? ProjectControllerID { get; set; }
        public string ProjectControllerName { get; set; }
        public int? ProjectAreaID { get; set; }
    }
}
