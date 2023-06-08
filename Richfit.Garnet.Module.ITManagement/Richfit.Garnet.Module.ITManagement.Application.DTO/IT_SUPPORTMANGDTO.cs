using System;
using Richfit.Garnet.Module.Base.Application.DTO;

namespace Richfit.Garnet.Module.ITManagement.Application.DTO;

public class IT_SUPPORTMANGDTO : DTOBase
{
	public string Catalog { get; set; }

	public Guid? IT_SUPPORTMANG_ID { get; set; }

	public string IT_SUPPORTMANG_NAME { get; set; }

	public Guid? IT_SUPPORTMANG_TYPE_ID { get; set; }

	public string IT_SUPPORTMANG_TYPE_NAME { get; set; }

	public string REMARK { get; set; }

	public string FILE_RELATIVE_PATH { get; set; }

	public string FILE_NETWORK_PATH { get; set; }

	public string NOTE { get; set; }

	public string FILE_TYPE { get; set; }

	public decimal? IT_SUPPORTMANG_SIZE { get; set; }

	public decimal? ISDEL { get; set; }

	public Guid? CREATOR { get; set; }

	public string CREATOR_NAME { get; set; }

	public DateTime? CREATETIME { get; set; }

	public Guid? MODIFIER { get; set; }

	public DateTime? MODIFYTIME { get; set; }
}
