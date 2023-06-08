using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.MeetingManagement.Application.DTO;
using Richfit.Garnet.Module.MeetingManagement.Application.Services;

namespace Richfit.Garnet.Module.MeetingManagement.HandlerProcess.Handlers;

public class MeetingHandler : HandlerBase
{
	private IMeetingService meetingService = ServiceLocator.Instance.GetService<IMeetingService>();

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
				case "MeetingManagement_AddMeetingRecord":
					AddMeetingRecord(handlerResult);
					break;
				case "MeetingManagement_UpdateMeetingRecord":
					UpdateMeetingRecord(handlerResult);
					break;
				case "MeetingManagement_DeleteMeetingRecord":
					DeleteMeetingRecord(handlerResult);
					break;
				case "MeetingManagement_ExportMeetingRecordList":
					ExportMeetingRecordList(handlerResult);
					break;
				case "MeetingManagement_QueryMeetingRecordList":
					QueryMeetingRecordList(handlerResult);
					break;
				case "MeetingManagement_QueryMeetingRecordSimple":
					QueryMeetingRecordSimple(handlerResult);
					break;
				case "MeetingManagement_QueryMeetingRecordAdvance":
					QueryMeetingRecordAdvance(handlerResult);
					break;
				case "MeetingManagement_MeetingRecordMission":
					MeetingRecordMission(handlerResult);
					break;
				case "MeetingManagement_GetMeetingRecordByKeyID":
					GetMeetingRecordByKeyID(handlerResult);
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

	private void GetMeetingRecordByKeyID(ResponseData handlerResult)
	{
	}

	private void AddMeetingRecord(ResponseData handlerResult)
	{
		MM_MEETING_APPLYDTO meetingDTO = DTOBase.DeserializeFromJson<MM_MEETING_APPLYDTO>(base.RequestData.Data);
		DateTime startDate = meetingDTO.BEGIN_TIME.Value;
		DateTime endDate = meetingDTO.END_TIME.Value;
		startDate = startDate.AddHours(-startDate.GetHour());
		startDate = startDate.AddMinutes(-startDate.GetMinute());
		endDate = endDate.AddHours(-endDate.GetHour());
		endDate = endDate.AddMinutes(-endDate.GetMinute());
		if (endDate.Subtract(startDate).Days == 0)
		{
			handlerResult.Data = meetingService.AddMeetingRecord(meetingDTO).ToJson();
			return;
		}
		while (endDate.Subtract(startDate).Days >= 0)
		{
			MM_MEETING_APPLYDTO dto = DTOBase.DeserializeFromJson<MM_MEETING_APPLYDTO>(base.RequestData.Data);
			DateTime MstartDate = dto.BEGIN_TIME.Value;
			DateTime MendDate = dto.END_TIME.Value;
			DateTime DTOStartDate = startDate;
			DateTime DTOEndDate = startDate;
			DTOStartDate = DTOStartDate.AddHours(MstartDate.GetHour()).AddMinutes(MstartDate.GetMinute());
			DTOEndDate = DTOEndDate.AddHours(MendDate.GetHour()).AddMinutes(MendDate.GetMinute());
			DateTime reserveDate = startDate;
			dto.BEGIN_TIME = DTOStartDate;
			dto.END_TIME = DTOEndDate;
			dto.RESERVE_DATE = reserveDate;
			handlerResult.Data = meetingService.AddMeetingRecord(dto).ToJson();
			startDate = startDate.AddDays(1.0);
		}
	}

	private void MeetingRecordMission(ResponseData handlerResult)
	{
	}

	private void QueryMeetingRecordAdvance(ResponseData handlerResult)
	{
	}

	private void QueryMeetingRecordSimple(ResponseData handlerResult)
	{
	}

	private void QueryMeetingRecordList(ResponseData handlerResult)
	{
		MM_MEETING_APPLYDTO condition = base.RequestData.Data.JsonDeserialize<MM_MEETING_APPLYDTO>(new JsonConverter[0]);
		handlerResult.Data = meetingService.QueryMeetingRecordList(condition).ToJson();
	}

	private void ExportMeetingRecordList(ResponseData handlerResult)
	{
	}

	private void DeleteMeetingRecord(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		meetingService.DeleteMeetingRecordByKeyIDs(dictionary["MEETING_APPLY_ID"]);
	}

	private void UpdateMeetingRecord(ResponseData handlerResult)
	{
		MM_MEETING_APPLYDTO meetingDTO = DTOBase.DeserializeFromJson<MM_MEETING_APPLYDTO>(base.RequestData.Data);
		handlerResult.Data = meetingService.UpdateMeetingRecord(meetingDTO).ToJson();
	}
}
