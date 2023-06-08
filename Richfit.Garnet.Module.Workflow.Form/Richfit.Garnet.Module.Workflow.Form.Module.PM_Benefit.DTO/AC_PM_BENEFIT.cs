using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PM_Benefit.DTO;

[Serializable]
public class AC_PM_BENEFIT : DTOExt, IDTO
{
	private Guid? _pm_benefit_id;

	private string _content;

	private DateTime? _applydate;

	private decimal? _apply_money;

	private decimal? _benefit_type;

	private string _remark;

	private decimal? _isdel;

	private Guid? _creator;

	private DateTime? _createtime;

	private Guid? _modifier;

	private DateTime? _modifytime;

	private Guid? _user_id;

	private string _user_name;

	private Guid? _org_id;

	private string _org_name;

	private Guid? _instance_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Primary]
	[Col]
	public virtual Guid? PM_BENEFIT_ID
	{
		get
		{
			return _pm_benefit_id;
		}
		set
		{
			_pm_benefit_id = value;
		}
	}

	[Col]
	public virtual string CONTENT
	{
		get
		{
			return _content;
		}
		set
		{
			_content = value;
		}
	}

	[Col]
	public virtual DateTime? APPLYDATE
	{
		get
		{
			return _applydate;
		}
		set
		{
			_applydate = value;
		}
	}

	[Col]
	public virtual decimal? APPLY_MONEY
	{
		get
		{
			return _apply_money;
		}
		set
		{
			_apply_money = value;
		}
	}

	[Col]
	public virtual decimal? BENEFIT_TYPE
	{
		get
		{
			return _benefit_type;
		}
		set
		{
			_benefit_type = value;
		}
	}

	[Col]
	public virtual string REMARK
	{
		get
		{
			return _remark;
		}
		set
		{
			_remark = value;
		}
	}

	[Col]
	public override decimal? ISDEL
	{
		get
		{
			return _isdel;
		}
		set
		{
			_isdel = value;
		}
	}

	[Col]
	public override Guid? CREATOR
	{
		get
		{
			return _creator;
		}
		set
		{
			_creator = value;
		}
	}

	[Col]
	public override DateTime? CREATETIME
	{
		get
		{
			return _createtime;
		}
		set
		{
			_createtime = value;
		}
	}

	[Col]
	public override Guid? MODIFIER
	{
		get
		{
			return _modifier;
		}
		set
		{
			_modifier = value;
		}
	}

	[Col]
	public override DateTime? MODIFYTIME
	{
		get
		{
			return _modifytime;
		}
		set
		{
			_modifytime = value;
		}
	}

	[Col]
	public override Guid? USER_ID
	{
		get
		{
			return _user_id;
		}
		set
		{
			_user_id = value;
		}
	}

	[Col]
	public override string USER_NAME
	{
		get
		{
			return _user_name;
		}
		set
		{
			_user_name = value;
		}
	}

	[Col]
	public override Guid? ORG_ID
	{
		get
		{
			return _org_id;
		}
		set
		{
			_org_id = value;
		}
	}

	[Col]
	public override string ORG_NAME
	{
		get
		{
			return _org_name;
		}
		set
		{
			_org_name = value;
		}
	}

	[Col]
	public virtual Guid? INSTANCE_ID
	{
		get
		{
			return _instance_id;
		}
		set
		{
			_instance_id = value;
		}
	}

	[JsonIgnore]
	public override string AddSql
	{
		get
		{
			return _addsql;
		}
		set
		{
			_addsql = value;
		}
	}

	[JsonIgnore]
	public override string UpdateSql
	{
		get
		{
			return _updatesql;
		}
		set
		{
			_updatesql = value;
		}
	}

	[JsonIgnore]
	public override string FindByInstance
	{
		get
		{
			return _findbyinstance;
		}
		set
		{
			_findbyinstance = value;
		}
	}

	[JsonIgnore]
	public override string FindPage
	{
		get
		{
			return _findpage;
		}
		set
		{
			_findpage = value;
		}
	}

	public AC_PM_BENEFIT()
	{
		_addsql = "insert into AC_PM_BENEFIT (\r\nPM_BENEFIT_ID ,\r\nCONTENT ,\r\nAPPLYDATE ,\r\nAPPLY_MONEY ,\r\nBENEFIT_TYPE ,\r\nREMARK ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:PM_BENEFIT_ID ,\r\n:CONTENT ,\r\n:APPLYDATE ,\r\n:APPLY_MONEY ,\r\n:BENEFIT_TYPE ,\r\n:REMARK ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM AC_PM_BENEFIT WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM AC_PM_BENEFIT T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update AC_PM_BENEFIT set PM_BENEFIT_ID=:PM_BENEFIT_ID \r\n,CONTENT=:CONTENT \r\n,APPLYDATE=:APPLYDATE \r\n,APPLY_MONEY=:APPLY_MONEY \r\n,BENEFIT_TYPE=:BENEFIT_TYPE \r\n,REMARK=:REMARK \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		AC_PM_BENEFIT dto = parm.JsonDeserialize<AC_PM_BENEFIT>(new JsonConverter[0]);
		return FindList<AC_PM_BENEFIT>(dto);
	}

	[SpecialName]
	int IDTO.get_SearchType()
	{
		return base.SearchType;
	}

	[SpecialName]
	void IDTO.set_SearchType(int value)
	{
		base.SearchType = value;
	}
}
