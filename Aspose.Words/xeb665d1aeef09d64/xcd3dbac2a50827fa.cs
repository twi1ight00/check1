using System;
using System.Collections;
using System.Collections.Specialized;
using Aspose;
using x6c95d9cf46ff5f25;

namespace xeb665d1aeef09d64;

internal class xcd3dbac2a50827fa : x551d3b1862a114b1
{
	private readonly string xb623bfc824f99feb;

	private readonly bool xfd125918fb7778b4;

	public string xc7faa4629ea73ace => xb623bfc824f99feb;

	public bool x9e0d704480302933 => xfd125918fb7778b4;

	public xcd3dbac2a50827fa(string folderPath, bool scanSubfolders)
	{
		xb623bfc824f99feb = folderPath;
		xfd125918fb7778b4 = scanSubfolders;
	}

	[JavaThrows(false)]
	internal override x25998da3963930e9[] xe8752f84ee2ed522()
	{
		try
		{
			if (!x0d299f323d241756.x5959bccb67bbf051(xb623bfc824f99feb))
			{
				return new x25998da3963930e9[0];
			}
			ArrayList arrayList = new ArrayList();
			StringEnumerator enumerator = x0d299f323d241756.x67bd11727bb1eb41(xb623bfc824f99feb, xfd125918fb7778b4).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					arrayList.Add(new xda6c010448467ed0(current));
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			return (x25998da3963930e9[])arrayList.ToArray(typeof(x25998da3963930e9));
		}
		catch (Exception)
		{
			return new x25998da3963930e9[0];
		}
	}
}
