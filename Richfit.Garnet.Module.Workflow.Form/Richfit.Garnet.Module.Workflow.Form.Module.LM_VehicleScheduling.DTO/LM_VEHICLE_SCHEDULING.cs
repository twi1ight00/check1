using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_VehicleScheduling.DTO;

[Serializable]
public class LM_VEHICLE_SCHEDULING : DTOExt, IDTO
{
	private Guid? _vehicle_scheduling_id;

	private string _title;

	private Guid? _vehicle_id;

	private string _vehicle_no;

	private Guid? _use_vehicle_org;

	private string _use_vehicle_orgname;

	private Guid? _use_vehicle_user;

	private string _use_vehicle_username;

	private string _task_type_desc;

	private string _point_departure;

	private string _destination;

	private DateTime? _departure_date;

	private DateTime? _departure_time;

	private DateTime? _apply_date;

	private DateTime? _return_date;

	private DateTime? _return_time;

	private string _driver;

	private Guid? _driver_id;

	private decimal? _departure_odometer;

	private decimal? _return_odometer;

	private decimal? _mileage;

	private decimal? _road_costs;

	private Guid? _distributor_id;

	private string _distributor_name;

	private Guid? _distributor_orgid;

	private string _distributor_orgname;

	private Guid? _creator;

	private decimal? _isdel;

	private DateTime? _createtime;

	private Guid? _modifier;

	private DateTime? _modifytime;

	private Guid? _user_id;

	private string _user_name;

	private Guid? _org_id;

	private string _org_name;

	private string _isout;

	private string _evaluate;

	private string _remark;

	private string _apply_mobile;

	private string _driver_mobile;

