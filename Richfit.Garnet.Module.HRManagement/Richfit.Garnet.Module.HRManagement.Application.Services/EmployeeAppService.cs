using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Domain;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.HRManagement.Application.DTO;
using Richfit.Garnet.Module.HRManagement.Domain.Models;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.Services.OrgUserCache;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_Vacation.DTO;

namespace Richfit.Garnet.Module.HRManagement.Application.Services;

public class EmployeeAppService : ServiceBase, IEmployeeAppService
{
	/// <summary>
	/// 人员 仓储对象
	/// </summary>
	private readonly IRepository<HR_EMPLOYEE> employeeRepository;

	private readonly IRepository<HR_DONATE_BLOOD> employeeBloodRepository;

	/// <summary>
	/// 通讯录 仓储对象
	/// </summary>
	private readonly IRepository<AB_CONTACT> contactRepository;

	/// <summary>
	///  组织机构 仓储对象
	///  </summary>
	private readonly IRepository<SYS_ORG> orgRepository;

	private readonly IRepository<LY_INFO> lyRepository;

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="repositoryEmployee">人员 仓储对象</param>
	/// <param name="repositoryAddress">通讯录 仓储对象</param>
	/// <param name="repositoryPhone">组织机构 仓储对象</param>
	public EmployeeAppService(IRepository<HR_EMPLOYEE> repositoryEmployee, IRepository<HR_DONATE_BLOOD> repositoryEmployeeBlood, IRepository<AB_CONTACT> repositoryContact, IRepository<SYS_ORG> repositoryOrg, IRepository<LY_INFO> repositoryLy)
	{
		employeeRepository = repositoryEmployee;
		employeeBloodRepository = repositoryEmployeeBlood;
		contactRepository = repositoryContact;
		orgRepository = repositoryOrg;
		lyRepository = repositoryLy;
	}

	public HR_EMPLOYEEDTO AddEmployee(HR_EMPLOYEEDTO employeeDTO)
	{
		if (employeeDTO == null)
		{
			throw new ArgumentException("AddEmployee方法参数不能为空！");
		}
		if (employeeDTO.IsValid())
		{
			HR_EMPLOYEE employeePOCO = employeeDTO.AdaptAsEntity<HR_EMPLOYEE>();
			employeeRepository.AddCommit(employeePOCO);
			employeeDTO = employeePOCO.AdaptAsDTO<HR_EMPLOYEEDTO>();
			return employeeDTO;
		}
		throw new ValidationException(employeeDTO.GetInvalidMessages());
	}

	public void RemoveEmployeeByUserId(string userIds)
	{
		string[] idArray = userIds.Split(",", removeEmptyEntries: true);
		if (idArray == null || !idArray.Any())
		{
			return;
		}
		idArray.ForEach(delegate(string x)
		{
			Guid id = Guid.Parse(x);
			HR_EMPLOYEE hR_EMPLOYEE = employeeRepository.Find((HR_EMPLOYEE a) => a.USER_ID == id && a.ISDEL == (decimal?)0m);
			if (hR_EMPLOYEE != null)
			{
				hR_EMPLOYEE.ISDEL = 1m;
				if (hR_EMPLOYEE.CONTACT_ID.HasValue && hR_EMPLOYEE.CONTACT_ID != Guid.Empty)
				{
					AB_CONTACT byKey = contactRepository.GetByKey(hR_EMPLOYEE.CONTACT_ID);
					byKey.ISDEL = 1m;
					contactRepository.RemoveChild(byKey.AB_ORG_CONTACT);
					contactRepository.UpdateCommit(byKey);
				}
				employeeRepository.UpdateCommit(hR_EMPLOYEE);
			}
		});
	}

	public void RemoveEmployee(string EmployeeIds)
	{
		string[] idArray = EmployeeIds.Split(",", removeEmptyEntries: true);
		if (idArray == null || !idArray.Any())
		{
			return;
		}
		idArray.ForEach(delegate(string x)
		{
			Guid guid = Guid.Parse(x);
			HR_EMPLOYEE byKey = employeeRepository.GetByKey(guid);
			if (byKey != null)
			{
				byKey.ISDEL = 1m;
				if (byKey.CONTACT_ID.HasValue && byKey.CONTACT_ID != Guid.Empty)
				{
					AB_CONTACT byKey2 = contactRepository.GetByKey(byKey.CONTACT_ID);
					byKey2.ISDEL = 1m;
					contactRepository.RemoveChild(byKey2.AB_ORG_CONTACT);
					contactRepository.UpdateCommit(byKey2);
				}
				employeeRepository.UpdateCommit(byKey);
			}
		});
	}

