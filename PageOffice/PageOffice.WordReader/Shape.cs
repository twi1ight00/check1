using System;
using System.IO;
using System.Xml;

namespace PageOffice.WordReader;

public class Shape
{
	private XmlNode _0002;

	private int _0003;

	public int Index => _0003;

	internal Shape(XmlNode _0002)
	{
		_0003 = 1;
		this._0002 = _0002;
		_0003 = int.Parse(this._0002.Attributes[_0005_2000._0002(1402789197)].InnerText);
	}

	public void SaveAsJPG(string SaveAsFileName)
	{
		if (SaveAsFileName == string.Empty)
		{
			throw new Exception(_0005_2000._0002(1402789049));
		}
		byte[] array = Convert.FromBase64String(_0002.InnerText);
		FileStream fileStream = File.Open(SaveAsFileName, FileMode.Create, FileAccess.Write);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
	}
}
