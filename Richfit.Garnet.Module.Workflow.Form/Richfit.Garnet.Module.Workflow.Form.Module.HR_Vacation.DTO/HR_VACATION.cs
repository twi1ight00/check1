using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_Vacation.DTO;

[Serializable]
public class HR_VACATION : DTOExt, IDTO
{
	private Guid? _hr_vacation_id;

	private Guid? _user_level_id;

	private string _user_level_name;

	private Guid? _vacation_type;

	private string _user_workage;

	private string _reason;

	private DateTime? _vacation_date_from;

	private DateTime? _vacation_date_to;

	private string _user_phone;

	private string _remark;

	private DateTime? _back_date;

	private DateTime? _actual_vacation_date_from;

	private DateTime? _actual_vacation_date_to;

	private string _vacation_apply_days;

	private string _actual_vacation_days;

	private string _vacation_days;

	private string _vacation_days_left;

	private Guid? _creator;

	private decimal? _isdel;

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
	public virtual Guid? HR_VACATION_ID
	{
		get
		{
			return _hr_vacation_id;
		}
		set
		{
			_hr_vacation_id = value;
		}
	}

	[Col]
	public virtual Guid? USER_LEVEL_ID
	{
		get
		{
			return _user_level_id;
		}
		set
		{
			_user_level_id = value;
		}
	}

	[Col]
	public virtual string USER_LEVEL_NAME
	{
		get
		{
			return _user_level_name;
		}
		set
		{
			_user_level_name = value;
		}
	}

	[Col]
	public virtual Guid? VACATION_TYPE
	{
		get
		{
			return _vacation_type;
		}
		set
		{
			_vacation_type = value;
		}
	}

	[Col]
	public virtual string USER_WORKAGE
	{
		get
		{
			return _user_workage;
		}
		set
		{
			_user_workage = value;
		}
	}

	[Col]
	public virtual string REASON
	{
		get
		{
			return _reason;
		}
		set
		{
			_reason = value;
		}
	}

	[Col]
	public virtual DateTime? VACATION_DATE_FROM
	{
		get
		{
			return _vacation_date_from;
		}
		set
		{
			_vacation_date_from = value;
		}
	}

	[Col]
	public virtual DateTime? VACATION_DATE_TO
	{
		get
		{
			return _vacation_date_to;
		}
		set
		{
			_vacation_date_to = value;
		}
	}

