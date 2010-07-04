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
            string strBasePath = Request.Url.AbsoluteUri.Replace("KanaDoIT.aspx", "");
            string strSilverlightSouceParam = String.Format
                (
                    "<param name=\"source\" value=\"{0}ClientBin/KanaDoIT.xap?{1}\"/>",
                    strBasePath,
                    versionNumber
                );
            LiteralControl silverlightSouceParam = new LiteralControl(strSilverlightSouceParam);
            SilverlightSouce.Controls.Add(silverlightSouceParam);
        }
    }
}