﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace center2015
{
    public partial class signupSuccess : System.Web.UI.Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["id"]!=null)
                {
                Label1.Text = Session["id"].ToString();
                }
            }
        }
    }
}