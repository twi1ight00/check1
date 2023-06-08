using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_InformationSUApply.DTO;

[Serializable]
public class IT_ISU_APPLY : DTOExt, IDTO
{
	private Guid? _it_isu_apply_id;

	private string _applicant;

	private Guid? _applicant_id;

	private string _contact_mode;

	private string _e_mail;

	private DateTime? _apply_date;

	private string _apply_type;

	private string _sys_name;

	private DateTime? _login_time_from;

	private DateTime? _login_time_to;

	private string _apply_description;

	private string _system_leader;

	private Guid? _system_leader_id;

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
	public virtual Guid? IT_ISU_APPLY_ID
	{
		get
		{
			return _it_isu_apply_id;
		}
		set
		{
			_it_isu_apply_id = value;
		}
	}

	[Col]
	public virtual string APPLICANT
	{
		get
		{
			return _applicant;
		}
		set
		{
			_applicant = value;
		}
	}

	[Col]
	public virtual Guid? APPLICANT_ID
	{
		get
		{
			return _applicant_id;
		}
		set
		{
			_applicant_id = value;
		}
	}

	[Col]
	public virtual string CONTACT_MODE
	{
		get
		{
			return _contact_mode;
		}
		set
		{
			_contact_mode = value;
		}
	}

	[Col]
	public virtual string E_MAIL
	{
		get
		{
			return _e_mail;
		}
		set
		{
			_e_mail = value;
		}
	}

	[Col]
	public virtual DateTime? APPLY_DATE
	{
		get
		{
			return _apply_date;
		}
		set
		{
			_apply_date = value;
		}
	}

	[Col]
	public virtual string APPLY_TYPE
	{
		get
		{
			return _apply_type;
		}
		set
		{
			_apply_type = value;
		}
	}

	[Col]
	public virtual string SYS_NAME
	{
		get
		{
			return _sys_name;
		}
		set
		{
			_sys_name = value;
		}
	}

	[Col]
	public virtual DateTime? LOGIN_TIME_FROM
	{
		get
		{
			return _login_time_from;
		}
		set
		{
			_login_time_from = value;
		}
	}

	[Col]
	public virtual DateTime? LOGIN_TIME_TO
	{
		get
		{
			return _login_time_to;
		}
		set
		{
			_login_time_to = value;
		}
	}

	[Col]
	public virtual string APPLY_DESCRIPTION
	{
		get
		{
			return _apply_description;
		}
		set
		{
			_apply_description = value;
		}
	}

	[Col]
	public virtual string SYSTEM_LEADER
	{
		get
		{
			return _system_leader;
		}
		set
		{
			_system_leader = value;
		}
	}

	[Col]
	public virtual Guid? SYSTEM_LEADER_ID
	{
		get
		{
			return _system_leader_id;
		}
		set
		{
			_system_leader_id = value;
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

	public IT_ISU_APPLY()
	{
		_addsql = "insert into IT_ISU_APPLY (\r\nIT_ISU_APPLY_ID ,\r\nAPPLICANT ,\r\nAPPLICANT_ID ,\r\nCONTACT_MODE ,\r\nE_MAIL ,\r\nAPPLY_DATE ,\r\nAPPLY_TYPE ,\r\nSYS_NAME ,\r\nLOGIN_TIME_FROM ,\r\nLOGIN_TIME_TO ,\r\nAPPLY_DESCRIPTION ,\r\nSYSTEM_LEADER ,\r\nSYSTEM_LEADER_ID ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:IT_ISU_APPLY_ID ,\r\n:APPLICANT ,\r\n:APPLICANT_ID ,\r\n:CONTACT_MODE ,\r\n:E_MAIL ,\r\n:APPLY_DATE ,\r\n:APPLY_TYPE ,\r\n:SYS_NAME ,\r\n:LOGIN_TIME_FROM ,\r\n:LOGIN_TIME_TO ,\r\n:APPLY_DESCRIPTION ,\r\n:SYSTEM_LEADER ,\r\n:SYSTEM_LEADER_ID ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM IT_ISU_APPLY WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM IT_ISU_APPLY T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update IT_ISU_APPLY set APPLICANT=:APPLICANT \r\n,APPLICANT_ID=:APPLICANT_ID \r\n,CONTACT_MODE=:CONTACT_MODE \r\n,E_MAIL=:E_MAIL \r\n,APPLY_DATE=:APPLY_DATE \r\n,APPLY_TYPE=:APPLY_TYPE \r\n,SYS_NAME=:SYS_NAME \r\n,LOGIN_TIME_FROM=:LOGIN_TIME_FROM \r\n,LOGIN_TIME_TO=:LOGIN_TIME_TO \r\n,APPLY_DESCRIPTION=:APPLY_DESCRIPTION \r\n,SYSTEM_LEADER=:SYSTEM_LEADER \r\n,SYSTEM_LEADER_ID=:SYSTEM_LEADER_ID \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		IT_ISU_APPLY dto = parm.JsonDeserialize<IT_ISU_APPLY>(new JsonConverter[0]);
		return FindList<IT_ISU_APPLY>(dto);
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
