using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.MeetingManagement.Application.DTO;

namespace Richfit.Garnet.Module.MeetingManagement.Application.Services;

public interface IMeetingService
{
	QueryResult<MM_MEETING_APPLYDTO> QueryMeetingRecordList(MM_MEETING_APPLYDTO queryCondition);

	MM_MEETING_APPLYDTO AddMeetingRecord(MM_MEETING_APPLYDTO meetingDTO);

	MM_MEETING_APPLYDTO UpdateMeetingRecord(MM_MEETING_APPLYDTO meetingDTO);

	void DeleteMeetingRecordByKeyIDs(string keyIds);
}
