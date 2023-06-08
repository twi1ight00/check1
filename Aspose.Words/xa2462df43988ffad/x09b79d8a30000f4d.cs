using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using xfbd1009a0cbb9842;

namespace xa2462df43988ffad;

internal class x09b79d8a30000f4d
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x09b79d8a30000f4d(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal void xd29409f2ba9889e2()
	{
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("office:body");
		xe1410f585439c7d.x2307058321cdb62f("office:text");
		xce9602ec6a2d8817();
		x9b287b671d592594.x05ee8ce4d7312eb5 = x14bf6f47128e4438.x04e4ed301f6f3a72;
	}

	internal VisitorAction x648a8aa88d1bbe19()
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62896619d90ad964)
		{
			return VisitorAction.Continue;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2dfde153f4ef96d0();
		xe1410f585439c7d.x2dfde153f4ef96d0();
		xe1410f585439c7d.xa0dfc102c691b11f();
		return VisitorAction.Continue;
	}

	private void xce9602ec6a2d8817()
	{
		ArrayList arrayList = xd7b978cfa08d43e5();
		if (arrayList.Count == 0)
		{
			return;
		}
		x9c77c7e782b62883 xe1410f585439c7d = x9b287b671d592594.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("office:forms");
		xe1410f585439c7d.x2307058321cdb62f("form:form");
		xe1410f585439c7d.x943f6be3acf634db("form:control-implementation", "ooo:com.sun.star.form.component.Form");
		for (int i = 0; i < arrayList.Count; i++)
		{
			FormField formField = (FormField)arrayList[i];
			if (formField.xdda013621290d582 == xdda013621290d582.xfd2f38e457ba1955)
			{
				xe1410f585439c7d.x2307058321cdb62f("form:checkbox");
				xe1410f585439c7d.x943f6be3acf634db("form:control-implementation", "ooo:com.sun.star.form.component.CheckBox");
				xe1410f585439c7d.x943f6be3acf634db("form:id", $"control{x9b287b671d592594.x970d128a5aa17a0a}");
				x9b287b671d592594.x970d128a5aa17a0a++;
				if (formField.Checked && !x9b287b671d592594.xf57de0fd37d5e97d.IsStrictSchema11)
				{
					xe1410f585439c7d.x943f6be3acf634db("current-state", "checked");
				}
				xe1410f585439c7d.x2dfde153f4ef96d0("form:checkbox");
			}
		}
		xe1410f585439c7d.x2dfde153f4ef96d0("form:form");
		xe1410f585439c7d.x2dfde153f4ef96d0("office:forms");
		x9b287b671d592594.x970d128a5aa17a0a = 0;
	}

	private ArrayList xd7b978cfa08d43e5()
	{
		ArrayList arrayList = new ArrayList();
		foreach (FormField formField in x9b287b671d592594.x2c8c6741422a1298.Range.FormFields)
		{
			if (formField.xdda013621290d582 == xdda013621290d582.xfd2f38e457ba1955)
			{
				arrayList.Add(formField);
			}
		}
		return arrayList;
	}
}
