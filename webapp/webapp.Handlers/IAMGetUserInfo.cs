using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;

namespace webapp.Handlers;

public class IAMGetUserInfo : IHttpHandler
{
	private static readonly ILogger logger = LoggerManager.GetLogger();

	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		IAMGetUserInfoRespondData respondData = new IAMGetUserInfoRespondData();
		try
		{
			string token = context.Request.Params["token"];
			logger.Info("APP统一登陆, Token:" + token);
			string validateURL = ConfigurationManager.System.Settings.GetSetting<string>("uc_validateUrl").ToString();
			validateURL = validateURL + "?ticket=" + token + "&service=http://test.ccc&format=json";
			string validateResult = GetJsonStr(validateURL);
			logger.Info("APP统一登陆, Validate Result:" + validateResult);
			JObject validateResultObject = (JObject)JsonConvert.DeserializeObject(validateResult);
			string serviceResponse = validateResultObject["serviceResponse"].ToString();
			JObject serviceResponseObject = (JObject)JsonConvert.DeserializeObject(serviceResponse);
			if (serviceResponse.Contains("authenticationSuccess"))
			{
				string authenticationSuccess = serviceResponseObject["authenticationSuccess"].ToString();
				JObject authenticationSuccessObject = (JObject)JsonConvert.DeserializeObject(authenticationSuccess);
				string accountName = authenticationSuccessObject["user"].ToString();
				logger.Info("APP统一登陆, SAP Account:" + accountName);
				ISystemUserService service = ServiceLocator.Instance.GetService<ISystemUserService>();
				UserDTO user = service.GetUserBySapId(accountName);
				if (user != null)
				{
					logger.Info("APP统一登陆,找到系统用户:" + user.ToJson());
					UserSessionInfo userSessionInfo = GetSessionInfo(user);
					Guid tokenId = Singleton<SessionManager>.Instance.AddSession(userSessionInfo);
					JObject result = JObject.FromObject(user);
					result.Add("TokenGuid", tokenId);
					respondData.code = "SUCCESS";
					respondData.data = JsonConvert.SerializeObject(result);
				}
				else
				{
					respondData.code = "ERROR";
					respondData.message = "用户账户不存在";
				}
			}
			else
			{
				string authenticationFailure = serviceResponseObject["authenticationFailure"].ToString();
				JObject authenticationFailureObject = (JObject)JsonConvert.DeserializeObject(authenticationFailure);
				respondData.code = "ERROR";
				respondData.message = string.Format("Token验证发生错误错误, CODE: {0}, DESCRIPTION: {1}", authenticationFailureObject["code"].ToString(), authenticationFailureObject["description"].ToString());
			}
		}
		catch (Exception e)
		{
			respondData.code = "ERROR";
			respondData.message = "系统发生未知错误: " + e.Message;
		}
		finally
		{
			context.Response.ContentType = "application/json";
			context.Response.Write(JsonConvert.SerializeObject(respondData));
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
