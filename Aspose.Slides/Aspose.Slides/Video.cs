using ns223;
using ns24;

namespace Aspose.Slides;

public class Video : IVideo
{
	private Presentation presentation_0;

	private Class366 class366_0 = new Class366();

	private uint uint_0;

	private byte[] byte_0;

	internal Class366 PPTXUnsupportedProps => class366_0;

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

	internal Video(byte[] data, string contentType, string extension, Presentation presentation)
	{
		presentation_0 = presentation;
		byte_0 = data;
		PPTXUnsupportedProps.ContentType = contentType;
		PPTXUnsupportedProps.Extension = extension;
	}
}
