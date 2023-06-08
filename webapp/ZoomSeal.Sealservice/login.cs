using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ZoomSeal.Sealservice;

public class login : Page
{
	protected HtmlHead Head1;

	protected HtmlForm form1;

	protected Label Label1;

	protected TextBox txtUserName;

	protected Label Label2;

	protected TextBox txtUserPw;

	protected Button btnLogin;

	protected Button btnCancel;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnLogin_Click(object sender, EventArgs e)
	{
		string Errmsg = "";
		if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtUserPw.Text))
		{
			Errmsg = "请输入用户名和密码！";
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('" + Errmsg + "');</script>");
		}
		else if (!txtUserName.Text.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) || !txtUserPw.Text.Trim().Equals("111111", StringComparison.OrdinalIgnoreCase))
		{
			Errmsg = "用户名或密码错误！";
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('" + Errmsg + "');</script>");
		}
		else
		{
			Session["userName"] = txtUserName.Text.Trim();
			Session["userPw"] = txtUserPw.Text.Trim();
			base.Response.Redirect("seal.aspx");
		}
	}
}
