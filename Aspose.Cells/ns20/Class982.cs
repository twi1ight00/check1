using System;
using Aspose.Cells;
using ns2;
using ns25;
using ns43;

namespace ns20;

internal class Class982
{
	internal Class521 class521_0;

	internal Class978 class978_0;

	internal string string_0;

	public Class982(Workbook workbook_0)
	{
		class521_0 = new Class521(workbook_0);
		if (workbook_0.SaveOptions == null)
		{
			return;
		}
		SaveOptions saveOptions = workbook_0.SaveOptions;
		if (saveOptions.CachedFileFolder != null)
		{
			string_0 = saveOptions.CachedFileFolder;
			char c = string_0[string_0.Length - 1];
			if (c != '/' && c != '\\')
			{
				string_0 += '/';
			}
			string_0 = string_0 + "Aspose.Cells" + Guid.NewGuid().ToString();
		}
		if (saveOptions is XlsSaveOptions)
		{
			XlsSaveOptions xlsSaveOptions = (XlsSaveOptions)workbook_0.SaveOptions;
			if (xlsSaveOptions.LightCellsDataProvider != null)
			{
				class978_0 = new Class980(this, xlsSaveOptions.LightCellsDataProvider);
			}
		}
	}
}
