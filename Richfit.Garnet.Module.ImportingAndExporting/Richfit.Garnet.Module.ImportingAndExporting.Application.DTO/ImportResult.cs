using System.Collections;

namespace Richfit.Garnet.Module.ImportingAndExporting.Application.DTO;

public class ImportResult
{
	private bool result;

	private IList list;

	private string path;

	public bool Result
	{
		get
		{
			return result;
		}
		set
		{
			result = value;
		}
	}

	public IList List
	{
		get
		{
			return list;
		}
		set
		{
			list = value;
		}
	}

	public string Path
	{
		get
		{
			return path;
		}
		set
		{
			path = value;
		}
	}
}
