using System;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Base.Domain.Models;
using Richfit.Garnet.Module.Workflow.Application.IServices;

namespace Richfit.Garnet.Module.Workflow.Form.Core;

public class DTOExt : DTOBase
{
	public virtual Guid? MODIFIER { get; set; }

	public virtual DateTime? MODIFYTIME { get; set; }

	public virtual Guid? USER_ID { get; set; }

	public virtual Guid? CREATOR { get; set; }

	public virtual DateTime? CREATETIME { get; set; }

	public virtual string USER_NAME { get; set; }

	public virtual Guid? BUSINESS_ID { get; set; }

	public virtual Guid? ORG_ID { get; set; }

	public virtual Guid? TEMPLATE_ID { get; set; }

	public virtual string INSTANCE_NAME { get; set; }

	public virtual string ORG_NAME { get; set; }

	public virtual decimal? ISDEL { get; set; }

	public virtual string UpdateSql { get; set; }

	public virtual string AddSql { get; set; }

	public virtual string FindByInstance { get; set; }

	public virtual string FindPage { get; set; }

	public virtual string WhereSimple { get; set; }

	public virtual string WhereAdvance { get; set; }

	public string FindList<T>(IDTO parm)
	{
		if (FindPage == null || string.IsNullOrEmpty(FindPage))
		{
			Type t = GetType();
			FindPage = $"select t1.*,T2.TEMPLATE_ID from {t.Name} t1 inner join WF_INSTANCE t2 ON T1.INSTANCE_ID=T2.INSTANCE_ID";
		}
		SqlRepository repository = new SqlRepository(null);
		string sql = "";
		sql = ((parm.SearchType != 0) ? (FindPage + " WHERE " + WhereAdvance) : (FindPage + (string.IsNullOrEmpty(WhereSimple) ? "" : (" WHERE " + WhereSimple))));
		return repository.SqlQueryPager<T>(sql, parm).JsonSerialize();
	}

	public virtual string FindList(string parm)
	{
		return "";
	}
}
