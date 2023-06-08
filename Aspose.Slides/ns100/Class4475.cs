using System.IO;
using ns108;
using ns112;
using ns114;
using ns99;

namespace ns100;

internal class Class4475 : Class4474
{
	public override void Save()
	{
		if (!(class4408_0 is Class4410 @class))
		{
			return;
		}
		using Class4449 class8 = new Class4449(stream_0, closeStreamOnDispose: false);
		Class4410 class2 = (Class4410)class4408_0;
		Class4409 class3 = (Class4409)@class.OriginalFont;
		if (!class2.UsedGlyphs.Contains(Class4507.class4507_0))
		{
			class2.UsedGlyphs.Add(Class4507.class4507_0);
		}
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using Class4437 class4 = new Class4437(class4408_0.FontDefinition.FileDefinitions[0].StreamSource, 0L);
			Class4452 shifts = new Class4452();
			byte[] array = class4.method_5(class3.Internals.CustomParams.HeaderSize);
			memoryStream.Write(array, 0, array.Length);
			array = class4.method_5((int)(class3.Internals.NameIndex.IndexEndOffset - class3.Internals.NameIndex.IndexBeginOffset + 1L));
			memoryStream.Write(array, 0, array.Length);
			Class4440 class5 = new Class4440(class4);
			Class4439 class6 = new Class4439();
			class5.method_0(class6);
			Class4453 class7 = new Class4453();
			class7.method_0(shifts, class6);
		}
		byte[] value;
		using (BinaryReader binaryReader = new BinaryReader(class4408_0.FontDefinition.FileDefinitions[0].StreamSource.vmethod_0()))
		{
			value = binaryReader.ReadBytes((int)class4408_0.FontDefinition.FileDefinitions[0].StreamSource.vmethod_0().Length);
		}
		class8.method_5(value);
	}
}