	public HR_EMPLOYEEDTO UpdateEmployee(HR_EMPLOYEEDTO employeeDTO)
	{
		if (employeeDTO == null || employeeDTO.EMPLOYEE_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateEmployee方法参数不能为空！");
		}
		if (employeeDTO.IsValid())
		{
			HR_EMPLOYEE persisted = employeeRepository.GetByKey(employeeDTO.EMPLOYEE_ID);
			if (persisted != null)
			{
				HR_EMPLOYEE employeePOCO = employeeDTO.AdaptAsEntity<HR_EMPLOYEE>();
				if (persisted.IsUpdateConflict(employeePOCO))
				{
					throw new ArgumentException("数据已过期，请刷新重试！");
				}
				HR_EMPLOYEE newEmployeePOCO = persisted;
				newEmployeePOCO.SEX = employeeDTO.SEX;
				newEmployeePOCO.ADMINISTRATIVE_FUNCTION = employeeDTO.ADMINISTRATIVE_FUNCTION;
				newEmployeePOCO.ORG_ID = employeeDTO.ORG_ID;
				newEmployeePOCO.AFFILIATED_UNIT = employeeDTO.AFFILIATED_UNIT;
				newEmployeePOCO.WORKING_START_DATE = employeeDTO.WORKING_START_DATE;
				newEmployeePOCO.CONTRACT_EXPIRY_DATE = employeeDTO.CONTRACT_EXPIRY_DATE;
				newEmployeePOCO.JOB_PO_ETHNIC_GROUP = employeeDTO.JOB_PO_ETHNIC_GROUP;
				newEmployeePOCO.JOB_PO_LEVEL = employeeDTO.JOB_PO_LEVEL;
				newEmployeePOCO.JOB_PO_NAME = employeeDTO.JOB_PO_NAME;
				newEmployeePOCO.JOB_PO_SEQ = employeeDTO.JOB_PO_SEQ;
				newEmployeePOCO.JOB_PO_UP_SEQ = employeeDTO.JOB_PO_UP_SEQ;
				newEmployeePOCO.CONTRACT_TYPE = employeeDTO.CONTRACT_TYPE;
				newEmployeePOCO.USER_TYPE = employeeDTO.USER_TYPE;
				newEmployeePOCO.IN_CATEGORY = employeeDTO.IN_CATEGORY;
				newEmployeePOCO.AGE = employeeDTO.AGE;
				newEmployeePOCO.POLITICS_STATUS = employeeDTO.POLITICS_STATUS;
				newEmployeePOCO.ENG_LEVEL = employeeDTO.ENG_LEVEL;
				newEmployeePOCO.POSITION_TYPE = employeeDTO.POSITION_TYPE;
				newEmployeePOCO.EDUCATION_REMARK = employeeDTO.EDUCATION_REMARK;
				newEmployeePOCO.GRADUATION_COLLEGE = employeeDTO.GRADUATION_COLLEGE;
				newEmployeePOCO.TECHNICAL_TITLE_STR = employeeDTO.TECHNICAL_TITLE_STR;
				newEmployeePOCO.EMPLOYEE_NAME = employeeDTO.EMPLOYEE_NAME;
				newEmployeePOCO.PERSON_ID = employeeDTO.PERSON_ID;
				newEmployeePOCO.ID_NUMBER = employeeDTO.ID_NUMBER;
				newEmployeePOCO.BIRTHDAY = employeeDTO.BIRTHDAY;
				newEmployeePOCO.MARITAL_STATUS = employeeDTO.MARITAL_STATUS;
				newEmployeePOCO.NATION = employeeDTO.NATION;
				newEmployeePOCO.HOME_TOWN = employeeDTO.HOME_TOWN;
				newEmployeePOCO.WORK_TIME = employeeDTO.WORK_TIME;
				newEmployeePOCO.TRANSFERRED_TIME = employeeDTO.TRANSFERRED_TIME;
				newEmployeePOCO.POSITION = employeeDTO.POSITION;
				newEmployeePOCO.RANK = employeeDTO.RANK;
				newEmployeePOCO.PARTY_TIME = employeeDTO.PARTY_TIME;
				newEmployeePOCO.EDUCATION = employeeDTO.EDUCATION;
				newEmployeePOCO.SCHOOL_MAJOR = employeeDTO.SCHOOL_MAJOR;
				newEmployeePOCO.GRADUAION_TIME = employeeDTO.GRADUAION_TIME;
				newEmployeePOCO.WORK_TEL = employeeDTO.WORK_TEL;
				newEmployeePOCO.MOBILE = employeeDTO.MOBILE;
				newEmployeePOCO.MAIL = employeeDTO.MAIL;
				newEmployeePOCO.IMAGE_PATH = employeeDTO.IMAGE_PATH;
				newEmployeePOCO.VACATION_DAYS = employeeDTO.VACATION_DAYS;
				newEmployeePOCO.WORK_AGE = employeeDTO.WORK_AGE;
				newEmployeePOCO.TECHNICAL_POSITION = employeeDTO.TECHNICAL_POSITION;
				newEmployeePOCO.CONTACT_ID = ((!newEmployeePOCO.CONTACT_ID.HasValue) ? new Guid?(Guid.Empty) : newEmployeePOCO.CONTACT_ID);
				Guid newOrgID = Guid.Empty;
				if (newEmployeePOCO.ORG_ID != employeeDTO.ORG_ID)
				{
					newEmployeePOCO.ORG_ID = employeeDTO.ORG_ID;
					newOrgID = employeeDTO.ORG_ID.Value;
				}
				AB_CONTACT contactPOCO = contactRepository.GetByKey(newEmployeePOCO.CONTACT_ID);
				if (contactPOCO != null)
				{
					contactPOCO.CONTACT_NAME = employeeDTO.EMPLOYEE_NAME;
					contactPOCO.SEX = employeeDTO.SEX;
					contactPOCO.BIRTHDAY = employeeDTO.BIRTHDAY;
					contactPOCO.MOBILE = employeeDTO.MOBILE;
					contactPOCO.MAIL = employeeDTO.MAIL;
					contactPOCO.WORK_TEL = employeeDTO.WORK_TEL;
					if (newOrgID != Guid.Empty)
					{
						contactPOCO.AB_ORG_CONTACT.First().ORG_ID = newOrgID;
					}
					contactRepository.UpdateCommit(contactPOCO);
				}
				employeeRepository.UpdateCommit(newEmployeePOCO);
				employeeDTO = newEmployeePOCO.AdaptAsDTO<HR_EMPLOYEEDTO>();
				return employeeDTO;
			}
			throw new ArgumentException("UpdateEmployee不存在相关的实体对象！");
		}
		throw new ValidationException(employeeDTO.GetInvalidMessages());
	}

