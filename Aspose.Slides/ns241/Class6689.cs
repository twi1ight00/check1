using System.Collections;
using System.IO;
using ns220;
using ns271;

namespace ns241;

internal class Class6689 : Class6688
{
	private readonly string string_1;

	internal Class6689(string resourcesFolderPath, string resourcesFolderAlias)
		: base(resourcesFolderAlias)
	{
		string_1 = resourcesFolderPath;
	}

	internal override void vmethod_1()
	{
		if (base.FontSubsets.Count <= 0 && base.ImageResources.Count <= 0)
		{
			return;
		}
		if (!Directory.Exists(string_1))
		{
			Directory.CreateDirectory(string_1);
		}
		foreach (DictionaryEntry fontSubset in base.FontSubsets)
		{
			string path = Path.Combine(string_1, Path.GetFileName((string)fontSubset.Key));
			Class6733 @class = (Class6733)fontSubset.Value;
			using FileStream dstStream = new FileStream(path, FileMode.Create);
			@class.method_2(dstStream, isMakeValidTtf: true, isFullEmbedding: false);
		}
		foreach (Class6696 value in base.ImageResources.Values)
		{
			string path2 = Path.Combine(string_1, Path.GetFileName(value.Uri));
			using FileStream fileStream = new FileStream(path2, FileMode.Create);
			fileStream.Write(value.ImageBytes, 0, value.ImageBytes.Length);
		}
	}
}
