using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_PURCHASING_APPLY.DTO;

[Serializable]
public class IT_PURCHASING_APPLY_DETAIL : DTOExt, IDTO
{
	private Guid? _material_id;

	private string _material_name;

	private decimal? _material_number;

	private decimal? _check_in;

	private string _remark;

	private Guid? _it_purchasing_apply_detail_id;

	private Guid? _it_purchasing_apply_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Col]
	public virtual Guid? MATERIAL_ID
	{
		get
		{
			return _material_id;
		}
		set
		{
			_material_id = value;
		}
	}

	[Col]
	public virtual string MATERIAL_NAME
	{
		get
		{
			return _material_name;
		}
		set
		{
			_material_name = value;
		}
	}

	[Col]
	public virtual decimal? MATERIAL_NUMBER
	{
		get
		{
			return _material_number;
		}
		set
		{
			_material_number = value;
		}
	}

	[Col]
	public virtual decimal? CHECK_IN
	{
		get
		{
			return _check_in;
		}
		set
		{
			_check_in = value;
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
	[Primary]
	public virtual Guid? IT_PURCHASING_APPLY_DETAIL_ID
	{
		get
		{
			return _it_purchasing_apply_detail_id;
		}
		set
		{
			_it_purchasing_apply_detail_id = value;
		}
	}

	[Col]
	[Foreign]
	public virtual Guid? IT_PURCHASING_APPLY_ID
	{
		get
		{
			return _it_purchasing_apply_id;
		}
		set
		{
			_it_purchasing_apply_id = value;
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

	public IT_PURCHASING_APPLY_DETAIL()
	{
		_addsql = "insert into IT_PURCHASING_APPLY_DETAIL (\r\nMATERIAL_ID ,\r\nMATERIAL_NAME ,\r\nMATERIAL_NUMBER ,\r\nCHECK_IN ,\r\nREMARK ,\r\nIT_PURCHASING_APPLY_DETAIL_ID ,\r\nIT_PURCHASING_APPLY_ID ) values (\r\n:MATERIAL_ID ,\r\n:MATERIAL_NAME ,\r\n:MATERIAL_NUMBER ,\r\n:CHECK_IN ,\r\n:REMARK ,\r\n:IT_PURCHASING_APPLY_DETAIL_ID ,\r\n:IT_PURCHASING_APPLY_ID )";
		_findbyinstance = "SELECT * FROM IT_PURCHASING_APPLY_DETAIL WHERE IT_PURCHASING_APPLY_ID=:IT_PURCHASING_APPLY_ID";
		_updatesql = "update IT_PURCHASING_APPLY_DETAIL set MATERIAL_ID=:MATERIAL_ID \r\n,MATERIAL_NAME=:MATERIAL_NAME \r\n,MATERIAL_NUMBER=:MATERIAL_NUMBER \r\n,CHECK_IN=:CHECK_IN \r\n,REMARK=:REMARK \r\n,IT_PURCHASING_APPLY_ID=:IT_PURCHASING_APPLY_ID \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		IT_PURCHASING_APPLY_DETAIL dto = parm.JsonDeserialize<IT_PURCHASING_APPLY_DETAIL>(new JsonConverter[0]);
		return FindList<IT_PURCHASING_APPLY_DETAIL>(dto);
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
