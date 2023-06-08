using ns22;
using ns223;
using ns24;

namespace Aspose.Slides;

public class Audio : IAudio
{
	private Presentation presentation_0;

	private uint uint_0;

	private byte[] byte_0;

	private Class293 class293_0 = new Class293();

	private Class261 class261_0 = new Class261();

	internal Class293 PPTXUnsupportedProps => class293_0;

	internal Class261 PPTUnsupportedProps => class261_0;

	internal uint CRC
	{
		get
		{
			if (uint_0 == 0)
			{
				uint_0 = Class5979.smethod_2(data);
			}
			return uint_0;
		}
	}

	internal byte[] data => byte_0;

	internal IPresentation Presentation => presentation_0;

	public string ContentType => PPTXUnsupportedProps.ContentType;

	public byte[] BinaryData => (byte[])byte_0.Clone();

	internal Audio(byte[] data, string contentType, string extension, Presentation presentation)
	{
		presentation_0 = presentation;
		byte_0 = data;
		PPTXUnsupportedProps.ContentType = contentType;
		PPTXUnsupportedProps.Extension = extension;
	}
}
