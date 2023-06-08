using System;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;

namespace webapp.Handlers;

public class IAMQueryAccount : IHttpHandler
{
	private static readonly ILogger logger = LoggerManager.GetLogger();

	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		IAMQueryAccountRespondData respondData = new IAMQueryAccountRespondData();
		try
		{
			StreamReader reader = new StreamReader(context.Request.InputStream);
			string requestBody = reader.ReadToEnd();
			reader.Close();
			IAMQueryAccountRequestData requestData = requestBody.JsonDeserialize<IAMQueryAccountRequestData>(new JsonConverter[0]);
			string accountName = requestData.accountName;
			if (!string.IsNullOrEmpty(accountName))
			{
				if (AcountExisted(accountName))
				{
					respondData.code = "SUCCESS";
					respondData.data = "true";
				}
				else
				{
					respondData.code = "SUCCESS";
					respondData.data = "false";
				}
			}
			else
			{
				respondData.code = "APP_ERROR";
				respondData.message = "未传入账户名";
			}
		}
		catch (Exception e)
		{
			respondData.code = "APP_ERROR";
			respondData.message = "系统发生未知错误";
			logger.Error("IAM查询用户账户发生错误: " + e.Message);
		}
		finally
		{
			context.Response.ContentType = "application/json";
			context.Response.Write(JsonConvert.SerializeObject(respondData));
		}
	}

	private bool AcountExisted(string accountName)
	{
		ISystemUserService service = ServiceLocator.Instance.GetService<ISystemUserService>();
		UserDTO sysUser = service.GetUserBySapId(accountName);
		return sysUser != null;
	}
}
