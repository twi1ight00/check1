using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ns62;

internal class Class2637 : Class2629
{
	internal const int int_2 = 61468;

	private const string string_0 = "Aspose.Slides.PptBinaryFile.resources.";

	internal Guid guid_1;

	private byte[] byte_1;

	private Image image_0;

	public Class2637()
		: base(61468, 0)
	{
	}

	public Class2637(Class2637 srcBlip)
		: base(61468, 0)
	{
		base.Header.Type = srcBlip.Header.Type;
		base.Header.Instance = srcBlip.Header.Instance;
		byte[] array = new byte[srcBlip.BLIPFileData.Length];
		Array.Copy(srcBlip.BLIPFileData, array, array.Length);
		base.BLIPFileData = array;
		base.Header.Length = base.RgbUid.ToByteArray().Length + array.Length;
		base.RgbUid = new Guid(srcBlip.RgbUid.ToByteArray());
		if ((base.Header.Instance & 1) > 0)
		{
			base.Header.Length += 16;
			guid_1 = new Guid(srcBlip.guid_1.ToByteArray());
		}
	}

	public override void vmethod_5(Stream stream)
	{
		stream.Write(base.BLIPFileData, 0, base.BLIPFileData.Length);
	}

	public override byte[] vmethod_6()
	{
		if (byte_1 == null)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Aspose.Slides.PptBinaryFile.resources.NotSupported.emf");
			using MemoryStream memoryStream = new MemoryStream();
			byte[] array = new byte[4096];
			while (true)
			{
				int num = manifestResourceStream.Read(array, 0, array.Length);
				if (num <= 0)
				{
					break;
				}
				memoryStream.Write(array, 0, num);
			}
			byte_1 = memoryStream.ToArray();
		}
		return byte_1;
	}

	public override Image vmethod_7(SizeF size)
	{
		if (image_0 == null)
		{
			using MemoryStream stream = new MemoryStream(vmethod_6());
			image_0 = Image.FromStream(stream);
		}
		return image_0;
	}

	public override int vmethod_2()
	{
		int num = 16 + base.BLIPFileData.Length;
		if ((base.Header.Instance & 1) > 0)
		{
			num += 16;
		}
		return num;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		base.RgbUid = Class2629.smethod_0(reader);
		int num = base.Header.Length - 16;
		if ((base.Header.Instance & 1) > 0)
		{
			guid_1 = Class2629.smethod_0(reader);
			num -= 16;
		}
		base.BLIPFileData = reader.ReadBytes(num);
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(base.RgbUid.ToByteArray());
		if ((base.Header.Instance & 1) > 0)
		{
			writer.Write(guid_1.ToByteArray());
		}
		writer.Write(base.BLIPFileData);
	}
}
