using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CI_Gwap
{
    public partial class PresentationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "../images/presentationImage1.jpg";
            Image2.ImageUrl = "../images/cSharpTechnicalArchitecture.png";
            Image3.ImageUrl = "../images/challenge.jpg";
            Image4.ImageUrl = "../images/challenge2.png";
        }
    }
}