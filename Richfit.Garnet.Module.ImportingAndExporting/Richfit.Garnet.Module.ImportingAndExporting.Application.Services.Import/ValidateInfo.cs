namespace Richfit.Garnet.Module.ImportingAndExporting.Application.Services.Import;

public class ValidateInfo
{
	private bool result;

	private string message;

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

	public string Message
	{
		get
		{
			return message;
		}
		set
		{
			message = value;
		}
	}
}