	public QueryResult<HR_EMPLOYEEDTO> QueryEmployee(HR_EMPLOYEEDTO queryCondition)
	{
		return SqlQueryPager<HR_EMPLOYEEDTO>("GetEmployeeAllList", queryCondition);
	}

	public HR_EMPLOYEEDTO QueryEmpInfoById(Guid empId)
	{
		HR_EMPLOYEE empPOCO = employeeRepository.GetByKey(empId);
		if (empPOCO != null)
		{
			HR_EMPLOYEEDTO employeeDTO = empPOCO.AdaptAsDTO<HR_EMPLOYEEDTO>();
			employeeDTO.ORG_NAME = OrgUserCacheManager.GetOrgByKey(empPOCO.ORG_ID.Value).ORG_NAME;
			return employeeDTO;
		}
		return null;
	}

	public HR_EMPLOYEEDTO QueryEmpInfoByUserId(Guid userId)
	{
		HR_EMPLOYEEDTO employeeDTO = new HR_EMPLOYEEDTO();
		employeeDTO.USER_ID = userId;
		IList<HR_EMPLOYEEDTO> listResult = SqlQuery<HR_EMPLOYEEDTO>("GetEmployeeByUserId", employeeDTO);
		if (listResult != null && listResult.Count > 0)
		{
			employeeDTO = listResult[0];
			employeeDTO.ORG_NAME = OrgUserCacheManager.GetOrgByKey(employeeDTO.ORG_ID.Value).ORG_NAME;
		}
		return employeeDTO;
	}

	public IList<HR_EMPLOYEEDTO> GetUserInfoByName(string userName)
	{
		HR_EMPLOYEEDTO employeeDTO = new HR_EMPLOYEEDTO();
		employeeDTO.USER_NAME = userName;
		return SqlQuery<HR_EMPLOYEEDTO>("GetUserInfoByName", employeeDTO);
	}

	public IList<IDataObject> GetSexStatistics()
	{
		SqlStatement sqlStatement = employeeRepository.GetSqlStatement("GetSexStatistics", GetType());
		string sqlExpress = sqlStatement.Sql;
		return DynamicSqlQuery(sqlExpress, null, null, null).List;
	}

	public IList<IDataObject> GetEducationStatistics()
	{
		SqlStatement sqlStatement = employeeRepository.GetSqlStatement("GetEducationStatistics", GetType());
		string sqlExpress = sqlStatement.Sql;
		return DynamicSqlQuery(sqlExpress, null, null, null).List;
	}

	public IList<IDataObject> GetTechicalStatistics()
	{
		SqlStatement sqlStatement = employeeRepository.GetSqlStatement("GetTechicalStatistics", GetType());
		string sqlExpress = sqlStatement.Sql;
		return DynamicSqlQuery(sqlExpress, null, null, null).List;
	}

