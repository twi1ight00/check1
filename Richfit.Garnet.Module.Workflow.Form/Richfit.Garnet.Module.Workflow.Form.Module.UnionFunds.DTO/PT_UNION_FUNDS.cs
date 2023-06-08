using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.UnionFunds.DTO;

[Serializable]
public class PT_UNION_FUNDS : DTOExt, IDTO
{
	private Guid? _pt_union_funds_id;

	private string _active_personnel;

	private string _active_personnels;

	private DateTime? _activity_time;

	private string _activity_background;

	private string _activity_place;

	private decimal? _activity_budget;

	private decimal? _total;

	private decimal? _spend;

	private string _title;

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
	public virtual Guid? PT_UNION_FUNDS_ID
	{
		get
		{
			return _pt_union_funds_id;
		}
		set
		{
			_pt_union_funds_id = value;
		}
	}

	[Col]
	public virtual string ACTIVE_PERSONNEL
	{
		get
		{
			return _active_personnel;
		}
		set
		{
			_active_personnel = value;
		}
	}

	[Col]
	public virtual string ACTIVE_PERSONNELS
	{
		get
		{
			return _active_personnels;
		}
		set
		{
			_active_personnels = value;
		}
	}

	[Col]
	public virtual DateTime? ACTIVITY_TIME
	{
		get
		{
			return _activity_time;
		}
		set
		{
			_activity_time = value;
		}
	}

	[Col]
	public virtual string ACTIVITY_BACKGROUND
	{
		get
		{
			return _activity_background;
		}
		set
		{
			_activity_background = value;
		}
	}

	[Col]
	public virtual string ACTIVITY_PLACE
	{
		get
		{
			return _activity_place;
		}
		set
		{
			_activity_place = value;
		}
	}

	[Col]
	public virtual decimal? ACTIVITY_BUDGET
	{
		get
		{
			return _activity_budget;
		}
		set
		{
			_activity_budget = value;
		}
	}

	[Col]
	public virtual decimal? TOTAL
	{
		get
		{
			return _total;
		}
		set
		{
			_total = value;
		}
	}

	[Col]
	public virtual decimal? SPEND
	{
		get
		{
			return _spend;
		}
		set
		{
			_spend = value;
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

	public PT_UNION_FUNDS()
	{
		_addsql = "insert into PT_UNION_FUNDS (\r\nPT_UNION_FUNDS_ID ,\r\nACTIVE_PERSONNEL ,\r\nACTIVE_PERSONNELS ,\r\nACTIVITY_TIME ,\r\nACTIVITY_BACKGROUND ,\r\nACTIVITY_PLACE ,\r\nACTIVITY_BUDGET ,\r\nTOTAL ,\r\nSPEND ,\r\nTITLE ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:PT_UNION_FUNDS_ID ,\r\n:ACTIVE_PERSONNEL ,\r\n:ACTIVE_PERSONNELS ,\r\n:ACTIVITY_TIME ,\r\n:ACTIVITY_BACKGROUND ,\r\n:ACTIVITY_PLACE ,\r\n:ACTIVITY_BUDGET ,\r\n:TOTAL ,\r\n:SPEND ,\r\n:TITLE ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM PT_UNION_FUNDS WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM PT_UNION_FUNDS T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update PT_UNION_FUNDS set ACTIVE_PERSONNEL=:ACTIVE_PERSONNEL \r\n,ACTIVE_PERSONNELS=:ACTIVE_PERSONNELS \r\n,ACTIVITY_TIME=:ACTIVITY_TIME \r\n,ACTIVITY_BACKGROUND=:ACTIVITY_BACKGROUND \r\n,ACTIVITY_PLACE=:ACTIVITY_PLACE \r\n,ACTIVITY_BUDGET=:ACTIVITY_BUDGET \r\n,TOTAL=:TOTAL \r\n,SPEND=:SPEND \r\n,TITLE=:TITLE \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		PT_UNION_FUNDS dto = parm.JsonDeserialize<PT_UNION_FUNDS>(new JsonConverter[0]);
		return FindList<PT_UNION_FUNDS>(dto);
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
