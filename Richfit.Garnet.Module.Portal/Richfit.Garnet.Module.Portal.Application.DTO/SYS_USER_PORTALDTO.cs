using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Portal.Application.DTO;

public class SYS_USER_PORTALDTO : DTOBase, IComparable<SYS_USER_PORTALDTO>
{
	public Guid USER_PORTAL_ID { get; set; }

	public Guid? PORTAL_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public decimal? COL_NUMBER { get; set; }

	public decimal? SORT { get; set; }

	public SYS_PORTALDTO SYS_PORTAL { get; set; }

	public int CompareTo(SYS_USER_PORTALDTO other)
	{
		return SORT.Value.CompareTo(other.SORT.Value);
	}
}