	public IList<IDataObject> GetAgerangeStatistics()
	{
		SqlStatement sqlStatement = employeeRepository.GetSqlStatement("GetAgerangeStatistics", GetType());
		string sqlExpress = sqlStatement.Sql;
		return DynamicSqlQuery(sqlExpress, null, null, null).List;
	}

	public HR_EMPLOYEEDTO GetPositionByUserId(Guid userId)
	{
		HR_EMPLOYEEDTO employeeDTO = new HR_EMPLOYEEDTO();
		IList<HR_EMPLOYEE> listResult = employeeRepository.FindAll((HR_EMPLOYEE t) => t.USER_ID == userId);
		if (listResult != null && listResult.Count > 0)
		{
			employeeDTO = listResult[0].AdaptAsDTO<HR_EMPLOYEEDTO>();
			if (!employeeDTO.POSITION.HasValue)
			{
				employeeDTO.POSITION = Guid.Parse("B9B0C5A0-C2A5-C117-B6E6-08D2A797A968");
			}
		}
		return employeeDTO;
	}

	public IList<HR_EMPLOYEEDTO> GetEmpByPosition(Guid positionId)
	{
		IList<HR_EMPLOYEE> listResult = employeeRepository.FindAll((HR_EMPLOYEE t) => t.POSITION == positionId);
		return listResult.AdaptAsDTO<HR_EMPLOYEEDTO>();
	}

	public IList<HR_EMPLOYEEDTO> ExportEmp(HR_EMPLOYEEDTO queryCondition)
	{
		return SqlQuery<HR_EMPLOYEEDTO>("GetEmployeeList", queryCondition);
	}

	public IList<HR_EMPLOYEEDTO> GetBirthdayEmpList()
	{
		return SqlQuery<HR_EMPLOYEEDTO>("GetBirthdayEmpList", new object());
	}

	public IList<HR_EMPLOYEEDTO> GetALLEmployee()
	{
		return employeeRepository.FindAll((HR_EMPLOYEE a) => a.ISDEL == (decimal?)0m).AdaptAsDTO<HR_EMPLOYEEDTO>();
	}

	/// <summary>
	/// 添加人员及通讯录信息
	/// </summary>
	/// <param name="userDTO"></param>
	/// <returns></returns>
	public HR_EMPLOYEEDTO AddEmployeeAndContact(SYS_USERDTO userDTO)
	{
		if (userDTO == null)
		{
			throw new ArgumentException("AddEmployee方法参数不能为空！");
		}
		if (userDTO.IsValid())
		{
			HR_EMPLOYEE employeePOCO = new HR_EMPLOYEE();
			employeePOCO.EMPLOYEE_ID = Guid.NewGuid();
			employeePOCO.EMPLOYEE_NAME = userDTO.DISPLAY_NAME;
			employeePOCO.USER_ID = userDTO.USER_ID;
			employeePOCO.SORT = userDTO.SORT;
			employeePOCO.ORG_ID = Guid.Parse(userDTO.ORG_ID.ToString());
			employeeRepository.AddCommit(employeePOCO);
			return employeePOCO.AdaptAsDTO<HR_EMPLOYEEDTO>();
		}
		throw new ValidationException(userDTO.GetInvalidMessages());
	}

	public HR_EMPLOYEEDTO UpdateEmployeeAndContact(SYS_USERDTO userDTO)
	{
		if (userDTO == null || userDTO.USER_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateEmployeeAndContact方法参数不能为空！");
		}
		HR_EMPLOYEE entity = employeeRepository.Find((HR_EMPLOYEE a) => a.USER_ID == userDTO.USER_ID && a.ISDEL == (decimal?)0m);
		if (entity != null)
		{
			entity.EMPLOYEE_NAME = userDTO.DISPLAY_NAME;
			entity.USER_ID = userDTO.USER_ID;
			entity.SORT = userDTO.SORT;
			entity.ORG_ID = Guid.Parse(userDTO.ORG_ID.ToString());
			employeeRepository.UpdateCommit(entity);
			return entity.AdaptAsDTO<HR_EMPLOYEEDTO>();
		}
		throw new ArgumentException("UpdateEmployee不存在相关的实体对象！");
	}

