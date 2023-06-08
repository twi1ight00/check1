using System.Collections;
using System.Collections.Generic;
using System.IO;
using ns276;
using ns60;

namespace ns63;

internal abstract class Class2773 : Class2623
{
	private byte[] byte_0;

	private List<Class6751> list_0;

	public byte[] Data
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
			list_0 = null;
		}
	}

	public List<Class6751> ZipPreview
	{
		get
		{
			if (list_0 == null && byte_0 != null)
			{
				list_0 = new List<Class6751>();
				MemoryStream zipStream = new MemoryStream(byte_0);
				Class6752 @class = Class6752.Read(zipStream);
				foreach (Class6751 item in (IEnumerable)@class)
				{
					if (!item.IsDirectory)
					{
						list_0.Add(item);
					}
				}
			}
			return list_0;
		}
	}

	internal Class2773(ushort sidn)
	{
		base.Header.Type = sidn;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadBytes(base.Header.Length);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		if (byte_0 != null)
		{
			writer.Write(byte_0);
		}
	}

	public override int vmethod_2()
	{
		if (byte_0 == null)
		{
			return 0;
		}
		return byte_0.Length;
	}
}