	[Col]
	public virtual string USER_PHONE
	{
		get
		{
			return _user_phone;
		}
		set
		{
			_user_phone = value;
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
	public virtual DateTime? BACK_DATE
	{
		get
		{
			return _back_date;
		}
		set
		{
			_back_date = value;
		}
	}

	[Col]
	public virtual DateTime? ACTUAL_VACATION_DATE_FROM
	{
		get
		{
			return _actual_vacation_date_from;
		}
		set
		{
			_actual_vacation_date_from = value;
		}
	}

	[Col]
	public virtual DateTime? ACTUAL_VACATION_DATE_TO
	{
		get
		{
			return _actual_vacation_date_to;
		}
		set
		{
			_actual_vacation_date_to = value;
		}
	}

	[Col]
	public virtual string VACATION_APPLY_DAYS
	{
		get
		{
			return _vacation_apply_days;
		}
		set
		{
			_vacation_apply_days = value;
		}
	}

	[Col]
	public virtual string ACTUAL_VACATION_DAYS
	{
		get
		{
			return _actual_vacation_days;
		}
		set
		{
			_actual_vacation_days = value;
		}
	}

	[Col]
	public virtual string VACATION_DAYS
	{
		get
		{
			return _vacation_days;
		}
		set
		{
			_vacation_days = value;
		}
	}

	[Col]
	public virtual string VACATION_DAYS_LEFT
	{
		get
		{
			return _vacation_days_left;
		}
		set
		{
			_vacation_days_left = value;
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

	public string VACATION_TYPE_NAME { get; set; }

	public string RUN_STATE { get; set; }

	public string VACATION_DATE_FROM_START { get; set; }

	public string VACATION_DATE_TO_END { get; set; }

	public string CURRENT_YEAR { get; set; }

	public string EMPLOYEE_NAME { get; set; }

	public string POSITION_NAME { get; set; }

	public decimal? TOTAL_APPLY_DAYS { get; set; }

	public decimal? TOTAL_ACTUAL_DAYS { get; set; }

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

	public HR_VACATION()
	{
		_addsql = "insert into HR_VACATION (\r\nHR_VACATION_ID ,\r\nUSER_LEVEL_ID ,\r\nUSER_LEVEL_NAME ,\r\nVACATION_TYPE ,\r\nUSER_WORKAGE ,\r\nREASON ,\r\nVACATION_DATE_FROM ,\r\nVACATION_DATE_TO ,\r\nUSER_PHONE ,\r\nREMARK ,\r\nBACK_DATE ,\r\nACTUAL_VACATION_DATE_FROM ,\r\nACTUAL_VACATION_DATE_TO ,\r\nVACATION_APPLY_DAYS ,\r\nACTUAL_VACATION_DAYS ,\r\nVACATION_DAYS ,\r\nVACATION_DAYS_LEFT ,\r\nCREATOR ,\r\nISDEL ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:HR_VACATION_ID ,\r\n:USER_LEVEL_ID ,\r\n:USER_LEVEL_NAME ,\r\n:VACATION_TYPE ,\r\n:USER_WORKAGE ,\r\n:REASON ,\r\n:VACATION_DATE_FROM ,\r\n:VACATION_DATE_TO ,\r\n:USER_PHONE ,\r\n:REMARK ,\r\n:BACK_DATE ,\r\n:ACTUAL_VACATION_DATE_FROM ,\r\n:ACTUAL_VACATION_DATE_TO ,\r\n:VACATION_APPLY_DAYS ,\r\n:ACTUAL_VACATION_DAYS ,\r\n:VACATION_DAYS ,\r\n:VACATION_DAYS_LEFT ,\r\n:CREATOR ,\r\n:ISDEL ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT T1.*,\r\nT2.STRING_KEY_DESC AS VACATION_TYPE_NAME FROM HR_VACATION T1 \r\nLEFT JOIN V_CODE_TABLE T2 ON T1.VACATION_TYPE=T2.CODE_TABLE_ID\r\nWHERE T1.INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T3.STRING_KEY_DESC AS VACATION_TYPE_NAME,\r\nT2.TEMPLATE_ID,T2.INSTANCE_NAME,T2.RUN_STATE FROM HR_VACATION T1 \r\nLEFT JOIN V_CODE_TABLE T3 ON T1.VACATION_TYPE=T3.CODE_TABLE_ID\r\nLEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		WhereSimple = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) \r\n         AND (@USER_NAME IS NULL OR T1.USER_NAME LIKE ('%'||(@USER_NAME)||'%'))";
		WhereAdvance = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) \r\n         AND\r\n(\r\n(@USER_NAME IS NULL OR T1.USER_NAME LIKE ('%'||(@USER_NAME)||'%'))\r\n AND (@USER_PHONE IS NULL OR T1.USER_PHONE LIKE ('%'||(@USER_PHONE)||'%'))\r\nAND (@VACATION_DATE_FROM_START IS NULL OR T1.VACATION_DATE_FROM >= TO_DATE(@VACATION_DATE_FROM_START,'YYYY-MM-DD'))\r\nAND (@VACATION_DATE_TO_END IS NULL OR T1.VACATION_DATE_TO <= TO_DATE(@VACATION_DATE_TO_END,'YYYY-MM-DD'))\r\n)\r\n";
		_updatesql = "update HR_VACATION set USER_LEVEL_ID=:USER_LEVEL_ID \r\n,USER_LEVEL_NAME=:USER_LEVEL_NAME \r\n,VACATION_TYPE=:VACATION_TYPE \r\n,USER_WORKAGE=:USER_WORKAGE \r\n,REASON=:REASON \r\n,VACATION_DATE_FROM=:VACATION_DATE_FROM \r\n,VACATION_DATE_TO=:VACATION_DATE_TO \r\n,USER_PHONE=:USER_PHONE \r\n,REMARK=:REMARK \r\n,BACK_DATE=:BACK_DATE \r\n,ACTUAL_VACATION_DATE_FROM=:ACTUAL_VACATION_DATE_FROM \r\n,ACTUAL_VACATION_DATE_TO=:ACTUAL_VACATION_DATE_TO \r\n,VACATION_APPLY_DAYS=:VACATION_APPLY_DAYS \r\n,ACTUAL_VACATION_DAYS=:ACTUAL_VACATION_DAYS \r\n,VACATION_DAYS=:VACATION_DAYS \r\n,VACATION_DAYS_LEFT=:VACATION_DAYS_LEFT \r\n,CREATOR=:CREATOR \r\n,ISDEL=:ISDEL \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		HR_VACATION dto = parm.JsonDeserialize<HR_VACATION>(new JsonConverter[0]);
		return FindList<HR_VACATION>(dto);
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
