using System.ComponentModel.Design;
using System.Text;
using System.Web.UI.Design;

namespace PageOffice.Design;

internal sealed class PageOfficeCtrlDesigner : ControlDesigner
{
	private DesignerActionListCollection _0002;

	public override DesignerActionListCollection ActionLists
	{
		get
		{
			if (_0002 == null)
			{
				_0002 = new DesignerActionListCollection();
				_0002.Add(new PageOfficeCtrlActionList(this));
			}
			return _0002;
		}
	}

	public override bool AllowResize => false;

	public override string GetDesignTimeHtml()
	{
		if (_0002 != null)
		{
			_ = _0002[0];
		}
		StringBuilder stringBuilder = new StringBuilder(_0005_2000._0002(1402765592));
		string text = _0005_2000._0002(1402765512);
		PageOfficeCtrl pageOfficeCtrl = (PageOfficeCtrl)base.Component;
		if (pageOfficeCtrl != null)
		{
			if (pageOfficeCtrl.Caption != string.Empty)
			{
				text = text + _0005_2000._0002(1402765371) + pageOfficeCtrl.Caption;
			}
			if (pageOfficeCtrl.Titlebar)
			{
				stringBuilder.Append(_0005_2000._0002(1402766689));
				stringBuilder.Append(_0005_2000._0002(1402765347) + text + _0005_2000._0002(1402766241));
				stringBuilder.Append(_0005_2000._0002(1402766547));
			}
			if (pageOfficeCtrl.Menubar)
			{
				stringBuilder.Append(_0005_2000._0002(1402766689));
				stringBuilder.Append(_0005_2000._0002(1402766255));
				stringBuilder.Append(_0005_2000._0002(1402766547));
			}
			if (pageOfficeCtrl.CustomToolbar)
			{
				stringBuilder.Append(_0005_2000._0002(1402766689));
				stringBuilder.Append(_0005_2000._0002(1402766010));
				stringBuilder.Append(_0005_2000._0002(1402766547));
			}
			if (pageOfficeCtrl.OfficeToolbars)
			{
				stringBuilder.Append(_0005_2000._0002(1402766689));
				stringBuilder.Append(_0005_2000._0002(1402765903));
				stringBuilder.Append(_0005_2000._0002(1402766547));
			}
			stringBuilder.Append(_0005_2000._0002(1402766689));
			stringBuilder.Append(_0005_2000._0002(1402768710));
			stringBuilder.Append(_0005_2000._0002(1402766547));
		}
		else
		{
			stringBuilder.Append(_0005_2000._0002(1402766689));
			stringBuilder.Append(_0005_2000._0002(1402769393));
			stringBuilder.Append(_0005_2000._0002(1402766547));
		}
		stringBuilder.Append(_0005_2000._0002(1402766529));
		return stringBuilder.ToString();
	}
}
