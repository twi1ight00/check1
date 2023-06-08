using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_TimesheetSenior.DTO;

[Serializable]
public class HR_TIMESHEETSENIOR_DETAIL : DTOExt, IDTO
{
	private decimal? _sn;

	private string _user_name;

	private Guid? _user_id;

	private decimal? _ycq;

	private decimal? _cq;

	private decimal? _bj;

	private decimal? _sj;

	private Guid? _hr_timesheetsenior_detail_id;

	private decimal? _qt;

	private Guid? _hr_timesheetsenior_id;

	private string _remark;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Col]
	public virtual decimal? SN
	{
		get
		{
			return _sn;
		}
		set
		{
			_sn = value;
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
	public virtual decimal? YCQ
	{
		get
		{
			return _ycq;
		}
		set
		{
			_ycq = value;
		}
	}

	[Col]
	public virtual decimal? CQ
	{
		get
		{
			return _cq;
		}
		set
		{
			_cq = value;
		}
	}

	[Col]
	public virtual decimal? BJ
	{
		get
		{
			return _bj;
		}
		set
		{
			_bj = value;
		}
	}

	[Col]
	public virtual decimal? SJ
	{
		get
		{
			return _sj;
		}
		set
		{
			_sj = value;
		}
	}

	[Col]
	[Primary]
	public virtual Guid? HR_TIMESHEETSENIOR_DETAIL_ID
	{
		get
		{
			return _hr_timesheetsenior_detail_id;
		}
		set
		{
			_hr_timesheetsenior_detail_id = value;
		}
	}

	[Col]
	public virtual decimal? QT
	{
		get
		{
			return _qt;
		}
		set
		{
			_qt = value;
		}
	}

	[Foreign]
	[Col]
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

	public HR_TIMESHEETSENIOR_DETAIL()
	{
		_addsql = "insert into HR_TIMESHEETSENIOR_DETAIL (\r\nSN ,\r\nUSER_NAME ,\r\nUSER_ID ,\r\nYCQ ,\r\nCQ ,\r\nBJ ,\r\nSJ ,\r\nHR_TIMESHEETSENIOR_DETAIL_ID ,\r\nQT ,\r\nHR_TIMESHEETSENIOR_ID ,\r\nREMARK ) values (\r\n:SN ,\r\n:USER_NAME ,\r\n:USER_ID ,\r\n:YCQ ,\r\n:CQ ,\r\n:BJ ,\r\n:SJ ,\r\n:HR_TIMESHEETSENIOR_DETAIL_ID ,\r\n:QT ,\r\n:HR_TIMESHEETSENIOR_ID ,\r\n:REMARK )";
		_findbyinstance = "SELECT * FROM HR_TIMESHEETSENIOR_DETAIL WHERE HR_TIMESHEETSENIOR_ID=:HR_TIMESHEETSENIOR_ID";
		_updatesql = "update HR_TIMESHEETSENIOR_DETAIL set SN=:SN \r\n,USER_NAME=:USER_NAME \r\n,USER_ID=:USER_ID \r\n,YCQ=:YCQ \r\n,CQ=:CQ \r\n,BJ=:BJ \r\n,SJ=:SJ \r\n,QT=:QT \r\n,HR_TIMESHEETSENIOR_ID=:HR_TIMESHEETSENIOR_ID \r\n,REMARK=:REMARK \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		HR_TIMESHEETSENIOR_DETAIL dto = parm.JsonDeserialize<HR_TIMESHEETSENIOR_DETAIL>(new JsonConverter[0]);
		return FindList<HR_TIMESHEETSENIOR_DETAIL>(dto);
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
