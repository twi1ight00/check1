using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Portal.Application.DTO;

public class SYS_PORTALDTO : DTOBase, IComparable<SYS_USER_PORTALDTO>
{
	public Guid PORTAL_ID { get; set; }

	public string PORTAL_TEXT { get; set; }

	public string PORTAL_URL { get; set; }

	public string IMAGE_URL { get; set; }

	public decimal? SORT { get; set; }

	public decimal? IS_REFRESH { get; set; }

	public decimal ISDEL { get; set; }

	public int CompareTo(SYS_USER_PORTALDTO other)
	{
		return SORT.Value.CompareTo(other.SORT.Value);
	}
}
