using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO;

[Serializable]
public class IT_STOCK_OUT_DETAIL : DTOExt, IDTO
{
	private Guid? _it_stock_out_detail_id;

	private Guid? _it_material_apply_id;

	private Guid? _instance_id;

	private Guid? _material_id;

	private string _material_name;

	private decimal? _material_number;

	private Guid? _user_id;

	private string _user_name;

	private Guid? _org_id;

	private string _org_name;

	private decimal? _stock_quantity;

	private decimal? _isdel;

	private Guid? _creator;

	private DateTime? _createtime;

	private Guid? _modifier;

	private DateTime? _modifytime;

	private string _addsql;

	[Primary]
	[Col]
	public virtual Guid? IT_STOCK_OUT_DETAIL_ID
	{
		get
		{
			return _it_stock_out_detail_id;
		}
		set
		{
			_it_stock_out_detail_id = value;
		}
	}

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
	public virtual decimal? STOCK_QUANTITY
	{
		get
		{
			return _stock_quantity;
		}
		set
		{
			_stock_quantity = value;
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

	public IT_STOCK_OUT_DETAIL()
	{
		_addsql = "insert into IT_STOCK_OUT_DETAIL (\r\nIT_STOCK_OUT_DETAIL_ID ,\r\nIT_MATERIAL_APPLY_ID ,\r\nINSTANCE_ID ,\r\nMATERIAL_ID ,\r\nMATERIAL_NAME ,\r\nMATERIAL_NUMBER ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nSTOCK_QUANTITY ) values (\r\n:IT_STOCK_OUT_DETAIL_ID ,\r\n:IT_MATERIAL_APPLY_ID ,\r\n:INSTANCE_ID ,\r\n:MATERIAL_ID ,\r\n:MATERIAL_NAME ,\r\n:MATERIAL_NUMBER ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:STOCK_QUANTITY )";
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
