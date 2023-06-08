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
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.ITManagement.Application.DTO;
using Richfit.Garnet.Module.ITManagement.Domain.Models;
using Richfit.Garnet.Module.Workflow.Application.DTO.Message.entinfo;
using Richfit.Garnet.Module.Workflow.Application.Services;

namespace Richfit.Garnet.Module.ITManagement.Application.Services;

public class ITDeviceManagementService : ServiceBase, IITDeviceManagementService
{
	private delegate void SendByJPushDelegate(IT_DEVICE_SCRAPDTO scrapDTO);

	private delegate void SendBySMSDelegate(IT_DEVICE_SCRAPDTO scrapDTO);

	private static readonly ILogger logExp = LoggerManager.GetLogger("Exception");

	private readonly IRepository<IT_DEVICE> deviceRepository;

	private readonly IRepository<IT_DEVICE_SCRAP> scrapRepository;

	private readonly IRepository<IT_DEVICE_SCRAP_DETAIL> scrapDetailRepository;

	public ITDeviceManagementService(IRepository<IT_DEVICE> dRepository, IRepository<IT_DEVICE_SCRAP> sRepository, IRepository<IT_DEVICE_SCRAP_DETAIL> sdRepository)
	{
		deviceRepository = dRepository;
		scrapRepository = sRepository;
		scrapDetailRepository = sdRepository;
	}

	public QueryResult<IT_DEVICEDTO> QueryDeviceList(IT_DEVICEDTO queryCondition)
	{
		return SqlQueryPager<IT_DEVICEDTO>("QueryDeviceList", queryCondition);
	}

	public QueryResult<IT_DEVICEDTO> QueryDeviceList_Advance(IT_DEVICEDTO queryCondition)
	{
		return SqlQueryPager<IT_DEVICEDTO>("QueryDeviceList_Advance", queryCondition);
	}

	public IList<IT_DEVICEDTO> QueryDeviceToScrap(IT_DEVICEDTO queryCondition)
	{
		return SqlQuery<IT_DEVICEDTO>("QueryDeviceToScrap", queryCondition);
	}

	public IList<IT_DEVICEDTO> QueryDeviceInventoryList(IT_DEVICEDTO queryCondition)
	{
		return SqlQuery<IT_DEVICEDTO>("QueryDeviceInventoryList", queryCondition);
	}

	public IT_DEVICEDTO CheckInDevice(IT_DEVICEDTO deviceDTO)
	{
		if (deviceDTO == null)
		{
			throw new ArgumentException("CheckIn方法参数不能为空！");
		}
		if (deviceDTO.IsValid())
		{
			IT_DEVICE devicePOCO = deviceDTO.AdaptAsEntity<IT_DEVICE>();
			deviceRepository.AddCommit(devicePOCO);
			return deviceDTO;
		}
		throw new ValidationException(deviceDTO.GetInvalidMessages());
	}

	public IT_DEVICEDTO UpdateDevice(IT_DEVICEDTO deviceDTO)
	{
		if (deviceDTO == null)
		{
			throw new ArgumentException("CheckOut方法参数不能为空！");
		}
		if (deviceDTO.IsValid())
		{
			IT_DEVICE persisted = deviceRepository.GetByKey(deviceDTO.IT_DEVICE_ID);
			if (persisted != null)
			{
				IT_DEVICE devicePOCO = deviceDTO.AdaptAsEntity<IT_DEVICE>();
				IT_DEVICE newDevicePOCO = persisted;
				newDevicePOCO.SN = deviceDTO.SN;
				newDevicePOCO.SERIES = deviceDTO.SERIES;
				newDevicePOCO.PURCHASE_DATE = deviceDTO.PURCHASE_DATE;
				newDevicePOCO.ORIGINAL_VALUE = deviceDTO.ORIGINAL_VALUE;
				newDevicePOCO.REMAIN_VALUE = deviceDTO.REMAIN_VALUE;
				newDevicePOCO.REMARK = deviceDTO.REMARK;
				deviceRepository.UpdateCommit(newDevicePOCO);
				deviceDTO = newDevicePOCO.AdaptAsDTO<IT_DEVICEDTO>();
				return deviceDTO;
			}
			throw new ArgumentException("UpdateAccount不存在相关的实体对象！");
		}
		throw new ValidationException(deviceDTO.GetInvalidMessages());
	}

