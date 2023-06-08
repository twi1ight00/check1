using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.IT_DEVICEREPAIR.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_DEVICEREPAIR.Service;

public class IT_DeviceRepair_Service : RunWorkflow, IRunWorkflow
{
	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			IT_DEVICEREPAIRDTO _it_devicerepairdto = dataJson.JsonDeserialize<IT_DEVICEREPAIRDTO>(new JsonConverter[0]);
		}
		else
		{
			IT_DEVICEREPAIRDTO _it_devicerepairdto = (IT_DEVICEREPAIRDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"FQ" => true, 
			"END" => true, 
			"XXCSL" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		IT_DEVICEREPAIRDTO _it_devicerepairdto = dataJson.JsonDeserialize<IT_DEVICEREPAIRDTO>(new JsonConverter[0]);
		return $"{templateName}[{_it_devicerepairdto.IT_DEVICE_REPAIR.USER_NAME}]";
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		IT_DEVICEREPAIRDTO _it_devicerepairdto = dataJson.JsonDeserialize<IT_DEVICEREPAIRDTO>(new JsonConverter[0]);
		if (_it_devicerepairdto.IsCreate)
		{
			Add(_it_devicerepairdto.IT_DEVICE_REPAIR);
		}
		else
		{
			Update(_it_devicerepairdto.IT_DEVICE_REPAIR);
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		IT_DEVICEREPAIRDTO _it_devicerepairdto = new IT_DEVICEREPAIRDTO();
		_it_devicerepairdto.IT_DEVICE_REPAIR = FindByInstanceId<IT_DEVICE_REPAIR>(instanceId);
		return _it_devicerepairdto;
	}
}
