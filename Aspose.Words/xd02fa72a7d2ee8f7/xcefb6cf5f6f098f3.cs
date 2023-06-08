using System;
using System.Collections;
using System.IO;
using System.Text;
using x13f1efc79617a47b;
using x5f3520a4b31ea90f;
using xb92b7270f78a4e8d;

namespace xd02fa72a7d2ee8f7;

internal class xcefb6cf5f6f098f3
{
	private class x224053faa92915ae : IComparer
	{
		private int x91c86e0de828cc9f(object x08db3aeabb253cb1, object x1e218ceaee1bb583)
		{
			string strA = xaace6eea0124dd3c((string)x08db3aeabb253cb1);
			string strB = xaace6eea0124dd3c((string)x1e218ceaee1bb583);
			return string.CompareOrdinal(strA, strB);
		}

		int IComparer.Compare(object x08db3aeabb253cb1, object x1e218ceaee1bb583)
		{
			//ILSpy generated this explicit interface implementation from .override directive in x91c86e0de828cc9f
			return this.x91c86e0de828cc9f(x08db3aeabb253cb1, x1e218ceaee1bb583);
		}
	}

	private readonly x1e72f71e14224f7d x28def80233aa5135 = new x1e72f71e14224f7d();

	internal byte[] xf35aae0fa4a217a4 => x28def80233aa5135.x7a569e28d68fded6;

	internal xcefb6cf5f6f098f3(xe7be411416cfcd54 root)
	{
		x2106013781dc6d70(root);
		x28def80233aa5135.x20098fa15e62301f();
	}

	private void x2106013781dc6d70(xe7be411416cfcd54 x630baaeb4d769680)
	{
		x917b69030691beda(x630baaeb4d769680.x933ed8cf24f04c67.ToByteArray());
		SortedList sortedList = new SortedList(new x224053faa92915ae());
		SortedList sortedList2 = new SortedList(new x224053faa92915ae());
		foreach (DictionaryEntry item in x630baaeb4d769680)
		{
			string text = item.Key.ToString();
			object value = item.Value;
			if (item.Value is Stream)
			{
				if (text != "_signatures" && text != "\tDRMContent")
				{
					sortedList.Add(text, value);
				}
				continue;
			}
			if (item.Value is xe7be411416cfcd54)
			{
				if (text != "\u0006DataSpaces" && text != "\u0005Bagaaqy23kudbhchAaq5u2chNd")
				{
					sortedList2.Add(text, value);
				}
				continue;
			}
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ljlcblcdlkjdlkaejkheokoeckffbfmfnjdgnikgcjbhkiihfiphdjgimdniciejeiljddcknhjkchalhhhlgholghfmkhmmobdnogknmgboegioegpoafgpdfnpoeeaebla", 1725508422)));
		}
		foreach (DictionaryEntry item2 in sortedList)
		{
			x917b69030691beda((string)item2.Key);
			MemoryStream memoryStream = (MemoryStream)item2.Value;
			x917b69030691beda(memoryStream.GetBuffer(), (int)memoryStream.Length);
		}
		foreach (DictionaryEntry item3 in sortedList2)
		{
			x917b69030691beda((string)item3.Key);
			x2106013781dc6d70((xe7be411416cfcd54)item3.Value);
		}
	}

	private void x917b69030691beda(byte[] x4a3f0a05c02f235f)
	{
		x917b69030691beda(x4a3f0a05c02f235f, x4a3f0a05c02f235f.Length);
	}

	private void x917b69030691beda(byte[] x4a3f0a05c02f235f, int x961016a387451f05)
	{
		x28def80233aa5135.x295cb4a1df7a5add(x4a3f0a05c02f235f, x961016a387451f05);
	}

	private void x917b69030691beda(string xf6987a1745781d6f)
	{
		x917b69030691beda(Encoding.Unicode.GetBytes(xf6987a1745781d6f));
	}

	private static string xaace6eea0124dd3c(string xe4115acdf4fbfccc)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in xe4115acdf4fbfccc)
		{
			if (char.IsLetterOrDigit(c) || c == '_')
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
