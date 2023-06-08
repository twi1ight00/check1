using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PageOffice.ZoomSeal;

namespace ZoomSeal.Sealservice;

public class seal : Page
{
	protected bool flg = true;

	protected HtmlHead Head1;

	protected HtmlForm form1;

	protected Label lblUserName;

	protected Label lblNowTime;

	protected LinkButton LinkButton1;

	protected GridView GridView1;

	protected Image Image1;

	protected TextBox txtSealName;

	protected TextBox txtSignerName;

	protected DropDownList dropSealType;

	protected Button btnAddSeal;

	protected FileUpload FileUpload1;

	protected Button btnAddPic;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["userName"] == null || Session["userName"].ToString() == "" || Session["userPw"] == null || Session["userPw"].ToString() == "")
		{
			base.Response.Redirect("login.aspx");
		}
		lblUserName.Text = Session["userName"].ToString();
		lblNowTime.Text = DateTime.Now.ToString("yyyy/MM/dd");
		if (!base.IsPostBack)
		{
			SealManager sealMg = new SealManager(base.Server.MapPath("."));
			sealMg.DBConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=|DataDirectory|seal.mdb";
			if (((List<Seal>)(object)sealMg.GetQueryCollection("")).Count > 0)
			{
				flg = true;
				ShowList(sealMg);
			}
			else
			{
				flg = false;
				base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowDelAll();</script>");
			}
		}
	}

	private void ShowList(SealManager sealMg)
	{
		GridView1.AutoGenerateColumns = false;
		GridView1.DataSource = sealMg.GetQueryCollection(" order by ID desc");
		GridView1.DataBind();
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			if (GridView1.Rows[e.RowIndex].Cells[0].Text == null || GridView1.Rows[e.RowIndex].Cells[0].Text.Trim().Length <= 0)
			{
				return;
			}
			string id = GridView1.Rows[e.RowIndex].Cells[0].Text.Trim();
			SealManager sealMg = new SealManager(base.Server.MapPath("."));
			sealMg.DBConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=|DataDirectory|seal.mdb";
			if (string.IsNullOrEmpty(id) || !sealMg.Exists(int.Parse(id)))
			{
				base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('未获得印章的ID号，删除失败！');</script>");
			}
			else if (sealMg.Delete(int.Parse(id)))
			{
				ShowList(sealMg);
				if (((List<Seal>)(object)sealMg.GetQueryCollection("")).Count == 0)
				{
					flg = false;
					base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowDelAll();alert('删除成功！');</script>");
				}
				else
				{
					base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('删除成功！');</script>");
				}
			}
			else
			{
				base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('删除失败！');</script>");
			}
		}
		catch (Exception ex)
		{
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('删除失败！失败原因：" + ex.Message + "');</script>");
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
		{
			((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除\"编号\"为： " + e.Row.Cells[0].Text + " 的印章吗?')");
		}
	}

	protected void btnAddSeal_Click(object sender, EventArgs e)
	{
		if (Session["imageByte"] == null || Session["imageByte"].ToString() == "")
		{
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowAdd();alert('未获得上传图片路径，请重新上传！');</script>");
			Image1.ImageUrl = null;
			return;
		}
		if (string.IsNullOrEmpty(txtSealName.Text))
		{
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowAdd();alert('请输入印章名称！');</script>");
			Image1.ImageUrl = null;
			return;
		}
		if (string.IsNullOrEmpty(txtSignerName.Text))
		{
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowAdd();alert('请输入签章人姓名！');</script>");
			Image1.ImageUrl = null;
			return;
		}
		bool flg = false;
		int userId = 0;
		SealManager sealManager = new SealManager(base.Server.MapPath("."));
		sealManager.DBConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=|DataDirectory|seal.mdb";
		UserManager userManager = new UserManager();
		userManager.DBConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=|DataDirectory|seal.mdb";
		Seal seal2 = new Seal();
		try
		{
			seal2.SealName = txtSealName.Text.Trim();
			string signerName = txtSignerName.Text.Trim();
			if (userManager.Exists(signerName) <= 0)
			{
				User user = new User();
				user.DeptID = 1;
				user.DeptName = sealManager.GetLicOrg();
				user.Password = "111111";
				user.UserName = signerName;
				userId = userManager.Add(user);
				if (userId <= 0)
				{
					base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowAdd();alert('用户添加失败！');</script>");
					return;
				}
				flg = true;
			}
			seal2.SignerID = userManager.Exists(signerName);
			seal2.SignerName = signerName;
			seal2.SealImage = (byte[])Session["imageByte"];
			seal2.SealImageType = "image/" + Session["fileEx"];
			seal2.SealType = dropSealType.SelectedValue;
			seal2.DeptID = 1;
			seal2.DeptName = sealManager.GetLicOrg();
			seal2.AuthType = "密码";
			int id = sealManager.Add(seal2);
			if (id == -1)
			{
				base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowAdd();alert('印章添加失败！');</script>");
				if (flg)
				{
					userManager.Delete(userId);
				}
				return;
			}
			sealManager.Grant(id);
			flg = true;
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script type='text/javascript'>ShowList();alert('印章添加成功！');</script>");
			ShowList(sealManager);
			txtSealName.Text = "";
			txtSignerName.Text = "";
			dropSealType.SelectedValue = "印章";
			Image1.ImageUrl = "";
		}
		catch (Exception ex)
		{
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('印章添加失败！失败原因：" + ex.Message + "');</script>");
			if (flg && !userManager.Delete(userId))
			{
				base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>alert('新添加的用户删除失败，请在数据库中手动删除！');</script>");
			}
			Image1.ImageUrl = "";
			txtSealName.Text = "";
			txtSignerName.Text = "";
			dropSealType.SelectedValue = "印章";
			return;
		}
		Image1.ImageUrl = "";
		txtSealName.Text = "";
		txtSignerName.Text = "";
		dropSealType.SelectedValue = "印章";
	}

	protected void btnAddPic_Click(object sender, EventArgs e)
	{
		if (!FileUpload1.HasFile)
		{
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script type='text/javascript'>ShowAdd();alert('您还没有上传图片！');</script>");
			return;
		}
		HttpPostedFile hp = FileUpload1.PostedFile;
		int uplength = FileUpload1.PostedFile.ContentLength;
		string filepath = FileUpload1.PostedFile.FileName;
		string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
		string name = filename.Substring(0, filename.Length - 4);
		string fileEx = filepath.Substring(filepath.LastIndexOf(".") + 1).ToLower();
		switch (fileEx)
		{
		default:
			if (!(fileEx == "png"))
			{
				base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowAdd();alert('上传文件类型错误！\\r\\n请上传 .jpg|.jpeg|.bmp|.gif|.png 类型的图片！');</script>");
				break;
			}
			goto case "jpg";
		case "jpg":
		case "jpeg":
		case "bmp":
		case "gif":
		{
			string path = Environment.GetEnvironmentVariable("TEMP") + "\\" + filename;
			FileUpload1.PostedFile.SaveAs(path);
			Stream sr = hp.InputStream;
			byte[] imageByte = new byte[uplength];
			sr.Read(imageByte, 0, uplength);
			Session["fileEx"] = fileEx;
			Session["imageByte"] = imageByte;
			Session["imagePic"] = imageByte;
			Session["fileExPic"] = fileEx;
			Image1.ImageUrl = "sealPic.aspx";
			base.ClientScript.RegisterStartupScript(base.ClientScript.GetType(), "myscript", "<script>ShowAdd();</script>");
			break;
		}
		}
	}

	protected void LinkButton1_Click(object sender, EventArgs e)
	{
		Session.Clear();
		base.Response.Redirect("login.aspx");
	}
}
