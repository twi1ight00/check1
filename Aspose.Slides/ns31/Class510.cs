using System.IO;
using Aspose.Slides.Import;
using ns277;

namespace ns31;

internal class Class510 : Interface322
{
	private readonly IHtmlExternalResolver ihtmlExternalResolver_0;

	public Class510(IHtmlExternalResolver resolver)
	{
		ihtmlExternalResolver_0 = resolver;
	}

	public Class6814 imethod_0(object sender, EventArgs13 e)
	{
		if (ihtmlExternalResolver_0 == null)
		{
			return new Class6814(null);
		}
		Stream entity = ihtmlExternalResolver_0.GetEntity(e.Uri);
		using MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[1024];
		int count;
		while (0 < (count = entity.Read(array, 0, array.Length)))
		{
			memoryStream.Write(array, 0, count);
		}
		return new Class6814(memoryStream.ToArray());
	}
}
