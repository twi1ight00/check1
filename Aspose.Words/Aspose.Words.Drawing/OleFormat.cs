using System;
using System.IO;
using x011d489fb9df7027;
using x13f1efc79617a47b;
using x28925c9b27b37a46;
using x5af3f327d745698a;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Drawing;

public class OleFormat
{
	private readonly x7b71245a33212e76 xc454c03c23d4b4d9;

	private x3c332ff69b5b440d x912dc4f8421ff321;

	public string IconCaption
	{
		get
		{
			if (OleIcon)
			{
				if (x3c332ff69b5b440d != null && x3c332ff69b5b440d.x22ab5dfa6f12e902 && x3c332ff69b5b440d.x63f271b9608e0c03 != null)
				{
					return x3c332ff69b5b440d.x63f271b9608e0c03;
				}
				if (x58932c7e6fa3b905 is x71d39fdf56861cca x71d39fdf56861cca && x71d39fdf56861cca.xe9996a8329ef750a)
				{
					return x71d39fdf56861cca.x684dfe8d1a308be0();
				}
			}
			return "";
		}
	}

	public string SuggestedExtension
	{
		get
		{
			if (x58932c7e6fa3b905 == null)
			{
				return "";
			}
			return x58932c7e6fa3b905.x42fe3274236becd5(ProgId);
		}
	}

	internal bool x31d18bbaf493b1b0
	{
		get
		{
			if (IsLink)
			{
				return x58932c7e6fa3b905 == null;
			}
			return false;
		}
	}

	public string ProgId
	{
		get
		{
			return (string)xfe91eeeafcb3026a(4113);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xae20093bed1e48a8(4113, value);
		}
	}

	public bool IsLink => x0d299f323d241756.x5959bccb67bbf051(SourceFullName);

	public string SourceFullName
	{
		get
		{
			return (string)xfe91eeeafcb3026a(4114);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xae20093bed1e48a8(4114, value);
		}
	}

	public string SourceItem
	{
		get
		{
			return (string)xfe91eeeafcb3026a(4115);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xae20093bed1e48a8(4115, value);
		}
	}

	public bool AutoUpdate
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(4116);
		}
		set
		{
			xae20093bed1e48a8(4116, value);
		}
	}

	public bool OleIcon => (bool)xfe91eeeafcb3026a(826);

	public bool IsLocked
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(4117);
		}
		set
		{
			xae20093bed1e48a8(4117, value);
		}
	}

	public Guid Clsid
	{
		get
		{
			if (x71d39fdf56861cca != null)
			{
				return x71d39fdf56861cca.x6b73aa01aa019d3a.x933ed8cf24f04c67;
			}
			if (xb7e718098524b76c != null)
			{
				return xb7e718098524b76c.x933ed8cf24f04c67;
			}
			return Guid.Empty;
		}
	}

	internal xd142dcacd7ddc9dd x58932c7e6fa3b905
	{
		get
		{
			return (xd142dcacd7ddc9dd)xfe91eeeafcb3026a(4112);
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			xae20093bed1e48a8(4112, value);
			x280d4ad3b0640f9c();
		}
	}

	internal x71d39fdf56861cca x71d39fdf56861cca => x58932c7e6fa3b905 as x71d39fdf56861cca;

	internal xb7e718098524b76c xb7e718098524b76c => x58932c7e6fa3b905 as xb7e718098524b76c;

	internal int x78871a21d651e673
	{
		get
		{
			return (int)xfe91eeeafcb3026a(267);
		}
		set
		{
			xae20093bed1e48a8(267, value);
		}
	}

	internal x2e7d767f7d782a7a x2e7d767f7d782a7a
	{
		get
		{
			return (x2e7d767f7d782a7a)xfe91eeeafcb3026a(4118);
		}
		set
		{
			xae20093bed1e48a8(4118, value);
		}
	}

	internal int x577033bbed151076
	{
		get
		{
			return (int)xfe91eeeafcb3026a(4119);
		}
		set
		{
			xae20093bed1e48a8(4119, value);
		}
	}

	private x3c332ff69b5b440d x3c332ff69b5b440d
	{
		get
		{
			if (x912dc4f8421ff321 == null)
			{
				byte[] metafileBytes = (byte[])xc454c03c23d4b4d9.x048513c924d75f6b(4102);
				x912dc4f8421ff321 = new x3c332ff69b5b440d(metafileBytes);
			}
			if (!x912dc4f8421ff321.x22ab5dfa6f12e902)
			{
				return null;
			}
			return x912dc4f8421ff321;
		}
	}

	internal OleFormat(x7b71245a33212e76 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	[JavaInternal]
	public void Save(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (IsLink)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cmkhdnbibniiinpicigjoknjikekojlkghclcmjlclamhlhmpkomkkfnilmnbgdohkkookbpifipbkppljganjnahjeboilbkiccpejcaeadohhdiiodlhfeedmeehdfpgkfjhbgghigehpgghghpbnhofeiofligbcjggjjbfakdghkpeokleflcbmlbadmnckmjebneeinoepncpfoednojdeplclplccahcjaecabcchbobobhnecdamcnpcddpjdlmaehbiehapemagfeanfppdgnalgjachdlihdpphoogiipnihkejgoljgockojjkooaljnhlloolhnfmdnmmkjdn", 986806894)));
		}
		x58932c7e6fa3b905.x2961bf88b232b7a8(stream, ProgId);
	}

	public void Save(string fileName)
	{
		using Stream stream = File.Create(fileName);
		Save(stream);
	}

	public MemoryStream GetOleEntry(string oleEntryName)
	{
		if (x71d39fdf56861cca != null)
		{
			return (MemoryStream)x71d39fdf56861cca.x6b73aa01aa019d3a[oleEntryName];
		}
		return null;
	}

	internal void xf3959158bd894c23(bool xa3c32c64cb78d128)
	{
		xae20093bed1e48a8(826, xa3c32c64cb78d128);
	}

	[JavaConvertCheckedExceptions]
	private void x280d4ad3b0640f9c()
	{
		if (x71d39fdf56861cca != null && x71d39fdf56861cca.x6b73aa01aa019d3a.Contains("\u0003ObjInfo"))
		{
			x5a72a7bc4849e9de x5a72a7bc4849e9de = new x5a72a7bc4849e9de(x71d39fdf56861cca.x6b73aa01aa019d3a);
			xf3959158bd894c23(x5a72a7bc4849e9de.x713fda74e617b722);
		}
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xfc928672852cc4c4(xba08ce632055a1d9);
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
