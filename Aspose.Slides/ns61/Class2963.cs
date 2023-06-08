using System;
using System.IO;

namespace ns61;

internal sealed class Class2963
{
	public static readonly Guid guid_0 = new Guid(new byte[16]
	{
		224, 201, 234, 121, 186, 249, 17, 206, 140, 130,
		0, 170, 0, 75, 169, 11
	});

	public static readonly Guid guid_1 = new Guid(new byte[16]
	{
		3, 3, 0, 0, 0, 0, 0, 0, 192, 0,
		0, 0, 0, 0, 0, 70
	});

	public static readonly Guid guid_2 = new Guid(new byte[16]
	{
		9, 3, 0, 0, 0, 0, 0, 0, 192, 0,
		0, 0, 0, 0, 0, 70
	});

	public static readonly Guid guid_3 = new Guid(new byte[16]
	{
		5, 3, 0, 0, 0, 0, 0, 0, 192, 0,
		0, 0, 0, 0, 0, 70
	});

	public static readonly Guid guid_4 = new Guid(new byte[16]
	{
		4, 3, 0, 0, 0, 0, 0, 0, 192, 0,
		0, 0, 0, 0, 0, 70
	});

	public static Class2958 smethod_0(Guid monikerClsid)
	{
		if (!(monikerClsid == guid_1))
		{
			throw new NotImplementedException("Only FileMoniker is supported.");
		}
		return new Class2959();
	}

	public static Class2958 smethod_1(Guid monikerClsid, BinaryReader reader)
	{
		Class2958 @class = smethod_0(monikerClsid);
		@class.Read(reader);
		return @class;
	}
}
