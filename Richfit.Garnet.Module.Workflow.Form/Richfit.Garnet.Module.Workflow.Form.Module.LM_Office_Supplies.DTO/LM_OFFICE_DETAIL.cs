using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_Office_Supplies.DTO;

[Serializable]
public class LM_OFFICE_DETAIL : DTOExt, IDTO
{
	private string _typename;

	private string _countnum;

	private string _remark;

	private Guid? _office_detail_id;

	private Guid? _office_supplies_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Col]
	public virtual string TYPENAME
	{
		get
		{
			return _typename;
		}
		set
		{
			_typename = value;
		}
	}

	[Col]
	public virtual string COUNTNUM
	{
		get
		{
			return _countnum;
		}
		set
		{
			_countnum = value;
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

	[Primary]
	[Col]
	public virtual Guid? OFFICE_DETAIL_ID
	{
		get
		{
			return _office_detail_id;
		}
		set
		{
			_office_detail_id = value;
		}
	}

	[Col]
	[Foreign]
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

	public LM_OFFICE_DETAIL()
	{
		_addsql = "insert into LM_OFFICE_DETAIL (\r\nTYPENAME ,\r\nCOUNTNUM ,\r\nREMARK ,\r\nOFFICE_DETAIL_ID ,\r\nOFFICE_SUPPLIES_ID ) values (\r\n:TYPENAME ,\r\n:COUNTNUM ,\r\n:REMARK ,\r\n:OFFICE_DETAIL_ID ,\r\n:OFFICE_SUPPLIES_ID )";
		_findbyinstance = "SELECT * FROM LM_OFFICE_DETAIL WHERE OFFICE_SUPPLIES_ID=:OFFICE_SUPPLIES_ID";
		_updatesql = "update LM_OFFICE_DETAIL set TYPENAME=:TYPENAME \r\n,COUNTNUM=:COUNTNUM \r\n,REMARK=:REMARK \r\n,OFFICE_DETAIL_ID=:OFFICE_DETAIL_ID \r\n,OFFICE_SUPPLIES_ID=:OFFICE_SUPPLIES_ID \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		LM_OFFICE_DETAIL dto = parm.JsonDeserialize<LM_OFFICE_DETAIL>(new JsonConverter[0]);
		return FindList<LM_OFFICE_DETAIL>(dto);
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
