using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.IT_MATERIAL_APPLY.DTO;

[Serializable]
public class IT_MATERIAL_CHECKIN : DTOExt, IDTO
{
	private string _remark;

	private Guid? _it_material_id;

	private string _it_material_name;

	private decimal? _check_in_no;

	private Guid? _it_material_checkin_id;

	private Guid? _it_material_apply_id;

	private decimal? _isdel;

	private Guid? _creator;

	private DateTime? _createtime;

	private Guid? _modifier;

	private DateTime? _modifytime;

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
	public virtual Guid? IT_MATERIAL_ID
	{
		get
		{
			return _it_material_id;
		}
		set
		{
			_it_material_id = value;
		}
	}

	[Col]
	public virtual string IT_MATERIAL_NAME
	{
		get
		{
			return _it_material_name;
		}
		set
		{
			_it_material_name = value;
		}
	}

	[Col]
	public virtual decimal? CHECK_IN_NO
	{
		get
		{
			return _check_in_no;
		}
		set
		{
			_check_in_no = value;
		}
	}

	[Col]
	[Primary]
	public virtual Guid? IT_MATERIAL_CHECKIN_ID
	{
		get
		{
			return _it_material_checkin_id;
		}
		set
		{
			_it_material_checkin_id = value;
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

	public IT_MATERIAL_CHECKIN()
	{
		_addsql = "insert into IT_MATERIAL_CHECKIN (\r\nREMARK ,\r\nIT_MATERIAL_ID ,\r\nIT_MATERIAL_NAME ,\r\nCHECK_IN_NO ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nIT_MATERIAL_CHECKIN_ID ,\r\nIT_MATERIAL_APPLY_ID ) values (\r\n:REMARK ,\r\n:IT_MATERIAL_ID ,\r\n:IT_MATERIAL_NAME ,\r\n:CHECK_IN_NO ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:IT_MATERIAL_CHECKIN_ID ,\r\n:IT_MATERIAL_APPLY_ID )";
		_findbyinstance = "SELECT * FROM IT_MATERIAL_CHECKIN WHERE IT_MATERIAL_APPLY_ID=:IT_MATERIAL_APPLY_ID";
		_updatesql = "update IT_MATERIAL_CHECKIN set REMARK=:REMARK \r\n,IT_MATERIAL_ID=:IT_MATERIAL_ID \r\n,IT_MATERIAL_NAME=:IT_MATERIAL_NAME\r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,CHECK_IN_NO=:CHECK_IN_NO \r\n,IT_MATERIAL_APPLY_ID=:IT_MATERIAL_APPLY_ID \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		IT_MATERIAL_CHECKIN dto = parm.JsonDeserialize<IT_MATERIAL_CHECKIN>(new JsonConverter[0]);
		return FindList<IT_MATERIAL_CHECKIN>(dto);
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
