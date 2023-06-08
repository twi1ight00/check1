using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_Timesheet.DTO;

[Serializable]
public class HR_TIMESHEET : DTOExt, IDTO
{
	private Guid? _hr_timesheet_id;

	private DateTime? _month;

	private string _department;

	private string _note;

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

	private IList<HR_TIMESHEET_DETAIL> _hr_timesheet_detail;

	[Primary]
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
	public virtual string DEPARTMENT
	{
		get
		{
			return _department;
		}
		set
		{
			_department = value;
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

	public string MONTH_FROM { get; set; }

	public string MONTH_TO { get; set; }

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
	public virtual IList<HR_TIMESHEET_DETAIL> HR_TIMESHEET_DETAIL
	{
		get
		{
			return _hr_timesheet_detail;
		}
		set
		{
			_hr_timesheet_detail = value;
		}
	}

	public HR_TIMESHEET()
	{
		_addsql = "insert into HR_TIMESHEET (\r\nHR_TIMESHEET_ID ,\r\nMONTH ,\r\nDEPARTMENT ,\r\nNOTE ,\r\nBJSQ ,\r\nQTSQ ,\r\nBJXC ,\r\nQTXC ,\r\nSH ,\r\nSJGR ,\r\nHX ,\r\nPX ,\r\nQTCQ ,\r\nYCQ  ,\r\nGXR  ,\r\nSJCQ ,\r\nBJ ,\r\nTQJ  ,\r\nLYJ  ,\r\nNXJ  ,\r\nXXJ  ,\r\nHJ ,\r\nSAJ ,\r\nCJ ,\r\nSJ ,\r\nKG ,\r\nGZRJB  ,\r\nGXRJB  ,\r\nJRJB ,\r\nYCGL ,\r\nYCQL ,\r\nYHX ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:HR_TIMESHEET_ID ,\r\n:MONTH ,\r\n:DEPARTMENT ,\r\n:NOTE ,\r\n:BJSQ ,\r\n:QTSQ ,\r\n:BJXC ,\r\n:QTXC ,\r\n:SH ,\r\n:SJGR ,\r\n:HX ,\r\n:PX ,\r\n:QTCQ ,\r\n:YCQ  ,\r\n:GXR  ,\r\n:SJCQ ,\r\n:BJ ,\r\n:TQJ  ,\r\n:LYJ  ,\r\n:NXJ  ,\r\n:XXJ  ,\r\n:HJ ,\r\n:SAJ ,\r\n:CJ ,\r\n:SJ ,\r\n:KG ,\r\n:GZRJB  ,\r\n:GXRJB  ,\r\n:JRJB ,\r\n:YCGL ,\r\n:YCQL ,\r\n:YHX ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM HR_TIMESHEET WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM HR_TIMESHEET T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		WhereSimple = " T2.ISDEL=0 AND T2.RUN_STATE=2 AND (@DEPARTMENT IS NULL OR DEPARTMENT LIKE ('%'||@DEPARTMENT||'%'))";
		WhereAdvance = " T2.ISDEL=0 AND T2.RUN_STATE=2 AND (@DEPARTMENT IS NULL OR DEPARTMENT LIKE ('%'||@DEPARTMENT||'%')) AND (@USER_NAME IS NULL OR T1.USER_NAME LIKE ('%'||@USER_NAME||'%')) AND (@MONTH_FROM IS NULL OR MONTH >= TO_DATE(@MONTH_FROM,'YYYY-MM-DD')) AND (@MONTH_TO IS NULL OR MONTH <= TO_DATE(@MONTH_TO,'YYYY-MM-DD'))";
		_updatesql = "update HR_TIMESHEET set MONTH=:MONTH \r\n,DEPARTMENT=:DEPARTMENT \r\n,NOTE=:NOTE\r\n,BJSQ=:BJSQ\r\n,QTSQ=:QTSQ\r\n,BJXC=:BJXC\r\n,QTXC=:QTXC\r\n,SH=:SH\r\n,SJGR=:SJGR\r\n,HX=:HX\r\n,PX=:PX\r\n,QTCQ=:QTCQ\r\n,YCQ =:YCQ\r\n,GXR =:GXR\r\n,SJCQ=:SJCQ\r\n,BJ=:BJ\r\n,TQJ =:TQJ\r\n,LYJ =:LYJ\r\n,NXJ =:NXJ\r\n,XXJ =:XXJ\r\n,HJ=:HJ\r\n,SAJ=:SAJ\r\n,CJ=:CJ\r\n,SJ=:SJ\r\n,KG=:KG\r\n,GZRJB =:GZRJB\r\n,GXRJB =:GXRJB\r\n,JRJB=:JRJB\r\n,YCGL=:YCGL\r\n,YCQL=:YCQL\r\n,YHX=:YHX\r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
		_hr_timesheet_detail = new List<HR_TIMESHEET_DETAIL>();
	}

	public override string FindList(string parm)
	{
		HR_TIMESHEET dto = parm.JsonDeserialize<HR_TIMESHEET>(new JsonConverter[0]);
		return FindList<HR_TIMESHEET>(dto);
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
