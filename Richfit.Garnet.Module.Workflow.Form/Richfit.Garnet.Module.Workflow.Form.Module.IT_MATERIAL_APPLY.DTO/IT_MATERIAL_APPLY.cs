using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO;

[Serializable]
public class IT_MATERIAL_APPLY : DTOExt, IDTO
{
	private Guid? _it_material_apply_id;

	private string _remark;

	private DateTime? _apply_time;

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

	private IList<IT_MATERIAL_APPLY_DETAIL> _it_material_apply_detail;

	private IList<IT_MATERIAL_CHECKIN> _it_material_checkin;

	[Primary]
	[Col]
	public virtual Guid? IT_MATERIAL_APPLY_ID
	{
		get
		{
			return _it_material_apply_id;
		}
		set
		{
			_it_material_apply_id = value;
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
	public virtual DateTime? APPLY_TIME
	{
		get
		{
			return _apply_time;
		}
		set
		{
			_apply_time = value;
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

	public string RUN_STATE { get; set; }

	public string APPLY_TIME_FROM { get; set; }

	public string APPLY_TIME_TO { get; set; }

	public string MATERIAL_NAME { get; set; }

	public string MATERIAL_NUMBER { get; set; }

	public string MATERIAL_USER_NAME { get; set; }

	public string MATERIAL_REMARK { get; set; }

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
	public virtual IList<IT_MATERIAL_APPLY_DETAIL> IT_MATERIAL_APPLY_DETAIL
	{
		get
		{
			return _it_material_apply_detail;
		}
		set
		{
			_it_material_apply_detail = value;
		}
	}

	[Sub]
	public virtual IList<IT_MATERIAL_CHECKIN> IT_MATERIAL_CHECKIN
	{
		get
		{
			return _it_material_checkin;
		}
		set
		{
			_it_material_checkin = value;
		}
	}

	public IT_MATERIAL_APPLY()
	{
		_addsql = "insert into IT_MATERIAL_APPLY (\r\nIT_MATERIAL_APPLY_ID ,\r\nREMARK ,\r\nAPPLY_TIME ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:IT_MATERIAL_APPLY_ID ,\r\n:REMARK ,\r\n:APPLY_TIME ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM IT_MATERIAL_APPLY WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T2.*,T1.MATERIAL_TYPE_ID,T3.MATERIAL_NAME,T1.MATERIAL_NUMBER,T1.MATERIAL_USER_NAME,T1.REMARK AS MATERIAL_REMARK,W.TEMPLATE_ID,W.INSTANCE_NAME,W.RUN_STATE FROM IT_MATERIAL_APPLY_DETAIL T1\r\n   LEFT JOIN IT_MATERIAL_APPLY T2 ON T1.IT_MATERIAL_APPLY_ID=T2.IT_MATERIAL_APPLY_ID\r\n   LEFT JOIN WF_INSTANCE W ON T2.INSTANCE_ID=W.INSTANCE_ID\r\n   LEFT JOIN IT_MATERIAL T3 ON T1.MATERIAL_TYPE_ID=T3.IT_MATERIAL_ID ";
		WhereSimple = "T2.ISDEL=0 AND W.ISDEL=0 AND (W.RUN_STATE=2 OR W.RUN_STATE=0) \r\n         AND (@MATERIAL_NAME IS NULL OR T3.MATERIAL_NAME LIKE ('%'||(@MATERIAL_NAME)||'%'))";
		WhereAdvance = "T2.ISDEL=0 AND W.ISDEL=0 AND (W.RUN_STATE=2 OR W.RUN_STATE=0) \r\n         AND\r\n(\r\n(@MATERIAL_NAME IS NULL OR T3.MATERIAL_NAME LIKE ('%'||(@MATERIAL_NAME)||'%'))\r\n AND (@ORG_NAME IS NULL OR T2.ORG_NAME LIKE ('%'||(@ORG_NAME)||'%'))\r\nAND (@APPLY_TIME_FROM IS NULL OR T2.APPLY_TIME >= TO_DATE(@APPLY_TIME_FROM,'YYYY-MM-DD'))\r\nAND (@APPLY_TIME_TO IS NULL OR T2.APPLY_TIME <= TO_DATE(@APPLY_TIME_TO,'YYYY-MM-DD'))\r\n)\r\n";
		_updatesql = "update IT_MATERIAL_APPLY set REMARK=:REMARK \r\n,APPLY_TIME=:APPLY_TIME \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
		_it_material_apply_detail = new List<IT_MATERIAL_APPLY_DETAIL>();
		_it_material_checkin = new List<IT_MATERIAL_CHECKIN>();
	}

	public override string FindList(string parm)
	{
		IT_MATERIAL_APPLY dto = parm.JsonDeserialize<IT_MATERIAL_APPLY>(new JsonConverter[0]);
		return FindList<IT_MATERIAL_APPLY>(dto);
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