	public void UpdateHRInfo()
	{
		try
		{
			IList<HR_EMPLOYEE> listResult = employeeRepository.FindAll((HR_EMPLOYEE a) => a.ISDEL == (decimal?)0m && a.WORK_AGE != null);
			if (listResult == null || listResult.Count <= 0)
			{
				return;
			}
			ServiceBase.log.Info("开始更新员工工龄和应休天数！");
			foreach (HR_EMPLOYEE employeeHR in listResult)
			{
				HR_EMPLOYEEDTO employeeDTO = new HR_EMPLOYEEDTO();
				employeeDTO = employeeHR.AdaptAsDTO<HR_EMPLOYEEDTO>();
				DateTime dt = DateTime.Now;
				SqlRepository repository = new SqlRepository(null);
				if (employeeDTO.ORIGINAL_UNIT == null || !(employeeDTO.ORIGINAL_UNIT == DateTime.Now.AddYears(-1).Year.ToString().Trim()))
				{
					continue;
				}
				int vacationDays = 0;
				if (employeeDTO.WORK_AGE.HasValue)
				{
					int workage = Convert.ToInt16(employeeDTO.WORK_AGE) + 1;
					if (workage >= 1 && workage < 10)
					{
						vacationDays = 5;
					}
					else if (workage >= 10 && workage < 20)
					{
						vacationDays = 10;
					}
					else if (workage >= 20)
					{
						vacationDays = 15;
					}
					employeeHR.VACATION_DAYS = vacationDays;
					employeeHR.WORK_AGE = workage;
					employeeHR.ORIGINAL_UNIT = DateTime.Now.Year.ToString().Trim();
					employeeRepository.UpdateCommit(employeeHR);
				}
			}
			ServiceBase.log.Info("更新员工工龄和应休天数结束！");
		}
		catch (Exception)
		{
			ServiceBase.log.Info("尝试更新失败！");
		}
	}

	public bool UpdateLyInfoByYear()
	{
		bool flag = false;
		try
		{
			IList<HR_EMPLOYEE> listResult = employeeRepository.FindAll((HR_EMPLOYEE a) => a.ISDEL == (decimal?)0m && a.WORK_AGE != null);
			if (listResult != null && listResult.Count > 0)
			{
				ServiceBase.log.Info("开始更新员工疗养信息！");
				foreach (HR_EMPLOYEE employeeHR in listResult)
				{
					HR_EMPLOYEEDTO employeeDTO = new HR_EMPLOYEEDTO();
					employeeDTO = employeeHR.AdaptAsDTO<HR_EMPLOYEEDTO>();
					string currentYear = DateTime.Now.Year.ToString().Trim();
					if (employeeHR.ORIGINAL_UNIT != currentYear)
					{
						throw new ArgumentException(employeeHR.EMPLOYEE_NAME + "请先在人力信息管理中更新工龄！");
					}
					IList<LY_INFO> lyListResult = lyRepository.FindAll((LY_INFO a) => a.ISDEL == 0m && a.EMPLOYEE_ID == employeeDTO.EMPLOYEE_ID);
					if (lyListResult == null || lyListResult.Count <= 0)
					{
						continue;
					}
					LY_INFO currentYearResult = lyRepository.Find((LY_INFO a) => a.ISDEL == 0m && a.EMPLOYEE_ID == employeeDTO.EMPLOYEE_ID && a.CURRENT_YEAR == currentYear);
					LY_INFO lastLyResult = lyListResult.OrderByDescending((LY_INFO x) => x.CURRENT_YEAR).First();
					LY_INFO result;
					if (currentYearResult == null)
					{
						result = new LY_INFO();
						result.LY_ID = Guid.NewGuid();
						result.EMPLOYEE_ID = employeeHR.EMPLOYEE_ID;
						result.USER_ID = employeeHR.USER_ID;
						result.CURRENT_YEAR = currentYear;
						if (lastLyResult != null)
						{
							decimal? iS_HAVE_LY = lastLyResult.IS_HAVE_LY;
							if (iS_HAVE_LY.GetValueOrDefault() == 1m && iS_HAVE_LY.HasValue)
							{
								result.LAST_LY_YEAR = lastLyResult.CURRENT_YEAR;
								goto IL_04a6;
							}
						}
						if (lastLyResult != null)
						{
							decimal? iS_HAVE_LY = lastLyResult.IS_HAVE_LY;
							if (iS_HAVE_LY.GetValueOrDefault() == 0m && iS_HAVE_LY.HasValue)
							{
								result.LAST_LY_YEAR = lastLyResult.LAST_LY_YEAR;
								goto IL_04a6;
							}
						}
						result.LAST_LY_YEAR = "";
						goto IL_04a6;
					}
					int lastLyWorkAge = 0;
					int nextLyYear = 0;
					if (!string.IsNullOrEmpty(currentYearResult.LAST_LY_YEAR) && !string.IsNullOrEmpty(employeeHR.WORK_TIME.ToString()))
					{
						DateTime dt = employeeHR.WORK_TIME.Value;
						lastLyWorkAge = Convert.ToInt16(currentYearResult.LAST_LY_YEAR) - Convert.ToInt16(dt.Year);
					}
					if (currentYearResult.LAST_LY_YEAR != "2019")
					{
						nextLyYear = GetNextLyYear(Convert.ToInt16(employeeHR.WORK_AGE), lastLyWorkAge, (!string.IsNullOrEmpty(currentYearResult.LAST_LY_YEAR)) ? Convert.ToInt16(currentYearResult.LAST_LY_YEAR) : 0);
						if (nextLyYear == Convert.ToInt16(currentYear))
						{
							currentYearResult.IS_HAVE_LY = 1m;
						}
						else
						{
							currentYearResult.IS_HAVE_LY = 0m;
						}
						lyRepository.UpdateCommit(currentYearResult);
					}
					continue;
					IL_04a6:
					lastLyWorkAge = 0;
					nextLyYear = 0;
					if (!string.IsNullOrEmpty(result.LAST_LY_YEAR) && !string.IsNullOrEmpty(employeeHR.WORK_TIME.ToString()))
					{
						DateTime dt = employeeHR.WORK_TIME.Value;
						lastLyWorkAge = Convert.ToInt16(result.LAST_LY_YEAR) - Convert.ToInt16(dt.Year);
					}
					nextLyYear = GetNextLyYear(Convert.ToInt16(employeeHR.WORK_AGE), lastLyWorkAge, (!string.IsNullOrEmpty(result.LAST_LY_YEAR)) ? Convert.ToInt16(result.LAST_LY_YEAR) : 0);
					if (nextLyYear == Convert.ToInt16(currentYear))
					{
						result.IS_HAVE_LY = 1m;
					}
					else
					{
						result.IS_HAVE_LY = 0m;
					}
					result.VACATION_DAYS = "0";
					result.REMARK = "";
					result.ISDEL = 0m;
					lyRepository.AddCommit(result);
				}
				ServiceBase.log.Info("更新员工工龄和应休天数结束！");
			}
			flag = true;
		}
		catch (Exception)
		{
			ServiceBase.log.Info("尝试更新失败！");
		}
		return flag;
	}

