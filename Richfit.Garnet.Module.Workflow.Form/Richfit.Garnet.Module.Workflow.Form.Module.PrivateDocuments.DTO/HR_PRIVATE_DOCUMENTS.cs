using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PrivateDocuments.DTO;

[Serializable]
public class HR_PRIVATE_DOCUMENTS : DTOExt, IDTO
{
	private Guid? _hr_private_documents_id;

	private string _title;

	private Guid? _position;

	private string _abroad_type;

	private string _country;

	private string _time_desc;

	private DateTime? _start_time;

	private DateTime? _end_time;

	private string _reason;

	private string _approval_opinion;

	private decimal? _isdel;

	private Guid? _creator;

	private DateTime? _createtime;

	private Guid? _modifier;

	private DateTime? _modifytime;

	private Guid? _user_id;

	private string _user_name;

	private Guid? _org_id;

	private string _org_name;

	private Guid? _applicant_id;

	private string _applicant_name;

	private string _applicant_names;

	private Guid? _instance_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Col]
	[Primary]
	public virtual Guid? HR_PRIVATE_DOCUMENTS_ID
	{
		get
		{
			return _hr_private_documents_id;
		}
		set
		{
			_hr_private_documents_id = value;
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
	public virtual Guid? POSITION
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	[Col]
	public virtual string ABROAD_TYPE
	{
		get
		{
			return _abroad_type;
		}
		set
		{
			_abroad_type = value;
		}
	}

	[Col]
	public virtual string COUNTRY
	{
		get
		{
			return _country;
		}
		set
		{
			_country = value;
		}
	}

	[Col]
	public virtual string TIME_DESC
	{
		get
		{
			return _time_desc;
		}
		set
		{
			_time_desc = value;
		}
	}

	[Col]
	public virtual DateTime? START_TIME
	{
		get
		{
			return _start_time;
		}
		set
		{
			_start_time = value;
		}
	}

	[Col]
	public virtual DateTime? END_TIME
	{
		get
		{
			return _end_time;
		}
		set
		{
			_end_time = value;
		}
	}

	[Col]
	public virtual string REASON
	{
		get
		{
			return _reason;
		}
		set
		{
			_reason = value;
		}
	}

	[Col]
	public virtual string APPROVAL_OPINION
	{
		get
		{
			return _approval_opinion;
		}
		set
		{
			_approval_opinion = value;
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
	public virtual string APPLICANT_NAMES
	{
		get
		{
			return _applicant_names;
		}
		set
		{
			_applicant_names = value;
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

	public HR_PRIVATE_DOCUMENTS()
	{
		_addsql = "insert into HR_PRIVATE_DOCUMENTS (\r\nHR_PRIVATE_DOCUMENTS_ID ,\r\nTITLE ,\r\nPOSITION ,\r\nABROAD_TYPE ,\r\nCOUNTRY ,\r\nTIME_DESC,\r\nSTART_TIME ,\r\nEND_TIME ,\r\nREASON ,\r\nAPPROVAL_OPINION ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nAPPLICANT_ID ,\r\nAPPLICANT_NAME ,\r\nAPPLICANT_NAMES ,\r\nINSTANCE_ID ) values (\r\n:HR_PRIVATE_DOCUMENTS_ID ,\r\n:TITLE ,\r\n:POSITION ,\r\n:ABROAD_TYPE ,\r\n:COUNTRY ,\r\n:TIME_DESC,\r\n:START_TIME ,\r\n:END_TIME ,\r\n:REASON ,\r\n:APPROVAL_OPINION ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:APPLICANT_ID ,\r\n:APPLICANT_NAME ,\r\n:APPLICANT_NAMES ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM HR_PRIVATE_DOCUMENTS WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM HR_PRIVATE_DOCUMENTS T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update HR_PRIVATE_DOCUMENTS set TITLE=:TITLE \r\n,POSITION=:POSITION \r\n,ABROAD_TYPE=:ABROAD_TYPE \r\n,COUNTRY=:COUNTRY \r\n,TIME_DESC=:TIME_DESC \r\n,START_TIME=:START_TIME \r\n,END_TIME=:END_TIME \r\n,REASON=:REASON \r\n,APPROVAL_OPINION=:APPROVAL_OPINION \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n,APPLICANT_ID=:APPLICANT_ID \r\n,APPLICANT_NAME=:APPLICANT_NAME \r\n,APPLICANT_NAMES=:APPLICANT_NAMES \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		HR_PRIVATE_DOCUMENTS dto = parm.JsonDeserialize<HR_PRIVATE_DOCUMENTS>(new JsonConverter[0]);
		return FindList<HR_PRIVATE_DOCUMENTS>(dto);
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
