using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Common.Patterns;
using Richfit.Garnet.Module.Attachment.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.CMS.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.DTO;

namespace webapp.Handlers.Mobile;

public class RuixinHandler : IHttpHandler
{
	private static readonly ILogger moLog = LoggerManager.GetLogger("RxMobile");

	private string loginId;

	private string url;

	public bool IsReusable => false;

	public void ProcessRequest(HttpContext context)
	{
		DateTime dtNow = DateTime.Now;
		context.Response.ContentType = "text/plain";
		string szIncomeMessage = HttpContext.Current.Request.Form["req_data"] ?? "";
		moLog.Info($"接口消息内容:{szIncomeMessage}");
		if (string.IsNullOrEmpty(szIncomeMessage))
		{
			moLog.Info(string.Format("D01 消息为空", DateTime.Now.ToString()));
			context.Response.Write(ReturnMessages("", "", "D01", "消息为空！", "1", ""));
			return;
		}
		try
		{
			RuixinRequestData ruixinRequestData = szIncomeMessage.JsonDeserialize<RuixinRequestData>(new JsonConverter[0]);
			if (ruixinRequestData.data == null || ruixinRequestData.data.Count == 0)
			{
				moLog.Info("D02 缺少消息数据！");
				context.Response.Write(ReturnMessages("", "", "D02", "缺少消息数据！", "1", ""));
				return;
			}
			Dictionary<string, string> infoDic = ruixinRequestData.data;
			if (!infoDic.ContainsKey("ComType"))
			{
				moLog.Info("D04 未定义操作！");
				context.Response.Write(ReturnMessages("", "", "D04", "未定义操作！", "1", ""));
				return;
			}
			url = ConfigurationManager.System.Settings.GetSetting<string>("SerUrl");
			loginId = ruixinRequestData.user_id.Split("@")[0];
			string action = infoDic["ComType"];
			MethodInfo methodInfo = GetType().GetMethod(action, BindingFlags.Instance | BindingFlags.NonPublic);
			string retMsg = "";
			try
			{
				retMsg = methodInfo.Invoke(this, new object[1] { ruixinRequestData }).ToString();
			}
			catch (Exception ex)
			{
				context.Response.Write(ReturnMessages("", "", "D05", "后台操作异常！", "1", ""));
				moLog.Info($"处理数据发生异常：{ex.Message}");
				return;
			}
			moLog.Info($"返回消息：{retMsg}");
			context.Response.Write(retMsg);
		}
		catch (Exception)
		{
			moLog.Info("D03 消息处理发生错误！");
			context.Response.Write(ReturnMessages("", "", "D03", "消息处理发生错误！", "1", ""));
		}
	}

	private string Login(RuixinRequestData ruixinRequestData)
	{
		Dictionary<string, string> infoDic = ruixinRequestData.data;
		LogonDTO logonDTO = new LogonDTO();
		logonDTO.IS_MOBILE = 1;
		logonDTO.LOGON_NAME = loginId;
		logonDTO.PASSWORD = "205";
		LogonDTO logonDto = logonDTO;
		ResponseData result = AccessManager.ServiceAccess("Mobile", "SystemLogin_Login", logonDto.JsonSerialize());
		UserMobile logonContext = result.Data.JsonDeserialize<UserMobile>(new JsonConverter[0]);
		object data = new
		{
			external_token = logonContext.TokenGuid
		};
		return GenerateResult(ruixinRequestData, data).JsonSerialize();
	}

