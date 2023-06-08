using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.Portal.Application.DTO;

public class SYS_SHORTCUTDTO : DTOBase, IComparable<SYS_SHORTCUTDTO>
{
	public Guid SHORTCUT_ID { get; set; }

	public Guid? MENU_ID { get; set; }

	public Guid? USER_ID { get; set; }

	public decimal? SORT { get; set; }

	public int CompareTo(SYS_SHORTCUTDTO other)
	{
		return SORT.Value.CompareTo(other.SORT.Value);
	}
}