	public IT_DEVICEDTO CheckOutDevice(IT_DEVICEDTO deviceDTO)
	{
		if (deviceDTO == null)
		{
			throw new ArgumentException("CheckOut方法参数不能为空！");
		}
		if (deviceDTO.IsValid())
		{
			IT_DEVICE persisted = deviceRepository.GetByKey(deviceDTO.IT_DEVICE_ID);
			if (persisted != null)
			{
				IT_DEVICE devicePOCO = deviceDTO.AdaptAsEntity<IT_DEVICE>();
				IT_DEVICE newDevicePOCO = persisted;
				newDevicePOCO.DEPRECIATE_DATE = newDevicePOCO.DEPRECIATE_DATE ?? deviceDTO.DEPRECIATE_DATE;
				newDevicePOCO.USE_STATUS = deviceDTO.USE_STATUS;
				newDevicePOCO.ASSIGN_DATE = deviceDTO.ASSIGN_DATE;
				newDevicePOCO.USER_ID = deviceDTO.USER_ID;
				newDevicePOCO.REMARK = deviceDTO.REMARK;
				deviceRepository.UpdateCommit(newDevicePOCO);
				deviceDTO = newDevicePOCO.AdaptAsDTO<IT_DEVICEDTO>();
				return deviceDTO;
			}
			throw new ArgumentException("UpdateAccount不存在相关的实体对象！");
		}
		throw new ValidationException(deviceDTO.GetInvalidMessages());
	}

	public IT_DEVICEDTO RemoveDevice(IT_DEVICEDTO deviceDTO)
	{
		if (deviceDTO == null)
		{
			throw new ArgumentException("CheckOut方法参数不能为空！");
		}
		if (deviceDTO.IsValid())
		{
			IT_DEVICE persisted = deviceRepository.GetByKey(deviceDTO.IT_DEVICE_ID);
			if (persisted != null)
			{
				IT_DEVICE devicePOCO = deviceDTO.AdaptAsEntity<IT_DEVICE>();
				IT_DEVICE newDevicePOCO = persisted;
				newDevicePOCO.ISDEL = 1m;
				deviceRepository.UpdateCommit(newDevicePOCO);
				deviceDTO = newDevicePOCO.AdaptAsDTO<IT_DEVICEDTO>();
				return deviceDTO;
			}
			throw new ArgumentException("UpdateAccount不存在相关的实体对象！");
		}
		throw new ValidationException(deviceDTO.GetInvalidMessages());
	}

	public IT_DEVICEDTO RevertDevice(IT_DEVICEDTO deviceDTO)
	{
		if (deviceDTO == null)
		{
			throw new ArgumentException("CheckOut方法参数不能为空！");
		}
		if (deviceDTO.IsValid())
		{
			IT_DEVICE persisted = deviceRepository.GetByKey(deviceDTO.IT_DEVICE_ID);
			if (persisted != null)
			{
				IT_DEVICE devicePOCO = deviceDTO.AdaptAsEntity<IT_DEVICE>();
				IT_DEVICE newDevicePOCO = persisted;
				newDevicePOCO.USE_STATUS = 1m;
				newDevicePOCO.ASSIGN_DATE = null;
				newDevicePOCO.USER_ID = null;
				deviceRepository.UpdateCommit(newDevicePOCO);
				deviceDTO = newDevicePOCO.AdaptAsDTO<IT_DEVICEDTO>();
				return deviceDTO;
			}
			throw new ArgumentException("UpdateAccount不存在相关的实体对象！");
		}
		throw new ValidationException(deviceDTO.GetInvalidMessages());
	}

