using CloudPMS.Commands.OA.Users;
using CloudPMS.Web.Models;
using ECommon.Components;
using ECommon.IO;
using ECommon.Utilities;
using ENode.Commanding;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CloudPMS.Web.Controllers
{
    public class UsersController : ApiController
    {

        private readonly ICommandService _commandService;

        public UsersController()
        {
            _commandService = ObjectContainer.Resolve<ICommandService>();
        }
 
        public async Task<IHttpActionResult> Create(CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = "<div class=\"validation-summary-errors\">发生以下错误：<ul>";
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        errorMessage += "<li class=\"field-validation-error\">" + error.ErrorMessage + "</li>";
                    }
                }
                errorMessage += "</ul>";
                return Json(new { success = false, errorMsg = errorMessage });
            }
            var result = await _commandService.ExecuteAsync(
             new CreateUserCommand(
                 ObjectId.GenerateNewStringId(),
                 model.UserName));
            if (result.Status != AsyncTaskStatus.Success)
            {
                return Json(new { success = false, errorMsg = result.ErrorMessage });
            }
            var commandResult = result.Data;
            if (commandResult.Status == CommandStatus.Failed)
            {
                return Json(new { success = false, errorMsg = commandResult.Result });
            }

            return Json(new { success = true });
        }


    }
}