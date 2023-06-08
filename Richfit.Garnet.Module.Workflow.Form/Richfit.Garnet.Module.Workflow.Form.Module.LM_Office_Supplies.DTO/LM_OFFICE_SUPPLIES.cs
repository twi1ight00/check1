using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_Office_Supplies.DTO;

[Serializable]
public class LM_OFFICE_SUPPLIES : DTOExt, IDTO
{
	private Guid? _office_supplies_id;

	private string _title;

	private string _apply_desc;

	private string _applicant_name;

	private Guid? _applicant_id;

	private DateTime? _applicant_time;

	private Guid? _applicant_org_id;

	private string _applicant_org_name;

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

	private IList<LM_OFFICE_DETAIL> _lm_office_detail;

	[Col]
	[Primary]
	public virtual Guid? OFFICE_SUPPLIES_ID
	{
		get
		{
			return _office_supplies_id;
		}
		set
		{
			_office_supplies_id = value;
		}
	}

	[Col]
	public virtual string TITLE
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
		}
	}

	[Col]
	public virtual string APPLY_DESC
	{
		get
		{
			return _apply_desc;
		}
		set
		{
			_apply_desc = value;
		}
	}

	[Col]
	public virtual string APPLICANT_NAME
	{
		get
		{
			return _applicant_name;
		}
		set
		{
			_applicant_name = value;
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
	public virtual DateTime? APPLICANT_TIME
	{
		get
		{
			return _applicant_time;
		}
		set
		{
			_applicant_time = value;
		}
	}

	[Col]
	public virtual Guid? APPLICANT_ORG_ID
	{
		get
		{
			return _applicant_org_id;
		}
		set
		{
			_applicant_org_id = value;
		}
	}

	[Col]
	public virtual string APPLICANT_ORG_NAME
	{
		get
		{
			return _applicant_org_name;
		}
		set
		{
			_applicant_org_name = value;
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

	[Sub]
	public virtual IList<LM_OFFICE_DETAIL> LM_OFFICE_DETAIL
	{
		get
		{
			return _lm_office_detail;
		}
		set
		{
			_lm_office_detail = value;
		}
	}

	public LM_OFFICE_SUPPLIES()
	{
		_addsql = "insert into LM_OFFICE_SUPPLIES (\r\nOFFICE_SUPPLIES_ID ,\r\nTITLE ,\r\nAPPLY_DESC ,\r\nAPPLICANT_NAME ,\r\nAPPLICANT_ID ,\r\nAPPLICANT_TIME ,\r\nAPPLICANT_ORG_ID ,\r\nAPPLICANT_ORG_NAME ,\r\nREMARK ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:OFFICE_SUPPLIES_ID ,\r\n:TITLE ,\r\n:APPLY_DESC ,\r\n:APPLICANT_NAME ,\r\n:APPLICANT_ID ,\r\n:APPLICANT_TIME ,\r\n:APPLICANT_ORG_ID ,\r\n:APPLICANT_ORG_NAME ,\r\n:REMARK ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM LM_OFFICE_SUPPLIES WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM LM_OFFICE_SUPPLIES T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update LM_OFFICE_SUPPLIES set OFFICE_SUPPLIES_ID=:OFFICE_SUPPLIES_ID \r\n,TITLE=:TITLE \r\n,APPLY_DESC=:APPLY_DESC \r\n,APPLICANT_NAME=:APPLICANT_NAME \r\n,APPLICANT_ID=:APPLICANT_ID \r\n,APPLICANT_TIME=:APPLICANT_TIME \r\n,APPLICANT_ORG_ID=:APPLICANT_ORG_ID \r\n,APPLICANT_ORG_NAME=:APPLICANT_ORG_NAME \r\n,REMARK=:REMARK \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
		_lm_office_detail = new List<LM_OFFICE_DETAIL>();
	}

	public override string FindList(string parm)
	{
		LM_OFFICE_SUPPLIES dto = parm.JsonDeserialize<LM_OFFICE_SUPPLIES>(new JsonConverter[0]);
		return FindList<LM_OFFICE_SUPPLIES>(dto);
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
