using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.FA_TravelExpense.DTO;

[Serializable]
public class FA_TRAVELEXPENSE : DTOExt, IDTO
{
	private Guid? _fa_travelexpense_id;

	private string _travel_purpose;

	private string _traveller_names;

	private string _traveller_names_string;

	private DateTime? _application_date;

	private decimal? _subsidy_subtotal;

	private decimal? _hotel_expense;

	private decimal? _traffic_expense;

	private decimal? _flight_expense;

	private decimal? _cancellation_fee;

	private decimal? _other_subsidy;

	private decimal? _other_traffic;

	private decimal? _other_expense;

	private decimal? _extras_subtotal;

	private decimal? _amount;

	private string _amount_in_words;

	private decimal? _petty_cash;

	private string _note;

	private decimal? _attachment_count;

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

	private IList<FA_TRAVELEXPENSE_DETAIL> _fa_travelexpense_detail;

	[Col]
	[Primary]
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

	[Col]
	public virtual string TRAVEL_PURPOSE
	{
		get
		{
			return _travel_purpose;
		}
		set
		{
			_travel_purpose = value;
		}
	}

	[Col]
	public virtual string TRAVELLER_NAMES
	{
		get
		{
			return _traveller_names;
		}
		set
		{
			_traveller_names = value;
		}
	}

	[Col]
	public virtual string TRAVELLER_NAMES_STRING
	{
		get
		{
			return _traveller_names_string;
		}
		set
		{
			_traveller_names_string = value;
		}
	}

	[Col]
	public virtual DateTime? APPLICATION_DATE
	{
		get
		{
			return _application_date;
		}
		set
		{
			_application_date = value;
		}
	}

	[Col]
	public virtual decimal? SUBSIDY_SUBTOTAL
	{
		get
		{
			return _subsidy_subtotal;
		}
		set
		{
			_subsidy_subtotal = value;
		}
	}

	[Col]
	public virtual decimal? HOTEL_EXPENSE
	{
		get
		{
			return _hotel_expense;
		}
		set
		{
			_hotel_expense = value;
		}
	}

	[Col]
	public virtual decimal? TRAFFIC_EXPENSE
	{
		get
		{
			return _traffic_expense;
		}
		set
		{
			_traffic_expense = value;
		}
	}

	[Col]
	public virtual decimal? FLIGHT_EXPENSE
	{
		get
		{
			return _flight_expense;
		}
		set
		{
			_flight_expense = value;
		}
	}

	[Col]
	public virtual decimal? CANCELLATION_FEE
	{
		get
		{
			return _cancellation_fee;
		}
		set
		{
			_cancellation_fee = value;
		}
	}

	[Col]
	public virtual decimal? OTHER_SUBSIDY
	{
		get
		{
			return _other_subsidy;
		}
		set
		{
			_other_subsidy = value;
		}
	}

	[Col]
	public virtual decimal? OTHER_TRAFFIC
	{
		get
		{
			return _other_traffic;
		}
		set
		{
			_other_traffic = value;
		}
	}

	[Col]
	public virtual decimal? OTHER_EXPENSE
	{
		get
		{
			return _other_expense;
		}
		set
		{
			_other_expense = value;
		}
	}

	[Col]
	public virtual decimal? EXTRAS_SUBTOTAL
	{
		get
		{
			return _extras_subtotal;
		}
		set
		{
			_extras_subtotal = value;
		}
	}

	[Col]
	public virtual decimal? AMOUNT
	{
		get
		{
			return _amount;
		}
		set
		{
			_amount = value;
		}
	}

	[Col]
	public virtual string AMOUNT_IN_WORDS
	{
		get
		{
			return _amount_in_words;
		}
		set
		{
			_amount_in_words = value;
		}
	}

	[Col]
	public virtual decimal? PETTY_CASH
	{
		get
		{
			return _petty_cash;
		}
		set
		{
			_petty_cash = value;
		}
	}

	[Col]
	public virtual string NOTE
	{
		get
		{
			return _note;
		}
		set
		{
			_note = value;
		}
	}

