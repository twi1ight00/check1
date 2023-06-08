using System.Data;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class QueryResult
{
	public DataTable List { get; set; }

	public int RecordCount { get; set; }
}
