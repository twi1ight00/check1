using System.Collections;
using System.IO;
using Aspose;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x7c7a1dceb600404e;

internal class x6f6338c074d2d794
{
	private static volatile Hashtable xa4987d1e4319199a;

	private static readonly object x9c69dd8b21b66e04 = new object();

	private static readonly Hashtable xf43c56a75baaec5e = new Hashtable();

	private static readonly object x7d5b1fcc36957f32 = new object();

	private static Hashtable x00be18fc287e41f7
	{
		get
		{
			if (xa4987d1e4319199a == null)
			{
				lock (x9c69dd8b21b66e04)
				{
					if (xa4987d1e4319199a == null)
					{
						xa4987d1e4319199a = xc799481315972a96();
					}
				}
			}
			return xa4987d1e4319199a;
		}
	}

	private x6f6338c074d2d794()
	{
	}

	internal static string xed451fba51ebd67a(ShapeType x02f2ab213025de6d)
	{
		return (string)x00be18fc287e41f7[x02f2ab213025de6d];
	}

	[JavaConvertCheckedExceptions]
	internal static xf7125312c7ee115c xc49bc34e8c134250(ShapeType x02f2ab213025de6d)
	{
		xf7125312c7ee115c xf7125312c7ee115c;
		lock (x7d5b1fcc36957f32)
		{
			xf7125312c7ee115c = (xf7125312c7ee115c)xf43c56a75baaec5e[x02f2ab213025de6d];
		}
		if (xf7125312c7ee115c == null)
		{
			lock (x7d5b1fcc36957f32)
			{
				if (xf43c56a75baaec5e.ContainsKey(x02f2ab213025de6d))
				{
					xf7125312c7ee115c = (xf7125312c7ee115c)xf43c56a75baaec5e[x02f2ab213025de6d];
				}
				else
				{
					xf43c56a75baaec5e[x02f2ab213025de6d] = null;
					string text = xed451fba51ebd67a(x02f2ab213025de6d);
					if (x0d299f323d241756.x5959bccb67bbf051(text))
					{
						xf7125312c7ee115c = xcb00358ab5144003.xdbced29cb6a266e4(new x288eb83327ae0dc9(text));
						xf43c56a75baaec5e[x02f2ab213025de6d] = xf7125312c7ee115c;
					}
				}
			}
		}
		return xf7125312c7ee115c;
	}

	private static Hashtable xc799481315972a96()
	{
		using Stream stream = xed747ca236d86aa0.xe1cd764b6fb0d6f6("Aspose.Words.Resources.ShapeTypes.txt");
		using StreamReader streamReader = new StreamReader(stream);
		Hashtable hashtable = new Hashtable(220);
		int num = -2;
		string value;
		while ((value = streamReader.ReadLine()) != null)
		{
			hashtable.Add((ShapeType)num, value);
			num++;
		}
		return hashtable;
	}
}
