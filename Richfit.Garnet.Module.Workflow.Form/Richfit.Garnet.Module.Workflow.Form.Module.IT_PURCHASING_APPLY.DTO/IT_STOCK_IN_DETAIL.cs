using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_PURCHASING_APPLY.DTO;

[Serializable]
public class IT_STOCK_IN_DETAIL : DTOExt, IDTO
{
	private Guid? _it_stock_in_detail_id;

	private Guid? _it_stock_in_id;

	private Guid? _it_purchasing_apply_detail_id;

	private Guid? _material_id;

	private string _material_name;

	private decimal? _material_number;

	private decimal? _stock_quantity;

	private decimal? _check_in;

	private Guid? _instance_id;

	private decimal? _isdel;

	private Guid? _creator;

	private DateTime? _createtime;

	private Guid? _modifier;

	private DateTime? _modifytime;

	private string _addsql;

	[Col]
	[Primary]
	public virtual Guid? IT_STOCK_IN_DETAIL_ID
	{
		get
		{
			return _it_stock_in_detail_id;
		}
		set
		{
			_it_stock_in_detail_id = value;
		}
	}

	[Col]
	public virtual Guid? IT_STOCK_IN_ID
	{
		get
		{
			return _it_stock_in_id;
		}
		set
		{
			_it_stock_in_id = value;
		}
	}

	[Col]
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

	public IT_STOCK_IN_DETAIL()
	{
		_addsql = "insert into IT_STOCK_IN_DETAIL (\r\nIT_STOCK_IN_DETAIL_ID ,\r\nIT_STOCK_IN_ID,\r\nIT_PURCHASING_APPLY_DETAIL_ID,\r\nMATERIAL_ID ,\r\nMATERIAL_NAME ,\r\nMATERIAL_NUMBER ,\r\nCHECK_IN,\r\nINSTANCE_ID ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME \r\n) values (\r\n:IT_STOCK_IN_DETAIL_ID ,\r\n:IT_STOCK_IN_ID,\r\n:IT_PURCHASING_APPLY_DETAIL_ID,\r\n:MATERIAL_ID ,\r\n:MATERIAL_NAME ,\r\n:MATERIAL_NUMBER ,\r\n:CHECK_IN,\r\n:INSTANCE_ID ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME  )";
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
