using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_TimesheetSenior.DTO;

[Serializable]
public class HR_TIMESHEETSENIOR : DTOExt, IDTO
{
	private Guid? _hr_timesheetsenior_id;

	private string _organization;

	private DateTime? _month;

	private DateTime? _application_date;

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

	private IList<HR_TIMESHEETSENIOR_DETAIL> _hr_timesheetsenior_detail;

	[Col]
	[Primary]
	public virtual Guid? HR_TIMESHEETSENIOR_ID
	{
		get
		{
			return _hr_timesheetsenior_id;
		}
		set
		{
			_hr_timesheetsenior_id = value;
		}
	}

	[Col]
	public virtual string ORGANIZATION
	{
		get
		{
			return _organization;
		}
		set
		{
			_organization = value;
		}
	}

	[Col]
	public virtual DateTime? MONTH
	{
		get
		{
			return _month;
		}
		set
		{
			_month = value;
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

	[Sub]
	public virtual IList<HR_TIMESHEETSENIOR_DETAIL> HR_TIMESHEETSENIOR_DETAIL
	{
		get
		{
			return _hr_timesheetsenior_detail;
		}
		set
		{
			_hr_timesheetsenior_detail = value;
		}
	}

	public HR_TIMESHEETSENIOR()
	{
		_addsql = "insert into HR_TIMESHEETSENIOR (\r\nHR_TIMESHEETSENIOR_ID ,\r\nORGANIZATION ,\r\nMONTH ,\r\nAPPLICATION_DATE ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:HR_TIMESHEETSENIOR_ID ,\r\n:ORGANIZATION ,\r\n:MONTH ,\r\n:APPLICATION_DATE ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM HR_TIMESHEETSENIOR WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME,T2.RUN_STATE FROM HR_TIMESHEETSENIOR T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update HR_TIMESHEETSENIOR set ORGANIZATION=:ORGANIZATION \r\n,MONTH=:MONTH \r\n,APPLICATION_DATE=:APPLICATION_DATE \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
		_hr_timesheetsenior_detail = new List<HR_TIMESHEETSENIOR_DETAIL>();
	}

	public override string FindList(string parm)
	{
		HR_TIMESHEETSENIOR dto = parm.JsonDeserialize<HR_TIMESHEETSENIOR>(new JsonConverter[0]);
		return FindList<HR_TIMESHEETSENIOR>(dto);
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
