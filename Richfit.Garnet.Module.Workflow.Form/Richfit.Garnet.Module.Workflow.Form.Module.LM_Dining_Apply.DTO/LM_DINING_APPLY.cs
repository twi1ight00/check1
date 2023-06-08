using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.LM_Dining_Apply.DTO;

[Serializable]
public class LM_DINING_APPLY : DTOExt, IDTO
{
	private Guid? _dining_apply_id;

	private string _title;

	private string _apply_desc;

	private Guid? _applicant_id;

	private string _applicant_name;

	private Guid? _apply_org_id;

	private string _apply_org_name;

	private DateTime? _apply_time;

	private string _remark;

	private Guid? _receiver;

	private string _receiver_name;

	private Guid? _receiver_orgid;

	private string _receiver_orgname;

	private string _breakfast_num;

	private string _lunch_num;

	private string _supper_num;

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

	[Col]
	[Primary]
	public virtual Guid? DINING_APPLY_ID
	{
		get
		{
			return _dining_apply_id;
		}
		set
		{
			_dining_apply_id = value;
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
	public virtual string APPLY_DESC
	{
		get
		{
			return _apply_desc;
		}
		set
		{
			_apply_desc = value;
		}
	}

	[Col]
	public virtual Guid? APPLICANT_ID
	{
		get
		{
			return _applicant_id;
		}
		set
		{
			_applicant_id = value;
		}
	}

	[Col]
	public virtual string APPLICANT_NAME
	{
		get
		{
			return _applicant_name;
		}
		set
		{
			_applicant_name = value;
		}
	}

	[Col]
	public virtual Guid? APPLY_ORG_ID
	{
		get
		{
			return _apply_org_id;
		}
		set
		{
			_apply_org_id = value;
		}
	}

	[Col]
	public virtual string APPLY_ORG_NAME
	{
		get
		{
			return _apply_org_name;
		}
		set
		{
			_apply_org_name = value;
		}
	}

	[Col]
	public virtual DateTime? APPLY_TIME
	{
		get
		{
			return _apply_time;
		}
		set
		{
			_apply_time = value;
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
	public virtual Guid? RECEIVER
	{
		get
		{
			return _receiver;
		}
		set
		{
			_receiver = value;
		}
	}

	[Col]
	public virtual string RECEIVER_NAME
	{
		get
		{
			return _receiver_name;
		}
		set
		{
			_receiver_name = value;
		}
	}

	[Col]
	public virtual Guid? RECEIVER_ORGID
	{
		get
		{
			return _receiver_orgid;
		}
		set
		{
			_receiver_orgid = value;
		}
	}

	[Col]
	public virtual string RECEIVER_ORGNAME
	{
		get
		{
			return _receiver_orgname;
		}
		set
		{
			_receiver_orgname = value;
		}
	}

	[Col]
	public virtual string BREAKFAST_NUM
	{
		get
		{
			return _breakfast_num;
		}
		set
		{
			_breakfast_num = value;
		}
	}

	[Col]
	public virtual string LUNCH_NUM
	{
		get
		{
			return _lunch_num;
		}
		set
		{
			_lunch_num = value;
		}
	}

	[Col]
	public virtual string SUPPER_NUM
	{
		get
		{
			return _supper_num;
		}
		set
		{
			_supper_num = value;
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

	public LM_DINING_APPLY()
	{
		_addsql = "insert into LM_DINING_APPLY (\r\nDINING_APPLY_ID ,\r\nTITLE ,\r\nAPPLY_DESC ,\r\nAPPLICANT_ID ,\r\nAPPLICANT_NAME ,\r\nAPPLY_ORG_ID ,\r\nAPPLY_ORG_NAME ,\r\nAPPLY_TIME ,\r\nREMARK ,\r\nRECEIVER ,\r\nRECEIVER_NAME ,\r\nRECEIVER_ORGID ,\r\nRECEIVER_ORGNAME ,\r\nBREAKFAST_NUM ,\r\nLUNCH_NUM ,\r\nSUPPER_NUM ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:DINING_APPLY_ID ,\r\n:TITLE ,\r\n:APPLY_DESC ,\r\n:APPLICANT_ID ,\r\n:APPLICANT_NAME ,\r\n:APPLY_ORG_ID ,\r\n:APPLY_ORG_NAME ,\r\n:APPLY_TIME ,\r\n:REMARK ,\r\n:RECEIVER ,\r\n:RECEIVER_NAME ,\r\n:RECEIVER_ORGID ,\r\n:RECEIVER_ORGNAME ,\r\n:BREAKFAST_NUM ,\r\n:LUNCH_NUM ,\r\n:SUPPER_NUM ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM LM_DINING_APPLY WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM LM_DINING_APPLY T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update LM_DINING_APPLY set DINING_APPLY_ID=:DINING_APPLY_ID \r\n,TITLE=:TITLE \r\n,APPLY_DESC=:APPLY_DESC \r\n,APPLICANT_ID=:APPLICANT_ID \r\n,APPLICANT_NAME=:APPLICANT_NAME \r\n,APPLY_ORG_ID=:APPLY_ORG_ID \r\n,APPLY_ORG_NAME=:APPLY_ORG_NAME \r\n,APPLY_TIME=:APPLY_TIME \r\n,REMARK=:REMARK \r\n,RECEIVER=:RECEIVER \r\n,RECEIVER_NAME=:RECEIVER_NAME \r\n,RECEIVER_ORGID=:RECEIVER_ORGID \r\n,RECEIVER_ORGNAME=:RECEIVER_ORGNAME \r\n,BREAKFAST_NUM=:BREAKFAST_NUM \r\n,LUNCH_NUM=:LUNCH_NUM \r\n,SUPPER_NUM=:SUPPER_NUM \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		LM_DINING_APPLY dto = parm.JsonDeserialize<LM_DINING_APPLY>(new JsonConverter[0]);
		return FindList<LM_DINING_APPLY>(dto);
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
