using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.push.mode;
using Quartz;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Application.Services;
using Richfit.Garnet.Module.Workflow.Application.DTO.Message.entinfo;
using Richfit.Garnet.Module.Workflow.Application.Services;

namespace Richfit.Garnet.Module.ITManagement.Infrastructure.Jobs;

public class DeviceScrapJob : IJob
{
	private static readonly ILogger logExp = LoggerManager.GetLogger();

	private IITDeviceManagementService deviceService = ServiceLocator.Instance.GetService<IITDeviceManagementService>();

	public void Execute(IJobExecutionContext context)
	{
		IT_DEVICE_SCRAPDTO parmScrap = new IT_DEVICE_SCRAPDTO();
		IEnumerable<IT_DEVICE_SCRAPDTO> scrapList = from t in deviceService.GetAllScrapList(parmScrap)
			where t.BUY_DATE_END.HasValue && t.BUY_DATE_END.Value.CompareTo(DateTime.Today) >= 0
			select t;
		foreach (IT_DEVICE_SCRAPDTO scrap in scrapList)
		{
			IT_DEVICE_SCRAP_DETAILDTO parmDetail = new IT_DEVICE_SCRAP_DETAILDTO();
			parmDetail.IT_DEVICE_SCRAP_ID = scrap.IT_DEVICE_SCRAP_ID;
			List<IT_DEVICE_SCRAP_DETAILDTO> deviceList = (from t in deviceService.QueryScrapList(parmDetail)
				where t.BUYER_ID.HasValue
				select t).ToList();
			if (deviceList.Count > 0 && ConfigurationManager.System.Settings.GetSetting("EnableJPush", defaultValue: false))
			{
				string AppKey = ConfigurationManager.System.Settings.GetSetting<string>("AppKey");
				string MasterSecret = ConfigurationManager.System.Settings.GetSetting<string>("MasterSecret");
				JPushClient client = new JPushClient(AppKey, MasterSecret);
				SendByJPush(client, deviceList);
			}
			if (deviceList.Count > 0 && ConfigurationManager.System.Settings.GetSetting("EnableSendMessage", defaultValue: false))
			{
				SendBySMS(deviceList);
			}
		}
	}

	private void SendByJPush(JPushClient client, List<IT_DEVICE_SCRAP_DETAILDTO> deviceList)
	{
		foreach (IT_DEVICE_SCRAP_DETAILDTO device in deviceList)
		{
			PushPayload pushLoad = new PushPayload();
			pushLoad.platform = Platform.all();
			pushLoad.audience = Audience.s_alias(device.BUYER_ID.ToString().Replace("-", "").ToLower());
			pushLoad.ResetOptionsApnsProduction(apnsProduction: true);
			string message = $"{device.BUYER_NAME}您好，您已成功申请购买设备{device.SERIES}（序列号{device.SN}），请您在一周内转账至财务并备注姓名。";
			pushLoad.notification = new Notification().setAlert(message);
			try
			{
				client.SendPush(pushLoad);
			}
			catch (APIRequestException e2)
			{
				logExp.Error("Error response from JPush server. Should review and fix it.");
				logExp.Error("HTTP Status: " + e2.Status);
				logExp.Error("Error Code: " + e2.ErrorCode);
				logExp.Error("Error Message: " + e2.ErrorMessage);
			}
			catch (APIConnectionException e)
			{
				logExp.Error("Failed to establish JPush API connection.");
				logExp.Error(e.Message);
			}
		}
	}

	private void SendBySMS(List<IT_DEVICE_SCRAP_DETAILDTO> deviceList)
	{
		string Sn = ConfigurationManager.System.Settings.GetSetting<string>("SendMessage_Sn");
		string Pwd = ConfigurationManager.System.Settings.GetSetting<string>("SendMessage_Pwd");
		string browserName = "";
		string IP = "";
		try
		{
			browserName = HttpContext.Current.Request.Browser.Browser + " " + HttpContext.Current.Request.Browser.Version;
			IP = GetCurrentUserHostAddress();
		}
		catch
		{
		}
		string path = HttpContext.Current.Server.MapPath("/Packages/WorkflowManagement/Config/MessageTemplate.xml");
		XmlDocument doc = new XmlDocument();
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.IgnoreComments = true;
		XmlReader reader = XmlReader.Create(path, settings);
		doc.Load(reader);
		XmlNode xn = doc.SelectSingleNode("MessageInfo");
		string text = "";
		foreach (XmlNode node in xn.ChildNodes)
		{
			XmlElement element = (XmlElement)node;
			if (element.GetAttribute("Type") == "ScrapPayment")
			{
				text = element.SelectSingleNode("Text").InnerText;
				break;
			}
		}
		MessageService messageService = new MessageService();
		foreach (IT_DEVICE_SCRAP_DETAILDTO device in deviceList)
		{
			string Content = string.Format(text, device.BUYER_NAME, device.SERIES, device.SN);
			CONTACTDTO contact = deviceService.GetContactByUserId(device.BUYER_ID.Value);
			messageService.SendToMessage(() => new MessageInfo
			{
				Mobile = new string[1] { contact.MOBILE },
				Sn = Sn,
				Pwd = Pwd,
				Content = Content
			}, device.IT_DEVICE_SCRAP_ID.Value, device.IT_DEVICE_SCRAP_DETAIL_ID, IP, browserName);
		}
	}

	private bool CheckPhoneIsAble(string input)
	{
		if (input.Length < 11)
		{
			return false;
		}
		string dianxin = "^1[3578][01379]\\d{8}$";
		Regex regexDX = new Regex(dianxin);
		string liantong = "^1[34578][01256]\\d{8}";
		Regex regexLT = new Regex(liantong);
		string yidong = "^(1[012345678]\\d{8}|1[345678][012356789]\\d{8})$";
		Regex regexYD = new Regex(yidong);
		if (regexDX.IsMatch(input) || regexLT.IsMatch(input) || regexYD.IsMatch(input))
		{
			return true;
		}
		return false;
	}

	private string GetCurrentUserHostAddress()
	{
		string AddressIP = string.Empty;
		string hostName = Dns.GetHostName();
		IPAddress[] addresses = Dns.GetHostAddresses(hostName);
		for (int i = 0; i < addresses.Length; i++)
		{
			if (addresses[i].AddressFamily.ToString() == "InterNetwork")
			{
				AddressIP = addresses[i].ToString();
			}
		}
		return AddressIP;
	}
}