	public IT_DEVICE_SCRAPDTO NewDeviceScrap(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		if (scrapDTO.IsValid())
		{
			scrapDTO.IT_DEVICE_SCRAP_ID = Guid.NewGuid();
			IT_DEVICE_SCRAP scrapPOCO = scrapDTO.AdaptAsEntity<IT_DEVICE_SCRAP>();
			foreach (IT_DEVICE_SCRAP_DETAIL item in scrapPOCO.IT_DEVICE_SCRAP_DETAIL)
			{
				item.IT_DEVICE_SCRAP_DETAIL_ID = Guid.NewGuid();
				item.IT_DEVICE_SCRAP_ID = scrapPOCO.IT_DEVICE_SCRAP_ID;
				IT_DEVICE device = deviceRepository.GetByKey(item.IT_DEVICE_ID);
				device.PRE_SCRAP = 1m;
				device.PRE_SCRAP_DATE = DateTime.Now;
				deviceRepository.Update(device);
			}
			scrapRepository.AddCommit(scrapPOCO);
			deviceRepository.DbContext.Commit();
			scrapDTO = scrapPOCO.AdaptAsDTO<IT_DEVICE_SCRAPDTO>();
			NotifyNewScrap(scrapDTO);
			return scrapDTO;
		}
		throw new ValidationException(scrapDTO.GetInvalidMessages());
	}

	public IList<IT_DEVICE_SCRAP_DETAILDTO> QueryScrapList(IT_DEVICE_SCRAP_DETAILDTO scrapDTO)
	{
		return SqlQuery<IT_DEVICE_SCRAP_DETAILDTO>("QueryScrapList", scrapDTO);
	}

	public IList<IT_DEVICE_SCRAPDTO> GetAllScrapList(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		return SqlQuery<IT_DEVICE_SCRAPDTO>("GetAllScrapList", scrapDTO);
	}

	public bool ConfirmScrapPayment(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		IT_DEVICE_SCRAP scrapPOCO = scrapRepository.GetByKey(scrapDTO.IT_DEVICE_SCRAP_ID);
		if (scrapPOCO != null)
		{
			scrapPOCO.CONFIRMED_BY = scrapDTO.CONFIRMED_BY;
			scrapPOCO.CONFIRM_DATE = DateTime.Now;
			scrapRepository.UpdateCommit(scrapPOCO);
		}
		return true;
	}

	public bool CloseScrap(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		IT_DEVICE_SCRAP scrapPOCO = scrapRepository.GetByKey(scrapDTO.IT_DEVICE_SCRAP_ID);
		if (scrapPOCO != null)
		{
			scrapPOCO.CLOSED_BY = scrapDTO.CLOSED_BY;
			scrapPOCO.CLOSE_DATE = DateTime.Now;
			scrapRepository.Update(scrapPOCO);
			foreach (IT_DEVICE_SCRAP_DETAIL scraped in scrapPOCO.IT_DEVICE_SCRAP_DETAIL)
			{
				IT_DEVICE devicePOCO = deviceRepository.GetByKey(scraped.IT_DEVICE_ID);
				if (devicePOCO != null)
				{
					devicePOCO.SCRAP = 1m;
					devicePOCO.SCRAP_DATE = DateTime.Now;
					deviceRepository.Update(devicePOCO);
				}
			}
			scrapRepository.DbContext.Commit();
			deviceRepository.DbContext.Commit();
		}
		return true;
	}

	public bool ChangeScrapDetail(IT_DEVICE_SCRAP_DETAILDTO detail)
	{
		IT_DEVICE_SCRAP_DETAIL scrapDetailPOCO = scrapDetailRepository.GetByKey(detail.IT_DEVICE_SCRAP_DETAIL_ID);
		if (scrapDetailPOCO != null)
		{
			scrapDetailPOCO.BUYER_ID = detail.BUYER_ID;
			scrapDetailPOCO.BUY_DATE = DateTime.Now;
			scrapDetailRepository.UpdateCommit(scrapDetailPOCO);
		}
		return true;
	}

	public bool BuyScrapedDevice(IT_DEVICE_SCRAP_DETAILDTO detail)
	{
		IT_DEVICE_SCRAP_DETAIL scrapDetailPOCO = scrapDetailRepository.GetByKey(detail.IT_DEVICE_SCRAP_DETAIL_ID);
		if (scrapDetailPOCO != null)
		{
			if (detail.BUYER_ID.HasValue)
			{
				scrapDetailPOCO.BUYER_ID = detail.BUYER_ID;
				scrapDetailPOCO.BUY_DATE = DateTime.Now;
			}
			else
			{
				scrapDetailPOCO.BUYER_ID = null;
				scrapDetailPOCO.NOT_BUY = 1m;
				scrapDetailPOCO.BUY_DATE = DateTime.Now;
			}
			scrapDetailRepository.UpdateCommit(scrapDetailPOCO);
		}
		return true;
	}

