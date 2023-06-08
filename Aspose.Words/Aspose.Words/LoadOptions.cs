using System.Text;
using Aspose.Words.Loading;

namespace Aspose.Words;

public class LoadOptions
{
	private LoadFormat xac8f6c715bbaaafc;

	private string x43bfbd3c83649bc6;

	private string x62ff3dabf0a6c41f;

	private Encoding xcce637b6f486a407;

	private IResourceLoadingCallback xe50b02df29e39a57;

	private IWarningCallback xa056586c1f99e199;

	private bool x3164ff71c365c955;

	public LoadFormat LoadFormat
	{
		get
		{
			return xac8f6c715bbaaafc;
		}
		set
		{
			xac8f6c715bbaaafc = value;
		}
	}

	public string Password
	{
		get
		{
			return x43bfbd3c83649bc6;
		}
		set
		{
			x43bfbd3c83649bc6 = value;
		}
	}

	public string BaseUri
	{
		get
		{
			return x62ff3dabf0a6c41f;
		}
		set
		{
			x62ff3dabf0a6c41f = value;
		}
	}

	public Encoding Encoding
	{
		get
		{
			return xcce637b6f486a407;
		}
		set
		{
			xcce637b6f486a407 = value;
		}
	}

	public IResourceLoadingCallback ResourceLoadingCallback
	{
		get
		{
			return xe50b02df29e39a57;
		}
		set
		{
			xe50b02df29e39a57 = value;
		}
	}

	public IWarningCallback WarningCallback
	{
		get
		{
			return xa056586c1f99e199;
		}
		set
		{
			xa056586c1f99e199 = value;
		}
	}

	public bool PreserveIncludePictureField
	{
		get
		{
			return x3164ff71c365c955;
		}
		set
		{
			x3164ff71c365c955 = value;
		}
	}

	public LoadOptions()
	{
	}

	public LoadOptions(string password)
	{
		x43bfbd3c83649bc6 = password;
	}

	public LoadOptions(LoadFormat loadFormat, string password, string baseUri)
	{
		xac8f6c715bbaaafc = loadFormat;
		x43bfbd3c83649bc6 = password;
		x62ff3dabf0a6c41f = baseUri;
	}

	internal LoadOptions x8b61531c8ea35b85()
	{
		return (LoadOptions)MemberwiseClone();
	}
}
