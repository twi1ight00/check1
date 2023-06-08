using System.Collections;
using System.IO;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;
using xaf73fad8cede26de;

namespace xe8a881d5eff3c473;

internal class x5e2e30bcd1453aea : x22a2c6bbecd8ed7a
{
	private readonly string xeb511bdbea3830d6;

	internal x5e2e30bcd1453aea(string resourcesFolderPath, string resourcesFolderAlias, x54b98d0096d7251a warningCallback)
		: base(resourcesFolderAlias, warningCallback)
	{
		xeb511bdbea3830d6 = resourcesFolderPath;
	}

	internal override void xa04e23b676ea0cc9()
	{
		if (base.x39ca55b691f96321.Count <= 0 && base.xb3bbeebb44588c3a.Count <= 0)
		{
			return;
		}
		if (!Directory.Exists(xeb511bdbea3830d6))
		{
			Directory.CreateDirectory(xeb511bdbea3830d6);
		}
		foreach (DictionaryEntry item in base.x39ca55b691f96321)
		{
			string path = Path.Combine(xeb511bdbea3830d6, Path.GetFileName((string)item.Key));
			xcd986872cf3bcf68 xcd986872cf3bcf = (xcd986872cf3bcf68)item.Value;
			using FileStream dstStream = new FileStream(path, FileMode.Create);
			xcd986872cf3bcf.WriteToStream(dstStream);
		}
		foreach (xfc4b33756f599219 value in base.xb3bbeebb44588c3a.Values)
		{
			string path2 = Path.Combine(xeb511bdbea3830d6, Path.GetFileName(value.xb405a444ca77e2d4));
			using FileStream fileStream = new FileStream(path2, FileMode.Create);
			fileStream.Write(value.xcc18177a965e0313, 0, value.xcc18177a965e0313.Length);
		}
	}
}
