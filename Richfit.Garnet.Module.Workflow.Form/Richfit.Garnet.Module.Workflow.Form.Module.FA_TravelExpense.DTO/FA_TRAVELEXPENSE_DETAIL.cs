using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.FA_TravelExpense.DTO;

[Serializable]
public class FA_TRAVELEXPENSE_DETAIL : DTOExt, IDTO
{
	private DateTime? _from_date;

	private DateTime? _to_date;

	private string _from_city;

	private string _to_city;

	private decimal? _days;

	private decimal? _people;

	private decimal? _standard;

	private Guid? _fa_travelexpense_detail_id;

	private decimal? _subtotal;

	private Guid? _fa_travelexpense_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Col]
	public virtual DateTime? FROM_DATE
	{
		get
		{
			return _from_date;
		}
		set
		{
			_from_date = value;
		}
	}

	[Col]
	public virtual DateTime? TO_DATE
	{
		get
		{
			return _to_date;
		}
		set
		{
			_to_date = value;
		}
	}

	[Col]
	public virtual string FROM_CITY
	{
		get
		{
			return _from_city;
		}
		set
		{
			_from_city = value;
		}
	}

	[Col]
	public virtual string TO_CITY
	{
		get
		{
			return _to_city;
		}
		set
		{
			_to_city = value;
		}
	}

	[Col]
	public virtual decimal? DAYS
	{
		get
		{
			return _days;
		}
		set
		{
			_days = value;
		}
	}

	[Col]
	public virtual decimal? PEOPLE
	{
		get
		{
			return _people;
		}
		set
		{
			_people = value;
		}
	}

	[Col]
	public virtual decimal? STANDARD
	{
		get
		{
			return _standard;
		}
		set
		{
			_standard = value;
		}
	}

	[Col]
	[Primary]
	public virtual Guid? FA_TRAVELEXPENSE_DETAIL_ID
	{
		get
		{
			return _fa_travelexpense_detail_id;
		}
		set
		{
			_fa_travelexpense_detail_id = value;
		}
	}

	[Col]
	public virtual decimal? SUBTOTAL
	{
		get
		{
			return _subtotal;
		}
		set
		{
			_subtotal = value;
		}
	}

	[Foreign]
	[Col]
	public virtual Guid? FA_TRAVELEXPENSE_ID
	{
		get
		{
			return _fa_travelexpense_id;
		}
		set
		{
			_fa_travelexpense_id = value;
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

	public FA_TRAVELEXPENSE_DETAIL()
	{
		_addsql = "insert into FA_TRAVELEXPENSE_DETAIL (\r\nFROM_DATE ,\r\nTO_DATE ,\r\nFROM_CITY ,\r\nTO_CITY ,\r\nDAYS ,\r\nPEOPLE ,\r\nSTANDARD ,\r\nFA_TRAVELEXPENSE_DETAIL_ID ,\r\nSUBTOTAL ,\r\nFA_TRAVELEXPENSE_ID ) values (\r\n:FROM_DATE ,\r\n:TO_DATE ,\r\n:FROM_CITY ,\r\n:TO_CITY ,\r\n:DAYS ,\r\n:PEOPLE ,\r\n:STANDARD ,\r\n:FA_TRAVELEXPENSE_DETAIL_ID ,\r\n:SUBTOTAL ,\r\n:FA_TRAVELEXPENSE_ID )";
		_findbyinstance = "SELECT * FROM FA_TRAVELEXPENSE_DETAIL WHERE FA_TRAVELEXPENSE_ID=:FA_TRAVELEXPENSE_ID";
		_updatesql = "update FA_TRAVELEXPENSE_DETAIL set FROM_DATE=:FROM_DATE \r\n,TO_DATE=:TO_DATE \r\n,FROM_CITY=:FROM_CITY \r\n,TO_CITY=:TO_CITY \r\n,DAYS=:DAYS \r\n,PEOPLE=:PEOPLE \r\n,STANDARD=:STANDARD \r\n,SUBTOTAL=:SUBTOTAL \r\n,FA_TRAVELEXPENSE_ID=:FA_TRAVELEXPENSE_ID \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		FA_TRAVELEXPENSE_DETAIL dto = parm.JsonDeserialize<FA_TRAVELEXPENSE_DETAIL>(new JsonConverter[0]);
		return FindList<FA_TRAVELEXPENSE_DETAIL>(dto);
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
