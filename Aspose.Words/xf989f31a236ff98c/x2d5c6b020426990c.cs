using System;
using System.Collections;
using System.IO;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xf989f31a236ff98c;

internal class x2d5c6b020426990c
{
	private class xa22448e9635b227c
	{
		private readonly FileStream xa49cef274042e702;

		private readonly string x8c40c8553a51ec75;

		public FileStream xb8a774e0111d0fbe => xa49cef274042e702;

		public string xd168ac2ed64c4662 => x8c40c8553a51ec75;

		internal xa22448e9635b227c(FileStream stream, string filename)
		{
			xa49cef274042e702 = stream;
			x8c40c8553a51ec75 = filename;
		}
	}

	private readonly ArrayList xa2f6fdd7bc130c33 = new ArrayList();

	private readonly string xf5e0ee752f83f28a;

	internal bool xea795c1b94b2c099 => x0d299f323d241756.x5959bccb67bbf051(xf5e0ee752f83f28a);

	internal x2d5c6b020426990c(x8556eed81191af11 saveInfo)
	{
		xf5e0ee752f83f28a = saveInfo.xf57de0fd37d5e97d.TempFolder;
	}

	internal Stream x6795cf98c786308b()
	{
		Stream stream;
		if (xea795c1b94b2c099)
		{
			string text = Path.Combine(xf5e0ee752f83f28a, $"{Guid.NewGuid()}.tmp");
			stream = new FileStream(text, FileMode.Create, FileAccess.ReadWrite);
			xa2f6fdd7bc130c33.Add(new xa22448e9635b227c((FileStream)stream, text));
		}
		else
		{
			stream = new MemoryStream();
		}
		return stream;
	}

	internal void x618890967a836e8b()
	{
		foreach (xa22448e9635b227c item in xa2f6fdd7bc130c33)
		{
			item.xb8a774e0111d0fbe.Close();
			File.Delete(item.xd168ac2ed64c4662);
		}
	}
}
