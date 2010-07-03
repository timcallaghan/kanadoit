using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace KanaDoIT.Web
{
    public partial class KanaDoIT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var versionNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            SourceParam.Attributes["value"] += "?" + versionNumber;
        }
    }
}