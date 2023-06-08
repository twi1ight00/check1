using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_Timesheet.DTO;

[Serializable]
public class HR_TIMESHEET_DETAIL : DTOExt, IDTO
{
	private decimal? _sort;

	private string _user_name;

	private Guid? _user_id;

	private string _attendence;

	private Guid? _hr_timesheet_detail_id;

	private Guid? _hr_timesheet_id;

	private decimal? _bjsq;

	private decimal? _qtsq;

	private decimal? _bjxc;

	private decimal? _qtxc;

	private decimal? _sh;

	private decimal? _sjgr;

	private decimal? _hx;

	private decimal? _px;

	private decimal? _qtcq;

	private decimal? _ycq;

	private decimal? _gxr;

	private decimal? _sjcq;

	private decimal? _bj;

	private decimal? _tqj;

	private decimal? _lyj;

	private decimal? _nxj;

	private decimal? _xxj;

	private decimal? _hj;

	private decimal? _saj;

	private decimal? _cj;

	private decimal? _sj;

	private decimal? _kg;

	private decimal? _gzrjb;

	private decimal? _gxrjb;

	private decimal? _jrjb;

	private string _ycgl;

	private string _ycql;

	private decimal? _yhx;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Col]
	public virtual decimal? SORT
	{
		get
		{
			return _sort;
		}
		set
		{
			_sort = value;
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
	public virtual string ATTENDENCE
	{
		get
		{
			return _attendence;
		}
		set
		{
			_attendence = value;
		}
	}

	[Col]
	public virtual decimal? BJSQ
	{
		get
		{
			return _bjsq;
		}
		set
		{
			_bjsq = value;
		}
	}

	[Col]
	public virtual decimal? QTSQ
	{
		get
		{
			return _qtsq;
		}
		set
		{
			_qtsq = value;
		}
	}

	[Col]
	public virtual decimal? BJXC
	{
		get
		{
			return _bjxc;
		}
		set
		{
			_bjxc = value;
		}
	}

	[Col]
	public virtual decimal? QTXC
	{
		get
		{
			return _qtxc;
		}
		set
		{
			_qtxc = value;
		}
	}

	[Col]
	public virtual decimal? SH
	{
		get
		{
			return _sh;
		}
		set
		{
			_sh = value;
		}
	}

	[Col]
	public virtual decimal? SJGR
	{
		get
		{
			return _sjgr;
		}
		set
		{
			_sjgr = value;
		}
	}

	[Col]
	public virtual decimal? HX
	{
		get
		{
			return _hx;
		}
		set
		{
			_hx = value;
		}
	}

	[Col]
	public virtual decimal? PX
	{
		get
		{
			return _px;
		}
		set
		{
			_px = value;
		}
	}

	[Col]
	public virtual decimal? QTCQ
	{
		get
		{
			return _qtcq;
		}
		set
		{
			_qtcq = value;
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
	public virtual decimal? GXR
	{
		get
		{
			return _gxr;
		}
		set
		{
			_gxr = value;
		}
	}

	[Col]
	public virtual decimal? SJCQ
	{
		get
		{
			return _sjcq;
		}
		set
		{
			_sjcq = value;
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
	public virtual decimal? TQJ
	{
		get
		{
			return _tqj;
		}
		set
		{
			_tqj = value;
		}
	}

	[Col]
	public virtual decimal? LYJ
	{
		get
		{
			return _lyj;
		}
		set
		{
			_lyj = value;
		}
	}

	[Col]
	public virtual decimal? NXJ
	{
		get
		{
			return _nxj;
		}
		set
		{
			_nxj = value;
		}
	}

	[Col]
	public virtual decimal? XXJ
	{
		get
		{
			return _xxj;
		}
		set
		{
			_xxj = value;
		}
	}

	[Col]
	public virtual decimal? HJ
	{
		get
		{
			return _hj;
		}
		set
		{
			_hj = value;
		}
	}

	[Col]
	public virtual decimal? SAJ
	{
		get
		{
			return _saj;
		}
		set
		{
			_saj = value;
		}
	}

	[Col]
	public virtual decimal? CJ
	{
		get
		{
			return _cj;
		}
		set
		{
			_cj = value;
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
	public virtual decimal? KG
	{
		get
		{
			return _kg;
		}
		set
		{
			_kg = value;
		}
	}

	[Col]
	public virtual decimal? GZRJB
	{
		get
		{
			return _gzrjb;
		}
		set
		{
			_gzrjb = value;
		}
	}

	[Col]
	public virtual decimal? GXRJB
	{
		get
		{
			return _gxrjb;
		}
		set
		{
			_gxrjb = value;
		}
	}

	[Col]
	public virtual decimal? JRJB
	{
		get
		{
			return _jrjb;
		}
		set
		{
			_jrjb = value;
		}
	}

	[Col]
	public virtual string YCGL
	{
		get
		{
			return _ycgl;
		}
		set
		{
			_ycgl = value;
		}
	}

	[Col]
	public virtual string YCQL
	{
		get
		{
			return _ycql;
		}
		set
		{
			_ycql = value;
		}
	}

	[Col]
	public virtual decimal? YHX
	{
		get
		{
			return _yhx;
		}
		set
		{
			_yhx = value;
		}
	}

	[Col]
	[Primary]
	public virtual Guid? HR_TIMESHEET_DETAIL_ID
	{
		get
		{
			return _hr_timesheet_detail_id;
		}
		set
		{
			_hr_timesheet_detail_id = value;
		}
	}

	[Foreign]
	[Col]
	public virtual Guid? HR_TIMESHEET_ID
	{
		get
		{
			return _hr_timesheet_id;
		}
		set
		{
			_hr_timesheet_id = value;
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

	public HR_TIMESHEET_DETAIL()
	{
		_addsql = "insert into HR_TIMESHEET_DETAIL (\r\nSORT ,\r\nUSER_NAME ,\r\nUSER_ID ,\r\nATTENDENCE ,\r\nHR_TIMESHEET_DETAIL_ID ,\r\nHR_TIMESHEET_ID ,\r\nBJSQ ,\r\nQTSQ ,\r\nBJXC ,\r\nQTXC ,\r\nSH ,\r\nSJGR ,\r\nHX ,\r\nPX ,\r\nQTCQ ,\r\nYCQ  ,\r\nGXR  ,\r\nSJCQ ,\r\nBJ ,\r\nTQJ  ,\r\nLYJ  ,\r\nNXJ  ,\r\nXXJ  ,\r\nHJ ,\r\nSAJ ,\r\nCJ ,\r\nSJ ,\r\nKG ,\r\nGZRJB  ,\r\nGXRJB  ,\r\nJRJB ,\r\nYCGL ,\r\nYCQL ,\r\nYHX ) values (\r\n:SORT ,\r\n:USER_NAME ,\r\n:USER_ID ,\r\n:ATTENDENCE ,\r\n:HR_TIMESHEET_DETAIL_ID ,\r\n:HR_TIMESHEET_ID ,\r\n:BJSQ ,\r\n:QTSQ ,\r\n:BJXC ,\r\n:QTXC ,\r\n:SH ,\r\n:SJGR ,\r\n:HX ,\r\n:PX ,\r\n:QTCQ ,\r\n:YCQ  ,\r\n:GXR  ,\r\n:SJCQ ,\r\n:BJ ,\r\n:TQJ  ,\r\n:LYJ  ,\r\n:NXJ  ,\r\n:XXJ  ,\r\n:HJ ,\r\n:SAJ ,\r\n:CJ ,\r\n:SJ ,\r\n:KG ,\r\n:GZRJB  ,\r\n:GXRJB  ,\r\n:JRJB ,\r\n:YCGL ,\r\n:YCQL ,\r\n:YHX )";
		_findbyinstance = "SELECT * FROM HR_TIMESHEET_DETAIL WHERE HR_TIMESHEET_ID=:HR_TIMESHEET_ID";
		_updatesql = "update HR_TIMESHEET_DETAIL set SORT=:SORT \r\n,USER_NAME=:USER_NAME \r\n,USER_ID=:USER_ID \r\n,ATTENDENCE=:ATTENDENCE \r\n,HR_TIMESHEET_ID=:HR_TIMESHEET_ID \r\n,BJSQ=:BJSQ\r\n,QTSQ=:QTSQ\r\n,BJXC=:BJXC\r\n,QTXC=:QTXC\r\n,SH=:SH\r\n,SJGR=:SJGR\r\n,HX=:HX\r\n,PX=:PX\r\n,QTCQ=:QTCQ\r\n,YCQ =:YCQ\r\n,GXR =:GXR\r\n,SJCQ=:SJCQ\r\n,BJ=:BJ\r\n,TQJ =:TQJ\r\n,LYJ =:LYJ\r\n,NXJ =:NXJ\r\n,XXJ =:XXJ\r\n,HJ=:HJ\r\n,SAJ=:SAJ\r\n,CJ=:CJ\r\n,SJ=:SJ\r\n,KG=:KG\r\n,GZRJB =:GZRJB\r\n,GXRJB =:GXRJB\r\n,JRJB=:JRJB\r\n,YCGL=:YCGL\r\n,YCQL=:YCQL\r\n,YHX=:YHX \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		HR_TIMESHEET_DETAIL dto = parm.JsonDeserialize<HR_TIMESHEET_DETAIL>(new JsonConverter[0]);
		return FindList<HR_TIMESHEET_DETAIL>(dto);
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
