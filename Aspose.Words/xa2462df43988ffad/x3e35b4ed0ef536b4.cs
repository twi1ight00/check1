using Aspose.Words;
using Aspose.Words.Settings;
using xf9a9481c3f63a419;

namespace xa2462df43988ffad;

internal class x3e35b4ed0ef536b4
{
	private readonly x9c77c7e782b62883 x800085dd555f7711;

	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x3e35b4ed0ef536b4(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
		x800085dd555f7711 = writer.x082c3925d43afdad("/settings.xml");
	}

	internal void x6210059f049f0d48()
	{
		x800085dd555f7711.x56de5194528bd68b();
		x800085dd555f7711.x2307058321cdb62f("office:settings");
		xc37cd2d767ac82e8();
		xf73fdd455b101c4a();
		x800085dd555f7711.x2dfde153f4ef96d0("office:settings");
		x800085dd555f7711.xa0dfc102c691b11f();
	}

	private void xc37cd2d767ac82e8()
	{
		Document x2c8c6741422a = x9b287b671d592594.x2c8c6741422a1298;
		x800085dd555f7711.x2307058321cdb62f("config:config-item-set");
		x800085dd555f7711.x943f6be3acf634db("config:name", "ooo:view-settings");
		if (x2c8c6741422a.xdade2366eaa6f915.x14fd633e1477f9de)
		{
			x7ea3939ee0585d1e("ShowRedlineChanges", "boolean", "true");
		}
		x800085dd555f7711.x2307058321cdb62f("config:config-item-map-indexed");
		x800085dd555f7711.x943f6be3acf634db("config:name", "Views");
		x800085dd555f7711.x2307058321cdb62f("config:config-item-map-entry");
		x7ea3939ee0585d1e("VisibleLeft", "int", "0");
		x7ea3939ee0585d1e("VisibleRight", "int", "0");
		x7ea3939ee0585d1e("VisibleTop", "int", "0");
		x7ea3939ee0585d1e("VisibleBottom", "int", "0");
		x7ea3939ee0585d1e("ZoomType", "short", xca004f56614e2431.xc8ba948e0d631490((int)x2c8c6741422a.ViewOptions.ZoomType));
		x7ea3939ee0585d1e("ZoomFactor", "short", x2c8c6741422a.ViewOptions.ZoomPercent.ToString());
		x800085dd555f7711.x2dfde153f4ef96d0("config:config-item-map-entry");
		x800085dd555f7711.x2dfde153f4ef96d0("config:config-item-map-indexed");
		x800085dd555f7711.x2dfde153f4ef96d0("config:config-item-set");
	}

	private void xf73fdd455b101c4a()
	{
		CompatibilityOptions xe322902ca0e695f = x9b287b671d592594.x2c8c6741422a1298.xdade2366eaa6f915.xe322902ca0e695f5;
		x800085dd555f7711.x2307058321cdb62f("config:config-item-set");
		x800085dd555f7711.x943f6be3acf634db("config:name", "ooo:configuration-settings");
		x7ea3939ee0585d1e("UseFormerObjectPositioning", "boolean", "false");
		x7ea3939ee0585d1e("UseFormerTextWrapping", "boolean", "false");
		x7ea3939ee0585d1e("PrinterIndependentLayout", "string", "high-resolution");
		x7ea3939ee0585d1e("DoNotJustifyLinesWithManualBreak", "boolean", "false");
		x7ea3939ee0585d1e("IgnoreTabsAndBlanksForLineCalculation", "boolean", "true");
		x7ea3939ee0585d1e("AddExternalLeading", "boolean", xca004f56614e2431.x957baa621044fc39(!xe322902ca0e695f.NoLeading));
		x7ea3939ee0585d1e("PrinterIndependentLayout", "string", "high-resolution");
		x7ea3939ee0585d1e("IgnoreFirstLineIndentInNumbering", "boolean", "false");
		if (x9b287b671d592594.x3939850b09f0d40e)
		{
			x7ea3939ee0585d1e("AddParaSpacingToTableCells", "boolean", "true");
		}
		x7ea3939ee0585d1e("UseFormerLineSpacing", "boolean", xe322902ca0e695f.ApplyBreakingRules ? "true" : "false");
		if (!xe322902ca0e695f.DoNotUseHTMLParagraphAutoSpacing)
		{
			x7ea3939ee0585d1e("AddParaTableSpacing", "boolean", "false");
		}
		x800085dd555f7711.x2dfde153f4ef96d0("config:config-item-set");
	}

	private void x7ea3939ee0585d1e(string xc15bd84e01929885, string x43163d22e8cd5a71, string xbcea506a33cf9111)
	{
		x800085dd555f7711.x2307058321cdb62f("config:config-item");
		x800085dd555f7711.x943f6be3acf634db("config:name", xc15bd84e01929885);
		x800085dd555f7711.x943f6be3acf634db("config:type", x43163d22e8cd5a71);
		x800085dd555f7711.x3d1be38abe5723e3(xbcea506a33cf9111);
		x800085dd555f7711.x2dfde153f4ef96d0("config:config-item");
	}
}
