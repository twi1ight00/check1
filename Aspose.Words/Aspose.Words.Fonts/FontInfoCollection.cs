using System;
using System.Collections;
using x2ca723f92be254b6;
using x38d3ef1c1d247e82;
using x4b4f8b01ec4cb4b2;
using x6c95d9cf46ff5f25;
using xeb665d1aeef09d64;
using xf9a9481c3f63a419;

namespace Aspose.Words.Fonts;

[JavaGenericArguments("Iterable<FontInfo>")]
public class FontInfoCollection : IEnumerable
{
	private ArrayList x82b70567a5f68f41;

	private IDictionary x3774b230709fb131;

	private ArrayList xacd2d7f6e68cacd5;

	private IDictionary xdb4ef8594a0d0c4c;

	private x26ee10d60756aeab x32d7c8a7e17e084b;

	public int Count => x82b70567a5f68f41.Count;

	public FontInfo this[string name]
	{
		get
		{
			object obj = x3774b230709fb131[name];
			if (obj == null)
			{
				return null;
			}
			return this[(int)obj];
		}
	}

	public FontInfo this[int index] => (FontInfo)x82b70567a5f68f41[index];

	internal x26ee10d60756aeab x26ee10d60756aeab
	{
		get
		{
			if (x32d7c8a7e17e084b == null)
			{
				x7485f4675052e498();
			}
			return x32d7c8a7e17e084b;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	public bool Contains(string name)
	{
		return x3774b230709fb131.Contains(name);
	}

	internal FontInfoCollection()
	{
		xa9d636b00ff486b7();
	}

	internal int x04327ff503798cdd(string xc15bd84e01929885)
	{
		object obj = x3774b230709fb131[xc15bd84e01929885];
		if (obj == null)
		{
			obj = xdb4ef8594a0d0c4c[xc15bd84e01929885];
		}
		if (obj != null)
		{
			return (int)obj;
		}
		return xd5da23b762ce52a2(new FontInfo(xc15bd84e01929885));
	}

	internal string x7bcd2fb72fb7aae6(int x3d2dde7c72e020a4)
	{
		if (x82b70567a5f68f41.Count == 0)
		{
			xd5da23b762ce52a2(new FontInfo("Times New Roman"));
		}
		if (x3d2dde7c72e020a4 < 0 || x3d2dde7c72e020a4 >= xacd2d7f6e68cacd5.Count)
		{
			x3d2dde7c72e020a4 = 0;
		}
		return (string)xacd2d7f6e68cacd5[x3d2dde7c72e020a4];
	}

	internal int xd5da23b762ce52a2(FontInfo xfa5e135bae569bda)
	{
		int num = 0;
		if (Contains(xfa5e135bae569bda.Name))
		{
			num = (int)x3774b230709fb131[xfa5e135bae569bda.Name];
			((FontInfo)x82b70567a5f68f41[num]).xd5da23b762ce52a2(xfa5e135bae569bda);
		}
		else if (x0d299f323d241756.x5959bccb67bbf051(xfa5e135bae569bda.Name))
		{
			num = x82b70567a5f68f41.Add(xfa5e135bae569bda.x8b61531c8ea35b85());
			x3774b230709fb131[xfa5e135bae569bda.Name] = num;
		}
		xacd2d7f6e68cacd5.Add(xfa5e135bae569bda.Name);
		foreach (string item in xfa5e135bae569bda.xad8f5d5549eb487c())
		{
			if (!xdb4ef8594a0d0c4c.Contains(item))
			{
				xdb4ef8594a0d0c4c[item] = num;
			}
		}
		x32d7c8a7e17e084b = null;
		return num;
	}

	internal void xd5da23b762ce52a2(FontInfoCollection xb57c4a9902d360dc)
	{
		foreach (FontInfo item in xb57c4a9902d360dc)
		{
			xd5da23b762ce52a2(item);
		}
	}

	internal void x9b3bacb3ea1603b5(x94c83b1ca7961561 x33e549b893445a37)
	{
		ArrayList x2e05f892ec1c586a = new ArrayList();
		x6519502b0e34e920 x1a8377aa = new x6519502b0e34e920();
		x27233a168e3a1745(x33e549b893445a37, x2e05f892ec1c586a, x1a8377aa);
		xc841db02f4801dd1(x1a8377aa);
		xd606075dbc19647b(x2e05f892ec1c586a);
	}

	internal FontInfoCollection x8b61531c8ea35b85()
	{
		FontInfoCollection fontInfoCollection = new FontInfoCollection();
		fontInfoCollection.xd5da23b762ce52a2(this);
		return fontInfoCollection;
	}

	private void xa9d636b00ff486b7()
	{
		x82b70567a5f68f41 = new ArrayList();
		xacd2d7f6e68cacd5 = new ArrayList();
		x3774b230709fb131 = xd51c34d05311eee3.xdb04a310bbb29cff();
		xdb4ef8594a0d0c4c = xd51c34d05311eee3.xdb04a310bbb29cff();
	}

	private void x27233a168e3a1745(x94c83b1ca7961561 x33e549b893445a37, ArrayList x2e05f892ec1c586a, x6519502b0e34e920 x1a8377aa55560294)
	{
		ArrayList arrayList = new ArrayList();
		foreach (string item in x33e549b893445a37)
		{
			arrayList.Add(item);
		}
		arrayList.Sort();
		foreach (string item2 in arrayList)
		{
			object obj = x3774b230709fb131[item2];
			if (obj == null)
			{
				obj = xdb4ef8594a0d0c4c[item2];
			}
			if (obj != null)
			{
				x1a8377aa55560294.xd6b6ed77479ef68c(obj);
			}
			else
			{
				x2e05f892ec1c586a.Add(item2);
			}
		}
	}

	private void xc841db02f4801dd1(x6519502b0e34e920 x1a8377aa55560294)
	{
		ArrayList arrayList = x82b70567a5f68f41;
		xa9d636b00ff486b7();
		foreach (int item in x1a8377aa55560294)
		{
			xd5da23b762ce52a2((FontInfo)arrayList[item]);
		}
	}

	private void xd606075dbc19647b(ArrayList x2e05f892ec1c586a)
	{
		foreach (string item in x2e05f892ec1c586a)
		{
			xd5da23b762ce52a2(new FontInfo(item));
		}
	}

	private void x7485f4675052e498()
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				FontInfo fontInfo = (FontInfo)enumerator.Current;
				ArrayList arrayList2 = new ArrayList();
				if (fontInfo.xf24d2f6e3cbd9dd5(EmbeddedFontFormat.OpenType) != null)
				{
					arrayList2.AddRange(fontInfo.xf24d2f6e3cbd9dd5(EmbeddedFontFormat.OpenType));
				}
				if (fontInfo.xf24d2f6e3cbd9dd5(EmbeddedFontFormat.EmbeddedOpenType) != null)
				{
					arrayList2.AddRange(fontInfo.xf24d2f6e3cbd9dd5(EmbeddedFontFormat.EmbeddedOpenType));
				}
				foreach (x393d198b88cf5ed5 item in arrayList2)
				{
					if (item != null)
					{
						byte[] array = null;
						if (item.xa890d2fd18bed2bc == EmbeddedFontFormat.OpenType)
						{
							array = item.x6b73aa01aa019d3a;
						}
						else if (item.xa890d2fd18bed2bc == EmbeddedFontFormat.EmbeddedOpenType)
						{
							array = xac66d47cb447c5bf.xb257ab73498e1e07(item.x6b73aa01aa019d3a);
						}
						if (array != null)
						{
							x8989ff189b375934 x8989ff189b = new x8989ff189b375934(fontInfo.Name, x6501b25762b2024e(fontInfo.Name, item.xfe2178c1f916f36c));
							x8989ff189b.x6b73aa01aa019d3a = new x6033a882faba96b0(array);
							arrayList.Add(x8989ff189b);
						}
					}
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		x32d7c8a7e17e084b = new x26ee10d60756aeab((x8989ff189b375934[])arrayList.ToArray(typeof(x8989ff189b375934)));
	}

	private string x6501b25762b2024e(string xa79a9f649c74f4a4, EmbeddedFontStyle x44ecfea61c937b8e)
	{
		string arg = string.Empty;
		switch (x44ecfea61c937b8e)
		{
		case EmbeddedFontStyle.Regular:
			arg = "Regular";
			break;
		case EmbeddedFontStyle.Bold:
			arg = "Bold";
			break;
		case EmbeddedFontStyle.Italic:
			arg = "Italic";
			break;
		case EmbeddedFontStyle.BoldItalic:
			arg = "BoldItalic";
			break;
		}
		return $"{xa79a9f649c74f4a4}-{arg}";
	}
}
