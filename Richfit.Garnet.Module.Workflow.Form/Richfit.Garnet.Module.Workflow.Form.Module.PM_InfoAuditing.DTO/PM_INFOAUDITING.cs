using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PM_InfoAuditing.DTO;

[Serializable]
public class PM_INFOAUDITING : DTOExt, IDTO
{
	private Guid? _pm_infoauditing_id;

	private DateTime? _applytime;

	private string _website_type;

	private string _website_other_name;

	private string _platform_type;

	private string _platform_other_name;

	private string _title;

	private string _content;

	private Guid? _is_audit;

	private Guid? _user_type;

	private Guid? _operate_type;

	private string _user_info;

	private Guid? _change_type;

	private string _change_content;

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
	public virtual Guid? PM_INFOAUDITING_ID
	{
		get
		{
			return _pm_infoauditing_id;
		}
		set
		{
			_pm_infoauditing_id = value;
		}
	}

	[Col]
	public virtual DateTime? APPLYTIME
	{
		get
		{
			return _applytime;
		}
		set
		{
			_applytime = value;
		}
	}

	[Col]
	public virtual string WEBSITE_TYPE
	{
		get
		{
			return _website_type;
		}
		set
		{
			_website_type = value;
		}
	}

	[Col]
	public virtual string WEBSITE_OTHER_NAME
	{
		get
		{
			return _website_other_name;
		}
		set
		{
			_website_other_name = value;
		}
	}

	[Col]
	public virtual string PLATFORM_TYPE
	{
		get
		{
			return _platform_type;
		}
		set
		{
			_platform_type = value;
		}
	}

	[Col]
	public virtual string PLATFORM_OTHER_NAME
	{
		get
		{
			return _platform_other_name;
		}
		set
		{
			_platform_other_name = value;
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
	public virtual Guid? IS_AUDIT
	{
		get
		{
			return _is_audit;
		}
		set
		{
			_is_audit = value;
		}
	}

	[Col]
	public virtual Guid? USER_TYPE
	{
		get
		{
			return _user_type;
		}
		set
		{
			_user_type = value;
		}
	}

	[Col]
	public virtual Guid? OPERATE_TYPE
	{
		get
		{
			return _operate_type;
		}
		set
		{
			_operate_type = value;
		}
	}

	[Col]
	public virtual string USER_INFO
	{
		get
		{
			return _user_info;
		}
		set
		{
			_user_info = value;
		}
	}

	[Col]
	public virtual Guid? CHANGE_TYPE
	{
		get
		{
			return _change_type;
		}
		set
		{
			_change_type = value;
		}
	}

	[Col]
	public virtual string CHANGE_CONTENT
	{
		get
		{
			return _change_content;
		}
		set
		{
			_change_content = value;
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

	public string RUN_STATE { get; set; }

	public string IS_AUDIT_NAME { get; set; }

	public string USER_TYPE_NAME { get; set; }

	public string OPERATE_TYPE_NAME { get; set; }

	public string CHANGE_TYPE_NAME { get; set; }

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

	public PM_INFOAUDITING()
	{
		_addsql = "insert into PM_INFOAUDITING (\r\nPM_INFOAUDITING_ID ,\r\nAPPLYTIME ,\r\nWEBSITE_TYPE ,\r\nWEBSITE_OTHER_NAME ,\r\nPLATFORM_TYPE ,\r\nPLATFORM_OTHER_NAME ,\r\nTITLE ,\r\nCONTENT ,\r\nIS_AUDIT ,\r\nUSER_TYPE ,\r\nOPERATE_TYPE ,\r\nUSER_INFO ,\r\nCHANGE_TYPE ,\r\nCHANGE_CONTENT ,\r\nREMARK ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:PM_INFOAUDITING_ID ,\r\n:APPLYTIME ,\r\n:WEBSITE_TYPE ,\r\n:WEBSITE_OTHER_NAME ,\r\n:PLATFORM_TYPE ,\r\n:PLATFORM_OTHER_NAME ,\r\n:TITLE ,\r\n:CONTENT ,\r\n:IS_AUDIT ,\r\n:USER_TYPE ,\r\n:OPERATE_TYPE ,\r\n:USER_INFO ,\r\n:CHANGE_TYPE ,\r\n:CHANGE_CONTENT ,\r\n:REMARK ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT T1.*, \r\nT2.STRING_KEY_DESC AS IS_AUDIT_NAME,T3.STRING_KEY_DESC AS USER_TYPE_NAME,\r\nT4.STRING_KEY_DESC AS OPERATE_TYPE_NAME,T5.STRING_KEY_DESC AS CHANGE_TYPE_NAME FROM PM_INFOAUDITING T1 \r\nLEFT JOIN V_CODE_TABLE T2 ON T1.IS_AUDIT=T2.CODE_TABLE_ID\r\nLEFT JOIN V_CODE_TABLE T3 ON T1.USER_TYPE=T3.CODE_TABLE_ID\r\nLEFT JOIN V_CODE_TABLE T4 ON T1.OPERATE_TYPE=T4.CODE_TABLE_ID\r\nLEFT JOIN V_CODE_TABLE T5 ON T1.CHANGE_TYPE=T5.CODE_TABLE_ID\r\n WHERE T1.INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME,T2.RUN_STATE FROM PM_INFOAUDITING T1 \r\nLEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		WhereSimple = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) \r\n         AND (@TITLE IS NULL OR T1.TITLE LIKE ('%'||(@TITLE)||'%'))";
		WhereAdvance = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) \r\n         AND\r\n(\r\n(@USER_NAME IS NULL OR T1.USER_NAME LIKE ('%'||(@USER_NAME)||'%'))\r\n AND (@TITLE IS NULL OR T1.TITLE LIKE ('%'||(@TITLE)||'%'))\r\n)\r\n";
		_updatesql = "update PM_INFOAUDITING set APPLYTIME=:APPLYTIME \r\n,WEBSITE_TYPE=:WEBSITE_TYPE \r\n,WEBSITE_OTHER_NAME=:WEBSITE_OTHER_NAME \r\n,PLATFORM_TYPE=:PLATFORM_TYPE \r\n,PLATFORM_OTHER_NAME=:PLATFORM_OTHER_NAME \r\n,TITLE=:TITLE \r\n,CONTENT=:CONTENT \r\n,IS_AUDIT=:IS_AUDIT \r\n,USER_TYPE=:USER_TYPE \r\n,OPERATE_TYPE=:OPERATE_TYPE \r\n,USER_INFO=:USER_INFO \r\n,CHANGE_TYPE=:CHANGE_TYPE \r\n,CHANGE_CONTENT=:CHANGE_CONTENT \r\n,REMARK=:REMARK \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		PM_INFOAUDITING dto = parm.JsonDeserialize<PM_INFOAUDITING>(new JsonConverter[0]);
		return FindList<PM_INFOAUDITING>(dto);
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
