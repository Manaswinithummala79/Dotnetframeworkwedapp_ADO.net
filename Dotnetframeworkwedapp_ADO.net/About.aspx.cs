﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dotnetframeworkwedapp_ADO.net
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int currentUsers = (int)HttpContext.Current.Application["TotalUsers"];
            lblTotalCount.Text = currentUsers.ToString();
        }
    }
}