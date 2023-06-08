using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO;

[Serializable]
public class IT_MATERIAL_APPLY_DETAIL : DTOExt, IDTO
{
	private string _remark;

	private Guid? _material_type_id;

	private string _material_type_name;

	private decimal? _material_number;

	private string _material_user_id;

	private string _material_user_name;

	private Guid? _it_material_apply_detail_id;

	private Guid? _it_material_apply_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

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
	public virtual Guid? MATERIAL_TYPE_ID
	{
		get
		{
			return _material_type_id;
		}
		set
		{
			_material_type_id = value;
		}
	}

	[Col]
	public virtual string MATERIAL_TYPE_NAME
	{
		get
		{
			return _material_type_name;
		}
		set
		{
			_material_type_name = value;
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
	public virtual string MATERIAL_USER_ID
	{
		get
		{
			return _material_user_id;
		}
		set
		{
			_material_user_id = value;
		}
	}

	[Col]
	public virtual string MATERIAL_USER_NAME
	{
		get
		{
			return _material_user_name;
		}
		set
		{
			_material_user_name = value;
		}
	}

	[Col]
	[Primary]
	public virtual Guid? IT_MATERIAL_APPLY_DETAIL_ID
	{
		get
		{
			return _it_material_apply_detail_id;
		}
		set
		{
			_it_material_apply_detail_id = value;
		}
	}

	[Foreign]
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

	public string MATERIAL_NUMBER_LEFT { get; set; }

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

	public IT_MATERIAL_APPLY_DETAIL()
	{
		_addsql = "insert into IT_MATERIAL_APPLY_DETAIL (\r\nREMARK ,\r\nMATERIAL_TYPE_ID ,\r\nMATERIAL_TYPE_NAME ,\r\nMATERIAL_NUMBER ,\r\nMATERIAL_USER_ID ,\r\nMATERIAL_USER_NAME ,\r\nIT_MATERIAL_APPLY_DETAIL_ID ,\r\nIT_MATERIAL_APPLY_ID ) values (\r\n:REMARK ,\r\n:MATERIAL_TYPE_ID ,\r\n:MATERIAL_TYPE_NAME ,\r\n:MATERIAL_NUMBER ,\r\n:MATERIAL_USER_ID ,\r\n:MATERIAL_USER_NAME ,\r\n:IT_MATERIAL_APPLY_DETAIL_ID ,\r\n:IT_MATERIAL_APPLY_ID )";
		_findbyinstance = "\r\nSELECT T1.*,T3.STOCK_QUANTITY AS MATERIAL_NUMBER_LEFT FROM IT_MATERIAL_APPLY_DETAIL T1\r\nLEFT JOIN IT_MATERIAL_APPLY T2 ON T1.IT_MATERIAL_APPLY_ID=T2.IT_MATERIAL_APPLY_ID\r\nLEFT JOIN IT_MATERIAL T3 ON T3.IT_MATERIAL_ID=T1.MATERIAL_TYPE_ID\r\nWHERE T1.IT_MATERIAL_APPLY_ID=:IT_MATERIAL_APPLY_ID";
		_updatesql = "update IT_MATERIAL_APPLY_DETAIL set REMARK=:REMARK \r\n,MATERIAL_TYPE_ID=:MATERIAL_TYPE_ID \r\n,MATERIAL_TYPE_NAME=:MATERIAL_TYPE_NAME \r\n,MATERIAL_NUMBER=:MATERIAL_NUMBER \r\n,MATERIAL_USER_ID=:MATERIAL_USER_ID \r\n,MATERIAL_USER_NAME=:MATERIAL_USER_NAME \r\n,IT_MATERIAL_APPLY_ID=:IT_MATERIAL_APPLY_ID \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		IT_MATERIAL_APPLY_DETAIL dto = parm.JsonDeserialize<IT_MATERIAL_APPLY_DETAIL>(new JsonConverter[0]);
		return FindList<IT_MATERIAL_APPLY_DETAIL>(dto);
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
