using x6c95d9cf46ff5f25;

namespace Aspose.Words.Markup;

public class CustomPart
{
	private string xc61ff88f1f98652d = "";

	private string x168dda60412223f5 = "";

	private bool xd358cae2a35b60d8;

	private string x98e285df741c9d32 = "";

	private byte[] x73f065a6b420cfe1 = xcd4bd3abd72ff2da.x2b0797e1bb4e840a;

	public string Name
	{
		get
		{
			return xc61ff88f1f98652d;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "name");
			xc61ff88f1f98652d = value;
		}
	}

	public string RelationshipType
	{
		get
		{
			return x168dda60412223f5;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "relationshipType");
			x168dda60412223f5 = value;
		}
	}

	public bool IsExternal
	{
		get
		{
			return xd358cae2a35b60d8;
		}
		set
		{
			xd358cae2a35b60d8 = value;
		}
	}

	public string ContentType
	{
		get
		{
			return x98e285df741c9d32;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "contentType");
			x98e285df741c9d32 = value;
		}
	}

	public byte[] Data
	{
		get
		{
			return x73f065a6b420cfe1;
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "data");
			x73f065a6b420cfe1 = value;
		}
	}

	public CustomPart Clone()
	{
		return (CustomPart)MemberwiseClone();
	}
}
