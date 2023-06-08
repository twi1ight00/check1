using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;

namespace webapp;

public class LocalSsoUc : Page
{
	private static readonly ILogger moLog = LoggerManager.GetLogger();

	protected HtmlForm form1;

	protected TextBox txtUserInfo;

	private string Base64Decode(string code, string key = "")
	{
		byte[] outputb = Convert.FromBase64String(code);
		string retStr = Encoding.Default.GetString(outputb);
		return (key != "") ? retStr.Replace(key, "") : retStr;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string appcode = ConfigurationManager.System.Settings.GetSetting<string>("uc_appcode").ToString();
			string secret = ConfigurationManager.System.Settings.GetSetting<string>("uc_secret").ToString();
			string tokenUrl = ConfigurationManager.System.Settings.GetSetting<string>("uc_tokenUrl").ToString();
			string userinfoUrl = ConfigurationManager.System.Settings.GetSetting<string>("uc_userinfoUrl").ToString();
			string code = base.Request["code"].ToString();
			moLog.Info("统一登陆,参数Code:" + code);
			string url = tokenUrl + "?appcode=" + appcode + "&secret=" + secret + "&code=" + code;
			string tokenJson = GetJsonStr(url);
			moLog.Info("统一登陆,获取token反馈:" + tokenJson);
			JObject jo = (JObject)JsonConvert.DeserializeObject(tokenJson);
			string token = jo["accessToken"].ToString();
			string userurl = userinfoUrl + "?appcode=" + appcode + "&secret=" + secret + "&token=" + token;
			string UserInfo = GetJsonStr(userurl);
			moLog.Info("统一登陆,获取userinfo反馈:" + UserInfo);
			JObject jos = (JObject)JsonConvert.DeserializeObject(UserInfo);
			string accountName = jos["accountName"].ToString();
			moLog.Info("统一登陆,用户编号:" + accountName);
			ISystemUserService service = ServiceLocator.Instance.GetService<ISystemUserService>();
			UserDTO user = service.GetUserBySapId(accountName);
			if (user != null)
			{
				moLog.Info("统一登陆,找到系统用户:" + user.ToJson());
				UserSessionInfo userSessionInfo = GetSessionInfo(user);
				Guid tokenId = Singleton<SessionManager>.Instance.AddSession(userSessionInfo);
				JObject result = JObject.FromObject(user);
				result.Add("TokenGuid", tokenId);
				txtUserInfo.Text = JsonConvert.SerializeObject(result);
			}
			else
			{
				txtUserInfo.Text = "";
			}
		}
		catch (Exception ex)
		{
			moLog.Info("统一登陆------错误：" + ex);
			txtUserInfo.Text = "";
		}
	}

	private string GetJsonStr(string url)
	{
		ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(RemoteCertificateValidate));
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		Stream responseStream = response.GetResponseStream();
		StreamReader sr = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
		string responseText = sr.ReadToEnd();
		sr.Close();
		sr.Dispose();
		responseStream.Close();
		return responseText;
	}

	private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
	{
		return true;
	}

	private UserSessionInfo GetSessionInfo(UserDTO userInfo)
	{
		UserSessionInfo userSessionInfo = new UserSessionInfo();
		userSessionInfo.LanguageCulture = ConfigurationManager.System.Settings.DefaultCulture.Name;
		userSessionInfo.LogonName = userInfo.LOGON_NAME;
		userSessionInfo.IsMobile = 0;
		userSessionInfo.LogonPassword = userInfo.USER_PASSWORD;
		userSessionInfo.UserID = userInfo.USER_ID;
		userSessionInfo.UserName = userInfo.DISPLAY_NAME;
		userSessionInfo.EXTEND1 = userInfo.EXTEND1;
		decimal? uSER_TYPE = userInfo.USER_TYPE;
		userSessionInfo.IsSuperUser = ((uSER_TYPE.GetValueOrDefault() == 2m && uSER_TYPE.HasValue) ? true : false);
		userSessionInfo.TimeOffset = 0;
		userSessionInfo.BelongToOrgID = userInfo.ORG_ID;
		userSessionInfo.IP = SessionContext.IP;
		return userSessionInfo;
	}
}
