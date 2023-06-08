using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Workflow.Application.IServices;
using Richfit.Garnet.Module.Workflow.Form.Core;
using Richfit.Garnet.Module.Workflow.Form.Core.Attribute;

namespace Richfit.Garnet.Module.Workflow.Form.Module.PersonalExit.DTO;

[Serializable]
public class AC_HR_PERSONAL_EXIT : DTOExt, IDTO
{
	private Guid? _hr_personal_exit_id;

	private string _title;

	private decimal? _sex;

	private DateTime? _birthday;

	private Guid? _nation;

	private string _native_place;

	private string _birthplace;

	private Guid? _political_status;

	private Guid? _marital_status;

	private Guid? _education;

	private string _address;

	private string _work_unit;

	private Guid? _position;

	private string _country;

	private string _reason;

	private string _org_suggestion;

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

	private Guid? _instance_id;

	private string _addsql;

	private string _updatesql;

	private string _findbyinstance;

	private string _findpage;

	[Col]
	[Primary]
	public virtual Guid? HR_PERSONAL_EXIT_ID
	{
		get
		{
			return _hr_personal_exit_id;
		}
		set
		{
			_hr_personal_exit_id = value;
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
	public virtual decimal? SEX
	{
		get
		{
			return _sex;
		}
		set
		{
			_sex = value;
		}
	}

	[Col]
	public virtual DateTime? BIRTHDAY
	{
		get
		{
			return _birthday;
		}
		set
		{
			_birthday = value;
		}
	}

	[Col]
	public virtual Guid? NATION
	{
		get
		{
			return _nation;
		}
		set
		{
			_nation = value;
		}
	}

	[Col]
	public virtual string NATIVE_PLACE
	{
		get
		{
			return _native_place;
		}
		set
		{
			_native_place = value;
		}
	}

	[Col]
	public virtual string BIRTHPLACE
	{
		get
		{
			return _birthplace;
		}
		set
		{
			_birthplace = value;
		}
	}

	[Col]
	public virtual Guid? POLITICAL_STATUS
	{
		get
		{
			return _political_status;
		}
		set
		{
			_political_status = value;
		}
	}

	[Col]
	public virtual Guid? MARITAL_STATUS
	{
		get
		{
			return _marital_status;
		}
		set
		{
			_marital_status = value;
		}
	}

	[Col]
	public virtual Guid? EDUCATION
	{
		get
		{
			return _education;
		}
		set
		{
			_education = value;
		}
	}

	[Col]
	public virtual string ADDRESS
	{
		get
		{
			return _address;
		}
		set
		{
			_address = value;
		}
	}

	[Col]
	public virtual string WORK_UNIT
	{
		get
		{
			return _work_unit;
		}
		set
		{
			_work_unit = value;
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
	public virtual string ORG_SUGGESTION
	{
		get
		{
			return _org_suggestion;
		}
		set
		{
			_org_suggestion = value;
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

	public AC_HR_PERSONAL_EXIT()
	{
		_addsql = "insert into AC_HR_PERSONAL_EXIT (\r\nHR_PERSONAL_EXIT_ID ,\r\nTITLE ,\r\nSEX ,\r\nBIRTHDAY ,\r\nNATION ,\r\nNATIVE_PLACE ,\r\nBIRTHPLACE ,\r\nPOLITICAL_STATUS ,\r\nMARITAL_STATUS ,\r\nEDUCATION ,\r\nADDRESS ,\r\nWORK_UNIT ,\r\nPOSITION ,\r\nCOUNTRY ,\r\nREASON ,\r\nORG_SUGGESTION ,\r\nAPPROVAL_OPINION ,\r\nISDEL ,\r\nCREATOR ,\r\nCREATETIME ,\r\nMODIFIER ,\r\nMODIFYTIME ,\r\nUSER_ID ,\r\nUSER_NAME ,\r\nORG_ID ,\r\nORG_NAME ,\r\nINSTANCE_ID ) values (\r\n:HR_PERSONAL_EXIT_ID ,\r\n:TITLE ,\r\n:SEX ,\r\n:BIRTHDAY ,\r\n:NATION ,\r\n:NATIVE_PLACE ,\r\n:BIRTHPLACE ,\r\n:POLITICAL_STATUS ,\r\n:MARITAL_STATUS ,\r\n:EDUCATION ,\r\n:ADDRESS ,\r\n:WORK_UNIT ,\r\n:POSITION ,\r\n:COUNTRY ,\r\n:REASON ,\r\n:ORG_SUGGESTION ,\r\n:APPROVAL_OPINION ,\r\n:ISDEL ,\r\n:CREATOR ,\r\n:CREATETIME ,\r\n:MODIFIER ,\r\n:MODIFYTIME ,\r\n:USER_ID ,\r\n:USER_NAME ,\r\n:ORG_ID ,\r\n:ORG_NAME ,\r\n:INSTANCE_ID )";
		_findbyinstance = "SELECT * FROM AC_HR_PERSONAL_EXIT WHERE INSTANCE_ID=:INSTANCE_ID";
		_findpage = "SELECT T1.*,T2.TEMPLATE_ID,T2.INSTANCE_NAME FROM AC_HR_PERSONAL_EXIT T1 LEFT JOIN WF_INSTANCE T2 ON T1.INSTANCE_ID=T2.INSTANCE_ID ";
		_updatesql = "update AC_HR_PERSONAL_EXIT set HR_PERSONAL_EXIT_ID=:HR_PERSONAL_EXIT_ID \r\n,TITLE=:TITLE \r\n,SEX=:SEX \r\n,BIRTHDAY=:BIRTHDAY \r\n,NATION=:NATION \r\n,NATIVE_PLACE=:NATIVE_PLACE \r\n,BIRTHPLACE=:BIRTHPLACE \r\n,POLITICAL_STATUS=:POLITICAL_STATUS \r\n,MARITAL_STATUS=:MARITAL_STATUS \r\n,EDUCATION=:EDUCATION \r\n,ADDRESS=:ADDRESS \r\n,WORK_UNIT=:WORK_UNIT \r\n,POSITION=:POSITION \r\n,COUNTRY=:COUNTRY \r\n,REASON=:REASON \r\n,ORG_SUGGESTION=:ORG_SUGGESTION \r\n,APPROVAL_OPINION=:APPROVAL_OPINION \r\n,ISDEL=:ISDEL \r\n,CREATOR=:CREATOR \r\n,CREATETIME=:CREATETIME \r\n,MODIFIER=:MODIFIER \r\n,MODIFYTIME=:MODIFYTIME \r\n,USER_ID=:USER_ID \r\n,USER_NAME=:USER_NAME \r\n,ORG_ID=:ORG_ID \r\n,ORG_NAME=:ORG_NAME \r\n WHERE INSTANCE_ID=:INSTANCE_ID";
	}

	public override string FindList(string parm)
	{
		AC_HR_PERSONAL_EXIT dto = parm.JsonDeserialize<AC_HR_PERSONAL_EXIT>(new JsonConverter[0]);
		return FindList<AC_HR_PERSONAL_EXIT>(dto);
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
