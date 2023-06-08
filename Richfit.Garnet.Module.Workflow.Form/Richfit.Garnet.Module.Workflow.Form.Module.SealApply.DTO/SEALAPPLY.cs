using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.SealApply.DTO;

[Serializable]
public class SEALAPPLY : DTOExt, IDTO
{
	private Guid? _sealapply_id;

	private Guid? _apply_user_id;

	private string _apply_user_name;

	private DateTime? _applydate;

	private decimal? _copynum;

	private string _contactunit;

	private string _maincontent;

	private string _remark;

	private string _seal_type;

	private string _sealtypetext;

	private Guid? _seal_org;

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

	private string _handle_user_names;

	private string _yzglyname;

	[Col]
	[Primary]
	public virtual Guid? SEALAPPLY_ID
	{
		get
		{
			return _sealapply_id;
		}
		set
		{
			_sealapply_id = value;
		}
	}

	[Col]
	public virtual Guid? APPLY_USER_ID
	{
		get
		{
			return _apply_user_id;
		}
		set
		{
			_apply_user_id = value;
		}
	}

	[Col]
	public virtual string APPLY_USER_NAME
	{
		get
		{
			return _apply_user_name;
		}
		set
		{
			_apply_user_name = value;
		}
	}

	[Col]
	public virtual string HANDLE_USER_NAMES
	{
		get
		{
			return _handle_user_names;
		}
		set
		{
			_handle_user_names = value;
		}
	}

	[Col]
	public virtual string YZGLYNAME
	{
		get
		{
			return _yzglyname;
		}
		set
		{
			_yzglyname = value;
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
	public virtual decimal? COPYNUM
	{
		get
		{
			return _copynum;
		}
		set
		{
			_copynum = value;
		}
	}

	[Col]
	public virtual string CONTACTUNIT
	{
		get
		{
			return _contactunit;
		}
		set
		{
			_contactunit = value;
		}
	}

	[Col]
	public virtual string MAINCONTENT
	{
		get
		{
			return _maincontent;
		}
		set
		{
			_maincontent = value;
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
	public virtual string SEAL_TYPE
	{
		get
		{
			return _seal_type;
		}
		set
		{
			_seal_type = value;
		}
	}

	[Col]
	public virtual string SEALTYPETEXT
	{
		get
		{
			return _sealtypetext;
		}
		set
		{
			_sealtypetext = value;
		}
	}

	[Col]
	public virtual Guid? SEAL_ORG
	{
		get
		{
			return _seal_org;
		}
		set
		{
			_seal_org = value;
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

	public string APPLYDATE_FROM { get; set; }

	public string APPLYDATE_TO { get; set; }

	public string RUN_STATE { get; set; }

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

	public SEALAPPLY()
	{
		_addsql = "insert into SEALAPPLY (\r\nSEALAPPLY_ID ,\r\nAPPLY_USER_ID ,\r\nAPPLY_USER_NAME ,\r\nAPPLYDATE ,\r\nCOPYNUM ,\r\nCONTACTUNIT ,\r\nMAINCONTENT ,\r\nREMARK ,\r\nSEAL_TYPE ,\r\nSEALTYPETEXT ,\r\nSEAL_ORG ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:SEALAPPLY_ID ,\r\n:APPLY_USER_ID ,\r\n:APPLY_USER_NAME ,\r\n:APPLYDATE ,\r\n:COPYNUM ,\r\n:CONTACTUNIT ,\r\n:MAINCONTENT ,\r\n:REMARK ,\r\n:SEAL_TYPE ,\r\n:SEALTYPETEXT ,\r\n:SEAL_ORG ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM SEALAPPLY WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME,T3.HANDLE_USER_NAMES,T9.HANDLE_USER_NAME AS YZGLYNAME FROM SEALAPPLY T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID \r\nLEFT JOIN (\r\nselect t.instance_id,listagg(to_char(t.handle_user_name),',') within GROUP (order by t.handle_time)  handle_user_names\r\n  from wf_workitem_handler t\r\n  left join WF_WORKITEM t8 on t.workitem_id=t8.workitem_id\r\n where  t.isdel = 0\r\n   and t.handle_user_name is not null\r\n   and t.workitem_name!='发起申请' and t.workitem_name!='条件' and t.workitem_name!='印章管理员确认' and t.handle_result!=1024  and t8.handle_result!=1024\r\n   group by t.instance_id\r\n   )T3 ON T3.INSTANCE_ID=T1.INSTANCE_ID \r\n  LEFT JOIN WF_WORKITEM_HANDLER T9 ON T9.INSTANCE_ID=T1.INSTANCE_ID AND T9.WORKITEM_NAME='印章管理员确认' AND T9.HANDLE_RESULT=2 ";
		WhereSimple = "T2.ISDEL=0 AND  T2.RUN_STATE=2\r\n           AND T1.SEAL_ORG=:SEAL_ORG\r\n           AND ((@APPLY_USER_NAME IS NULL OR T1.APPLY_USER_NAME LIKE ('%'||(@APPLY_USER_NAME)||'%'))\r\n OR (@SEALTYPETEXT IS NULL OR T1.SEALTYPETEXT LIKE ('%'||(@SEALTYPETEXT)||'%')))";
		WhereAdvance = "T2.ISDEL=0 AND T2.RUN_STATE=2  AND T1.SEAL_ORG=:SEAL_ORG\r\n         AND\r\n(\r\n(@APPLY_USER_NAME IS NULL OR T1.APPLY_USER_NAME LIKE ('%'||(@APPLY_USER_NAME)||'%'))\r\n AND (@SEALTYPETEXT IS NULL OR T1.SEALTYPETEXT LIKE ('%'||(@SEALTYPETEXT)||'%'))\r\n AND(@ORG_NAME IS NULL OR T1.ORG_NAME LIKE ('%'||(@ORG_NAME)||'%'))\r\n AND (@USER_NAME IS NULL OR T1.USER_NAME LIKE ('%'||(@USER_NAME)||'%'))\r\nAND (@APPLYDATE_TO IS NULL OR T1.APPLYDATE <= TO_DATE(@APPLYDATE_TO,'YYYY-MM-DD'))\r\nAND (@APPLYDATE_FROM IS NULL OR T1.APPLYDATE >= TO_DATE(@APPLYDATE_FROM,'YYYY-MM-DD'))\r\n)\r\n";
		_updatesql = "update SEALAPPLY set APPLY_USER_ID=:APPLY_USER_ID \r\n,APPLY_USER_NAME=:APPLY_USER_NAME \r\n,APPLYDATE=:APPLYDATE \r\n,COPYNUM=:COPYNUM \r\n,CONTACTUNIT=:CONTACTUNIT \r\n,MAINCONTENT=:MAINCONTENT \r\n,REMARK=:REMARK \r\n,SEAL_TYPE=:SEAL_TYPE \r\n,SEALTYPETEXT=:SEALTYPETEXT \r\n,SEAL_ORG=:SEAL_ORG \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		SEALAPPLY dto = parm.JsonDeserialize<SEALAPPLY>(new JsonConverter[0]);
		return FindList<SEALAPPLY>(dto);
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
