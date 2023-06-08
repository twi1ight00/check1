using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PageOffice.POServer;

namespace pageoffice;

public class server : Page
{
	protected HtmlHead Head1;

	protected HtmlForm form1;

	protected Label LabelReg;

	protected Label LabelLog;

	protected void Page_Load(object sender, EventArgs e)
	{
		Server ServerObj = new Server();
		ServerObj.DBConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=|DataDirectory|seal.mdb";
		ServerObj.Run();
		string strOutPut = "欢迎使用 PageOffice 产品\r\n";
		string strRegInfo = "";
		if (ServerObj.SerialNumber != "")
		{
			strRegInfo = "注册码：" + ServerObj.SerialNumber + "<br>版 本：" + ServerObj.VersionInfo + "<br>用 户：" + ServerObj.Organization;
			if (ServerObj.TrialEndTime != "")
			{
				strRegInfo = strRegInfo + "<br>此产品是<span style=\"color:Red;\">试用版</span>，试用结束时间是 " + ServerObj.TrialEndTime + "。";
			}
			strRegInfo = strRegInfo + "<br>PageOffice Server Version: " + ServerObj.ServerVersion;
		}
		else
		{
			strRegInfo = "<span style=\"color:Red;\">此产品尚未注册激活。</span>";
		}
		strOutPut = strOutPut + "PageOffice 注册信息：" + strRegInfo + "\r\n";
		strOutPut = strOutPut + "PageOffice 运行信息：" + ServerObj.GetStatusLog() + "\r\n";
		string ServerIP = base.Request.ServerVariables["HTTP_HOST"].ToLower();
		if (ServerIP.StartsWith("localhost") || ServerIP.StartsWith("127.0.0.1"))
		{
			LabelReg.Text = strRegInfo;
			LabelLog.Text = ServerObj.GetStatusLog();
			return;
		}
		try
		{
			FileStream fs = new FileStream(Path.GetTempPath() + "poserver_log.txt", FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);
			sw.Write(strOutPut);
			sw.Flush();
			sw.Close();
			fs.Close();
			LabelReg.Text = "PageOffice 注册信息已生成，请到Web服务器临时文件夹里查看poserver_log.txt文件。<br>PageOffice Server Version: " + ServerObj.ServerVersion;
			LabelLog.Text = ServerObj.GetStatusLog();
		}
		catch
		{
			LabelReg.Text = "无法生成poserver_log.txt文件，可能是临时文件夹权限不够。出于安全考虑，您只能在Web服务器上通过localhost方式来查看本页显示的PageOffice系统信息。<br>PageOffice Server Version: " + ServerObj.ServerVersion;
			LabelLog.Text = ServerObj.GetStatusLog();
		}
	}
}
