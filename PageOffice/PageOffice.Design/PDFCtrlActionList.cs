using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace PageOffice.Design;

internal class PDFCtrlActionList : DesignerActionList
{
	private PDFCtrl _control;

	private PDFCtrlDesigner _parentDesigner;

	private DesignerActionUIService _designerActionUISvc;

	public bool ShowTitlebar
	{
		get
		{
			return _control.Titlebar;
		}
		set
		{
			SetProperty(_0005_2000._0002(1402767043), value);
		}
	}

	public bool ShowMenubar
	{
		get
		{
			return _control.Menubar;
		}
		set
		{
			SetProperty(_0005_2000._0002(1402766896), value);
		}
	}

	public bool ShowCustomToolbar
	{
		get
		{
			return _control.CustomToolbar;
		}
		set
		{
			SetProperty(_0005_2000._0002(1402766910), value);
		}
	}

	public string Caption
	{
		get
		{
			return _control.Caption;
		}
		set
		{
			SetProperty(_0005_2000._0002(1402766857), value);
		}
	}

	public PDFCtrlActionList(PDFCtrlDesigner designer)
		: base(designer.Component)
	{
		_parentDesigner = designer;
		_control = (PDFCtrl)_parentDesigner.Component;
		_designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
	}

	private void SelectTheme()
	{
		_0005 obj = new _0005();
		obj._0002(_0005_2000._0002(1402766375));
		obj._0002((int)_control.Theme);
		if (obj.ShowDialog() == DialogResult.OK)
		{
			SetProperty(_0005_2000._0002(1402766967), obj._0002());
		}
	}

	private void SetProperty(string name, object value)
	{
		PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_control)[name];
		propertyDescriptor.SetValue(_control, value);
	}

	private object GetProperty(string name)
	{
		PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_control)[name];
		return propertyDescriptor.GetValue(_control);
	}

	private void SetStyle(int index)
	{
	}

	private void RefreshAll()
	{
		_designerActionUISvc.Refresh(_control);
		_parentDesigner.UpdateDesignTimeHtml();
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		designerActionItemCollection.Add(new DesignerActionMethodItem(this, _0005_2000._0002(1402766947), _0005_2000._0002(1402767204), _0005_2000._0002(1402766933)));
		designerActionItemCollection.Add(new DesignerActionPropertyItem(_0005_2000._0002(1402766912), _0005_2000._0002(1402765749), _0005_2000._0002(1402765732)));
		designerActionItemCollection.Add(new DesignerActionPropertyItem(_0005_2000._0002(1402765712), _0005_2000._0002(1402765698), _0005_2000._0002(1402765732)));
		designerActionItemCollection.Add(new DesignerActionPropertyItem(_0005_2000._0002(1402765813), _0005_2000._0002(1402765805), _0005_2000._0002(1402765732)));
		return designerActionItemCollection;
	}
}
