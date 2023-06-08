using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.HandlerProcess;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;
using Richfit.Garnet.Module.HRManagement.Application.DTO;
using Richfit.Garnet.Module.HRManagement.Application.Services;
using Richfit.Garnet.Module.SystemManagement.Application.DTO;
using Richfit.Garnet.Module.Workflow.Form.Module.HR_Vacation.DTO;

namespace Richfit.Garnet.Module.HRManagement.HandlerProcess.Handlers;

public class EmployeeHandler : HandlerBase
{
	private HttpContext context;

	private IEmployeeAppService employeeAppService = ServiceLocator.Instance.GetService<IEmployeeAppService>();

	public override void ProcessRequest(HttpContext context)
	{
		this.context = context;
		string action = base.RequestData.ActionCode;
		ResponseData handlerResult = new ResponseData();
		try
		{
			handlerResult.Code = "Public.I_0001";
			if (!string.IsNullOrEmpty(action))
			{
				switch (action)
				{
				case "HRManagement_AddEmp":
					AddEmp(handlerResult);
					break;
				case "HRManagement_RemoveEmp":
					RemoveEmp(handlerResult);
					break;
				case "HRManagement_UpdateEmp":
					UpdateEmp(handlerResult);
					break;
				case "HRManagement_FindEmp":
					FindEmp(handlerResult);
					break;
				case "HRManagement_GetEmpById":
					GetEmpById(handlerResult);
					break;
				case "HRManagement_FindEmpByUserId":
					GetEmpByUserId(handlerResult);
					break;
				case "HRManagement_GetUserInfoByName":
					GetUserInfoByName(handlerResult);
					break;
				case "HRManagement_GetSexStatistics":
					GetSexStatistics(handlerResult);
					break;
				case "HRManagement_GetEducationStatistics":
					GetEducationStatistics(handlerResult);
					break;
				case "HRManagement_GetTechicalStatistics":
					GetTechicalStatistics(handlerResult);
					break;
				case "HRManagement_GetAgerangeStatistics":
					GetAgerangeStatistics(handlerResult);
					break;
				case "HRManagement_GetPositionByUserId":
					GetPositionByUserId(handlerResult);
					break;
				case "HRManagement_GetEmpByPosition":
					GetEmpByPosition(handlerResult);
					break;
				case "HRManagement_ExportEmp":
					ExportEmp(handlerResult);
					break;
				case "HRManagement_GetBirthdayEmpList":
					GetBirthdayEmpList(handlerResult);
					break;
				case "HRManagement_FindEmpByUserIdForMobile":
					GetMobileEmpByUserId(handlerResult);
					break;
				case "HRManagement_AddEmployeeAndContact":
					AddEmployeeAndContact(handlerResult);
					break;
				case "HRManagement_UpdateLyInfo":
					UpdateLyInfo(handlerResult);
					break;
				case "HRManagement_AddLyInfo":
					AddLyInfo(handlerResult);
					break;
				case "HRManagement_FindLyInfo":
					FindLyInfo(handlerResult);
					break;
				case "HRManagement_UpdateLyInfoByYear":
					UpdateLyInfoByYear(handlerResult);
					break;
				case "HRManagement_GetVacationStatistics":
					GetVacationStatistics(handlerResult);
					break;
				case "HRManagement_UpdateEmployeeAndContact":
					UpdateEmployeeAndContact(handlerResult);
					break;
				case "HRManagement_AddDonate":
					AddDonate(handlerResult);
					break;
				case "HRManagement_UpdateDonate":
					UpdateDonate(handlerResult);
					break;
				case "HRManagement_RemoveDonate":
					RemoveDonate(handlerResult);
					break;
				case "HRManagement_FindEmpOfDonate":
					FindEmpOfDonate(handlerResult);
					break;
				case "HRManagement_FindDonateDays":
					FindDonateDays(handlerResult);
					break;
				case "HRManagement_IsRepeatVacation":
					IsRepeatVacation(handlerResult);
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

	private void IsRepeatVacation(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userId = dictionary["USER_ID"];
		string keyId = dictionary["HR_VACATION_ID"];
		string runState = dictionary["RUN_STATE"];
		string applyDateFrom = dictionary["VACATION_DATE_FROM"];
		string applyDateTo = dictionary["VACATION_DATE_TO"];
		string actualDateFrom = dictionary["ACTUAL_VACATION_DATE_FROM"];
		string actualDateTo = dictionary["ACTUAL_VACATION_DATE_TO"];
		handlerResult.Data = (employeeAppService.IsRepeatVacation(runState, userId, keyId, applyDateFrom, applyDateTo, actualDateFrom, actualDateTo) ? "1" : " 0");
	}

	private void FindDonateDays(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userId = dictionary["USER_ID"];
		string orgId = dictionary["ORG_ID"];
		handlerResult.Data = employeeAppService.FindDonateDays(Guid.Parse(userId), Guid.Parse(orgId)).ToJson();
	}

	private void FindEmpOfDonate(ResponseData handlerResult)
	{
		HR_DONATE_BLOODDTO condition = base.RequestData.Data.JsonDeserialize<HR_DONATE_BLOODDTO>(new JsonConverter[0]);
		handlerResult.Data = employeeAppService.FindEmpOfDonate(condition).ToJson();
	}

	private void RemoveDonate(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		employeeAppService.RemoveDonate(dictionary["DONATE_BLOOD_ID"]);
	}

	private void UpdateDonate(ResponseData handlerResult)
	{
		HR_DONATE_BLOODDTO empDTO = DTOBase.DeserializeFromJson<HR_DONATE_BLOODDTO>(base.RequestData.Data);
		handlerResult.Data = employeeAppService.UpdateDonate(empDTO).ToJson();
	}

	private void AddDonate(ResponseData handlerResult)
	{
		HR_DONATE_BLOODDTO empDTO = DTOBase.DeserializeFromJson<HR_DONATE_BLOODDTO>(base.RequestData.Data);
		handlerResult.Data = employeeAppService.AddDonate(empDTO).ToJson();
	}

	private void GetVacationStatistics(ResponseData handlerResult)
	{
		HR_VACATION condition = base.RequestData.Data.JsonDeserialize<HR_VACATION>(new JsonConverter[0]);
		handlerResult.Data = employeeAppService.GetVacationStatistics(condition).ToJson();
	}

	private void UpdateLyInfoByYear(ResponseData handlerResult)
	{
		handlerResult.Data = (employeeAppService.UpdateLyInfoByYear() ? "1" : "0");
	}

	private void FindLyInfo(ResponseData handlerResult)
	{
		HR_EMPLOYEEDTO condition = base.RequestData.Data.JsonDeserialize<HR_EMPLOYEEDTO>(new JsonConverter[0]);
		handlerResult.Data = employeeAppService.QueryLyList(condition).ToJson();
	}

	private void AddLyInfo(ResponseData handlerResult)
	{
	}

	private void UpdateLyInfo(ResponseData handlerResult)
	{
		LY_INFODTO lyDTO = DTOBase.DeserializeFromJson<LY_INFODTO>(base.RequestData.Data);
		handlerResult.Data = employeeAppService.UpdateLyInfo(lyDTO).ToJson();
	}

	private void AddEmployeeAndContact(ResponseData handlerResult)
	{
		SYS_USERDTO userDTO = DTOBase.DeserializeFromJson<SYS_USERDTO>(base.RequestData.Data);
		handlerResult.Data = employeeAppService.AddEmployeeAndContact(userDTO).ToJson();
	}

	private void UpdateEmployeeAndContact(ResponseData handlerResult)
	{
		SYS_USERDTO userDTO = DTOBase.DeserializeFromJson<SYS_USERDTO>(base.RequestData.Data);
		handlerResult.Data = employeeAppService.UpdateEmployeeAndContact(userDTO).ToJson();
	}

	/// <summary>
	/// 获取属性值
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="t"></param>
	/// <param name="propertyname"></param>
	/// <returns></returns>
	public string GetObjectPropertyValue<T>(T t, string propertyname)
	{
		Type type = typeof(T);
		PropertyInfo property = type.GetProperty(propertyname);
		if (property == null)
		{
			return string.Empty;
		}
		object o = property.GetValue(t, null);
		if (o == null)
		{
			return string.Empty;
		}
		return o.ToString();
	}

	private void GetMobileEmpByUserId(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userId = dictionary["USER_ID"];
		HR_EMPLOYEEDTO employeeDTO = employeeAppService.QueryEmpInfoByUserId(Guid.Parse(userId));
		string path = context.Server.MapPath("/Packages/HRManagement/Config/FormConfig.xml");
		XmlDocument doc = new XmlDocument();
		XmlReaderSettings settings = new XmlReaderSettings();
		settings.IgnoreComments = true;
		XmlReader reader = XmlReader.Create(path, settings);
		doc.Load(reader);
		XmlNode xn = doc.SelectSingleNode("Forms");
		List<HR_FORMDTO> formList = new List<HR_FORMDTO>();
		Hashtable fields = new Hashtable();
		foreach (XmlNode node in xn.ChildNodes)
		{
			XmlElement element = (XmlElement)node;
			HR_FORMDTO formDTO = new HR_FORMDTO();
			formDTO.columnName = element.GetAttribute("Name");
			formDTO.fieldName = element.GetAttribute("Desc");
			formDTO.type = element.GetAttribute("Type");
			formDTO.format = element.GetAttribute("Format");
			formDTO.sort = Convert.ToDecimal(element.GetAttribute("Sort"));
			formList.Add(formDTO);
			fields.Add(formDTO.columnName, string.Empty);
		}
		IOrderedEnumerable<HR_FORMDTO> f = formList.OrderBy((HR_FORMDTO c) => c.sort);
		List<HR_FORMDTO> newFormList = f.ToList();
		Type t = employeeDTO.GetType();
		PropertyInfo[] properties = t.GetProperties();
		PropertyInfo[] array = properties;
		foreach (PropertyInfo info in array)
		{
			string columnName = info.Name;
			string columnValue = GetObjectPropertyValue(employeeDTO, info.Name);
			if (fields.ContainsKey(columnName))
			{
				fields[columnName] = columnValue;
			}
		}
		newFormList.ForEach(delegate(HR_FORMDTO form)
		{
			if (fields.ContainsKey(form.columnName))
			{
				string text = fields[form.columnName].ToString();
				if (form.type == "Date" && !string.IsNullOrEmpty(text))
				{
					text = DateTime.Parse(text).ToString(form.format);
				}
				form.fieldValue = text;
			}
		});
		handlerResult.Data = newFormList.ToJson();
	}

	private void GetBirthdayEmpList(ResponseData handlerResult)
	{
		employeeAppService.UpdateHRInfo();
	}

	private void ExportEmp(ResponseData handlerResult)
	{
		HR_EMPLOYEEDTO queryCondition = null;
		if (!string.IsNullOrEmpty(base.RequestData.Data))
		{
			queryCondition = base.RequestData.Data.JsonDeserialize<HR_EMPLOYEEDTO>(new JsonConverter[0]);
		}
		handlerResult.Data = employeeAppService.ExportEmp(queryCondition).ToJson();
	}

	private void GetEmpByPosition(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string positionId = dictionary["POSITION"];
		handlerResult.Data = employeeAppService.GetEmpByPosition(Guid.Parse(positionId)).ToJson();
	}

	private void GetPositionByUserId(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userId = dictionary["USER_ID"];
		handlerResult.Data = employeeAppService.GetPositionByUserId(Guid.Parse(userId)).ToJson();
	}

	private void AddEmp(ResponseData handlerResult)
	{
		HR_EMPLOYEEDTO empDTO = DTOBase.DeserializeFromJson<HR_EMPLOYEEDTO>(base.RequestData.Data);
		handlerResult.Data = employeeAppService.AddEmployee(empDTO).ToJson();
	}

	private void UpdateEmp(ResponseData handlerResult)
	{
		HR_EMPLOYEEDTO empDTO = DTOBase.DeserializeFromJson<HR_EMPLOYEEDTO>(base.RequestData.Data);
		handlerResult.Data = employeeAppService.UpdateEmployee(empDTO).ToJson();
	}

	private void RemoveEmp(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		if (dictionary.ContainsKey("USER_ID"))
		{
			employeeAppService.RemoveEmployeeByUserId(dictionary["USER_ID"]);
		}
		else
		{
			employeeAppService.RemoveEmployee(dictionary["EMPLOYEE_ID"]);
		}
	}

	private void FindEmp(ResponseData handlerResult)
	{
		HR_EMPLOYEEDTO condition = base.RequestData.Data.JsonDeserialize<HR_EMPLOYEEDTO>(new JsonConverter[0]);
		handlerResult.Data = employeeAppService.QueryEmployee(condition).ToJson();
	}

	private void GetEmpById(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string empId = dictionary["EMPLOYEE_ID"];
		handlerResult.Data = employeeAppService.QueryEmpInfoById(Guid.Parse(empId)).ToJson();
	}

	private void GetEmpByUserId(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userId = dictionary["USER_ID"];
		handlerResult.Data = employeeAppService.QueryEmpInfoByUserId(Guid.Parse(userId)).ToJson();
	}

	private void GetUserInfoByName(ResponseData handlerResult)
	{
		Dictionary<string, string> dictionary = base.RequestData.Data.JsonDeserialize<Dictionary<string, string>>(new JsonConverter[0]);
		string userName = dictionary["USER_NAME"];
		handlerResult.Data = employeeAppService.GetUserInfoByName(userName).ToJson();
	}

	private void GetSexStatistics(ResponseData handlerResult)
	{
		handlerResult.Data = JsonConvert.SerializeObject(employeeAppService.GetSexStatistics());
	}

	private void GetEducationStatistics(ResponseData handlerResult)
	{
		handlerResult.Data = JsonConvert.SerializeObject(employeeAppService.GetEducationStatistics());
	}

	private void GetTechicalStatistics(ResponseData handlerResult)
	{
		handlerResult.Data = JsonConvert.SerializeObject(employeeAppService.GetTechicalStatistics());
	}

	private void GetAgerangeStatistics(ResponseData handlerResult)
	{
		handlerResult.Data = JsonConvert.SerializeObject(employeeAppService.GetAgerangeStatistics());
	}
}