	private string GetTaskList(RuixinRequestData ruixinRequestData)
	{
		List<string> list = new List<string>();
		list.Add("OverseasTraining");
		list.Add("InternalTraining");
		list.Add("EmployeeResign");
		list.Add("RECRUITMENT");
		list.Add("FinanceCertificates");
		list.Add("HrSealApply");
		list.Add("LeadLeave");
		list.Add("AchievementReuse");
		list.Add("OtherSeal");
		list.Add("InformationTechnologyCenterSeal");
		list.Add("LectureFees");
		list.Add("ConversionForm");
		list.Add("ProjectExterior");
		list.Add("EmpInternalTransfer");
		list.Add("HRContractRenewal");
		List<string> lstTmpCode = list;
		Dictionary<string, string> infoDic = ruixinRequestData.data;
		int pageNo = Convert.ToInt32(infoDic["PageNo"]);
		int pageSize = Convert.ToInt32(infoDic["PageSize"]);
		int pageIndex = pageNo * pageSize;
		WF_WORKITEMDTO wF_WORKITEMDTO = new WF_WORKITEMDTO();
		wF_WORKITEMDTO.USER_ID = Singleton<SessionManager>.Instance.GetUserSessionInfo(Guid.Parse(infoDic["external_token"])).UserID;
		wF_WORKITEMDTO.PageSize = Convert.ToInt32(infoDic["PageSize"]);
		wF_WORKITEMDTO.PageIndex = pageIndex;
		wF_WORKITEMDTO.ISMOBILE = 1m;
		wF_WORKITEMDTO.SortBy = "START_TIME DESC";
		WF_WORKITEMDTO workItem = wF_WORKITEMDTO;
		IList<InstanceDTO> dtoList = new List<InstanceDTO>();
		ResponseData result = AccessManager.ServiceAccess("Mobile", "WorkflowExtend_GetWorkItemPager", workItem.JsonSerialize());
		QueryResult<WF_WORKITEMDTO> queryResult = result.Data.JsonDeserialize<QueryResult<WF_WORKITEMDTO>>(new JsonConverter[0]);
		if (queryResult != null && queryResult.List != null && queryResult.List.Count > 0)
		{
			foreach (WF_WORKITEMDTO item in queryResult.List)
			{
				Dictionary<string, string> parm = new Dictionary<string, string>();
				parm.Add("TemplateID", item.TEMPLATE_ID.ToString());
				parm.Add("ActivityID", item.ACTIVITY_ID.ToString());
				parm.Add("InstanceID", item.INSTANCE_ID.ToString());
				parm.Add("WorkItemID", item.WORKITEM_ID.ToString());
				parm.Add("TokenGuid", infoDic["external_token"]);
				parm.Add("PROXY_USER_ID", item.USER_ID.ToString());
				parm.Add("PROXY_USER_NAME", item.USER_NAME);
				parm.Add("PROXY_ORG_ID", item.ORG_ID.ToString());
				parm.Add("PROXY_ORG_NAME", item.ORG_NAME);
				parm.Add("Time", DateTime.Now.ToString("yyyyMMddHHmmss"));
				string p = HttpUtility.UrlEncode(parm.JsonSerialize(), Encoding.GetEncoding(936));
				object objSendTime = item.SEND_TIME.Value;
				string newUrl = item.FORM_PATH_URL.Replace(".html", "") + "_mobile.html";
				dtoList.Add(new InstanceDTO
				{
					CurrentUser = item.SENDER_USER_NAME,
					SendTime = Convert.ToDateTime(objSendTime).ToString("yyyy-MM-dd"),
					Title = item.INSTANCE_NAME,
					FlowID = item.INSTANCE_ID.Value,
					FlowName = item.TEMPLATE_NAME,
					FlowType = item.PACKAGE_NAME,
					FlowTypeID = item.PACKAGE_ID.Value,
					FlowTypeName = "RFOA2_0_HRBUSINESS",
					ptCode = ruixinRequestData.p_code,
					detailPageURL = $"{url}{newUrl}?P={p}",
					iconURL = $"{url}/assets/img/rx_richfit_oa.png"
				});
			}
		}
		return GenerateResult(ruixinRequestData, new
		{
			WorkList = dtoList
		}).JsonSerialize();
	}

