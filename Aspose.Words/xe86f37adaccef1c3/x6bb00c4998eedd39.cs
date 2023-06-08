using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x28925c9b27b37a46;
using xfbd1009a0cbb9842;

namespace xe86f37adaccef1c3;

internal class x6bb00c4998eedd39 : x15a33f6d96885286
{
	private ArrayList xadee0f5e87ef6ec5;

	private Hashtable xf029f9d9ec5224ac;

	private static readonly FieldType[] xa800fe5e781662fa = new FieldType[2]
	{
		FieldType.FieldAsk,
		FieldType.FieldFillIn
	};

	internal void x3ef8d9eab8302a17(Document x3664041d21d73fdc)
	{
		x6435b7bbb0879a04 x6435b7bbb0879a = xe25d778fe9f1252a.x105bab38d511372f(x3664041d21d73fdc, x0d900d42b3598fde: true, xa800fe5e781662fa);
		foreach (Field item in x6435b7bbb0879a)
		{
			if (x5f1c608c8429679f(item))
			{
				if (xadee0f5e87ef6ec5 == null)
				{
					xadee0f5e87ef6ec5 = new ArrayList();
				}
				xadee0f5e87ef6ec5.Add(item.Start);
			}
		}
	}

	private bool x5f1c608c8429679f(Field xe01ae93d9fe5a880)
	{
		switch (xe01ae93d9fe5a880.Type)
		{
		case FieldType.FieldAsk:
		case FieldType.FieldFillIn:
			return x7f52a76f265da478.x353c1ff63384adf1(xe01ae93d9fe5a880);
		default:
			return false;
		}
	}

	internal void x09cb5d25e0058445()
	{
		xadee0f5e87ef6ec5 = null;
		xf029f9d9ec5224ac = null;
	}

	internal object xf39c106b43956987(Node x3b2496727a21f4a2)
	{
		if (xf029f9d9ec5224ac != null)
		{
			return xf029f9d9ec5224ac[x3b2496727a21f4a2];
		}
		return null;
	}

	private void x4c0c8a54a45873df(Node x337e217cb3ba0627, Node x3b2496727a21f4a2)
	{
		if (xadee0f5e87ef6ec5 == null)
		{
			return;
		}
		object obj = null;
		if (xf029f9d9ec5224ac != null)
		{
			obj = xf029f9d9ec5224ac[x337e217cb3ba0627];
		}
		if (obj == null)
		{
			if (!xadee0f5e87ef6ec5.Contains(x337e217cb3ba0627))
			{
				return;
			}
			obj = x337e217cb3ba0627;
		}
		if (xf029f9d9ec5224ac == null)
		{
			xf029f9d9ec5224ac = new Hashtable();
		}
		xf029f9d9ec5224ac[x3b2496727a21f4a2] = obj;
	}

	void x15a33f6d96885286.xcc01c1f2f17c1af0(Node x337e217cb3ba0627, Node x3b2496727a21f4a2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x4c0c8a54a45873df
		this.x4c0c8a54a45873df(x337e217cb3ba0627, x3b2496727a21f4a2);
	}
}