	private int GetNextLyYear(int workAge, int lastLyWorkAge, int lastLyYear)
	{
		int nextLyYear = 0;
		if (workAge == 10)
		{
			nextLyYear = DateTime.Now.Year;
		}
		else if (workAge > 10 && lastLyWorkAge >= 1 && lastLyWorkAge < 10)
		{
			nextLyYear = lastLyYear + 4;
		}
		else if (workAge > 10 && lastLyWorkAge >= 10 && lastLyWorkAge < 20)
		{
			nextLyYear = lastLyYear + 4;
		}
		else if (workAge > 10 && lastLyWorkAge >= 20 && lastLyWorkAge < 30)
		{
			nextLyYear = lastLyYear + 3;
		}
		else if (workAge > 10 && lastLyWorkAge >= 30)
		{
			nextLyYear = lastLyYear + 2;
		}
		return nextLyYear;
	}

	public QueryResult<HR_EMPLOYEEDTO> QueryLyList(HR_EMPLOYEEDTO queryCondition)
	{
		return SqlQueryPager<HR_EMPLOYEEDTO>("GetLYAllList", queryCondition);
	}

	public LY_INFODTO UpdateLyInfo(LY_INFODTO lyDTO)
	{
		if (lyDTO == null || lyDTO.LY_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateEmployee方法参数不能为空！");
		}
		if (lyDTO.IsValid())
		{
			LY_INFO persisted = lyRepository.GetByKey(lyDTO.LY_ID);
			if (persisted != null)
			{
				LY_INFO lyPOCO = lyDTO.AdaptAsEntity<LY_INFO>();
				LY_INFO newLYPOCO = persisted;
				newLYPOCO.REMARK = lyDTO.REMARK;
				lyRepository.UpdateCommit(newLYPOCO);
				lyDTO = newLYPOCO.AdaptAsDTO<LY_INFODTO>();
				return lyDTO;
			}
			throw new ArgumentException("UpdateEmployee不存在相关的实体对象！");
		}
		throw new ValidationException(lyDTO.GetInvalidMessages());
	}

	public QueryResult<HR_VACATION> GetVacationStatistics(HR_VACATION queryCondition)
	{
		return SqlQueryPager<HR_VACATION>("GetVacationStatistics", queryCondition);
	}

	public QueryResult<HR_DONATE_BLOODDTO> FindEmpOfDonate(HR_DONATE_BLOODDTO queryCondition)
	{
		return SqlQueryPager<HR_DONATE_BLOODDTO>("FindEmpOfDonate", queryCondition);
	}

