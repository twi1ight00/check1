using System;
using System.Collections.Generic;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.ScheduleManagement.Application.DTO;

namespace Richfit.Garnet.Module.ScheduleManagement.Application.Services;

public interface IScheduleService
{
	SCH_INFODTO AddSchedule(SCH_INFODTO infoDTO);

	SCH_INFODTO UpdateSchedule(SCH_INFODTO infoDTO);

	void RemoveSchedule(string infoIds);

	SCH_INFODTO GetScheduleByKey(Guid infoId);

	QueryResult<SCH_INFODTO> QueryScheduleList(SCH_INFODTO infoDTO);

	QueryResult<SCH_INFODTO> GetScheduleCalendar(SCH_INFODTO queryCondition);

	QueryResult<SCH_INFODTO> GetPersonScheduleCalendar(SCH_INFODTO queryCondition);

	IList<TREE_NODE> GetParticipantsUserTree(Guid infoId);

	IList<TREE_NODE> GetBelongerUserTree(Guid infoId);

	SCH_INFODTO QuickSaveSchedule(SCH_INFODTO infoDTO);

	SCH_INFODTO ChangeStateSchedule(SCH_INFODTO infoDTO);

	string GetWeekDutyLeader(SCH_INFODTO infoDTO);
}
