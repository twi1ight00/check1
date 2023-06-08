using System;
using System.Collections.Generic;
using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.push;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Module.SystemManagement.Application.Services.UserManagement;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.LM_VehicleScheduling.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_VehicleScheduling.Service;

public class VehicleScheduling_v1_Service : RunWorkflow, IRunWorkflow
{
	private ISystemUserService userService = ServiceLocator.Instance.GetService<ISystemUserService>();

	private static readonly ILogger logExp = LoggerManager.GetLogger("Exception");

	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		VehicleSchedulingDTO _vehicleschedulingdto = (string.IsNullOrEmpty(dataJson) ? ((VehicleSchedulingDTO)FindByInstanceId(instance.INSTANCE_ID)) : dataJson.JsonDeserialize<VehicleSchedulingDTO>(new JsonConverter[0]));
		switch (activity.ACTIVITY_CODE)
		{
		case "CLDD_END":
			_vehicleschedulingdto.LM_VEHICLE_SCHEDULING.CREATETIME = DateTime.Now;
			_vehicleschedulingdto.LM_VEHICLE_SCHEDULING.MODIFYTIME = DateTime.Now;
			repository.ExecuteCommand(new AC_LM_VEHICLE_SCHEDULING().AddSql, _vehicleschedulingdto.LM_VEHICLE_SCHEDULING);
			return true;
		case "CLDD_SCLD":
			return true;
		case "CLDD_HQSP":
			return true;
		case "CLDD_CZSP":
			return true;
		case "CLDD_DD":
			return true;
		case "CLDD_SQ":
			return true;
		case "CLDD_XCQR":
			return true;
		default:
			return true;
		}
	}

	public string InstanceName(string templateName, string dataJson)
	{
		VehicleSchedulingDTO _vehicleschedulingdto = dataJson.JsonDeserialize<VehicleSchedulingDTO>(new JsonConverter[0]);
		return string.Format("{0}[{1}]", templateName, DateTime.Now.ToString("yyyyMMddHHmmss"));
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		VehicleSchedulingDTO _vehicleschedulingdto = dataJson.JsonDeserialize<VehicleSchedulingDTO>(new JsonConverter[0]);
		if (_vehicleschedulingdto.IsCreate)
		{
			Add(_vehicleschedulingdto.LM_VEHICLE_SCHEDULING);
		}
		else
		{
			Update(_vehicleschedulingdto.LM_VEHICLE_SCHEDULING);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		if (activity.ACTIVITY_CODE == "CLDD_XCQR")
		{
			List<User> users = new List<User>();
			VehicleSchedulingDTO _vehicleschedulingdto = (string.IsNullOrEmpty(dataJson) ? ((VehicleSchedulingDTO)FindByInstanceId(instance.INSTANCE_ID)) : dataJson.JsonDeserialize<VehicleSchedulingDTO>(new JsonConverter[0]));
			users.Add(new User
			{
				CURRENT_USER_ID = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.DRIVER_ID.Value,
				CURRENT_USER_NAME = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.DRIVER
			});
			return users;
		}
		if (activity.ACTIVITY_CODE == "CLDD_SCLD")
		{
			VehicleSchedulingDTO _vehicleschedulingdto = (VehicleSchedulingDTO)FindByInstanceId(instance.INSTANCE_ID);
			List<User> users = new List<User>();
			if (_vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USER_ID.ToString().Equals(_vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USE_VEHICLE_USER.ToString()))
			{
				users.Add(new User
				{
					CURRENT_USER_ID = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USER_ID.Value,
					CURRENT_USER_NAME = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USER_NAME
				});
			}
			else
			{
				users.Add(new User
				{
					CURRENT_USER_ID = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USER_ID.Value,
					CURRENT_USER_NAME = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USER_NAME
				});
				users.Add(new User
				{
					CURRENT_USER_ID = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USE_VEHICLE_USER.Value,
					CURRENT_USER_NAME = _vehicleschedulingdto.LM_VEHICLE_SCHEDULING.USE_VEHICLE_USERNAME
				});
			}
			if (users.Count == 0)
			{
				return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
			}
			return users;
		}
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		VehicleSchedulingDTO _vehicleschedulingdto = new VehicleSchedulingDTO();
		_vehicleschedulingdto.LM_VEHICLE_SCHEDULING = FindByInstanceId<LM_VEHICLE_SCHEDULING>(instanceId);
		return _vehicleschedulingdto;
	}

	private void SendPushToMobile(WF_INSTANCE currentInstance, User CurUser, WF_ACTIVITY activity)
	{
		_ = CurUser.CURRENT_USER_ID;
		if (CurUser.CURRENT_USER_NAME != null)
		{
			string AppKey = ConfigurationManager.System.Settings.GetSetting<string>("AppKey");
			string MasterSecret = ConfigurationManager.System.Settings.GetSetting<string>("MasterSecret");
			string MessageContent = ConfigurationManager.System.Settings.GetSetting<string>("MessageContent");
			JPushClient client = new JPushClient(AppKey, MasterSecret);
			PushPayload pushLoad = new PushPayload();
			pushLoad.platform = Platform.all();
			pushLoad.ResetOptionsApnsProduction(apnsProduction: true);
			pushLoad.audience = Audience.s_alias(CurUser.CURRENT_USER_ID.ToString().Replace("-", "").ToLower());
			AndroidNotification androidNotification = new AndroidNotification().AddExtra("Type", "Message").AddExtra("TemplateID", activity.TEMPLATE_ID).AddExtra("INSTANCE_NAME", currentInstance.INSTANCE_NAME)
				.AddExtra("PROXY_USER_ID", CurUser.CURRENT_USER_ID)
				.AddExtra("PROXY_USER_NAME", CurUser.CURRENT_USER_NAME)
				.AddExtra("PROXY_ORG_ID", currentInstance.ORG_ID)
				.AddExtra("PROXY_ORG_NAME", currentInstance.ORG_NAME);
			IosNotification iosNotification = new IosNotification().AddExtra("Type", "Message").AddExtra("TemplateID", activity.TEMPLATE_ID).AddExtra("INSTANCE_NAME", currentInstance.INSTANCE_NAME)
				.AddExtra("PROXY_USER_ID", CurUser.CURRENT_USER_ID)
				.AddExtra("PROXY_USER_NAME", CurUser.CURRENT_USER_NAME)
				.AddExtra("PROXY_ORG_ID", currentInstance.ORG_ID)
				.AddExtra("PROXY_ORG_NAME", currentInstance.ORG_NAME);
			pushLoad.notification = new Notification().setAlert(MessageContent).setAndroid(androidNotification).setIos(iosNotification);
			try
			{
				MessageResult result = client.SendPush(pushLoad);
			}
			catch (APIRequestException e2)
			{
				logExp.Error("Error response from JPush server. Should review and fix it.");
				logExp.Error("HTTP Status: " + e2.Status);
				logExp.Error("Error Code: " + e2.ErrorCode);
				logExp.Error("Error Message: " + e2.ErrorMessage);
				logExp.Error("Audience: " + CurUser.CURRENT_USER_NAME);
			}
			catch (APIConnectionException e)
			{
				logExp.Error("Failed to establish JPush API connection.");
				logExp.Error(e.Message);
			}
		}
	}
}
