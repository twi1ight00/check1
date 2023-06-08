using System;
using System.Collections;
using System.Collections.Specialized;
using Aspose;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xeb665d1aeef09d64;

internal class x829cfec1381601a4 : x551d3b1862a114b1
{
	[JavaThrows(false)]
	internal override x25998da3963930e9[] xe8752f84ee2ed522()
	{
		try
		{
			IDictionary dictionary = xd51c34d05311eee3.xdb04a310bbb29cff();
			string text = x09d499c483428bd1.x7e3d53d5e4ddb3fd();
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				return new x25998da3963930e9[0];
			}
			StringEnumerator enumerator = x0d299f323d241756.x67bd11727bb1eb41(text, xa5c28c1d423983a7: true).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					dictionary[current] = current;
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			if (xed747ca236d86aa0.xf40b599afa14f524() == x3bb20242a64c30a9.x8a2adacc78a4bcc9)
			{
				xed747ca236d86aa0.x82611b255d9983ac(dictionary);
			}
			ArrayList arrayList = new ArrayList();
			foreach (string key in dictionary.Keys)
			{
				arrayList.Add(new xda6c010448467ed0(key));
			}
			return (x25998da3963930e9[])arrayList.ToArray(typeof(x25998da3963930e9));
		}
		catch (Exception)
		{
			return new x25998da3963930e9[0];
		}
	}
}
