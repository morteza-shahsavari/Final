using System.ComponentModel.DataAnnotations;

namespace Security.BuessinessServiceContract.BusinessModel.RoleAction
{
    public class RoleActionViewModel
    {
        [Required(ErrorMessage = "Enter Role")]
        public int RoleID { get; set; }
        [Required(ErrorMessage = "Enter Controller And Actions")]
        public int ProjectControllerID { get; set; }
        [Required(ErrorMessage = "EnterController And Actions")]
        public int ProjectActionID { get; set; }
        public bool HasPermission { get; set; }
    }
}