	private string GetList(RuixinRequestData ruixinRequestData)
	{
		Dictionary<string, string> infoDic = ruixinRequestData.data;
		int RecordStart = Convert.ToInt32(infoDic["RecordStart"]);
		int RecordLength = Convert.ToInt32(infoDic["RecordLength"]);
		CMS_ARTICLEDTO dto = new CMS_ARTICLEDTO();
		int tmp = Convert.ToInt32(RecordStart) % Convert.ToInt32(RecordLength);
		int page = Convert.ToInt32(RecordStart) / Convert.ToInt32(RecordLength) + ((tmp >= 0) ? 1 : 0);
		dto.USER_ID = Singleton<SessionManager>.Instance.GetUserSessionInfo(Guid.Parse(infoDic["external_token"])).UserID;
		dto.PageIndex = page - 1;
		dto.PageSize = RecordLength;
		dto.SortBy = "WEIGHT DESC,WEIGHT_SORT DESC,AUDIT_DATE DESC";
		dto.StartDate = Convert.ToDateTime(infoDic["ContStartTime"]);
		dto.EndDate = Convert.ToDateTime(infoDic["ContEndTime"]).AddDays(-1.0);
		dto.PARENT_ID = Guid.Parse((infoDic["QueryType"] == "1") ? "8D2A873D-722A-CB4D-8E3E-C8CA4B733D4E" : "CDF1485A-4A6F-C417-571D-08CF62CB01A1");
		ResponseData result = AccessManager.ServiceAccess("Mobile", "CMS_GetViewArticle_Advance", dto.JsonSerialize());
		QueryResult<CMS_ARTICLEDTO> queryResult = result.Data.JsonDeserialize<QueryResult<CMS_ARTICLEDTO>>(new JsonConverter[0]);
		IList<ArticleDTO> dtoList = new List<ArticleDTO>();
		if (queryResult != null && queryResult.List != null && queryResult.List.Count > 0)
		{
			foreach (CMS_ARTICLEDTO item in queryResult.List)
			{
				ResponseData attString = AccessManager.ServiceAccess("Mobile", "L_GetAttachmentByObjId", new
				{
					OBJ_ID = item.ID
				}.JsonSerialize());
				IList<AttachmentDTO> attList = null;
				IList<AttDTO> list = new List<AttDTO>();
				if (!string.IsNullOrEmpty(attString.Data))
				{
					attList = attString.Data.JsonDeserialize<List<AttachmentDTO>>(new JsonConverter[0]);
					foreach (AttachmentDTO att in attList)
					{
						list.Add(new AttDTO
						{
							AttachID = att.ATTACHMENT_ID.ToString(),
							AttachSize = att.ATTACHMENT_SIZE.ToString(),
							AttachTitle = att.ATTACHMENT_NAME,
							AttachType = att.ATTACHMENT_TYPE
						});
					}
				}
				ArticleDTO articleDTO = new ArticleDTO
				{
					AuditStatus = "",
					DispatchDep = item.ORG_NAME,
					DispatchPeo = item.USER_NAME
				};
				decimal? iS_TOP = item.IS_TOP;
				articleDTO.IsTop = ((iS_TOP.GetValueOrDefault() == 1m && iS_TOP.HasValue) ? "是" : "否");
				articleDTO.SendPeo = item.USER_NAME;
				articleDTO.SendTime = item.MODIFYTIME.ToLongTimeString();
				articleDTO.Title = item.TITLE;
				articleDTO.Url = string.Format("{0}/cms/{1}.html?license={2}", url, item.ID, DateTime.Now.ToString("yyyyMMddHHmmss"));
				articleDTO.AttachmentList = list;
				dtoList.Add(articleDTO);
			}
		}
		return new
		{
			rx_token = ruixinRequestData.rx_token,
			p_code = ruixinRequestData.p_code,
			user_id = ruixinRequestData.user_id,
			res_code = 0,
			res_msg = "成功",
			encrypted = 1,
			RecordCount = queryResult.RecordCount,
			DataList = dtoList
		}.JsonSerialize();
	}

	public static string ReturnMessages(string token, string p_code, string rescode, string resmsg, string encrypted, string user_id)
	{
		string msgTemplate = string.Format("\"rx_token\":\"{0}\",\"p_code\":\"{1}\",\"user_id\":\"{5}\",\"res_code\":\"{2}\",\"res_msg\":\"{3}\",\"encrypted\":\"{4}\"", token, p_code, rescode, resmsg, encrypted, user_id);
		return "{" + msgTemplate + "}";
	}

	private RfUser UserValidate(string token)
	{
		string parm = "{\"interface\": \"getuserbytoken\",\"parameters\":{\"token\": \"" + token + "\"}}";
		string userValidate = HttpPost(ConfigurationManager.System.Settings.GetSetting<string>("RxAuthUrl"), parm);
		ValidateData<RfUser> validate = userValidate.JsonDeserialize<ValidateData<RfUser>>(new JsonConverter[0]);
		if (validate.body.error.errorcode == 0 && validate.body.information.list.Count == 1)
		{
			return validate.body.information.list[0];
		}
		return null;
	}

	private object GenerateResult(RuixinRequestData ruixinRequestData, object data)
	{
		return new
		{
			rx_token = ruixinRequestData.rx_token,
			p_code = ruixinRequestData.p_code,
			user_id = ruixinRequestData.user_id,
			res_code = 0,
			res_msg = "成功",
			encrypted = 1,
			data = data
		};
	}

	private string HttpPost(string Url, string postDataStr)
	{
		try
		{
			string ret = string.Empty;
			Encoding dataEncode = Encoding.Default;
			byte[] byteArray = dataEncode.GetBytes(postDataStr);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(Url));
			webReq.Method = "POST";
			webReq.ContentType = "application/x-www-form-urlencoded";
			webReq.ContentLength = byteArray.Length;
			Stream newStream = webReq.GetRequestStream();
			newStream.Write(byteArray, 0, byteArray.Length);
			newStream.Close();
			HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
			StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
			ret = sr.ReadToEnd();
			sr.Close();
			response.Close();
			newStream.Close();
			return ret;
		}
		catch (Exception ex)
		{
			moLog.Info("获取瑞信用户信息发生错误：{0}" + ex.Message);
			return null;
		}
	}
}
