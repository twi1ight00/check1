using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Module.Base.Application.Services;
using Richfit.Garnet.Module.Base.Infrastructure.Exceptions;
using Richfit.Garnet.Module.ITManagement.Application.Services;
using Richfit.Garnet.Module.ITManagement.Domain.Models;
using Richfit.Garnet.Module.Workflow.Application.DTO;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Application.Services;
using Richfit.Garnet.Module.Workflow.Domain.Models;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.Service;

public class IT_Material_Apply_V1_Service : RunWorkflow, IRunWorkflow
{
	private ITManagementService itManagementService = ServiceLocator.Instance.GetService<ITManagementService>();

	private static ReaderWriterLock syncLock = new ReaderWriterLock();

	public DateTime lastUpdate = DateTime.Now;

	public bool PrHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		return true;
	}

	public bool AfterHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		if (!string.IsNullOrEmpty(dataJson))
		{
			IT_MATERIAL_APPLYDTO _it_material_applydto = dataJson.JsonDeserialize<IT_MATERIAL_APPLYDTO>(new JsonConverter[0]);
		}
		else
		{
			IT_MATERIAL_APPLYDTO _it_material_applydto = (IT_MATERIAL_APPLYDTO)FindByInstanceId(instance.INSTANCE_ID);
		}
		return activity.ACTIVITY_CODE switch
		{
			"FQ" => true, 
			"END" => true, 
			"DM" => true, 
			"XXCSL" => true, 
			"GRLQ" => true, 
			_ => true, 
		};
	}

	public string InstanceName(string templateName, string dataJson)
	{
		StringBuilder instancename = new StringBuilder("耗材申请-");
		IT_MATERIAL_APPLYDTO _it_material_applydto = dataJson.JsonDeserialize<IT_MATERIAL_APPLYDTO>(new JsonConverter[0]);
		foreach (Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL _it_material_apply_detail in _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL)
		{
			_it_material_apply_detail.IT_MATERIAL_APPLY_ID = _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_ID;
			instancename.Append(_it_material_apply_detail.MATERIAL_TYPE_NAME + "(" + _it_material_apply_detail.MATERIAL_NUMBER + ")");
		}
		return instancename.ToString();
	}

	public bool SaveData(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, string dataJson)
	{
		IT_MATERIAL_APPLYDTO _it_material_applydto = dataJson.JsonDeserialize<IT_MATERIAL_APPLYDTO>(new JsonConverter[0]);
		if (_it_material_applydto.IsCreate)
		{
			Add(_it_material_applydto.IT_MATERIAL_APPLY);
			if (_it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL != null && _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL.Count > 0)
			{
				foreach (Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL _it_material_apply_detail in _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL)
				{
					_it_material_apply_detail.IT_MATERIAL_APPLY_ID = _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_ID;
					Add(_it_material_apply_detail);
				}
			}
		}
		else if (activity.ACTIVITY_CODE == "GRLQ")
		{
			UpdateStock(_it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL, _it_material_applydto.IT_MATERIAL_APPLY);
		}
		else
		{
			Update(_it_material_applydto.IT_MATERIAL_APPLY);
			string sql = "delete from IT_MATERIAL_APPLY_DETAIL where IT_MATERIAL_APPLY_ID=:IT_MATERIAL_APPLY_ID";
			repository.ExecuteCommand(sql, _it_material_applydto.IT_MATERIAL_APPLY);
			if (_it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL.Count > 0)
			{
				foreach (Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL _it_material_apply_detail in _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL)
				{
					_it_material_apply_detail.IT_MATERIAL_APPLY_ID = _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_ID;
					Add(_it_material_apply_detail);
				}
			}
		}
		return true;
	}

	public List<User> GetNextHandler(WF_TEMPLATE template, WF_INSTANCE instance, WF_ACTIVITY activity, Guid orgId, string dataJson)
	{
		return GetActivityParticipantOnlyUser(instance, activity.ACTIVITY_ID, orgId);
	}

	public IDTO FindByInstanceId(Guid instanceId)
	{
		IT_MATERIAL_APPLYDTO _it_material_applydto = new IT_MATERIAL_APPLYDTO();
		_it_material_applydto.IT_MATERIAL_APPLY = FindByInstanceId<Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY>(instanceId);
		if (_it_material_applydto.IT_MATERIAL_APPLY != null)
		{
			_it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_DETAIL = repository.ExecuteQuery<Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL>(new Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL().FindByInstance, new { _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_ID });
			_it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_CHECKIN = repository.ExecuteQuery<Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_CHECKIN>(new Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_CHECKIN().FindByInstance, new { _it_material_applydto.IT_MATERIAL_APPLY.IT_MATERIAL_APPLY_ID });
		}
		return _it_material_applydto;
	}

	public void UpdateStock(IList<Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL> materialdetails, Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY materialapply)
	{
		syncLock.AcquireWriterLock(-1);
		try
		{
			if (materialdetails == null || materialdetails.Count <= 0 || materialapply == null)
			{
				return;
			}
			IList<IT_MATERIAL> realMaterial = new List<IT_MATERIAL>();
			IEnumerable<IGrouping<Guid?, Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL>> groupInfo = from a in materialdetails
				group a by a.MATERIAL_TYPE_ID;
			foreach (IGrouping<Guid?, Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL> item in groupInfo)
			{
				decimal? tempchange = 0m;
				string selectsql = "SELECT * FROM IT_MATERIAL WHERE  IT_MATERIAL_ID=:IT_MATERIAL_ID";
				IT_MATERIAL material = repository.ExecuteQuery<IT_MATERIAL>(selectsql, new
				{
					IT_MATERIAL_ID = item.Key
				}).FirstOrDefault();
				foreach (Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL applydetail in item)
				{
					tempchange += applydetail.MATERIAL_NUMBER;
				}
				decimal? num = material.STOCK_QUANTITY - tempchange;
				if (num.GetValueOrDefault() < 0m && num.HasValue)
				{
					throw new ValidationException(new string[1] { $" 耗材{material.MATERIAL_NAME}库存不足" });
				}
				realMaterial.Add(material);
			}
			foreach (Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_MATERIAL_APPLY_DETAIL _it_material_apply_detail in materialdetails)
			{
				Func<IT_MATERIAL, bool> predicate = delegate(IT_MATERIAL a)
				{
					Guid iT_MATERIAL_ID = a.IT_MATERIAL_ID;
					Guid? mATERIAL_TYPE_ID = _it_material_apply_detail.MATERIAL_TYPE_ID;
					return iT_MATERIAL_ID == mATERIAL_TYPE_ID;
				};
				IT_MATERIAL temp = realMaterial.SingleOrDefault(predicate);
				Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_STOCK_OUT_DETAIL stockoutdeail = new Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO.IT_STOCK_OUT_DETAIL();
				stockoutdeail.IT_MATERIAL_APPLY_ID = materialapply.IT_MATERIAL_APPLY_ID.Value;
				stockoutdeail.IT_STOCK_OUT_DETAIL_ID = Guid.NewGuid();
				stockoutdeail.INSTANCE_ID = materialapply.INSTANCE_ID;
				stockoutdeail.MATERIAL_ID = temp.IT_MATERIAL_ID;
				stockoutdeail.MATERIAL_NAME = temp.MATERIAL_NAME;
				stockoutdeail.MATERIAL_NUMBER = _it_material_apply_detail.MATERIAL_NUMBER;
				stockoutdeail.USER_ID = materialapply.USER_ID;
				stockoutdeail.USER_NAME = materialapply.USER_NAME;
				stockoutdeail.ORG_ID = materialapply.ORG_ID;
				stockoutdeail.ORG_NAME = materialapply.ORG_NAME;
				stockoutdeail.STOCK_QUANTITY = temp.STOCK_QUANTITY.Value;
				Add(stockoutdeail);
				decimal? STOCK_QUANTITY = temp.STOCK_QUANTITY - _it_material_apply_detail.MATERIAL_NUMBER;
				decimal? num = STOCK_QUANTITY;
				if (num.GetValueOrDefault() >= 0m && num.HasValue)
				{
					string updatesql = "update IT_MATERIAL set STOCK_QUANTITY= " + STOCK_QUANTITY + " where IT_MATERIAL_ID=:IT_MATERIAL_ID";
					repository.ExecuteCommand(updatesql, new
					{
						IT_MATERIAL_ID = _it_material_apply_detail.MATERIAL_TYPE_ID
					});
					lastUpdate = DateTime.Now;
					ServiceBase.log.Info($"操作时间: {lastUpdate} 耗材{_it_material_apply_detail.MATERIAL_TYPE_NAME}库存{temp.STOCK_QUANTITY}减少{_it_material_apply_detail.MATERIAL_NUMBER}");
					temp.STOCK_QUANTITY = STOCK_QUANTITY;
					continue;
				}
				throw new ValidationException(new string[1] { $" 耗材{temp.MATERIAL_NAME}库存不足" });
			}
		}
		finally
		{
			syncLock.ReleaseWriterLock();
		}
	}
}
