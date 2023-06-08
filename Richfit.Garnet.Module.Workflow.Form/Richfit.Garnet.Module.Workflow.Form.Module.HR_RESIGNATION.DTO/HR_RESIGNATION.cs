using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.HR_RESIGNATION.DTO;

[Serializable]
public class HR_RESIGNATION : DTOExt, IDTO
{
	private Guid? _hr_resignation_id;

	private string _position;

	private string _title;

	private string _education_level;

	private string _reason;

	private DateTime? _resign_date;

	private DateTime? _application_date;

	private string _contact;

	private decimal? _close_of_1;

	private decimal? _close_fa_1;

	private decimal? _close_pt_1;

	private decimal? _close_pt_2;

	private decimal? _close_it_1;

	private decimal? _close_hq_1;

	private decimal? _close_hq_2;

	private decimal? _close_hq_3;

	private decimal? _close_hq_4;

	private decimal? _close_de_1;

	private decimal? _close_own_1;

	private string _hr_remark;

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
	public virtual Guid? HR_RESIGNATION_ID
	{
		get
		{
			return _hr_resignation_id;
		}
		set
		{
			_hr_resignation_id = value;
		}
	}

	[Col]
	public virtual string POSITION
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
	public virtual string EDUCATION_LEVEL
	{
		get
		{
			return _education_level;
		}
		set
		{
			_education_level = value;
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
	public virtual DateTime? RESIGN_DATE
	{
		get
		{
			return _resign_date;
		}
		set
		{
			_resign_date = value;
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
	public virtual string CONTACT
	{
		get
		{
			return _contact;
		}
		set
		{
			_contact = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_OF_1
	{
		get
		{
			return _close_of_1;
		}
		set
		{
			_close_of_1 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_FA_1
	{
		get
		{
			return _close_fa_1;
		}
		set
		{
			_close_fa_1 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_PT_1
	{
		get
		{
			return _close_pt_1;
		}
		set
		{
			_close_pt_1 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_PT_2
	{
		get
		{
			return _close_pt_2;
		}
		set
		{
			_close_pt_2 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_IT_1
	{
		get
		{
			return _close_it_1;
		}
		set
		{
			_close_it_1 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_HQ_1
	{
		get
		{
			return _close_hq_1;
		}
		set
		{
			_close_hq_1 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_HQ_2
	{
		get
		{
			return _close_hq_2;
		}
		set
		{
			_close_hq_2 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_HQ_3
	{
		get
		{
			return _close_hq_3;
		}
		set
		{
			_close_hq_3 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_HQ_4
	{
		get
		{
			return _close_hq_4;
		}
		set
		{
			_close_hq_4 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_DE_1
	{
		get
		{
			return _close_de_1;
		}
		set
		{
			_close_de_1 = value;
		}
	}

	[Col]
	public virtual decimal? CLOSE_OWN_1
	{
		get
		{
			return _close_own_1;
		}
		set
		{
			_close_own_1 = value;
		}
	}

	[Col]
	public virtual string HR_REMARK
	{
		get
		{
			return _hr_remark;
		}
		set
		{
			_hr_remark = value;
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

	public HR_RESIGNATION()
	{
		_addsql = "insert into HR_RESIGNATION (\r\nHR_RESIGNATION_ID ,\r\nPOSITION ,\r\nTITLE ,\r\nEDUCATION_LEVEL ,\r\nREASON ,\r\nRESIGN_DATE ,\r\nAPPLICATION_DATE ,\r\nCONTACT ,\r\nCLOSE_OF_1 ,\r\nCLOSE_FA_1 ,\r\nCLOSE_PT_1 ,\r\nCLOSE_PT_2 ,\r\nCLOSE_IT_1 ,\r\nCLOSE_HQ_1 ,\r\nCLOSE_HQ_2 ,\r\nCLOSE_HQ_3 ,\r\nCLOSE_HQ_4 ,\r\nCLOSE_DE_1 ,\r\nCLOSE_OWN_1 ,\r\nHR_REMARK ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:HR_RESIGNATION_ID ,\r\n:POSITION ,\r\n:TITLE ,\r\n:EDUCATION_LEVEL ,\r\n:REASON ,\r\n:RESIGN_DATE ,\r\n:APPLICATION_DATE ,\r\n:CONTACT ,\r\n:CLOSE_OF_1 ,\r\n:CLOSE_FA_1 ,\r\n:CLOSE_PT_1 ,\r\n:CLOSE_PT_2 ,\r\n:CLOSE_IT_1 ,\r\n:CLOSE_HQ_1 ,\r\n:CLOSE_HQ_2 ,\r\n:CLOSE_HQ_3 ,\r\n:CLOSE_HQ_4 ,\r\n:CLOSE_DE_1 ,\r\n:CLOSE_OWN_1 ,\r\n:HR_REMARK ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM HR_RESIGNATION WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM HR_RESIGNATION T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update HR_RESIGNATION set POSITION=:POSITION \r\n,TITLE=:TITLE \r\n,EDUCATION_LEVEL=:EDUCATION_LEVEL \r\n,REASON=:REASON \r\n,RESIGN_DATE=:RESIGN_DATE \r\n,APPLICATION_DATE=:APPLICATION_DATE \r\n,CONTACT=:CONTACT \r\n,CLOSE_OF_1=:CLOSE_OF_1 \r\n,CLOSE_FA_1=:CLOSE_FA_1 \r\n,CLOSE_PT_1=:CLOSE_PT_1 \r\n,CLOSE_PT_2=:CLOSE_PT_2 \r\n,CLOSE_IT_1=:CLOSE_IT_1 \r\n,CLOSE_HQ_1=:CLOSE_HQ_1 \r\n,CLOSE_HQ_2=:CLOSE_HQ_2 \r\n,CLOSE_HQ_3=:CLOSE_HQ_3 \r\n,CLOSE_HQ_4=:CLOSE_HQ_4 \r\n,CLOSE_DE_1=:CLOSE_DE_1 \r\n,CLOSE_OWN_1=:CLOSE_OWN_1 \r\n,HR_REMARK=:HR_REMARK \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		HR_RESIGNATION dto = parm.JsonDeserialize<HR_RESIGNATION>(new JsonConverter[0]);
		return FindList<HR_RESIGNATION>(dto);
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
