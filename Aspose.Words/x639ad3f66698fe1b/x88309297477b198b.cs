using System.Text;
using Aspose.Words.Settings;
using x556d8f9846e43329;

namespace x639ad3f66698fe1b;

internal class x88309297477b198b
{
	private x88309297477b198b()
	{
	}

	internal static void xf69e3cf19f0625a0(MailMergeSettings x9fc6d11f73f7c086, xbfd162a6d47f59a4 xd07ce4b74c5774a7)
	{
		if (x9fc6d11f73f7c086.MainDocumentType != 0)
		{
			xd07ce4b74c5774a7.xee60bff2900a72f2("\\*\\mailmerge");
			x55c9f6e3e64cd786("\\*\\mmconnectstr", x9fc6d11f73f7c086.ConnectString, xd07ce4b74c5774a7);
			x55c9f6e3e64cd786("\\mmdatasource", x9fc6d11f73f7c086.DataSource, xd07ce4b74c5774a7);
			x55c9f6e3e64cd786("\\mmquery", x9fc6d11f73f7c086.Query, xd07ce4b74c5774a7);
			x55c9f6e3e64cd786("\\mmheadersource", x9fc6d11f73f7c086.HeaderSource, xd07ce4b74c5774a7);
			x55c9f6e3e64cd786("\\mmaddfieldname", x9fc6d11f73f7c086.AddressFieldName, xd07ce4b74c5774a7);
			x55c9f6e3e64cd786("\\mmmailsubject", x9fc6d11f73f7c086.MailSubject, xd07ce4b74c5774a7);
			xd07ce4b74c5774a7.x4d14ee33f46b5913(xa0d3611565b2a1f2.x7f4b7a05bb406cd0(x9fc6d11f73f7c086.MainDocumentType));
			if (x9fc6d11f73f7c086.DataType != MailMergeDataType.None)
			{
				xd07ce4b74c5774a7.x4d14ee33f46b5913(xa0d3611565b2a1f2.xe2ca4248b7e5af14(x9fc6d11f73f7c086.DataType));
			}
			xd07ce4b74c5774a7.x4d14ee33f46b5913(xa0d3611565b2a1f2.xf80f9be050516dd4(x9fc6d11f73f7c086.Destination));
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmreccur", x9fc6d11f73f7c086.ActiveRecord);
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmerrors", (int)x9fc6d11f73f7c086.CheckErrors);
			xd07ce4b74c5774a7.xb8aea59edd4060ce("\\mmblanklinks", x9fc6d11f73f7c086.DoNotSupressBlankLines);
			xd07ce4b74c5774a7.xb8aea59edd4060ce("\\mmlinktoquery", x9fc6d11f73f7c086.LinkToQuery);
			xd07ce4b74c5774a7.xb8aea59edd4060ce("\\mmattach", x9fc6d11f73f7c086.MailAsAttachment);
			xd07ce4b74c5774a7.xb8aea59edd4060ce("\\mmshowdata", x9fc6d11f73f7c086.ViewMergedData);
			if (x9fc6d11f73f7c086.Odso != null)
			{
				xc7f45f1cf1a88832(x9fc6d11f73f7c086.Odso, xd07ce4b74c5774a7);
			}
			xd07ce4b74c5774a7.xc8a13a52db0580ae();
		}
	}

	private static void xc7f45f1cf1a88832(Odso x9a57568ae1401104, xbfd162a6d47f59a4 xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.xee60bff2900a72f2("\\*\\mmodso");
		x55c9f6e3e64cd786("\\*\\mmodsoudl", x9a57568ae1401104.UdlConnectString, xd07ce4b74c5774a7);
		x55c9f6e3e64cd786("\\mmodsotable", x9a57568ae1401104.TableName, xd07ce4b74c5774a7);
		x55c9f6e3e64cd786("\\mmodsosrc", x9a57568ae1401104.DataSource, xd07ce4b74c5774a7);
		x029be9ce86c864d3(x9a57568ae1401104.FieldMapDatas, xd07ce4b74c5774a7);
		xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmodsocoldelim", x9a57568ae1401104.ColumnDelimiter);
		xd07ce4b74c5774a7.x5fdd0595d40cfe6d("\\mmodsofhdr", x9a57568ae1401104.FirstRowContainsColumnNames);
		xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmjdsotype", (int)x9a57568ae1401104.DataSourceType);
		x854db80dc54b9623(x9a57568ae1401104.RecipientDatas, xd07ce4b74c5774a7);
		xd07ce4b74c5774a7.xc8a13a52db0580ae();
	}

	private static void x854db80dc54b9623(OdsoRecipientDataCollection x4fa2af11f376db8e, xbfd162a6d47f59a4 xd07ce4b74c5774a7)
	{
		foreach (OdsoRecipientData item in x4fa2af11f376db8e)
		{
			xd07ce4b74c5774a7.xee60bff2900a72f2("\\*\\mmodsorecipdata");
			xd07ce4b74c5774a7.x5fdd0595d40cfe6d("\\mmodsoactive", item.Active);
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmodsohash", item.Hash, 0);
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmodsocolumn", item.Column, 0);
			byte[] uniqueTag = item.UniqueTag;
			if (uniqueTag != null)
			{
				xd07ce4b74c5774a7.xf55384516c165731("\\mmodsouniquetag", Encoding.Unicode.GetString(uniqueTag));
			}
			xd07ce4b74c5774a7.xc8a13a52db0580ae();
		}
	}

	private static void x029be9ce86c864d3(OdsoFieldMapDataCollection x5b96acea411938d0, xbfd162a6d47f59a4 xd07ce4b74c5774a7)
	{
		foreach (OdsoFieldMapData item in x5b96acea411938d0)
		{
			xd07ce4b74c5774a7.xee60bff2900a72f2("\\*\\mmodsofldmpdata");
			xd07ce4b74c5774a7.xf55384516c165731("\\mmodsoname", item.Name);
			xd07ce4b74c5774a7.xf55384516c165731("\\mmodsomappedname", item.MappedName);
			xd07ce4b74c5774a7.x5fdd0595d40cfe6d("\\mmodsodynaddr", item.x3fe67f230278a6df);
			xd07ce4b74c5774a7.x4d14ee33f46b5913(xa0d3611565b2a1f2.x2db1376f2c5d1640(item.Type));
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmodsofmcolumn", item.Column);
			xd07ce4b74c5774a7.x4d14ee33f46b5913("\\mmodsolid", (int)item.x448900fcb384c333);
			xd07ce4b74c5774a7.xc8a13a52db0580ae();
		}
	}

	private static void x55c9f6e3e64cd786(string x1c4259f170c30c43, string xbcea506a33cf9111, xbfd162a6d47f59a4 xd07ce4b74c5774a7)
	{
		if (xbcea506a33cf9111 != string.Empty)
		{
			xd07ce4b74c5774a7.xf55384516c165731(x1c4259f170c30c43, xbcea506a33cf9111);
		}
	}
}
