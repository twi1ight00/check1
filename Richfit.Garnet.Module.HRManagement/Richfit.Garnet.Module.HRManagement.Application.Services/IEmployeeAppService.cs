using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Dynamic;
using Richfit.Garnet.Module.Base.Infrastructure.Data.Query;
using Richfit.Garnet.Module.HRManagement.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_Vacation.DTO;

namespace Richfit.Garnet.Module.HRManagement.Application.Services;

public interface IEmployeeAppService
{
	/// <summary>
	/// 根据查询条件查询人员信息
	/// </summary>
	/// <param name="queryCondition">查询条件</param>
	/// <returns>人员信息</returns>
	QueryResult<HR_EMPLOYEEDTO> QueryEmployee(HR_EMPLOYEEDTO queryCondition);

	/// <summary>
	/// 新增人员信息
	/// </summary>
	/// <param name="employeeDTO">新增人员信息</param>
	/// <returns>新增人员信息</returns>
	HR_EMPLOYEEDTO AddEmployee(HR_EMPLOYEEDTO employeeDTO);

	/// <summary>
	/// 更新人员信息
	/// </summary>
	/// <param name="employeeDTO">更新人员信息</param>
	/// <returns>更新人员信息</returns>
	HR_EMPLOYEEDTO UpdateEmployee(HR_EMPLOYEEDTO employeeDTO);

	/// <summary>
	/// 根据人员ID查询员工信息
	/// </summary>
	/// <param name="empId">人员ID</param>
	/// <returns>员工信息</returns>
	HR_EMPLOYEEDTO QueryEmpInfoById(Guid empId);

	/// <summary>
	/// 根据员工ID(逗号分割)删除员工信息
	/// </summary>
	/// <param name="EmployeeIds">员工ID(字符串数组)</param>
	void RemoveEmployee(string EmployeeIds);

	void RemoveEmployeeByUserId(string userIds);

	/// <summary>
	/// 根据用户ID返回关联的员工信息
	/// </summary>
	/// <param name="empId"></param>
	/// <returns></returns>
	HR_EMPLOYEEDTO QueryEmpInfoByUserId(Guid userId);

	/// <summary>
	/// 根据人员姓名查找相关人员信息
	/// </summary>
	/// <param name="userName"></param>
	/// <returns></returns>
	IList<HR_EMPLOYEEDTO> GetUserInfoByName(string userName);

	/// <summary>
	/// 获取人员性别统计信息
	/// </summary>
	/// <returns></returns>
	IList<IDataObject> GetSexStatistics();

	/// <summary>
	/// 获取人员学历统计信息
	/// </summary>
	/// <returns></returns>
	IList<IDataObject> GetEducationStatistics();

	/// <summary>
	/// 获取人员职称统计信息
	/// </summary>
	/// <returns></returns>
	IList<IDataObject> GetTechicalStatistics();

	/// <summary>
	/// 获取人员年龄统计信息
	/// </summary>
	/// <returns></returns>
	IList<IDataObject> GetAgerangeStatistics();

	/// <summary>
	/// 根据用户ID获取关联人员的职务
	/// </summary>
	/// <param name="uesID"></param>
	/// <returns></returns>
	HR_EMPLOYEEDTO GetPositionByUserId(Guid uesID);

	/// <summary>
	/// 根据职务ID获取人员信息
	/// </summary>
	/// <param name="positionId"></param>
	/// <returns></returns>
	IList<HR_EMPLOYEEDTO> GetEmpByPosition(Guid positionId);

	/// <summary>
	/// 根据条件导出人员信息
	/// </summary>
	/// <param name="queryCondition"></param>
	/// <returns></returns>
	IList<HR_EMPLOYEEDTO> ExportEmp(HR_EMPLOYEEDTO queryCondition);

	/// <summary>
	/// 获取生日员工列表
	/// </summary>
	/// <returns></returns>
	IList<HR_EMPLOYEEDTO> GetBirthdayEmpList();

	/// <returns>全部人员信息</returns>
	IList<HR_EMPLOYEEDTO> GetALLEmployee();

	HR_EMPLOYEEDTO AddEmployeeAndContact(SYS_USERDTO userDTO);

	HR_EMPLOYEEDTO UpdateEmployeeAndContact(SYS_USERDTO userDTO);

	void UpdateHRInfo();

	bool UpdateLyInfoByYear();

	QueryResult<HR_EMPLOYEEDTO> QueryLyList(HR_EMPLOYEEDTO queryCondition);

	LY_INFODTO UpdateLyInfo(LY_INFODTO employeeDTO);

	QueryResult<HR_VACATION> GetVacationStatistics(HR_VACATION queryCondition);

	QueryResult<HR_DONATE_BLOODDTO> FindEmpOfDonate(HR_DONATE_BLOODDTO queryCondition);

	HR_DONATE_BLOODDTO AddDonate(HR_DONATE_BLOODDTO employeeBloodDTO);

	HR_DONATE_BLOODDTO UpdateDonate(HR_DONATE_BLOODDTO employeeBloodDTO);

	void RemoveDonate(string EmployeeBloodIds);

	IList<HR_DONATE_BLOODDTO> FindDonateDays(Guid userId, Guid orgId);

	bool IsRepeatVacation(string runState, string userId, string keyId, string applyDateFrom, string applyDateTo, string actualDateFrom, string actualDateTo);
}
