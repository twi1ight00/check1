using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.ScheduleManagement.Application.DTO;
using Richfit.Garnet.Module.ScheduleManagement.Application.Services;

namespace Richfit.Garnet.Module.ScheduleManagement.HandlerProcess.Handlers;

public class ScheduleHandler : HandlerBase
{
	private IScheduleService scheduleService = ServiceLocator.Instance.GetService<IScheduleService>();

	public override void ProcessRequest(HttpContext context)
	{
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "ScheduleManagement_AddSchedule":
					AddSchedule(handlerResult);
					break;
				case "ScheduleManagement_UpdateSchedule":
					UpdateSchedule(handlerResult);
					break;
				case "ScheduleManagement_RemoveSchedule":
					RemoveSchedule(handlerResult);
					break;
				case "ScheduleManagement_GetScheduleByKey":
					GetScheduleByKey(handlerResult);
					break;
				case "ScheduleManagement_QueryScheduleList":
					QueryScheduleList(handlerResult);
					break;
				case "ScheduleManagement_GetScheduleCalendar":
					GetScheduleCalendar(handlerResult);
					break;
				case "ScheduleManagement_GetPersonScheduleCalendar":
					GetPersonScheduleCalendar(handlerResult);
					break;
				case "ScheduleManagement_GetParticipantsUserTree":
					GetParticipantsUserTree(handlerResult);
					break;
				case "ScheduleManagement_GetBelongerUserTree":
					GetBelongerUserTree(handlerResult);
					break;
				case "ScheduleManagement_QuickSaveSchedule":
					QuickSaveSchedule(handlerResult);
					break;
				case "ScheduleManagement_ChangeStateSchedule":
					ChangeStateSchedule(handlerResult);
					break;
				case "ScheduleManagement_GetWeekDutyLeader":
					GetWeekDutyLeader(handlerResult);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			handlerResult = HandleException(ex);
		}
		context.Response.Write(handlerResult.ToJson());
	}

	private void GetWeekDutyLeader(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = base.RequestData.Data.JsonDeserialize<SCH_INFODTO>(new JsonConverter[0]);
		handlerResult.Data = scheduleService.GetWeekDutyLeader(infoDTO);
	}

	private void ChangeStateSchedule(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = DTOBase.DeserializeFromJson<SCH_INFODTO>(base.RequestData.Data);
		handlerResult.Data = scheduleService.ChangeStateSchedule(infoDTO).ToJson();
	}

	private void QuickSaveSchedule(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = DTOBase.DeserializeFromJson<SCH_INFODTO>(base.RequestData.Data);
		handlerResult.Data = scheduleService.QuickSaveSchedule(infoDTO).ToJson();
	}

	private void GetBelongerUserTree(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid infoId = (string.IsNullOrEmpty(Dict["SCHEDULE_ID"]) ? Guid.Empty : Guid.Parse(Dict["SCHEDULE_ID"]));
		handlerResult.Data = scheduleService.GetBelongerUserTree(infoId).JsonSerialize();
	}

	private void GetParticipantsUserTree(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid infoId = (string.IsNullOrEmpty(Dict["SCHEDULE_ID"]) ? Guid.Empty : Guid.Parse(Dict["SCHEDULE_ID"]));
		handlerResult.Data = scheduleService.GetParticipantsUserTree(infoId).JsonSerialize();
	}

	private void GetScheduleCalendar(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = DTOBase.DeserializeFromJson<SCH_INFODTO>(base.RequestData.Data);
		infoDTO.END_TIME = infoDTO.END_TIME.Value.AddDays(1.0);
		QueryResult<SCH_INFODTO> result = scheduleService.GetScheduleCalendar(infoDTO);
		if (result.List.Count > 0)
		{
			List<SCH_INFODTO> list = (List<SCH_INFODTO>)result.List;
			Comparison<SCH_INFODTO> comparison = (SCH_INFODTO x, SCH_INFODTO y) => DateTime.Compare(x.BEGIN_TIME.Value, y.BEGIN_TIME.Value);
			list.Sort(comparison);
			result.List = list;
		}
		handlerResult.Data = result.ToJson();
	}

	private void GetPersonScheduleCalendar(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = DTOBase.DeserializeFromJson<SCH_INFODTO>(base.RequestData.Data);
		infoDTO.END_TIME = infoDTO.END_TIME.Value.AddDays(1.0);
		QueryResult<SCH_INFODTO> result = scheduleService.GetPersonScheduleCalendar(infoDTO);
		if (result.List.Count > 0)
		{
			List<SCH_INFODTO> list = (List<SCH_INFODTO>)result.List;
			Comparison<SCH_INFODTO> comparison = (SCH_INFODTO x, SCH_INFODTO y) => DateTime.Compare(x.BEGIN_TIME.Value, y.BEGIN_TIME.Value);
			list.Sort(comparison);
			result.List = list;
		}
		handlerResult.Data = result.ToJson();
	}

	private void AddSchedule(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = DTOBase.DeserializeFromJson<SCH_INFODTO>(base.RequestData.Data);
		DateTime startDate = infoDTO.BEGIN_TIME.Value;
		DateTime endDate = infoDTO.END_TIME.Value;
		startDate = startDate.AddHours(-startDate.GetHour());
		startDate = startDate.AddMinutes(-startDate.GetMinute());
		endDate = endDate.AddHours(-endDate.GetHour());
		endDate = endDate.AddMinutes(-endDate.GetMinute());
		if (endDate.Subtract(startDate).Days == 0)
		{
			handlerResult.Data = scheduleService.AddSchedule(infoDTO).ToJson();
			return;
		}
		while (endDate.Subtract(startDate).Days >= 0)
		{
			SCH_INFODTO dto = DTOBase.DeserializeFromJson<SCH_INFODTO>(base.RequestData.Data);
			DateTime MstartDate = dto.BEGIN_TIME.Value;
			DateTime MendDate = dto.END_TIME.Value;
			DateTime DTOStartDate = startDate;
			DateTime DTOEndDate = startDate;
			DTOStartDate = DTOStartDate.AddHours(MstartDate.GetHour()).AddMinutes(MstartDate.GetMinute());
			DTOEndDate = DTOEndDate.AddHours(MendDate.GetHour()).AddMinutes(MendDate.GetMinute());
			DateTime reserveDate = startDate;
			dto.BEGIN_TIME = DTOStartDate;
			dto.END_TIME = DTOEndDate;
			dto.SCHEDULE_DATE = reserveDate;
			handlerResult.Data = scheduleService.AddSchedule(dto).ToJson();
			startDate = startDate.AddDays(1.0);
		}
	}

	private void UpdateSchedule(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = DTOBase.DeserializeFromJson<SCH_INFODTO>(base.RequestData.Data);
		handlerResult.Data = scheduleService.UpdateSchedule(infoDTO).ToJson();
	}

	private void RemoveSchedule(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		scheduleService.RemoveSchedule(Dict["SCHEDULE_ID"]);
	}

	private void GetScheduleByKey(ResponseData handlerResult)
	{
		Dictionary<string, string> Dict = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		Guid infoId = (string.IsNullOrEmpty(Dict["SCHEDULE_ID"]) ? Guid.Empty : Guid.Parse(Dict["SCHEDULE_ID"]));
		handlerResult.Data = scheduleService.GetScheduleByKey(infoId).ToJson();
	}

	private void QueryScheduleList(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = base.RequestData.Data.JsonDeserialize<SCH_INFODTO>(new JsonConverter[0]);
		handlerResult.Data = scheduleService.QueryScheduleList(infoDTO).ToJson();
	}

	private void QueryPersonScheduleList(ResponseData handlerResult)
	{
		SCH_INFODTO infoDTO = base.RequestData.Data.JsonDeserialize<SCH_INFODTO>(new JsonConverter[0]);
		handlerResult.Data = scheduleService.QueryScheduleList(infoDTO).ToJson();
	}
}
