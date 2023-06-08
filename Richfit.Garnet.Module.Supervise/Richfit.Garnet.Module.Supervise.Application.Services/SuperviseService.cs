using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;
using Richfit.Garnet.Module.MessageCenter.Application.DTO;
using Richfit.Garnet.Module.MessageCenter.Application.Services;
using Richfit.Garnet.Module.SiteMessage.Application.DTO;
using Richfit.Garnet.Module.SiteMessage.Application.Services;
using Richfit.Garnet.Module.SiteMessage.Domain.Models;
using Richfit.Garnet.Module.Supervise.Application.DTO;
using Richfit.Garnet.Module.Supervise.Domain.Models;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;

namespace Richfit.Garnet.Module.Supervise.Application.Services;

public class SuperviseService : ServiceBase, ISuperviseService
{
	private readonly IRepository<SUP_TASK_USER> supTaskUserRepository;

	private readonly IRepository<SUP_PORJECT_USER> supPorjectUserRepository;

	private readonly IRepository<SUP_PORJECT> supPorjectRepository;

	private readonly IRepository<SUP_FEED_BACK> supFeedBackRepository;

	private readonly IRepository<SUP_CHANGE> supChangeRepository;

	private readonly IRepository<SUP_ASSIGN_TASK> supAssignTaskRepository;

	private readonly IRepository<SUP_TASK_PROGRESS> supTaskProgressRepository;

	public SuperviseService()
	{
		supAssignTaskRepository = ServiceLocator.Instance.GetService<IRepository<SUP_ASSIGN_TASK>>();
		supChangeRepository = ServiceLocator.Instance.GetService<IRepository<SUP_CHANGE>>();
		supFeedBackRepository = ServiceLocator.Instance.GetService<IRepository<SUP_FEED_BACK>>();
		supPorjectRepository = ServiceLocator.Instance.GetService<IRepository<SUP_PORJECT>>();
		supPorjectUserRepository = ServiceLocator.Instance.GetService<IRepository<SUP_PORJECT_USER>>();
		supTaskUserRepository = ServiceLocator.Instance.GetService<IRepository<SUP_TASK_USER>>();
		supTaskProgressRepository = ServiceLocator.Instance.GetService<IRepository<SUP_TASK_PROGRESS>>();
	}

	public SUP_ASSIGN_TASKDTO AddTask(SUP_ASSIGN_TASKDTO taskDTO)
	{
		if (taskDTO.IsValid())
		{
			SUP_ASSIGN_TASK taskPOCO = taskDTO.AdaptAsEntity<SUP_ASSIGN_TASK>();
			taskPOCO.IS_EXCEED = 0m;
			taskPOCO.TASK_TYPE = 2m;
			supAssignTaskRepository.AddCommit(taskPOCO);
			taskDTO = taskPOCO.AdaptAsDTO<SUP_ASSIGN_TASKDTO>();
			return taskDTO;
		}
		throw new ValidationException(taskDTO.GetInvalidMessages());
	}