	private Guid? _instance_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Primary]
	[Col]
	public virtual Guid? VEHICLE_SCHEDULING_ID
	{
		get
		{
			return _vehicle_scheduling_id;
		}
		set
		{
			_vehicle_scheduling_id = value;
		}
	}

	[Col]
	public virtual string TITLE
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
		}
	}

	[Col]
	public virtual Guid? VEHICLE_ID
	{
		get
		{
			return _vehicle_id;
		}
		set
		{
			_vehicle_id = value;
		}
	}

	[Col]
	public virtual string VEHICLE_NO
	{
		get
		{
			return _vehicle_no;
		}
		set
		{
			_vehicle_no = value;
		}
	}

	[Col]
	public virtual Guid? USE_VEHICLE_ORG
	{
		get
		{
			return _use_vehicle_org;
		}
		set
		{
			_use_vehicle_org = value;
		}
	}

	[Col]
	public virtual string USE_VEHICLE_ORGNAME
	{
		get
		{
			return _use_vehicle_orgname;
		}
		set
		{
			_use_vehicle_orgname = value;
		}
	}

	[Col]
	public virtual Guid? USE_VEHICLE_USER
	{
		get
		{
			return _use_vehicle_user;
		}
		set
		{
			_use_vehicle_user = value;
		}
	}

	[Col]
	public virtual string USE_VEHICLE_USERNAME
	{
		get
		{
			return _use_vehicle_username;
		}
		set
		{
			_use_vehicle_username = value;
		}
	}

	[Col]
	public virtual string TASK_TYPE_DESC
	{
		get
		{
			return _task_type_desc;
		}
		set
		{
			_task_type_desc = value;
		}
	}

	[Col]
	public virtual string POINT_DEPARTURE
	{
		get
		{
			return _point_departure;
		}
		set
		{
			_point_departure = value;
		}
	}

	[Col]
	public virtual string DESTINATION
	{
		get
		{
			return _destination;
		}
		set
		{
			_destination = value;
		}
	}

	[Col]
	public virtual DateTime? DEPARTURE_DATE
	{
		get
		{
			return _departure_date;
		}
		set
		{
			_departure_date = value;
		}
	}

	[Col]
	public virtual DateTime? DEPARTURE_TIME
	{
		get
		{
			return _departure_time;
		}
		set
		{
			_departure_time = value;
		}
	}

	[Col]
	public virtual DateTime? APPLY_DATE
	{
		get
		{
			return _apply_date;
		}
		set
		{
			_apply_date = value;
		}
	}

	[Col]
	public virtual DateTime? RETURN_DATE
	{
		get
		{
			return _return_date;
		}
		set
		{
			_return_date = value;
		}
	}

	[Col]
	public virtual DateTime? RETURN_TIME
	{
		get
		{
			return _return_time;
		}
		set
		{
			_return_time = value;
		}
	}

	[Col]
	public virtual string DRIVER
	{
		get
		{
			return _driver;
		}
		set
		{
			_driver = value;
		}
	}

	[Col]
	public virtual Guid? DRIVER_ID
	{
		get
		{
			return _driver_id;
		}
		set
		{
			_driver_id = value;
		}
	}

	[Col]
	public virtual decimal? DEPARTURE_ODOMETER
	{
		get
		{
			return _departure_odometer;
		}
		set
		{
			_departure_odometer = value;
		}
	}

	[Col]
	public virtual decimal? RETURN_ODOMETER
	{
		get
		{
			return _return_odometer;
		}
		set
		{
			_return_odometer = value;
		}
	}

	[Col]
	public virtual decimal? MILEAGE
	{
		get
		{
			return _mileage;
		}
		set
		{
			_mileage = value;
		}
	}

	[Col]
	public virtual decimal? ROAD_COSTS
	{
		get
		{
			return _road_costs;
		}
		set
		{
			_road_costs = value;
		}
	}

	[Col]
	public virtual Guid? DISTRIBUTOR_ID
	{
		get
		{
			return _distributor_id;
		}
		set
		{
			_distributor_id = value;
		}
	}

	[Col]
	public virtual string DISTRIBUTOR_NAME
	{
		get
		{
			return _distributor_name;
		}
		set
		{
			_distributor_name = value;
		}
	}

	[Col]
	public virtual Guid? DISTRIBUTOR_ORGID
	{
		get
		{
			return _distributor_orgid;
		}
		set
		{
			_distributor_orgid = value;
		}
	}

	[Col]
	public virtual string DISTRIBUTOR_ORGNAME
	{
		get
		{
			return _distributor_orgname;
		}
		set
		{
			_distributor_orgname = value;
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
	public virtual string ISOUT
	{
		get
		{
			return _isout;
		}
		set
		{
			_isout = value;
		}
	}

	[Col]
	public virtual string EVALUATE
	{
		get
		{
			return _evaluate;
		}
		set
		{
			_evaluate = value;
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

	[Col]
	public virtual string APPLY_MOBILE
	{
		get
		{
			return _apply_mobile;
		}
		set
		{
			_apply_mobile = value;
		}
	}

	[Col]
	public virtual string DRIVER_MOBILE
	{
		get
		{
			return _driver_mobile;
		}
		set
		{
			_driver_mobile = value;
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

	public LM_VEHICLE_SCHEDULING()
	{
		_addsql = "insert into LM_VEHICLE_SCHEDULING (\r\nVEHICLE_SCHEDULING_ID ,\r\nTITLE ,\r\nVEHICLE_ID ,\r\nVEHICLE_NO ,\r\nUSE_VEHICLE_ORG ,\r\nUSE_VEHICLE_ORGNAME ,\r\nUSE_VEHICLE_USER ,\r\nUSE_VEHICLE_USERNAME ,\r\nTASK_TYPE_DESC ,\r\nPOINT_DEPARTURE ,\r\nDESTINATION ,\r\nDEPARTURE_DATE ,\r\nDEPARTURE_TIME ,\r\nAPPLY_DATE ,\r\nRETURN_DATE ,\r\nRETURN_TIME ,\r\nDRIVER ,\r\nDRIVER_ID ,\r\nDEPARTURE_ODOMETER ,\r\nRETURN_ODOMETER ,\r\nMILEAGE ,\r\nROAD_COSTS ,\r\nDISTRIBUTOR_ID ,\r\nDISTRIBUTOR_NAME ,\r\nDISTRIBUTOR_ORGID ,\r\nDISTRIBUTOR_ORGNAME ,\r\nCREATOR ,\r\nISDEL ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nISOUT,\r\nEVALUATE,\r\nREMARK,\r\nAPPLY_MOBILE,\r\nDRIVER_MOBILE,\r\nINSTANCE_ID ) values (\r\n:VEHICLE_SCHEDULING_ID ,\r\n:TITLE ,\r\n:VEHICLE_ID ,\r\n:VEHICLE_NO ,\r\n:USE_VEHICLE_ORG ,\r\n:USE_VEHICLE_ORGNAME ,\r\n:USE_VEHICLE_USER ,\r\n:USE_VEHICLE_USERNAME ,\r\n:TASK_TYPE_DESC ,\r\n:POINT_DEPARTURE ,\r\n:DESTINATION ,\r\n:DEPARTURE_DATE ,\r\n:DEPARTURE_TIME ,\r\n:APPLY_DATE ,\r\n:RETURN_DATE ,\r\n:RETURN_TIME ,\r\n:DRIVER ,\r\n:DRIVER_ID ,\r\n:DEPARTURE_ODOMETER ,\r\n:RETURN_ODOMETER ,\r\n:MILEAGE ,\r\n:ROAD_COSTS ,\r\n:DISTRIBUTOR_ID ,\r\n:DISTRIBUTOR_NAME ,\r\n:DISTRIBUTOR_ORGID ,\r\n:DISTRIBUTOR_ORGNAME ,\r\n:CREATOR ,\r\n:ISDEL ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:ISOUT,\r\n:EVALUATE,\r\n:REMARK,\r\n:APPLY_MOBILE,\r\n:DRIVER_MOBILE,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM LM_VEHICLE_SCHEDULING WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM LM_VEHICLE_SCHEDULING T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update LM_VEHICLE_SCHEDULING set VEHICLE_SCHEDULING_ID=:VEHICLE_SCHEDULING_ID \r\n,TITLE=:TITLE \r\n,VEHICLE_ID=:VEHICLE_ID \r\n,VEHICLE_NO=:VEHICLE_NO \r\n,USE_VEHICLE_ORG=:USE_VEHICLE_ORG \r\n,USE_VEHICLE_ORGNAME=:USE_VEHICLE_ORGNAME \r\n,USE_VEHICLE_USER=:USE_VEHICLE_USER \r\n,USE_VEHICLE_USERNAME=:USE_VEHICLE_USERNAME \r\n,TASK_TYPE_DESC=:TASK_TYPE_DESC \r\n,POINT_DEPARTURE=:POINT_DEPARTURE \r\n,DESTINATION=:DESTINATION \r\n,DEPARTURE_DATE=:DEPARTURE_DATE \r\n,DEPARTURE_TIME=:DEPARTURE_TIME \r\n,APPLY_DATE=:APPLY_DATE \r\n,RETURN_DATE=:RETURN_DATE \r\n,RETURN_TIME=:RETURN_TIME \r\n,DRIVER=:DRIVER \r\n,DRIVER_ID=:DRIVER_ID\r\n,DEPARTURE_ODOMETER=:DEPARTURE_ODOMETER \r\n,RETURN_ODOMETER=:RETURN_ODOMETER \r\n,MILEAGE=:MILEAGE \r\n,ROAD_COSTS=:ROAD_COSTS \r\n,DISTRIBUTOR_ID=:DISTRIBUTOR_ID \r\n,DISTRIBUTOR_NAME=:DISTRIBUTOR_NAME \r\n,DISTRIBUTOR_ORGID=:DISTRIBUTOR_ORGID \r\n,DISTRIBUTOR_ORGNAME=:DISTRIBUTOR_ORGNAME \r\n,CREATOR=:CREATOR \r\n,ISDEL=:ISDEL \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n,ISOUT=:ISOUT\r\n,EVALUATE=:EVALUATE\r\n,REMARK=:REMARK\r\n,APPLY_MOBILE=:APPLY_MOBILE\r\n,DRIVER_MOBILE=:DRIVER_MOBILE\r\n WHERE INSTANCE_ID=:INSTANCE_ID";
		WhereSimple = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) AND \r\n            ((@VEHICLE_NO IS NULL OR T1.VEHICLE_NO LIKE ('%'||(@VEHICLE_NO)||'%'))\r\nOR (@USE_VEHICLE_ORGNAME IS NULL OR T1.USE_VEHICLE_ORGNAME LIKE ('%'||(@USE_VEHICLE_ORGNAME)||'%'))\r\nOR (@USE_VEHICLE_USERNAME IS NULL OR T1.USE_VEHICLE_USERNAME LIKE ('%'||(@USE_VEHICLE_USERNAME)||'%'))\r\nOR (@TASK_TYPE_DESC IS NULL OR T1.TASK_TYPE_DESC LIKE ('%'||(@TASK_TYPE_DESC)||'%'))\r\nOR (@POINT_DEPARTURE IS NULL OR T1.POINT_DEPARTURE LIKE ('%'||(@POINT_DEPARTURE)||'%'))\r\nOR (@DISTRIBUTOR_NAME IS NULL OR T1.DISTRIBUTOR_NAME LIKE ('%'||(@DISTRIBUTOR_NAME)||'%'))\r\nOR (@DRIVER IS NULL OR T1.DRIVER LIKE ('%'||(@DRIVER)||'%')))";
		WhereAdvance = "T2.ISDEL=0 AND (T2.RUN_STATE=2 OR T2.RUN_STATE=0) \r\n         AND ((@VEHICLE_ID IS NULL OR T1.VEHICLE_ID = @VEHICLE_ID)\r\n         AND (@USE_VEHICLE_ORG IS NULL OR T1.USE_VEHICLE_ORG = @USE_VEHICLE_ORG)\r\n         AND (@USE_VEHICLE_USER IS NULL OR T1.USE_VEHICLE_USER = @DISTRIBUTOR_ID)\r\n         AND (@DISTRIBUTOR_ID IS NULL OR T1.DISTRIBUTOR_ID =  @DISTRIBUTOR_ID))\r\n         AND (@TASK_TYPE_DESC IS NULL OR T1.TASK_TYPE_DESC LIKE ('%'||(@TASK_TYPE_DESC)||'%'))\r\n         AND (@POINT_DEPARTURE IS NULL OR T1.POINT_DEPARTURE LIKE ('%'||(@POINT_DEPARTURE)||'%'))";
	}

	public override string FindList(string parm)
	{
		LM_VEHICLE_SCHEDULING dto = parm.JsonDeserialize<LM_VEHICLE_SCHEDULING>(new JsonConverter[0]);
		return FindList<LM_VEHICLE_SCHEDULING>(dto);
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