	public bool ConfirmDevicePayment(IT_DEVICE_SCRAP_DETAILDTO detail)
	{
		IT_DEVICE_SCRAP_DETAIL scrapDetailPOCO = scrapDetailRepository.GetByKey(detail.IT_DEVICE_SCRAP_DETAIL_ID);
		if (scrapDetailPOCO != null)
		{
			scrapDetailPOCO.PAYMENT_STATUS = 1m;
			scrapDetailPOCO.PAYMENT_DATE = DateTime.Now;
			scrapDetailRepository.UpdateCommit(scrapDetailPOCO);
		}
		return true;
	}

	private void NotifyNewScrap(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		if (ConfigurationManager.System.Settings.GetSetting("EnableJPush", defaultValue: false))
		{
			SendByJPushDelegate delJPush = SendByJPush;
			delJPush.BeginInvoke(scrapDTO, null, null);
		}
		if (ConfigurationManager.System.Settings.GetSetting("EnableSendMessage", defaultValue: false))
		{
			SendBySMSDelegate delSMS = SendBySMS;
			delSMS.BeginInvoke(scrapDTO, null, null);
		}
	}

	private void SendByJPush(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		string AppKey = ConfigurationManager.System.Settings.GetSetting<string>("AppKey");
		string MasterSecret = ConfigurationManager.System.Settings.GetSetting<string>("MasterSecret");
		JPushClient client = new JPushClient(AppKey, MasterSecret);
		PushPayload pushLoad = new PushPayload();
		pushLoad.platform = Platform.all();
		pushLoad.audience = Audience.s_alias(GetUserIdArray(scrapDTO));
		pushLoad.ResetOptionsApnsProduction(apnsProduction: true);
		string message = $"您好，{scrapDTO.TITLE}已经开始，请您在中国石油审计服务中心协同办公系统“个人办公->个人业务->设备报废”菜单中查看。";
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

	private void SendBySMS(IT_DEVICE_SCRAPDTO scrapDTO)
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
		string Content = "";
		foreach (XmlNode node in xn.ChildNodes)
		{
			XmlElement element = (XmlElement)node;
			if (element.GetAttribute("Type") == "ScrapStart")
			{
				Content = string.Format(element.SelectSingleNode("Text").InnerText, scrapDTO.TITLE);
				break;
			}
		}
		MessageService messageService = new MessageService();
		messageService.SendToMessage(() => new MessageInfo
		{
			Mobile = GetPhoneArray(scrapDTO),
			Sn = Sn,
			Pwd = Pwd,
			Content = Content
		}, scrapDTO.IT_DEVICE_SCRAP_ID, null, IP, browserName);
	}

	private string[] GetUserIdArray(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		List<string> list = new List<string>();
		IList<CONTACTDTO> contactList = SqlQuery<CONTACTDTO>("GetAllContactList", new { scrapDTO.SUB_CENTER });
		foreach (CONTACTDTO contact in contactList)
		{
			if (contact.USER_ID.HasValue)
			{
				list.Add(contact.USER_ID.Value.ToString().Replace("-", "").ToLower());
			}
		}
		return list.ToArray();
	}

	private string[] GetPhoneArray(IT_DEVICE_SCRAPDTO scrapDTO)
	{
		List<string> list = new List<string>();
		IList<CONTACTDTO> contactList = SqlQuery<CONTACTDTO>("GetAllContactList", new { scrapDTO.SUB_CENTER });
		foreach (CONTACTDTO contact in contactList)
		{
			if (!string.IsNullOrEmpty(contact.MOBILE) && CheckPhoneIsAble(contact.MOBILE))
			{
				list.Add(contact.MOBILE);
			}
		}
		return list.ToArray();
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

	public CONTACTDTO GetContactByUserId(Guid userId)
	{
		return SqlQuery<CONTACTDTO>("GetAllContactList", new
		{
			USER_ID = userId
		}).FirstOrDefault();
	}
}