	public HR_DONATE_BLOODDTO AddDonate(HR_DONATE_BLOODDTO employeeBloodDTO)
	{
		if (employeeBloodDTO == null)
		{
			throw new ArgumentException("AddDonate方法参数不能为空！");
		}
		if (employeeBloodDTO.IsValid())
		{
			HR_DONATE_BLOOD employeeBloodPOCO = employeeBloodDTO.AdaptAsEntity<HR_DONATE_BLOOD>();
			employeeBloodRepository.AddCommit(employeeBloodPOCO);
			employeeBloodDTO = employeeBloodPOCO.AdaptAsDTO<HR_DONATE_BLOODDTO>();
			return employeeBloodDTO;
		}
		throw new ValidationException(employeeBloodDTO.GetInvalidMessages());
	}

	public HR_DONATE_BLOODDTO UpdateDonate(HR_DONATE_BLOODDTO employeeBloodDTO)
	{
		if (employeeBloodDTO == null || employeeBloodDTO.DONATE_BLOOD_ID == Guid.Empty)
		{
			throw new ArgumentException("UpdateDonate方法参数不能为空！");
		}
		if (employeeBloodDTO.IsValid())
		{
			HR_DONATE_BLOOD persisted = employeeBloodRepository.GetByKey(employeeBloodDTO.DONATE_BLOOD_ID);
			if (persisted != null)
			{
				HR_DONATE_BLOOD employeeBloodPOCO = employeeBloodDTO.AdaptAsEntity<HR_DONATE_BLOOD>();
				if (persisted.IsUpdateConflict(employeeBloodPOCO))
				{
					throw new ArgumentException("数据已过期，请刷新重试！");
				}
				HR_DONATE_BLOOD newEmployeeBloodPOCO = persisted;
				newEmployeeBloodPOCO.EMPLOYEE_ID = employeeBloodDTO.EMPLOYEE_ID;
				newEmployeeBloodPOCO.EMPLOYEE_NAME = employeeBloodDTO.EMPLOYEE_NAME;
				newEmployeeBloodPOCO.DONATE_NUMBER = employeeBloodDTO.DONATE_NUMBER;
				newEmployeeBloodPOCO.DONATE_LOCATION = employeeBloodDTO.DONATE_LOCATION;
				newEmployeeBloodPOCO.DONATE_DATE = employeeBloodDTO.DONATE_DATE;
				newEmployeeBloodPOCO.REMARK = employeeBloodDTO.REMARK;
				newEmployeeBloodPOCO.EXTEND1 = employeeBloodDTO.EXTEND1;
				newEmployeeBloodPOCO.EXTEND2 = employeeBloodDTO.EXTEND2;
				newEmployeeBloodPOCO.EXTEND3 = employeeBloodDTO.EXTEND3;
				newEmployeeBloodPOCO.EXTEND4 = employeeBloodDTO.EXTEND4;
				newEmployeeBloodPOCO.EXTEND5 = employeeBloodDTO.EXTEND5;
				newEmployeeBloodPOCO.ORG_ID = employeeBloodDTO.ORG_ID;
				newEmployeeBloodPOCO.ORG_NAME = employeeBloodDTO.ORG_NAME;
				newEmployeeBloodPOCO.USER_ID = employeeBloodDTO.USER_ID;
				newEmployeeBloodPOCO.USER_NAME = employeeBloodDTO.USER_NAME;
				employeeBloodRepository.UpdateCommit(newEmployeeBloodPOCO);
				employeeBloodDTO = newEmployeeBloodPOCO.AdaptAsDTO<HR_DONATE_BLOODDTO>();
				return employeeBloodDTO;
			}
			throw new ArgumentException("UpdateDonate不存在相关的实体对象！");
		}
		throw new ValidationException(employeeBloodDTO.GetInvalidMessages());
	}

	public void RemoveDonate(string EmployeeBloodIds)
	{
		string[] idArray = EmployeeBloodIds.Split(",", removeEmptyEntries: true);
		if (idArray == null || !idArray.Any())
		{
			return;
		}
		idArray.ForEach(delegate(string x)
		{
			Guid guid = Guid.Parse(x);
			HR_DONATE_BLOOD byKey = employeeBloodRepository.GetByKey(guid);
			if (byKey != null)
			{
				byKey.ISDEL = 1m;
				employeeBloodRepository.UpdateCommit(byKey);
			}
		});
	}

	public IList<HR_DONATE_BLOODDTO> FindDonateDays(Guid userId, Guid orgId)
	{
		HR_DONATE_BLOODDTO employeeBloodDTO = new HR_DONATE_BLOODDTO();
		employeeBloodDTO.USER_ID = userId;
		employeeBloodDTO.ORG_ID = orgId;
		return SqlQuery<HR_DONATE_BLOODDTO>("FindEmpOfDonate", employeeBloodDTO);
	}