	public SUP_ASSIGN_TASKDTO UpdateTask(SUP_ASSIGN_TASKDTO taskDTO)
	{
		if (taskDTO != null && taskDTO.ASSIGN_TASK_ID != Guid.Empty)
		{
			if (taskDTO.IsValid())
			{
				IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.PARENT_ASSIGN_TASK_ID == taskDTO.ASSIGN_TASK_ID);
				List<SUP_ASSIGN_TASK> addList = new List<SUP_ASSIGN_TASK>();
				List<Guid> updateTaskList = new List<Guid>();
				taskDTO.CHILD_TASK.ForEach(delegate(SUP_ASSIGN_TASKDTO task)
				{
					if (task.ASSIGN_TASK_ID == Guid.Empty)
					{
						SUP_ASSIGN_TASK sUP_ASSIGN_TASK = task.AdaptAsEntity<SUP_ASSIGN_TASK>();
						sUP_ASSIGN_TASK.ASSIGN_TASK_ID = Guid.NewGuid();
						sUP_ASSIGN_TASK.PARENT_ASSIGN_TASK_ID = taskDTO.ASSIGN_TASK_ID;
						sUP_ASSIGN_TASK.PORJECT_ID = taskDTO.PORJECT_ID;
						sUP_ASSIGN_TASK.IS_EXCEED = 0m;
						sUP_ASSIGN_TASK.TASK_TYPE = 2m;
						sUP_ASSIGN_TASK.TASK_STATUS = 1m;
						sUP_ASSIGN_TASK.SUP_TASK_USER.ToList().ForEach(delegate(SUP_TASK_USER taskUser)
						{
							taskUser.TASK_USER_ID = Guid.Empty;
							taskUser.ASSIGN_TASK_ID = Guid.Empty;
						});
						addList.Add(sUP_ASSIGN_TASK);
					}
					else
					{
						updateTaskList.Add(task.ASSIGN_TASK_ID);
					}
				});
				taskList.ToList().ForEach(delegate(SUP_ASSIGN_TASK task)
				{
					if (updateTaskList.Contains(task.ASSIGN_TASK_ID))
					{
						SUP_ASSIGN_TASKDTO sUP_ASSIGN_TASKDTO = taskDTO.CHILD_TASK.Find((SUP_ASSIGN_TASKDTO t) => t.ASSIGN_TASK_ID == task.ASSIGN_TASK_ID);
						if (sUP_ASSIGN_TASKDTO != null)
						{
							SUP_ASSIGN_TASK byKey = supAssignTaskRepository.GetByKey(task.ASSIGN_TASK_ID);
							supAssignTaskRepository.RemoveChild(byKey.SUP_TASK_USER);
							supAssignTaskRepository.UpdateCommit(byKey, "SUP_TASK_USER");
							sUP_ASSIGN_TASKDTO.SUP_TASK_USER.ToList().ForEach(delegate(SUP_TASK_USERDTO taskUser)
							{
								SUP_TASK_USER sUP_TASK_USER = taskUser.AdaptAsEntity<SUP_TASK_USER>();
								sUP_TASK_USER.ASSIGN_TASK_ID = task.ASSIGN_TASK_ID;
								supTaskUserRepository.AddCommit(sUP_TASK_USER);
							});
							byKey.BEGIN_TIME = sUP_ASSIGN_TASKDTO.BEGIN_TIME;
							byKey.END_TIME = sUP_ASSIGN_TASKDTO.END_TIME;
							byKey.WORK_TITLE = sUP_ASSIGN_TASKDTO.WORK_TITLE;
							byKey.HAND_REQUIREMENT = sUP_ASSIGN_TASKDTO.HAND_REQUIREMENT;
							byKey.SORT = sUP_ASSIGN_TASKDTO.SORT;
						}
					}
					else
					{
						RemoveChildTask(task.ASSIGN_TASK_ID);
					}
				});
				addList.ForEach(delegate(SUP_ASSIGN_TASK task)
				{
					supAssignTaskRepository.AddCommit(task);
				});
				addList.ForEach(delegate(SUP_ASSIGN_TASK task)
				{
					task.TASK_STATUS = 0m;
					SendTaskMessage(task);
					task.TASK_STATUS = 1m;
				});
				supAssignTaskRepository.DbContext.Commit();
				taskDTO = GetTaskByKey(taskDTO.ASSIGN_TASK_ID);
				return taskDTO;
			}
			throw new ValidationException("SystemManagement.Public.V_0004");
		}
		throw new ValidationException(taskDTO.GetInvalidMessages());
	}

	public void RemoveTask(string taskIds)
	{
		string[] taskIdArray = taskIds.Split(',');
		if (taskIdArray != null && taskIdArray.Any())
		{
			taskIdArray.ToList().ForEach(delegate(string taskId)
			{
				RemoveChildTask(Guid.Parse(taskId));
			});
			supAssignTaskRepository.DbContext.Commit();
		}
	}

	public SUP_ASSIGN_TASKDTO GetTaskByKey(Guid taskId)
	{
		SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(taskId);
		SUP_ASSIGN_TASKDTO taskDTO = taskPOCO.AdaptAsDTO<SUP_ASSIGN_TASKDTO>();
		IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.PARENT_ASSIGN_TASK_ID == taskDTO.ASSIGN_TASK_ID);
		List<SUP_ASSIGN_TASKDTO> taskDTOList = new List<SUP_ASSIGN_TASKDTO>();
		taskList.ToList().ForEach(delegate(SUP_ASSIGN_TASK task)
		{
			taskDTOList.Add(task.AdaptAsDTO<SUP_ASSIGN_TASKDTO>());
		});
		IOrderedEnumerable<SUP_ASSIGN_TASKDTO> childTask = from task in taskDTOList
			where task.ISDEL == 0m
			orderby task.SORT
			select task;
		if (childTask != null)
		{
			List<SUP_ASSIGN_TASKDTO> childTaskDTOList = new List<SUP_ASSIGN_TASKDTO>();
			childTaskDTOList = childTask.ToList();
			childTaskDTOList.ForEach(delegate(SUP_ASSIGN_TASKDTO task)
			{
				task = GetTaskDetail(task);
			});
			taskDTO.CHILD_TASK = childTaskDTOList;
		}
		return GetTaskDetail(taskDTO);
	}

	public SUP_ASSIGN_TASKDTO GetTaskDetail(SUP_ASSIGN_TASKDTO taskDTO)
	{
		IOrderedEnumerable<SUP_CHANGEDTO> changeList = taskDTO.SUP_CHANGE.OrderByDescending((SUP_CHANGEDTO change) => change.CREATETIME);
		if (changeList.Count() > 0)
		{
			taskDTO.SUP_CHANGE = changeList.ToList();
		}
		IOrderedEnumerable<SUP_FEED_BACKDTO> feedList = taskDTO.SUP_FEED_BACK.OrderByDescending((SUP_FEED_BACKDTO feed) => feed.CREATETIME);
		if (feedList.Count() > 0)
		{
			taskDTO.SUP_FEED_BACK = feedList.ToList();
		}
		IOrderedEnumerable<SUP_TASK_PROGRESSDTO> taskProgressList = taskDTO.SUP_TASK_PROGRESS.OrderByDescending((SUP_TASK_PROGRESSDTO progress) => progress.CREATETIME);
		if (taskProgressList.Count() > 0)
		{
			taskDTO.SUP_TASK_PROGRESS = taskProgressList.ToList();
		}
		return taskDTO;
	}

	public QueryResult<SUP_ASSIGN_TASKDTO> QueryTaskList(SUP_ASSIGN_TASKDTO taskDTO)
	{
		taskDTO.USER_ID = SessionContext.UserInfo.UserID;
		QueryResult<SUP_ASSIGN_TASKDTO> result = SqlQueryPager<SUP_ASSIGN_TASKDTO>("QueryTaskList", taskDTO, (string a) => a.Replace("@STR_TASK_STATUS", taskDTO.STR_TASK_STATUS));
		foreach (SUP_ASSIGN_TASKDTO task in result.List)
		{
			IList<SUP_ASSIGN_TASK> childTask = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.PARENT_ASSIGN_TASK_ID == task.ASSIGN_TASK_ID);
			task.CHILD_TASK_COUNT = childTask.Count();
			task.CHILD_TASK_TODO = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS7 = t.TASK_STATUS;
				return tASK_STATUS7.GetValueOrDefault() == 0m && tASK_STATUS7.HasValue;
			}).Count();
			task.CHILD_TASK_INDO = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS6 = t.TASK_STATUS;
				return tASK_STATUS6.GetValueOrDefault() == 1m && tASK_STATUS6.HasValue;
			}).Count();
			task.CHILD_TASK_APPLYFORCHANGE = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS5 = t.TASK_STATUS;
				return tASK_STATUS5.GetValueOrDefault() == 4m && tASK_STATUS5.HasValue;
			}).Count();
			task.CHILD_TASK_APPLYFORCOMPLETED = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS4 = t.TASK_STATUS;
				return tASK_STATUS4.GetValueOrDefault() == 2m && tASK_STATUS4.HasValue;
			}).Count();
			task.CHILD_TASK_COMPLETED = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS3 = t.TASK_STATUS;
				return tASK_STATUS3.GetValueOrDefault() == 3m && tASK_STATUS3.HasValue;
			}).Count();
			task.CHILD_TASK_UNDO = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS2 = t.TASK_STATUS;
				return tASK_STATUS2.GetValueOrDefault() == 5m && tASK_STATUS2.HasValue;
			}).Count();
			task.CHILD_TASK_ABNORMALCOMPLETION = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS = t.TASK_STATUS;
				return tASK_STATUS.GetValueOrDefault() == 6m && tASK_STATUS.HasValue;
			}).Count();
			IOrderedEnumerable<SUP_FEED_BACK> feedList = from feed in supFeedBackRepository.FindAll((SUP_FEED_BACK t) => t.ISDEL == 0m && t.ASSIGN_TASK_ID == task.ASSIGN_TASK_ID)
				orderby feed.CREATETIME descending
				select feed;
			if (feedList != null && feedList.Count() > 0)
			{
				IList<SUP_FEED_BACK> feedBackList = feedList.ToList();
				task.FEED_BACK_TIME = feedBackList[0].CREATETIME;
			}
		}
		return result;
	}

	public QueryResult<SUP_ASSIGN_TASKDTO> QueryTaskStatusList(SUP_ASSIGN_TASKDTO taskDTO)
	{
		taskDTO.USER_ID = SessionContext.UserInfo.UserID;
		return SqlQueryPager<SUP_ASSIGN_TASKDTO>("QueryTaskStatusList", taskDTO, (string a) => a.Replace("@STR_TASK_STATUS", taskDTO.STR_TASK_STATUS));
	}

	public QueryResult<SUP_ASSIGN_TASKDTO> QueryApprovalChangeList(SUP_ASSIGN_TASKDTO taskDTO)
	{
		return SqlQueryPager<SUP_ASSIGN_TASKDTO>("QueryApprovalChangeList", taskDTO);
	}

	public void ChangeTaskStatus(Guid taskId, int status)
	{
		SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(taskId);
		if (taskPOCO == null)
		{
			return;
		}
		taskPOCO.TASK_STATUS = status;
		if (status == 2)
		{
			taskPOCO.APPLY_COPLETION_TIME = DateTime.Now;
		}
		if (status == 3)
		{
			if (!taskPOCO.APPLY_COPLETION_TIME.HasValue)
			{
				taskPOCO.TASK_STATUS = 3m;
			}
			else if (!taskPOCO.PARENT_ASSIGN_TASK_ID.HasValue)
			{
				taskPOCO.TASK_STATUS = 3m;
			}
			else
			{
				DateTime value = DateTime.Parse(taskPOCO.APPLY_COPLETION_TIME.Value.ToString("yyyy-MM-dd 00:00:00"));
				DateTime? eND_TIME = taskPOCO.END_TIME;
				if (value >= eND_TIME)
				{
					taskPOCO.TASK_STATUS = 7m;
				}
				else
				{
					taskPOCO.TASK_STATUS = 3m;
				}
			}
		}
		if (status == 6 || status == 3 || status == 5)
		{
			DateTime dtFinishTime = DateTime.Now;
			taskPOCO.FINISH_TIME = dtFinishTime;
			SUP_ASSIGN_TASK sUP_ASSIGN_TASK = taskPOCO;
			DateTime value = DateTime.Parse(taskPOCO.FINISH_TIME.Value.ToString("yyyy-MM-dd 00:00:00"));
			DateTime? eND_TIME = taskPOCO.END_TIME;
			sUP_ASSIGN_TASK.IS_EXCEED = ((!(value <= eND_TIME)) ? 1 : 0);
			if (!taskPOCO.PARENT_ASSIGN_TASK_ID.HasValue)
			{
				decimal? tASK_TYPE = taskPOCO.TASK_TYPE;
				if (tASK_TYPE.GetValueOrDefault() == 1m && tASK_TYPE.HasValue)
				{
					int superviseStatus = status switch
					{
						6 => 3, 
						3 => 1, 
						_ => 2, 
					};
					SUP_PORJECT projectPOCO = supPorjectRepository.GetByKey(taskPOCO.PORJECT_ID);
					if (projectPOCO != null)
					{
						projectPOCO.SUPERVISE_STATUS = superviseStatus;
						projectPOCO.FINISH_TIME = dtFinishTime;
						value = DateTime.Parse(projectPOCO.FINISH_TIME.Value.ToString("yyyy-MM-dd 00:00:00"));
						eND_TIME = projectPOCO.END_TIME;
						projectPOCO.IS_EXCEED = ((!(value <= eND_TIME)) ? 1 : 0);
						supPorjectRepository.UpdateCommit(projectPOCO);
					}
					if (status == 3)
					{
						SUP_ASSIGN_TASK supervisorTaskPOCO = supAssignTaskRepository.Find((SUP_ASSIGN_TASK t) => t.PORJECT_ID == taskPOCO.PORJECT_ID && t.TASK_TYPE == (decimal?)0m && t.ISDEL == 0m);
						if (supervisorTaskPOCO != null)
						{
							supervisorTaskPOCO.TASK_STATUS = status;
							supAssignTaskRepository.UpdateCommit(supervisorTaskPOCO);
						}
					}
				}
			}
			ChangeChildTaskAbnormalUnDoStatus(taskId, status);
		}
		supAssignTaskRepository.UpdateCommit(taskPOCO);
		SendTaskMessage(taskPOCO);
	}

	public void ChangeChildTaskAbnormalUnDoStatus(Guid taskId, int status)
	{
		List<SUP_ASSIGN_TASK> noCompleteList = new List<SUP_ASSIGN_TASK>();
		IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.PARENT_ASSIGN_TASK_ID != null);
		IEnumerable<SUP_ASSIGN_TASK> childTaskList = GetChildTask(taskList, taskId);
		DateTime dtFinishTime = DateTime.Now;
		foreach (SUP_ASSIGN_TASK task2 in childTaskList)
		{
			decimal? tASK_STATUS = task2.TASK_STATUS;
			if (tASK_STATUS.GetValueOrDefault() == 6m && tASK_STATUS.HasValue)
			{
				continue;
			}
			tASK_STATUS = task2.TASK_STATUS;
			if (!(tASK_STATUS.GetValueOrDefault() == 3m) || !tASK_STATUS.HasValue)
			{
				tASK_STATUS = task2.TASK_STATUS;
				if (!(tASK_STATUS.GetValueOrDefault() == 5m) || !tASK_STATUS.HasValue)
				{
					task2.TASK_STATUS = 6m;
					task2.FINISH_TIME = dtFinishTime;
					supAssignTaskRepository.Update(task2);
					noCompleteList.Add(task2);
				}
			}
		}
		supAssignTaskRepository.DbContext.Commit();
		if (status == 3 && noCompleteList.Count > 0)
		{
			noCompleteList.ForEach(delegate(SUP_ASSIGN_TASK task)
			{
				SendSubTaskMessage(task);
			});
		}
	}

	public void ChangeChildTaskStatus(Guid taskId, int status)
	{
		SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(taskId);
		if (taskPOCO != null)
		{
			taskPOCO.TASK_STATUS = status;
			supAssignTaskRepository.Update(taskPOCO);
			IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m);
			IEnumerable<SUP_ASSIGN_TASK> childTaskList = GetChildTask(taskList, taskId);
			foreach (SUP_ASSIGN_TASK task in childTaskList)
			{
				task.TASK_STATUS = status;
				supAssignTaskRepository.Update(task);
			}
		}
		supAssignTaskRepository.DbContext.Commit();
	}

	public SUP_PORJECTDTO AddProject(SUP_PORJECTDTO projectDTO)
	{
		if (projectDTO.IsValid())
		{
			SUP_ASSIGN_TASKDTO supervisorTaskDTO = null;
			SUP_ASSIGN_TASKDTO taskDTO = new SUP_ASSIGN_TASKDTO();
			taskDTO.ASSIGN_TASK_ID = Guid.NewGuid();
			taskDTO.BEGIN_TIME = projectDTO.BEGIN_TIME;
			taskDTO.END_TIME = projectDTO.END_TIME;
			taskDTO.WORK_TITLE = projectDTO.WORK_TITLE;
			taskDTO.HAND_REQUIREMENT = projectDTO.HAND_REQUIREMENT;
			taskDTO.WORK_CONTENT = projectDTO.WORK_CONTENT;
			taskDTO.TASK_STATUS = 1m;
			taskDTO.IS_EXCEED = 0m;
			taskDTO.TASK_TYPE = 1m;
			List<SUP_TASK_USERDTO> userList = new List<SUP_TASK_USERDTO>();
			SUP_TASK_USERDTO user = new SUP_TASK_USERDTO();
			user.USER_ID = projectDTO.USER_ID;
			user.USER_NAME = projectDTO.USER_NAME;
			user.TYPE_ID = 0m;
			userList.Add(user);
			if (projectDTO.SUP_PORJECT_USER != null && projectDTO.SUP_PORJECT_USER.Count > 0 && projectDTO.SUP_PORJECT_USER[0].USER_ID != projectDTO.USER_ID)
			{
				supervisorTaskDTO = new SUP_ASSIGN_TASKDTO();
				supervisorTaskDTO.ASSIGN_TASK_ID = Guid.NewGuid();
				supervisorTaskDTO.BEGIN_TIME = projectDTO.BEGIN_TIME;
				supervisorTaskDTO.END_TIME = projectDTO.END_TIME;
				supervisorTaskDTO.WORK_TITLE = projectDTO.WORK_TITLE;
				supervisorTaskDTO.HAND_REQUIREMENT = projectDTO.HAND_REQUIREMENT;
				supervisorTaskDTO.WORK_CONTENT = projectDTO.WORK_CONTENT;
				supervisorTaskDTO.TASK_STATUS = 1m;
				supervisorTaskDTO.IS_EXCEED = 0m;
				supervisorTaskDTO.TASK_TYPE = 0m;
				List<SUP_TASK_USERDTO> supervisorUserList = new List<SUP_TASK_USERDTO>();
				SUP_TASK_USERDTO supervisorUser = new SUP_TASK_USERDTO();
				supervisorUser.USER_ID = projectDTO.SUP_PORJECT_USER[0].USER_ID;
				supervisorUser.USER_NAME = projectDTO.SUP_PORJECT_USER[0].USER_NAME;
				supervisorUser.TYPE_ID = 0m;
				supervisorUserList.Add(supervisorUser);
				supervisorTaskDTO.SUP_TASK_USER = supervisorUserList;
			}
			taskDTO.SUP_TASK_USER = userList;
			if (projectDTO.SUP_ASSIGN_TASK.Count > 0)
			{
				projectDTO.SUP_ASSIGN_TASK.ForEach(delegate(SUP_ASSIGN_TASKDTO task)
				{
					task.PARENT_ASSIGN_TASK_ID = taskDTO.ASSIGN_TASK_ID;
					task.IS_EXCEED = 0m;
					task.TASK_STATUS = 1m;
					task.TASK_TYPE = 2m;
				});
			}
			projectDTO.SUP_ASSIGN_TASK.Add(taskDTO);
			if (supervisorTaskDTO != null)
			{
				projectDTO.SUP_ASSIGN_TASK.Add(supervisorTaskDTO);
			}
			SUP_PORJECT projectPOCO = projectDTO.AdaptAsEntity<SUP_PORJECT>();
			supPorjectRepository.AddCommit(projectPOCO);
			projectDTO = projectPOCO.AdaptAsDTO<SUP_PORJECTDTO>();
			IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.PARENT_ASSIGN_TASK_ID == taskDTO.ASSIGN_TASK_ID);
			taskList.ToList().ForEach(delegate(SUP_ASSIGN_TASK task)
			{
				task.TASK_STATUS = 0m;
				SendTaskMessage(task);
				task.TASK_STATUS = 1m;
			});
			return projectDTO;
		}
		throw new ValidationException(projectDTO.GetInvalidMessages());
	}

	public SUP_PORJECTDTO UpdateProject(SUP_PORJECTDTO projectDTO)
	{
		if (projectDTO.IsValid())
		{
			SUP_PORJECT projectPOCO = supPorjectRepository.GetByKey(projectDTO.PORJECT_ID);
			if (projectPOCO != null)
			{
				projectPOCO.SUPERVISE_TYPE = projectDTO.SUPERVISE_TYPE;
				projectPOCO.SUPERVISE_CLASSIFY = projectDTO.SUPERVISE_CLASSIFY;
				projectPOCO.ISSUED_ORGNAME = projectDTO.ISSUED_ORGNAME;
				projectPOCO.ISSUED_FILENUMBER = projectDTO.ISSUED_FILENUMBER;
				projectPOCO.FOCUS_ON = projectDTO.FOCUS_ON;
				projectPOCO.TIME_LIMIT = projectDTO.TIME_LIMIT;
				projectPOCO.PORJECT_TITLE = projectDTO.PORJECT_TITLE;
				projectPOCO.LEADER_INSTRUCTION = projectDTO.LEADER_INSTRUCTION;
				projectPOCO.LEADER_NAME = projectDTO.LEADER_NAME;
				projectPOCO.BEGIN_TIME = projectDTO.BEGIN_TIME;
				projectPOCO.END_TIME = projectDTO.END_TIME;
				projectPOCO.WORK_CONTENT = projectDTO.WORK_TITLE;
				projectPOCO.HAND_REQUIREMENT = projectDTO.HAND_REQUIREMENT;
				supPorjectRepository.UpdateCommit(projectPOCO);
				List<SUP_ASSIGN_TASK> addList = new List<SUP_ASSIGN_TASK>();
				List<Guid> updateTaskList = new List<Guid>();
				SUP_ASSIGN_TASK rootTask = projectPOCO.SUP_ASSIGN_TASK.ToList().Find(delegate(SUP_ASSIGN_TASK t)
				{
					decimal? tASK_TYPE = t.TASK_TYPE;
					return tASK_TYPE.GetValueOrDefault() == 1m && tASK_TYPE.HasValue && !t.PARENT_ASSIGN_TASK_ID.HasValue && t.ISDEL == 0m;
				});
				projectDTO.SUP_ASSIGN_TASK.ForEach(delegate(SUP_ASSIGN_TASKDTO task)
				{
					if (!(task.ASSIGN_TASK_ID == Guid.Empty))
					{
						_ = task.ASSIGN_TASK_ID;
						if (0 == 0)
						{
							updateTaskList.Add(task.ASSIGN_TASK_ID);
							return;
						}
					}
					SUP_ASSIGN_TASK sUP_ASSIGN_TASK = task.AdaptAsEntity<SUP_ASSIGN_TASK>();
					sUP_ASSIGN_TASK.ASSIGN_TASK_ID = Guid.NewGuid();
					sUP_ASSIGN_TASK.PORJECT_ID = projectDTO.PORJECT_ID;
					sUP_ASSIGN_TASK.IS_EXCEED = 0m;
					sUP_ASSIGN_TASK.PARENT_ASSIGN_TASK_ID = rootTask.ASSIGN_TASK_ID;
					sUP_ASSIGN_TASK.TASK_STATUS = 1m;
					sUP_ASSIGN_TASK.TASK_TYPE = 2m;
					addList.Add(sUP_ASSIGN_TASK);
				});
				projectPOCO.SUP_ASSIGN_TASK.ToList().FindAll((SUP_ASSIGN_TASK t) => t.PARENT_ASSIGN_TASK_ID.HasValue && t.ISDEL == 0m).ForEach(delegate(SUP_ASSIGN_TASK task)
				{
					if (updateTaskList.Contains(task.ASSIGN_TASK_ID))
					{
						SUP_ASSIGN_TASKDTO sUP_ASSIGN_TASKDTO = projectDTO.SUP_ASSIGN_TASK.Find((SUP_ASSIGN_TASKDTO t) => t.ASSIGN_TASK_ID == task.ASSIGN_TASK_ID);
						if (sUP_ASSIGN_TASKDTO != null)
						{
							SUP_ASSIGN_TASK byKey = supAssignTaskRepository.GetByKey(task.ASSIGN_TASK_ID);
							supAssignTaskRepository.RemoveChild(byKey.SUP_TASK_USER);
							supAssignTaskRepository.UpdateCommit(byKey, "SUP_TASK_USER");
							sUP_ASSIGN_TASKDTO.SUP_TASK_USER.ToList().ForEach(delegate(SUP_TASK_USERDTO taskUser)
							{
								SUP_TASK_USER sUP_TASK_USER = taskUser.AdaptAsEntity<SUP_TASK_USER>();
								sUP_TASK_USER.ASSIGN_TASK_ID = task.ASSIGN_TASK_ID;
								supTaskUserRepository.AddCommit(sUP_TASK_USER);
							});
							byKey.BEGIN_TIME = sUP_ASSIGN_TASKDTO.BEGIN_TIME;
							byKey.END_TIME = sUP_ASSIGN_TASKDTO.END_TIME;
							byKey.WORK_TITLE = sUP_ASSIGN_TASKDTO.WORK_TITLE;
							byKey.HAND_REQUIREMENT = sUP_ASSIGN_TASKDTO.HAND_REQUIREMENT;
							byKey.SORT = sUP_ASSIGN_TASKDTO.SORT;
						}
					}
					else
					{
						RemoveChildTask(task.ASSIGN_TASK_ID);
					}
				});
				addList.ForEach(delegate(SUP_ASSIGN_TASK task)
				{
					supAssignTaskRepository.AddCommit(task);
				});
				addList.ForEach(delegate(SUP_ASSIGN_TASK task)
				{
					task.TASK_STATUS = 0m;
					SendTaskMessage(task);
					task.TASK_STATUS = 1m;
				});
				supAssignTaskRepository.DbContext.Commit();
				projectDTO = projectPOCO.AdaptAsDTO<SUP_PORJECTDTO>();
			}
			return projectDTO;
		}
		throw new ValidationException(projectDTO.GetInvalidMessages());
	}

	public void RemoveProject(string projectIds)
	{
		string[] projectIdArray = projectIds.Split(',');
		if (projectIdArray == null || !projectIdArray.Any())
		{
			return;
		}
		projectIdArray.ToList().ForEach(delegate(string projectId)
		{
			SUP_PORJECT byKey = supPorjectRepository.GetByKey(Guid.Parse(projectId));
			if (byKey != null)
			{
				byKey.ISDEL = 1m;
				supPorjectRepository.RemoveChild(byKey.SUP_PORJECT_USER);
				supPorjectRepository.UpdateCommit(byKey, "SUP_PORJECT_USER");
				byKey.SUP_ASSIGN_TASK.ToList().ForEach(delegate(SUP_ASSIGN_TASK task)
				{
					RemoveChildTask(task.ASSIGN_TASK_ID);
				});
				supPorjectRepository.Update(byKey);
			}
		});
		supPorjectRepository.DbContext.Commit();
	}

	public SUP_PORJECTDTO GetProjectByKey(Guid projectId)
	{
		SUP_PORJECT projectPOCO = supPorjectRepository.GetByKey(projectId);
		SUP_PORJECTDTO projectDTO = projectPOCO.AdaptAsDTO<SUP_PORJECTDTO>();
		projectDTO.USER_NAME = projectPOCO.SYS_USER1.DISPLAY_NAME;
		if (projectPOCO.SYS_USER != null)
		{
			projectDTO.SUPERVISOR_NAME = projectPOCO.SYS_USER.DISPLAY_NAME;
		}
		IEnumerable<SUP_ASSIGN_TASKDTO> parentTask = projectDTO.SUP_ASSIGN_TASK.Where((SUP_ASSIGN_TASKDTO task) => task.ISDEL == 0m && !task.PARENT_ASSIGN_TASK_ID.HasValue && task.TASK_TYPE == 1m);
		if (parentTask != null)
		{
			projectDTO.WORK_CONTENT = parentTask.ToList()[0].WORK_TITLE;
		}
		IOrderedEnumerable<SUP_ASSIGN_TASKDTO> taskList = from task in projectDTO.SUP_ASSIGN_TASK
			where task.ISDEL == 0m
			orderby task.SORT
			select task;
		List<SUP_ASSIGN_TASKDTO> childTask = taskList.ToList();
		childTask.ForEach(delegate(SUP_ASSIGN_TASKDTO task)
		{
			task = GetTaskDetail(task);
		});
		projectDTO.SUP_ASSIGN_TASK = childTask;
		return projectDTO;
	}

	public void ChangeProjectStatus(Guid projectId, int status)
	{
		SUP_PORJECT projectPOCO = supPorjectRepository.GetByKey(projectId);
		if (projectPOCO != null)
		{
			DateTime dtFinishTime = DateTime.Now;
			projectPOCO.SUPERVISE_STATUS = status;
			projectPOCO.FINISH_TIME = dtFinishTime;
			supPorjectRepository.Update(projectPOCO);
			if (status == 1)
			{
				SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.Find((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.PORJECT_ID == projectId && t.PARENT_ASSIGN_TASK_ID == null && t.TASK_TYPE == (decimal?)1m);
				if (taskPOCO != null)
				{
					taskPOCO.TASK_STATUS = 3m;
					taskPOCO.FINISH_TIME = dtFinishTime;
					supAssignTaskRepository.UpdateCommit(taskPOCO);
				}
			}
		}
		supPorjectRepository.DbContext.Commit();
	}

	public void ChangeProjectChildTaskStatus(Guid projectId, int status)
	{
		SUP_PORJECT projectPOCO = supPorjectRepository.GetByKey(projectId);
		int taskStatus = ((status != 1) ? 5 : 3);
		if (projectPOCO == null)
		{
			return;
		}
		DateTime dtFinishTime = DateTime.Now;
		IList<Guid> taskID = new List<Guid>();
		foreach (SUP_ASSIGN_TASK task in projectPOCO.SUP_ASSIGN_TASK)
		{
			taskID.Add(task.ASSIGN_TASK_ID);
		}
		foreach (SUP_ASSIGN_TASK childTask in projectPOCO.SUP_ASSIGN_TASK)
		{
			IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m);
			IEnumerable<SUP_ASSIGN_TASK> childTaskList = GetChildTask(taskList, childTask.ASSIGN_TASK_ID);
			foreach (SUP_ASSIGN_TASK task in childTaskList)
			{
				taskID.Add(task.ASSIGN_TASK_ID);
			}
		}
		foreach (Guid taskId in taskID)
		{
			SUP_ASSIGN_TASK task = supAssignTaskRepository.GetByKey(taskId);
			task.TASK_STATUS = taskStatus;
			task.FINISH_TIME = dtFinishTime;
			supAssignTaskRepository.UpdateCommit(task);
		}
		projectPOCO.SUPERVISE_STATUS = status;
		projectPOCO.FINISH_TIME = dtFinishTime;
		supPorjectRepository.UpdateCommit(projectPOCO);
	}

	public QueryResult<SUP_PORJECTDTO> QueryProjectList(SUP_PORJECTDTO projectDTO)
	{
		QueryResult<SUP_PORJECTDTO> result = SqlQueryPager<SUP_PORJECTDTO>("QueryProjectList", projectDTO, (string a) => a.Replace("@STR_SUPERVISE_STATUS", projectDTO.STR_SUPERVISE_STATUS));
		foreach (SUP_PORJECTDTO project in result.List)
		{
			IList<SUP_ASSIGN_TASK> childTask = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.ASSIGN_TASK_ID != null && t.PORJECT_ID == project.PORJECT_ID);
			project.PROJECT_TASK_COUNT = childTask.Count();
			project.PROJECT_TODO = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS7 = t.TASK_STATUS;
				return tASK_STATUS7.GetValueOrDefault() == 0m && tASK_STATUS7.HasValue;
			}).Count();
			project.PROJECT_INDO = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS6 = t.TASK_STATUS;
				return tASK_STATUS6.GetValueOrDefault() == 1m && tASK_STATUS6.HasValue;
			}).Count();
			project.PROJECT_APPLYFORCHANGE = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS5 = t.TASK_STATUS;
				return tASK_STATUS5.GetValueOrDefault() == 4m && tASK_STATUS5.HasValue;
			}).Count();
			project.PROJECT_APPLYFORCOMPLETED = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS4 = t.TASK_STATUS;
				return tASK_STATUS4.GetValueOrDefault() == 2m && tASK_STATUS4.HasValue;
			}).Count();
			project.PROJECT_COMPLETED = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS3 = t.TASK_STATUS;
				return tASK_STATUS3.GetValueOrDefault() == 3m && tASK_STATUS3.HasValue;
			}).Count();
			project.PROJECT_UNDO = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS2 = t.TASK_STATUS;
				return tASK_STATUS2.GetValueOrDefault() == 5m && tASK_STATUS2.HasValue;
			}).Count();
			project.PROJECT_ABNORMALCOMPLETION = childTask.Where(delegate(SUP_ASSIGN_TASK t)
			{
				decimal? tASK_STATUS = t.TASK_STATUS;
				return tASK_STATUS.GetValueOrDefault() == 6m && tASK_STATUS.HasValue;
			}).Count();
		}
		return result;
	}

	public QueryResult<SUP_PORJECTDTO> QueryMyProcessProject(SUP_PORJECTDTO projectDTO)
	{
		return SqlQueryPager<SUP_PORJECTDTO>("QueryMyProcessProject", projectDTO);
	}

	public IList<TREE_NODE> GetTaskUserTree()
	{
		IList<Guid> user = new List<Guid>();
		return ServiceLocator.Instance.GetService<IOrgUserService>().GetOrgUserTree(null, -1, isFindUser: true, isAllowUserManyToOrg: false, isIncludeSelf: true, user);
	}

	public void RemoveChildTask(Guid taskId)
	{
		SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(taskId);
		if (taskPOCO != null)
		{
			taskPOCO.ISDEL = 1m;
			supAssignTaskRepository.RemoveChild(taskPOCO.SUP_TASK_USER);
			supAssignTaskRepository.UpdateCommit(taskPOCO, "SUP_TASK_USER");
			IList<SUP_ASSIGN_TASK> taskList = supAssignTaskRepository.FindAll((SUP_ASSIGN_TASK t) => t.ISDEL == 0m);
			IEnumerable<SUP_ASSIGN_TASK> childTaskList = GetChildTask(taskList, taskId);
			foreach (SUP_ASSIGN_TASK task in childTaskList)
			{
				task.ISDEL = 1m;
				task.SUP_CHANGE.ToList().ForEach(delegate(SUP_CHANGE change)
				{
					change.ISDEL = 1m;
				});
				task.SUP_FEED_BACK.ToList().ForEach(delegate(SUP_FEED_BACK feedBack)
				{
					feedBack.ISDEL = 1m;
				});
				supAssignTaskRepository.RemoveChild(task.SUP_TASK_USER);
				supAssignTaskRepository.UpdateCommit(task, "SUP_TASK_USER");
			}
		}
		supAssignTaskRepository.UpdateCommit(taskPOCO);
	}

	public IEnumerable<SUP_ASSIGN_TASK> GetChildTask(IList<SUP_ASSIGN_TASK> taskList, Guid parentID)
	{
		IEnumerable<SUP_ASSIGN_TASK> query = taskList.Where(delegate(SUP_ASSIGN_TASK c)
		{
			int result;
			if (c.PARENT_ASSIGN_TASK_ID.HasValue && c.PARENT_ASSIGN_TASK_ID.Equals(parentID))
			{
				decimal? tASK_TYPE = c.TASK_TYPE;
				result = ((tASK_TYPE.GetValueOrDefault() == 2m && tASK_TYPE.HasValue) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		});
		return query.ToList().Concat(query.ToList().SelectMany((SUP_ASSIGN_TASK t) => GetChildTask(taskList, t.ASSIGN_TASK_ID)));
	}

	public QueryResult<SUP_ASSIGN_TASKDTO> GetChildTaskByUser(SUP_ASSIGN_TASKDTO taskDTO)
	{
		return SqlQueryPager<SUP_ASSIGN_TASKDTO>("GetChildTaskByUser", taskDTO, (string a) => a.Replace("@STR_TASK_STATUS", taskDTO.STR_TASK_STATUS));
	}

	public SUP_CHANGEDTO AddTaskChange(SUP_CHANGEDTO changeDTO)
	{
		if (changeDTO.IsValid())
		{
			SUP_CHANGE changePOCO = changeDTO.AdaptAsEntity<SUP_CHANGE>();
			supChangeRepository.AddCommit(changePOCO);
			SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(changeDTO.ASSIGN_TASK_ID);
			taskPOCO.TASK_STATUS = 4m;
			supAssignTaskRepository.UpdateCommit(taskPOCO);
			changeDTO = changePOCO.AdaptAsDTO<SUP_CHANGEDTO>();
			SendTaskMessage(taskPOCO);
			return changeDTO;
		}
		throw new ValidationException(changeDTO.GetInvalidMessages());
	}

	public IList<SUP_FEED_BACKDTO> AddTaskFeedBack(SUP_FEED_BACKDTO feedBackDTO)
	{
		if (feedBackDTO.IsValid())
		{
			SUP_FEED_BACK feedBackPOCO = feedBackDTO.AdaptAsEntity<SUP_FEED_BACK>();
			supFeedBackRepository.AddCommit(feedBackPOCO);
			SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(feedBackPOCO.ASSIGN_TASK_ID);
			SUP_ASSIGN_TASKDTO taskDTO = taskPOCO.AdaptAsDTO<SUP_ASSIGN_TASKDTO>();
			IOrderedEnumerable<SUP_FEED_BACKDTO> feedList = taskDTO.SUP_FEED_BACK.OrderByDescending((SUP_FEED_BACKDTO feed) => feed.CREATETIME);
			return feedList.ToList();
		}
		throw new ValidationException(feedBackDTO.GetInvalidMessages());
	}

	public SUP_CHANGEDTO ApproveTaskChange(SUP_CHANGEDTO changeDTO)
	{
		if (changeDTO.IsValid())
		{
			SUP_CHANGE changePOCO = changeDTO.AdaptAsEntity<SUP_CHANGE>();
			changePOCO.CHANGE_STATUS = 1m;
			SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(changePOCO.ASSIGN_TASK_ID);
			taskPOCO.END_TIME = changePOCO.CHANGE_END_TIME;
			taskPOCO.IS_CHANGE = 1m;
			taskPOCO.TASK_STATUS = 1m;
			supChangeRepository.UpdateCommit(changePOCO);
			supAssignTaskRepository.UpdateCommit(taskPOCO);
			changeDTO = changePOCO.AdaptAsDTO<SUP_CHANGEDTO>();
			return changeDTO;
		}
		throw new ValidationException(changeDTO.GetInvalidMessages());
	}

	public SUP_CHANGEDTO VetoTaskChange(SUP_CHANGEDTO changeDTO)
	{
		if (changeDTO.IsValid())
		{
			SUP_CHANGE changePOCO = supChangeRepository.GetByKey(changeDTO.CHANGE_ID);
			changePOCO.CHANGE_STATUS = 2m;
			supChangeRepository.UpdateCommit(changePOCO);
			SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(changeDTO.ASSIGN_TASK_ID);
			taskPOCO.TASK_STATUS = 1m;
			supAssignTaskRepository.UpdateCommit(taskPOCO);
			changeDTO = changePOCO.AdaptAsDTO<SUP_CHANGEDTO>();
			ISiteMessageService SiteMessageService = ServiceLocator.Instance.GetService<ISiteMessageService>();
			MSG_MESSAGE_USERDTO userDTO = new MSG_MESSAGE_USERDTO();
			SUP_TASK_USER taskUser = taskPOCO.SUP_TASK_USER[0];
			userDTO.USER_ID = taskUser.USER_ID.Value;
			userDTO.USER_NAME = taskUser.USER_NAME;
			userDTO.ORG_ID = OrgUserCacheManager.GetUserByKey(taskUser.USER_ID.Value).ORG_ID.Value;
			userDTO.ORG_NAME = OrgUserCacheManager.GetOrgByKey(userDTO.ORG_ID.Value).ORG_NAME;
			userDTO.USER_TYPE = 1m;
			MSG_MESSAGEDTO messageDTO = new MSG_MESSAGEDTO();
			messageDTO.ID = Guid.NewGuid();
			messageDTO.SEND_USER_ID = SessionContext.UserInfo.UserID;
			messageDTO.SEND_USER_NAME = SessionContext.UserInfo.UserName;
			messageDTO.SEND_ORG_ID = SessionContext.UserInfo.BelongToOrgID;
			messageDTO.SEND_ORG_NAME = OrgUserCacheManager.GetOrgByKey(SessionContext.UserInfo.BelongToOrgID).ORG_NAME;
			messageDTO.SORT = 0m;
			messageDTO.MESSAGE_TITLE = SessionContext.UserInfo.UserName + "拒绝了你的延期申请，请在系统中查看！";
			messageDTO.MESSAGE_CONTENT = SessionContext.UserInfo.UserName + "拒绝了你的延期申请，请在系统中查看！";
			List<MSG_MESSAGE_USERDTO> userList = new List<MSG_MESSAGE_USERDTO>();
			userList.Add(userDTO);
			messageDTO.MSG_MESSAGE_USER = userList;
			List<MSG_CENTER_USERDTO> user = new List<MSG_CENTER_USERDTO>();
			List<string> userIds = new List<string>();
			foreach (MSG_MESSAGE_USERDTO item in messageDTO.MSG_MESSAGE_USER)
			{
				item.MESSAGE_ID = messageDTO.ID;
				if (item.USER_TYPE == 1m)
				{
					user.Add(new MSG_CENTER_USERDTO
					{
						ISREAD = 0m,
						USER_ID = item.USER_ID,
						USER_NAME = item.USER_NAME,
						ISIM = 0m,
						SORT = 0m
					});
				}
			}
			IRepository<MSG_MESSAGE> mesMessageRepository = ServiceLocator.Instance.GetService<IRepository<MSG_MESSAGE>>();
			mesMessageRepository.AddCommit(messageDTO.AdaptAsEntity<MSG_MESSAGE>());
			IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
			MessageCenterService.AddMessage(new MSG_CENTERDTO
			{
				SEND_USER_ID = SessionContext.UserInfo.UserID,
				MSG_TITLE = messageDTO.MESSAGE_TITLE,
				SEND_TIME = DateTime.Now,
				SEND_USER_NAME = SessionContext.UserInfo.UserName,
				SEND_ORG_ID = SessionContext.UserInfo.BelongToOrgID,
				SEND_ORG_NAME = OrgUserCacheManager.GetOrgByKey(SessionContext.UserInfo.BelongToOrgID).ORG_NAME,
				MSG_TYPE = 3m,
				MSG_OPEN_TYPE = 0m,
				MSG_BUSINESS_ID = messageDTO.ID,
				MSG_SOURCE = "/Packages/SiteMessage/Views/MessageEdit.html?ID=" + messageDTO.ID,
				MSG_CENTER_USER = user.ToList()
			});
			return changeDTO;
		}
		throw new ValidationException(changeDTO.GetInvalidMessages());
	}

	public QueryResult<SUP_ASSIGN_TASKDTO> GetPortalTaskByUser(SUP_ASSIGN_TASKDTO taskDTO)
	{
		return SqlQueryPager<SUP_ASSIGN_TASKDTO>("GetPortalTaskByUser", taskDTO);
	}

	public void SendTaskMessage(SUP_ASSIGN_TASK assignTask)
	{
		IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
		List<MSG_CENTER_USERDTO> centerUser = new List<MSG_CENTER_USERDTO>();
		SUP_ASSIGN_TASK parentTask = (parentTask = supAssignTaskRepository.Find((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.ASSIGN_TASK_ID == assignTask.PARENT_ASSIGN_TASK_ID));
		string url = "/Packages/Supervise/Views/superviseTask_v2.html?ObjectId={0}&IsDetail=true&IsView=0&TaskStatus={1}&IsApply={2}&TYPE_ID={3}&TaskType={4}&license={5}";
		decimal? tASK_STATUS = assignTask.TASK_STATUS;
		if (!(tASK_STATUS.GetValueOrDefault() == 0m) || !tASK_STATUS.HasValue)
		{
			tASK_STATUS = assignTask.TASK_STATUS;
			if (!(tASK_STATUS.GetValueOrDefault() == 4m) || !tASK_STATUS.HasValue)
			{
				tASK_STATUS = assignTask.TASK_STATUS;
				if (!(tASK_STATUS.GetValueOrDefault() == 2m) || !tASK_STATUS.HasValue)
				{
					goto IL_04dd;
				}
			}
		}
		int iApply;
		if (parentTask != null)
		{
			iApply = 0;
			tASK_STATUS = assignTask.TASK_STATUS;
			if (!(tASK_STATUS.GetValueOrDefault() == 2m) || !tASK_STATUS.HasValue)
			{
				tASK_STATUS = assignTask.TASK_STATUS;
				if (!(tASK_STATUS.GetValueOrDefault() == 4m) || !tASK_STATUS.HasValue)
				{
					goto IL_0219;
				}
			}
			iApply = 1;
			goto IL_0219;
		}
		goto IL_04dd;
		IL_04dd:
		tASK_STATUS = assignTask.TASK_STATUS;
		MSG_CENTER_USERDTO centerUserDto;
		string msgUrl;
		MSG_CENTERDTO centerDto;
		if (tASK_STATUS.GetValueOrDefault() == 3m && tASK_STATUS.HasValue && ((parentTask != null && !parentTask.PARENT_ASSIGN_TASK_ID.HasValue) || !assignTask.PARENT_ASSIGN_TASK_ID.HasValue))
		{
			SUP_ASSIGN_TASK supervisorTask = supAssignTaskRepository.Find((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.TASK_TYPE == (decimal?)0m && t.PORJECT_ID == assignTask.PORJECT_ID);
			SUP_TASK_USER parentTaskUser2 = null;
			if (supervisorTask != null)
			{
				parentTaskUser2 = supervisorTask.SUP_TASK_USER.First();
			}
			if (parentTaskUser2 != null)
			{
				iApply = 0;
				centerUserDto = new MSG_CENTER_USERDTO();
				centerUserDto.ISREAD = 0m;
				centerUserDto.SORT = 0m;
				centerUserDto.USER_ID = parentTaskUser2.USER_ID;
				centerUserDto.USER_NAME = parentTaskUser2.USER_NAME;
				centerUser.Add(centerUserDto);
				msgUrl = string.Format(url, assignTask.ASSIGN_TASK_ID, assignTask.TASK_STATUS, iApply, parentTaskUser2.TYPE_ID, (int)assignTask.TASK_TYPE.Value, DateTime.Now.ToFileTime().ToString());
				centerDto = new MSG_CENTERDTO();
				centerDto.MSG_TYPE = 4m;
				centerDto.MSG_OPEN_TYPE = 2m;
				centerDto.SEND_USER_ID = assignTask.SUP_TASK_USER.First().USER_ID;
				centerDto.SEND_USER_NAME = assignTask.SUP_TASK_USER.First().USER_NAME;
				centerDto.MSG_TITLE = assignTask.WORK_TITLE;
				centerDto.SEND_TIME = DateTime.Now;
				centerDto.SEND_ORG_ID = null;
				centerDto.SEND_ORG_NAME = null;
				centerDto.MSG_BUSINESS_ID = null;
				centerDto.MSG_SOURCE = msgUrl;
				centerDto.MSG_CENTER_USER = centerUser.ToList();
				MessageCenterService.AddMessage(centerDto);
			}
		}
		return;
		IL_0219:
		int iStatus = (int)assignTask.TASK_STATUS.Value;
		tASK_STATUS = assignTask.TASK_STATUS;
		if (tASK_STATUS.GetValueOrDefault() == 0m && tASK_STATUS.HasValue)
		{
			iStatus = 1;
		}
		int taskType = (int)assignTask.TASK_TYPE.Value;
		centerUserDto = new MSG_CENTER_USERDTO();
		centerUserDto.ISREAD = 0m;
		centerUserDto.SORT = 0m;
		tASK_STATUS = assignTask.TASK_STATUS;
		if (tASK_STATUS.GetValueOrDefault() == 0m && tASK_STATUS.HasValue)
		{
			centerUserDto.USER_ID = assignTask.SUP_TASK_USER.First().USER_ID;
			centerUserDto.USER_NAME = assignTask.SUP_TASK_USER.First().USER_NAME;
		}
		else
		{
			taskType = 3;
			SUP_TASK_USER parentTaskUser = null;
			parentTask.SUP_TASK_USER.ToList().ForEach(delegate(SUP_TASK_USER taskUser)
			{
				decimal? tYPE_ID = taskUser.TYPE_ID;
				if (tYPE_ID.GetValueOrDefault() == 0m && tYPE_ID.HasValue)
				{
					parentTaskUser = taskUser;
				}
			});
			centerUserDto.USER_ID = parentTaskUser.USER_ID;
			centerUserDto.USER_NAME = parentTaskUser.USER_NAME;
		}
		centerUser.Add(centerUserDto);
		msgUrl = string.Format(url, assignTask.ASSIGN_TASK_ID, iStatus, iApply, 0, taskType, DateTime.Now.ToFileTime().ToString());
		centerDto = new MSG_CENTERDTO();
		centerDto.MSG_TYPE = 4m;
		centerDto.MSG_OPEN_TYPE = 1m;
		centerDto.SEND_USER_ID = assignTask.SUP_TASK_USER.First().USER_ID;
		centerDto.SEND_USER_NAME = assignTask.SUP_TASK_USER.First().USER_NAME;
		centerDto.MSG_TITLE = assignTask.WORK_TITLE;
		centerDto.SEND_TIME = DateTime.Now;
		centerDto.SEND_ORG_ID = null;
		centerDto.SEND_ORG_NAME = null;
		centerDto.MSG_BUSINESS_ID = null;
		centerDto.MSG_SOURCE = msgUrl;
		centerDto.MSG_CENTER_USER = centerUser.ToList();
		MessageCenterService.AddMessage(centerDto);
		goto IL_04dd;
	}

	public void SendSuperviseRemindingMessage(List<SUP_ASSIGN_TASKDTO> taskList)
	{
		taskList?.ForEach(delegate(SUP_ASSIGN_TASKDTO taskDTO)
		{
			SendRemindingMessage(taskDTO);
		});
	}

	public void SendRemindingMessage(SUP_ASSIGN_TASKDTO assignTask)
	{
		IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
		List<MSG_CENTER_USERDTO> centerUser = new List<MSG_CENTER_USERDTO>();
		MSG_CENTER_USERDTO centerUserDto = new MSG_CENTER_USERDTO();
		centerUserDto.ISREAD = 0m;
		centerUserDto.SORT = 0m;
		centerUserDto.USER_ID = assignTask.SUP_TASK_USER.First().USER_ID;
		centerUserDto.USER_NAME = assignTask.SUP_TASK_USER.First().USER_NAME;
		centerUser.Add(centerUserDto);
		string url = "/Packages/Supervise/Views/superviseTask_v2.html?ObjectId={0}&IsDetail=true&IsView=0&TaskStatus={1}&IsApply={2}&TaskType={3}&license={4}";
		int iApply = 0;
		decimal? tASK_STATUS = assignTask.TASK_STATUS;
		if (!(tASK_STATUS.GetValueOrDefault() == 2m) || !tASK_STATUS.HasValue)
		{
			tASK_STATUS = assignTask.TASK_STATUS;
			if (!(tASK_STATUS.GetValueOrDefault() == 4m) || !tASK_STATUS.HasValue)
			{
				goto IL_00d3;
			}
		}
		iApply = 1;
		goto IL_00d3;
		IL_00d3:
		string msgUrl = string.Format(url, assignTask.ASSIGN_TASK_ID, assignTask.TASK_STATUS, iApply, (int)assignTask.TASK_TYPE, DateTime.Now.ToFileTime().ToString());
		MSG_CENTERDTO centerDto = new MSG_CENTERDTO();
		centerDto.MSG_TYPE = 4m;
		centerDto.MSG_OPEN_TYPE = 2m;
		centerDto.SEND_USER_ID = assignTask.MESSAGE_REMINDING_USER_ID;
		centerDto.SEND_USER_NAME = assignTask.MESSAGE_REMINDING_USER_NAME;
		centerDto.MSG_TITLE = assignTask.MESSAGE_REMINDING + assignTask.WORK_TITLE;
		centerDto.SEND_TIME = DateTime.Now;
		centerDto.SEND_ORG_ID = null;
		centerDto.SEND_ORG_NAME = null;
		centerDto.MSG_BUSINESS_ID = null;
		centerDto.MSG_SOURCE = msgUrl;
		centerDto.MSG_CENTER_USER = centerUser.ToList();
		MessageCenterService.AddMessage(centerDto);
	}

	public void SendSubTaskMessage(SUP_ASSIGN_TASK assignTask)
	{
		IMessageCenterService MessageCenterService = ServiceLocator.Instance.GetService<IMessageCenterService>();
		List<MSG_CENTER_USERDTO> centerUser = new List<MSG_CENTER_USERDTO>();
		SUP_ASSIGN_TASK parentTask = (parentTask = supAssignTaskRepository.Find((SUP_ASSIGN_TASK t) => t.ISDEL == 0m && t.ASSIGN_TASK_ID == assignTask.PARENT_ASSIGN_TASK_ID));
		string url = "/Packages/Supervise/Views/superviseTask_v2.html?ObjectId={0}&IsDetail=true&IsView=0&TaskStatus={1}&IsApply={2}&TYPE_ID={3}&TaskType={4}&license={5}";
		decimal? tASK_STATUS = assignTask.TASK_STATUS;
		if (!(tASK_STATUS.GetValueOrDefault() == 6m) || !tASK_STATUS.HasValue || parentTask == null)
		{
			return;
		}
		int iApply = 0;
		int iStatus = (int)assignTask.TASK_STATUS.Value;
		string msgUrl = string.Format(url, assignTask.ASSIGN_TASK_ID, iStatus, iApply, 0, (int)assignTask.TASK_TYPE.Value, DateTime.Now.ToFileTime().ToString());
		MSG_CENTER_USERDTO centerUserDto = new MSG_CENTER_USERDTO();
		centerUserDto.ISREAD = 0m;
		centerUserDto.SORT = 0m;
		centerUserDto.USER_ID = assignTask.SUP_TASK_USER.First().USER_ID;
		centerUserDto.USER_NAME = assignTask.SUP_TASK_USER.First().USER_NAME;
		centerUser.Add(centerUserDto);
		SUP_TASK_USER parentTaskUser = null;
		parentTask.SUP_TASK_USER.ToList().ForEach(delegate(SUP_TASK_USER taskUser)
		{
			decimal? tYPE_ID = taskUser.TYPE_ID;
			if (tYPE_ID.GetValueOrDefault() == 0m && tYPE_ID.HasValue)
			{
				parentTaskUser = taskUser;
			}
		});
		if (parentTaskUser != null)
		{
			MSG_CENTERDTO centerDto = new MSG_CENTERDTO();
			centerDto.MSG_TYPE = 4m;
			centerDto.MSG_OPEN_TYPE = 1m;
			centerDto.SEND_USER_ID = parentTaskUser.USER_ID;
			centerDto.SEND_USER_NAME = parentTaskUser.USER_NAME;
			centerDto.MSG_TITLE = assignTask.WORK_TITLE;
			centerDto.SEND_TIME = DateTime.Now;
			centerDto.SEND_ORG_ID = null;
			centerDto.SEND_ORG_NAME = null;
			centerDto.MSG_BUSINESS_ID = null;
			centerDto.MSG_SOURCE = msgUrl;
			centerDto.MSG_CENTER_USER = centerUser.ToList();
			MessageCenterService.AddMessage(centerDto);
		}
	}

	public IList<SUP_TASK_PROGRESSDTO> AddTaskProgress(SUP_TASK_PROGRESSDTO taskProgressDTO)
	{
		if (taskProgressDTO.IsValid())
		{
			SUP_TASK_PROGRESS taskProgressPOCO = taskProgressDTO.AdaptAsEntity<SUP_TASK_PROGRESS>();
			supTaskProgressRepository.AddCommit(taskProgressPOCO);
			SUP_ASSIGN_TASK taskPOCO = supAssignTaskRepository.GetByKey(taskProgressPOCO.ASSIGN_TASK_ID);
			SUP_ASSIGN_TASKDTO taskDTO = taskPOCO.AdaptAsDTO<SUP_ASSIGN_TASKDTO>();
			IOrderedEnumerable<SUP_TASK_PROGRESSDTO> progressList = taskDTO.SUP_TASK_PROGRESS.OrderByDescending((SUP_TASK_PROGRESSDTO progress) => progress.CREATETIME);
			return progressList.ToList();
		}
		throw new ValidationException(taskProgressDTO.GetInvalidMessages());
	}
}