	[Col]
	public virtual decimal? ATTACHMENT_COUNT
	{
		get
		{
			return _attachment_count;
		}
		set
		{
			_attachment_count = value;
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

	public string AMOUNT_FROM { get; set; }

	public string AMOUNT_TO { get; set; }

	public string APPLICATION_DATE_FROM { get; set; }

	public string APPLICATION_DATE_TO { get; set; }

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

	[Sub]
	public virtual IList<FA_TRAVELEXPENSE_DETAIL> FA_TRAVELEXPENSE_DETAIL
	{
		get
		{
			return _fa_travelexpense_detail;
		}
		set
		{
			_fa_travelexpense_detail = value;
		}
	}

	public FA_TRAVELEXPENSE()
	{
		_addsql = "insert into FA_TRAVELEXPENSE (\r\nFA_TRAVELEXPENSE_ID ,\r\nTRAVEL_PURPOSE ,\r\nTRAVELLER_NAMES ,\r\nTRAVELLER_NAMES_STRING ,\r\nAPPLICATION_DATE ,\r\nSUBSIDY_SUBTOTAL ,\r\nHOTEL_EXPENSE ,\r\nTRAFFIC_EXPENSE ,\r\nFLIGHT_EXPENSE ,\r\nCANCELLATION_FEE ,\r\nOTHER_SUBSIDY ,\r\nOTHER_TRAFFIC ,\r\nOTHER_EXPENSE ,\r\nEXTRAS_SUBTOTAL ,\r\nAMOUNT ,\r\nAMOUNT_IN_WORDS ,\r\nPETTY_CASH ,\r\nNOTE ,\r\nATTACHMENT_COUNT ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:FA_TRAVELEXPENSE_ID ,\r\n:TRAVEL_PURPOSE ,\r\n:TRAVELLER_NAMES ,\r\n:TRAVELLER_NAMES_STRING ,\r\n:APPLICATION_DATE ,\r\n:SUBSIDY_SUBTOTAL ,\r\n:HOTEL_EXPENSE ,\r\n:TRAFFIC_EXPENSE ,\r\n:FLIGHT_EXPENSE ,\r\n:CANCELLATION_FEE ,\r\n:OTHER_SUBSIDY ,\r\n:OTHER_TRAFFIC ,\r\n:OTHER_EXPENSE ,\r\n:EXTRAS_SUBTOTAL ,\r\n:AMOUNT ,\r\n:AMOUNT_IN_WORDS ,\r\n:PETTY_CASH ,\r\n:NOTE ,\r\n:ATTACHMENT_COUNT ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM FA_TRAVELEXPENSE WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.FA_TRAVELEXPENSE_ID,\r\n       T1.TRAVEL_PURPOSE,\r\n       T1.APPLICATION_DATE,\r\n       T1.AMOUNT,\r\nT1.USER_ID,\r\nT1.USER_NAME,\r\n       T1.ORG_ID,\r\n       T1.ORG_NAME,\r\nT1.CREATETIME,\r\n       T1.INSTANCE_ID,\r\n       T1.TRAVELLER_NAMES_STRING,\r\n       T2.TEMPLATE_ID,\r\n       T2.INSTANCE_NAME,\r\n       T2.RUN_STATE\r\n  FROM FA_TRAVELEXPENSE T1\r\n  LEFT JOIN WF_INSTANCE T2\r\n    ON T1.INSTANCE_ID = T2.INSTANCE_ID ";
		WhereSimple = " T2.ISDEL=0 AND T2.RUN_STATE in (0,2) AND ((@TRAVELLER_NAMES_STRING IS NULL OR TRAVELLER_NAMES_STRING LIKE ('%'||@TRAVELLER_NAMES_STRING||'%')) OR (@ORG_NAME IS NULL OR T1.ORG_NAME LIKE ('%'||@ORG_NAME||'%')))";
		WhereAdvance = " T2.ISDEL=0 AND T2.RUN_STATE in (0,2) AND (@TRAVELLER_NAMES_STRING IS NULL OR TRAVELLER_NAMES_STRING LIKE ('%'||@TRAVELLER_NAMES_STRING||'%')) AND (@ORG_NAME IS NULL OR T1.ORG_NAME LIKE ('%'||@ORG_NAME||'%')) AND (@AMOUNT_FROM IS NULL OR AMOUNT >= @AMOUNT_FROM) AND (@AMOUNT_TO IS NULL OR AMOUNT <= @AMOUNT_TO) AND (@APPLICATION_DATE_FROM IS NULL OR APPLICATION_DATE >= TO_DATE(@APPLICATION_DATE_FROM,'YYYY-MM-DD')) AND (@APPLICATION_DATE_TO IS NULL OR APPLICATION_DATE <= TO_DATE(@APPLICATION_DATE_TO,'YYYY-MM-DD'))";
		_updatesql = "update FA_TRAVELEXPENSE set TRAVEL_PURPOSE=:TRAVEL_PURPOSE \r\n,TRAVELLER_NAMES=:TRAVELLER_NAMES \r\n,TRAVELLER_NAMES_STRING=:TRAVELLER_NAMES_STRING \r\n,APPLICATION_DATE=:APPLICATION_DATE \r\n,SUBSIDY_SUBTOTAL=:SUBSIDY_SUBTOTAL \r\n,HOTEL_EXPENSE=:HOTEL_EXPENSE \r\n,TRAFFIC_EXPENSE=:TRAFFIC_EXPENSE \r\n,FLIGHT_EXPENSE=:FLIGHT_EXPENSE \r\n,CANCELLATION_FEE=:CANCELLATION_FEE \r\n,OTHER_SUBSIDY=:OTHER_SUBSIDY \r\n,OTHER_TRAFFIC=:OTHER_TRAFFIC \r\n,OTHER_EXPENSE=:OTHER_EXPENSE \r\n,EXTRAS_SUBTOTAL=:EXTRAS_SUBTOTAL \r\n,AMOUNT=:AMOUNT \r\n,AMOUNT_IN_WORDS=:AMOUNT_IN_WORDS \r\n,PETTY_CASH=:PETTY_CASH \r\n,NOTE=:NOTE \r\n,ATTACHMENT_COUNT=:ATTACHMENT_COUNT \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
		_fa_travelexpense_detail = new List<FA_TRAVELEXPENSE_DETAIL>();
	}

	public override string FindList(string parm)
	{
		FA_TRAVELEXPENSE dto = parm.JsonDeserialize<FA_TRAVELEXPENSE>(new JsonConverter[0]);
		return FindList<FA_TRAVELEXPENSE>(dto);
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