	public bool IsRepeatVacation(string runState, string userId, string keyId, string applyDateFrom, string applyDateTo, string actualDateFrom, string actualDateTo)
	{
		bool flag = false;
		string sqlForActual = "";
		SqlRepository repository = new SqlRepository(null);
		IList<IDataObject> resultApply;
		IList<IDataObject> resultActual;
		if (runState.Trim() == "-1" && string.IsNullOrEmpty(keyId))
		{
			string sqlForApply = "SELECT T1.* FROM HR_VACATION T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID\r\n                                WHERE T2.RUN_STATE=0 AND T1.VACATION_DATE_FROM <=TO_DATE('{0}','YYYY-MM-DD') \r\n                                AND T1.VACATION_DATE_TO >=TO_DATE('{1}','YYYY-MM-DD') AND T1.ISDEL = 0 AND T2.ISDEL=0 \r\n                                AND T1.USER_ID=F_GUIDTORAW('{2}')";
			resultApply = repository.DynamicSqlQuery(string.Format(sqlForApply, applyDateTo, applyDateFrom, userId), null);
			sqlForActual = "SELECT T1.* FROM HR_VACATION T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID\r\n                                WHERE T2.RUN_STATE=2 AND T1.ACTUAL_VACATION_DATE_FROM <=TO_DATE('{0}','YYYY-MM-DD') \r\n                                AND T1.ACTUAL_VACATION_DATE_TO >=TO_DATE('{1}','YYYY-MM-DD') AND T1.ISDEL = 0 AND T2.ISDEL=0 \r\n                                AND T1.USER_ID=F_GUIDTORAW('{2}')";
			resultActual = repository.DynamicSqlQuery(string.Format(sqlForActual, applyDateTo, applyDateFrom, userId), null);
		}
		else if (string.IsNullOrEmpty(actualDateFrom) && string.IsNullOrEmpty(actualDateTo))
		{
			string sqlForApply = "SELECT T1.* FROM HR_VACATION T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID\r\n                                WHERE T2.RUN_STATE=0 AND T1.VACATION_DATE_FROM <=TO_DATE('{0}','YYYY-MM-DD') \r\n                                AND T1.VACATION_DATE_TO >=TO_DATE('{1}','YYYY-MM-DD') AND T1.ISDEL = 0 AND T2.ISDEL=0 \r\n                                AND T1.USER_ID=F_GUIDTORAW('{2}') AND T1.HR_VACATION_ID<>F_GUIDTORAW('{3}')";
			resultApply = repository.DynamicSqlQuery(string.Format(sqlForApply, applyDateTo, applyDateFrom, userId, keyId), null);
			sqlForActual = "SELECT T1.* FROM HR_VACATION T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID\r\n                                WHERE T2.RUN_STATE=2 AND T1.ACTUAL_VACATION_DATE_FROM <=TO_DATE('{0}','YYYY-MM-DD') \r\n                                AND T1.ACTUAL_VACATION_DATE_TO >=TO_DATE('{1}','YYYY-MM-DD') AND T1.ISDEL = 0 AND T2.ISDEL=0 \r\n                                AND T1.USER_ID=F_GUIDTORAW('{2}') AND T1.HR_VACATION_ID<>F_GUIDTORAW('{3}')";
			resultActual = repository.DynamicSqlQuery(string.Format(sqlForActual, applyDateTo, applyDateFrom, userId, keyId), null);
		}
		else
		{
			string sqlForApply = "SELECT T1.* FROM HR_VACATION T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID\r\n                                WHERE T2.RUN_STATE=0 AND T1.VACATION_DATE_FROM <=TO_DATE('{0}','YYYY-MM-DD') \r\n                                AND T1.VACATION_DATE_TO >=TO_DATE('{1}','YYYY-MM-DD') AND T1.ISDEL = 0 AND T2.ISDEL=0 \r\n                                AND T1.USER_ID=F_GUIDTORAW('{2}') AND T1.HR_VACATION_ID<>F_GUIDTORAW('{3}')";
			resultApply = repository.DynamicSqlQuery(string.Format(sqlForApply, actualDateTo, actualDateFrom, userId, keyId), null);
			sqlForActual = "SELECT T1.* FROM HR_VACATION T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID\r\n                                WHERE T2.RUN_STATE=2 AND T1.ACTUAL_VACATION_DATE_FROM <=TO_DATE('{0}','YYYY-MM-DD') \r\n                                AND T1.ACTUAL_VACATION_DATE_TO >=TO_DATE('{1}','YYYY-MM-DD') AND T1.ISDEL = 0 AND T2.ISDEL=0 \r\n                                AND T1.USER_ID=F_GUIDTORAW('{2}') AND T1.HR_VACATION_ID<>F_GUIDTORAW('{3}')";
			resultActual = repository.DynamicSqlQuery(string.Format(sqlForActual, actualDateTo, actualDateFrom, userId, keyId), null);
		}
		if (resultApply.Count > 0 || resultActual.Count > 0)
		{
			flag = true;
		}
		return flag;
	}
}
