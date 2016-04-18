using CloudPMS.Commands.OA.Users;
using ECommon.Components;
using ECommon.IO;
using ECommon.Utilities;
using ENode.Commanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudPMS.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            var commandService = ObjectContainer.Resolve<ICommandService>();
          


            var result = await  commandService.ExecuteAsync(
              new CreateUserCommand(
                  ObjectId.GenerateNewStringId(),
                  "2332"));

            if (result.Status != AsyncTaskStatus.Success)
            {
                
            }
            var commandResult = result.Data;
            if (commandResult.Status == CommandStatus.Failed)
            {
                
            }
        }
    }
}