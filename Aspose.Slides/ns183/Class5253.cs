using System;
using System.Collections;
using System.Drawing;
using System.IO;
using ns175;

namespace ns183;

internal class Class5253 : IDisposable
{
	private Hashtable hashtable_0 = new Hashtable();

	public Class5253(Interface152 context)
	{
	}

	public Class5741 method_0(string uri, Interface170 session)
	{
		string key = uri.ToUpperInvariant();
		if (hashtable_0.ContainsKey(key))
		{
			return hashtable_0[key] as Class5741;
		}
		Stream stream = session.imethod_2(uri);
		if (stream == null)
		{
			hashtable_0.Add(key, null);
			return null;
		}
		try
		{
			Bitmap bitmap = new Bitmap(stream);
			Class5741 @class = new Class5741(uri, "image/png");
			Class5393 sizE = new Class5393(bitmap.Width, bitmap.Height, bitmap.HorizontalResolution, bitmap.VerticalResolution);
			@class.method_3(sizE);
			@class.method_4()[Class5741.object_0] = bitmap;
			hashtable_0.Add(key, @class);
			return @class;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public Image method_1(Class5741 info, Interface170 session)
	{
		return info.method_5();
	}

	public void Dispose()
	{
		if (hashtable_0 == null)
		{
			return;
		}
		foreach (DictionaryEntry item in hashtable_0)
		{
			if (item.Value is Class5741 @class)
			{
				@class.method_5().Dispose();
			}
		}
		hashtable_0.Clear();
		hashtable_0 = null;
	}
}
