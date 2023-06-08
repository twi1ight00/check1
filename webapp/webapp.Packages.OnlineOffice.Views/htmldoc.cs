using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.OnlineOffice.Application.DTO;
using Richfit.Garnet.Module.OnlineOffice.Application.Services;

namespace webapp.Packages.OnlineOffice.Views;

public class htmldoc : Page
{
	private IOnlineOfficeService onlineOfficeService = ServiceLocator.Instance.GetService<IOnlineOfficeService>();

	protected HtmlForm form1;

	public string DocFile { get; set; }

	public string DocSubject { get; set; }

	public string objId
	{
		get
		{
			if (!string.IsNullOrEmpty(base.Request["objId"]))
			{
				return base.Request["objId"].ToString();
			}
			return string.Empty;
		}
	}

	public OL_OFFICEDTO office => onlineOfficeService.GetOnlineOfficeByObjId(new Guid(objId));

	protected void Page_Load(object sender, EventArgs e)
	{
		if (office != null)
		{
			DocSubject = office.SUBJECT;
			DocFile = office.FILE_NAME.Substring(0, office.FILE_NAME.Length - 3) + "htm";
			base.Response.Redirect(ConfigurationManager.CurrentPackage.Settings["OnlinewordPath"].ToString() + DocFile);
		}
	}
}
