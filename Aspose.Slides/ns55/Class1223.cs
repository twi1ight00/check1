using System.Collections.Generic;

namespace ns55;

internal abstract class Class1223
{
	private static Dictionary<string, Class1223> dictionary_0;

	public abstract string ContentType { get; }

	public abstract Class1338 TypeAttributeOfSourceRelationship { get; }

	public virtual bool ForceCompression => true;

	static Class1223()
	{
		dictionary_0 = new Dictionary<string, Class1223>();
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.drawingml.chartshapes+xml", new Class1227());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.drawingml.chart+xml", new Class1228());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.drawingml.diagramColors+xml", new Class1230());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.drawingml.diagramData+xml", new Class1231());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.drawingml.diagramLayout+xml", new Class1232());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.drawingml.diagramStyle+xml", new Class1233());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.tableStyles+xml", new Class1235());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.themeOverride+xml", new Class1236());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.theme+xml", new Class1237());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.commentAuthors+xml", new Class1241());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.handoutMaster+xml", new Class1244());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.notesMaster+xml", new Class1245());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.notesSlide+xml", new Class1246());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.presentation.main+xml", new Class1251());
		dictionary_0.Add("application/vnd.ms-powerpoint.presentation.macroEnabled.main+xml", new Class1252());
		dictionary_0.Add("application/vnd.ms-powerpoint.template.macroEnabled.main+xml", new Class1253());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.presProps+xml", new Class1257());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.template.main+xml", new Class1254());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.comments+xml", new Class1242());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.slideLayout+xml", new Class1247());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.slideMaster+xml", new Class1248());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.slide+xml", new Class1249());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.slideshow.main+xml", new Class1255());
		dictionary_0.Add("application/vnd.ms-powerpoint.slideshow.macroEnabled.main+xml", new Class1256());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.tags+xml", new Class1258());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.viewProps+xml", new Class1259());
		dictionary_0.Add("application/vnd.ms-office.activeX", new Class1299());
		dictionary_0.Add("application/vnd.ms-office.activeX+xml", new Class1261());
		dictionary_0.Add("audio/unknown", new Class1302());
		dictionary_0.Add("audio/wav", new Class1303());
		dictionary_0.Add("audio/x-wav", new Class1304());
		dictionary_0.Add("application/vnd.openxmlformats-package.core-properties+xml", new Class1263());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.custom-properties+xml", new Class1264());
		dictionary_0.Add("application/vnd.openxmlformats-package.digital-signature-origin", new Class1336());
		dictionary_0.Add("application/vnd.ms-excel", new Class1323());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new Class1328());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.extended-properties+xml", new Class1265());
		dictionary_0.Add("application/x-fontdata", new Class1334());
		dictionary_0.Add("image/bmp", new Class1306());
		dictionary_0.Add("image/x-emf", new Class1307());
		dictionary_0.Add("image/gif", new Class1308());
		dictionary_0.Add("image/jpeg", new Class1309());
		dictionary_0.Add("image/pict", new Class1310());
		dictionary_0.Add("image/png", new Class1311());
		dictionary_0.Add("image/tiff", new Class1312());
		dictionary_0.Add("image/unknown", new Class1313());
		dictionary_0.Add("image/x-wmf", new Class1314());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.oleObject", new Class1324());
		dictionary_0.Add("application/vnd.ms-powerpoint.presentation.macroEnabled.12", new Class1329());
		dictionary_0.Add("application/vnd.ms-powerpoint", new Class1325());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.presentation", new Class1330());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.presentationml.slide", new Class1331());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.package", new Class1332());
		dictionary_0.Add("application/vnd.ms-office.vbaProject", new Class1335());
		dictionary_0.Add("video/avi", new Class1318());
		dictionary_0.Add("video/mpeg", new Class1319());
		dictionary_0.Add("video/unknown", new Class1320());
		dictionary_0.Add("video/x-ms-wmv", new Class1321());
		dictionary_0.Add("application/msword", new Class1326());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.wordprocessingml.document", new Class1333());
		dictionary_0.Add("application/vnd.ms-office.drawingml.diagramDrawing+xml", new Class1293());
		dictionary_0.Add("application/vnd.openxmlformats-package.relationships+xml", new Class1296());
		dictionary_0.Add("application/xml", new Class1238());
		dictionary_0.Add("unknown", new Class1337());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.vmlDrawing", new Class1294());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.calcChain+xml", new Class1267());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.chartsheet+xml", new Class1268());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.connections+xml", new Class1269());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.dialogsheet+xml", new Class1290());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.drawing+xml", new Class1292());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.externalLink+xml", new Class1289());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.sheetMetadata+xml", new Class1288());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.pivotCacheDefinition+xml", new Class1286());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.pivotCacheRecords+xml", new Class1285());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.pivotTable+xml", new Class1287());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.queryTable+xml", new Class1284());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml", new Class1283());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.revisionHeaders+xml", new Class1282());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.revisionLog+xml", new Class1281());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.userNames+xml", new Class1280());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.tableSingleCells+xml", new Class1279());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml", new Class1278());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.table+xml", new Class1277());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.volatileDependencies+xml", new Class1276());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml", new Class1274());
		dictionary_0.Add("application/vnd.ms-excel.sheet.macroEnabled.main+xml", new Class1273());
		dictionary_0.Add("application/vnd.ms-excel.template.macroEnabled.main+xml", new Class1271());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml", new Class1272());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.comments+xml", new Class1291());
		dictionary_0.Add("application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml", new Class1275());
	}

	public override string ToString()
	{
		return ContentType;
	}

	public static Class1223 smethod_0(string type)
	{
		if (!dictionary_0.TryGetValue(type, out var value))
		{
			return new Class1297(type, null);
		}
		return value;
	}
}
