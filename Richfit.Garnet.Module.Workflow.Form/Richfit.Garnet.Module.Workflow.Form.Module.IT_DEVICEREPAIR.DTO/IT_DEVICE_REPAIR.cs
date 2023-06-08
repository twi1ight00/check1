using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_DEVICEREPAIR.DTO;

[Serializable]
public class IT_DEVICE_REPAIR : DTOExt, IDTO
{
	private Guid? _it_device_repair_id;

	private string _device_name;

	private string _repair_reason;

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
	public virtual Guid? IT_DEVICE_REPAIR_ID
	{
		get
		{
			return _it_device_repair_id;
		}
		set
		{
			_it_device_repair_id = value;
		}
	}

	[Col]
	public virtual string DEVICE_NAME
	{
		get
		{
			return _device_name;
		}
		set
		{
			_device_name = value;
		}
	}

	[Col]
	public virtual string REPAIR_REASON
	{
		get
		{
			return _repair_reason;
		}
		set
		{
			_repair_reason = value;
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

	public IT_DEVICE_REPAIR()
	{
		_addsql = "insert into IT_DEVICE_REPAIR (\r\nIT_DEVICE_REPAIR_ID ,\r\nDEVICE_NAME ,\r\nREPAIR_REASON ,\r\nREMARK ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:IT_DEVICE_REPAIR_ID ,\r\n:DEVICE_NAME ,\r\n:REPAIR_REASON ,\r\n:REMARK ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM IT_DEVICE_REPAIR WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME,T2.RUN_STATE FROM IT_DEVICE_REPAIR T1 \r\nLEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		WhereSimple = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) \r\n         AND (@DEVICE_NAME IS NULL OR T1.DEVICE_NAME LIKE ('%'||(@DEVICE_NAME)||'%'))";
		WhereAdvance = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) \r\n         AND\r\n(\r\n(@USER_NAME IS NULL OR T1.USER_NAME LIKE ('%'||(@USER_NAME)||'%'))\r\n AND (@DEVICE_NAME IS NULL OR T1.DEVICE_NAME LIKE ('%'||(@DEVICE_NAME)||'%'))\r\n)\r\n";
		_updatesql = "update IT_DEVICE_REPAIR set DEVICE_NAME=:DEVICE_NAME \r\n,REPAIR_REASON=:REPAIR_REASON \r\n,REMARK=:REMARK \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		IT_DEVICE_REPAIR dto = parm.JsonDeserialize<IT_DEVICE_REPAIR>(new JsonConverter[0]);
		return FindList<IT_DEVICE_REPAIR>(dto);
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
