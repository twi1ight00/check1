using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using PageOffice.ExcelReader;
using PageOffice.ExcelWriter;

internal sealed class _0002
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 30)]
	private struct _0002
	{
	}

	internal static _0002 _0002/* Not supported: data(56 00 65 00 72 00 73 00 69 00 6F 00 6E 00 3A 00 20 00 42 00 75 00 69 00 6C 00 64 00 20 00) */;

	internal static int _0003/* Not supported: data(A1 20 80 1E) */;

	internal static _0002 _0005/* Not supported: data(56 00 65 00 72 00 73 00 69 00 6F 00 6E 00 3A 00 20 00 42 00 75 00 69 00 6C 00 64 00 20 00) */;

	internal static int _0008/* Not supported: data(A1 20 80 1E) */;

	internal static _0002 _0006/* Not supported: data(56 00 65 00 72 00 73 00 69 00 6F 00 6E 00 3A 00 20 00 42 00 75 00 69 00 6C 00 64 00 20 00) */;

	internal static int _000E/* Not supported: data(A1 20 80 1E) */;

	internal static _0002 _000F/* Not supported: data(56 00 65 00 72 00 73 00 69 00 6F 00 6E 00 3A 00 20 00 42 00 75 00 69 00 6C 00 64 00 20 00) */;

	internal static int _0002_2000/* Not supported: data(A1 20 80 1E) */;

	internal static _0002 _0003_2000/* Not supported: data(56 00 65 00 72 00 73 00 69 00 6F 00 6E 00 3A 00 20 00 42 00 75 00 69 00 6C 00 64 00 20 00) */;

	internal static int _0005_2000/* Not supported: data(A1 20 80 1E) */;
}
internal sealed class _0003 : ITypeDescriptorContext, IServiceProvider, IWindowsFormsEditorService
{
	private ComponentDesigner m__0002;

	private IComponentChangeService m__0003;

	private PropertyDescriptor _0005;

	internal _0003(ComponentDesigner _0002)
	{
		this.m__0002 = _0002;
	}

	internal _0003(ComponentDesigner _0002, PropertyDescriptor _0003)
	{
		this.m__0002 = _0002;
		_0005 = _0003;
		if (_0003 == null)
		{
			_0003 = TypeDescriptor.GetDefaultProperty(_0002.Component);
			if (_0003 != null && typeof(ICollection).IsAssignableFrom(_0003.PropertyType))
			{
				_0005 = _0003;
			}
		}
	}

	internal _0003(ComponentDesigner _0002, PropertyDescriptor _0003, string _0005)
		: this(_0002, _0003)
	{
		this.m__0002.Verbs.Add(new DesignerVerb(_0005, this._0002));
	}

	public static object _0002(ComponentDesigner _0002, object _0003, string _0005)
	{
		PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(_0003)[_0005];
		_0003 obj = new _0003(_0002, propertyDescriptor);
		UITypeEditor uITypeEditor = propertyDescriptor.GetEditor(typeof(UITypeEditor)) as UITypeEditor;
		object value = propertyDescriptor.GetValue(_0003);
		object obj2 = uITypeEditor.EditValue(obj, obj, value);
		if (obj2 != value)
		{
			try
			{
				propertyDescriptor.SetValue(_0003, obj2);
			}
			catch (CheckoutException)
			{
			}
		}
		return obj2;
	}

	private IComponentChangeService _0002()
	{
		if (m__0003 == null)
		{
			m__0003 = (IComponentChangeService)((IServiceProvider)this).GetService(typeof(IComponentChangeService));
		}
		return m__0003;
	}

	private IContainer _0003_2005_2000_2001_2006_0002()
	{
		if (this.m__0002.Component.Site != null)
		{
			return this.m__0002.Component.Site.Container;
		}
		return null;
	}

	IContainer ITypeDescriptorContext.get_Container()
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		return this._0003_2005_2000_2001_2006_0002();
	}

	private void _0003_2005_2000_2001_2006_0002()
	{
		_0002().OnComponentChanged(this.m__0002.Component, _0005, null, null);
	}

	void ITypeDescriptorContext.OnComponentChanged()
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		this._0003_2005_2000_2001_2006_0002();
	}

	private bool _0003_2005_2000_2001_2006_0002()
	{
		try
		{
			_0002().OnComponentChanging(this.m__0002.Component, _0005);
		}
		catch (CheckoutException ex)
		{
			if (ex == CheckoutException.Canceled)
			{
				return false;
			}
			throw;
		}
		return true;
	}

	bool ITypeDescriptorContext.OnComponentChanging()
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		return this._0003_2005_2000_2001_2006_0002();
	}

	private object _0003_2005_2000_2001_2006_0002()
	{
		return this.m__0002.Component;
	}

	object ITypeDescriptorContext.get_Instance()
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		return this._0003_2005_2000_2001_2006_0002();
	}

	private PropertyDescriptor _0003_2005_2000_2001_2006_0002()
	{
		return _0005;
	}

	PropertyDescriptor ITypeDescriptorContext.get_PropertyDescriptor()
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		return this._0003_2005_2000_2001_2006_0002();
	}

	private object _0003_2005_2000_2001_2006_0002(Type _0002)
	{
		if (_0002 == typeof(ITypeDescriptorContext) || _0002 == typeof(IWindowsFormsEditorService))
		{
			return this;
		}
		if (this.m__0002.Component.Site != null)
		{
			return this.m__0002.Component.Site.GetService(_0002);
		}
		return null;
	}

	object IServiceProvider.GetService(Type _0002)
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		return this._0003_2005_2000_2001_2006_0002(_0002);
	}

	private void _0003_2005_2000_2001_2006_0003()
	{
	}

	void IWindowsFormsEditorService.CloseDropDown()
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		this._0003_2005_2000_2001_2006_0003();
	}

	private void _0003_2005_2000_2001_2006_0002(Control _0002)
	{
	}

	void IWindowsFormsEditorService.DropDownControl(Control _0002)
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		this._0003_2005_2000_2001_2006_0002(_0002);
	}

	private DialogResult _0003_2005_2000_2001_2006_0002(Form _0002)
	{
		return ((IUIService)((IServiceProvider)this).GetService(typeof(IUIService)))?.ShowDialog(_0002) ?? _0002.ShowDialog(this.m__0002.Component as IWin32Window);
	}

	DialogResult IWindowsFormsEditorService.ShowDialog(Form _0002)
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		return this._0003_2005_2000_2001_2006_0002(_0002);
	}

	private void _0002(object _0002, EventArgs _0003)
	{
		object value = _0005.GetValue(this.m__0002.Component);
		if (value != null && TypeDescriptor.GetEditor(value, typeof(UITypeEditor)) is CollectionEditor collectionEditor)
		{
			collectionEditor.EditValue(this, this, value);
		}
	}
}
internal sealed class _0005 : Form
{
	private string m__0002;

	private IContainer m__0003;

	private Label m__0005;

	private Label _0008;

	private Button _0006;

	private Button _000E;

	private PictureBox _000F;

	private ListBox _0002_2000;

	private Label _0003_2000;

	public _0005()
	{
		_0002();
		this.m__0002 = string.Empty;
		_0002_2000.SelectedIndex = -1;
	}

	public int _0002()
	{
		return _0002_2000.SelectedIndex;
	}

	public void _0002(int _0002)
	{
		_0002_2000.SelectedIndex = _0002;
	}

	public void _0002(string _0002)
	{
		this.m__0002 = _0002;
	}

	private void _0002(object _0002, EventArgs _0003)
	{
		if (this.m__0002 == _0005_2000._0002(1402766384))
		{
			Image image = _0002_2000.SelectedIndex switch
			{
				0 => global::_0002_2000._0005(), 
				1 => global::_0002_2000._0002(), 
				2 => global::_0002_2000._0003(), 
				_ => global::_0002_2000._0002(), 
			};
			_000F.Image = image;
		}
		else if (this.m__0002 == _0005_2000._0002(1402766375))
		{
			Image image = _0002_2000.SelectedIndex switch
			{
				0 => global::_0002_2000._000E(), 
				1 => global::_0002_2000._0008(), 
				2 => global::_0002_2000._0006(), 
				_ => global::_0002_2000._0008(), 
			};
			_000F.Image = image;
		}
	}

	private void _0003(object _0002, EventArgs _0003)
	{
	}

	protected override void Dispose(bool _0002)
	{
		if (_0002 && this.m__0003 != null)
		{
			this.m__0003.Dispose();
		}
		base.Dispose(_0002);
	}

	private void _0002()
	{
		m__0005 = new Label();
		_0008 = new Label();
		_0006 = new Button();
		_000E = new Button();
		_000F = new PictureBox();
		_0002_2000 = new ListBox();
		_0003_2000 = new Label();
		((ISupportInitialize)_000F).BeginInit();
		SuspendLayout();
		m__0005.Location = new Point(8, 424);
		m__0005.Name = _0005_2000._0002(1402766357);
		m__0005.Size = new Size(372, 35);
		m__0005.TabIndex = 14;
		m__0005.Text = _0005_2000._0002(1402766338);
		_0008.AutoSize = true;
		_0008.Location = new Point(165, 4);
		_0008.Name = _0005_2000._0002(1402766431);
		_0008.Size = new Size(41, 12);
		_0008.TabIndex = 13;
		_0008.Text = _0005_2000._0002(1402766410);
		_0006.DialogResult = DialogResult.Cancel;
		_0006.Location = new Point(663, 432);
		_0006.Name = _0005_2000._0002(1402767289);
		_0006.Size = new Size(75, 21);
		_0006.TabIndex = 12;
		_0006.Text = _0005_2000._0002(1402767273);
		_0006.UseVisualStyleBackColor = true;
		_000E.DialogResult = DialogResult.OK;
		_000E.Location = new Point(582, 432);
		_000E.Name = _0005_2000._0002(1402767258);
		_000E.Size = new Size(75, 21);
		_000E.TabIndex = 11;
		_000E.Text = _0005_2000._0002(1402767238);
		_000E.UseVisualStyleBackColor = true;
		_000F.BackColor = SystemColors.Window;
		_000F.BorderStyle = BorderStyle.FixedSingle;
		_000F.Location = new Point(165, 19);
		_000F.Name = _0005_2000._0002(1402767355);
		_000F.Size = new Size(600, 400);
		_000F.TabIndex = 10;
		_000F.TabStop = false;
		_0002_2000.BorderStyle = BorderStyle.FixedSingle;
		_0002_2000.FormattingEnabled = true;
		_0002_2000.ItemHeight = 12;
		_0002_2000.Items.AddRange(new object[3]
		{
			_0005_2000._0002(1402767342),
			_0005_2000._0002(1402767297),
			_0005_2000._0002(1402767152)
		});
		_0002_2000.Location = new Point(11, 19);
		_0002_2000.Name = _0005_2000._0002(1402767139);
		_0002_2000.Size = new Size(148, 398);
		_0002_2000.TabIndex = 9;
		_0002_2000.SelectedIndexChanged += _0002;
		_0003_2000.AutoSize = true;
		_0003_2000.Location = new Point(11, 4);
		_0003_2000.Name = _0005_2000._0002(1402767123);
		_0003_2000.Size = new Size(65, 12);
		_0003_2000.TabIndex = 8;
		_0003_2000.Text = _0005_2000._0002(1402767134);
		base.AutoScaleDimensions = new SizeF(6f, 12f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(773, 462);
		base.Controls.Add(m__0005);
		base.Controls.Add(_0008);
		base.Controls.Add(_0006);
		base.Controls.Add(_000E);
		base.Controls.Add(_000F);
		base.Controls.Add(_0002_2000);
		base.Controls.Add(_0003_2000);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = _0005_2000._0002(1402767217);
		base.ShowIcon = false;
		Text = _0005_2000._0002(1402767204);
		base.Load += _0003;
		((ISupportInitialize)_000F).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
internal enum _0006
{
	Office,
	MHT,
	PDF
}
internal sealed class _0008 : UrlEditor
{
	public override object EditValue(ITypeDescriptorContext _0002, IServiceProvider _0003, object _0005)
	{
		object obj = base.EditValue(_0002, _0003, _0005);
		return Path.GetDirectoryName(obj.ToString());
	}
}
internal sealed class _000E : CollectionBase, PageOffice.ExcelReader.IDataFieldCollection
{
	private string m__0002 = string.Empty;

	private bool _0003 = true;

	public PageOffice.ExcelReader.DataField this[int _0002] => (PageOffice.ExcelReader.DataField)base.List[_0002];

	public string KeyValue => this.m__0002;

	public bool IsEmpty => _0003;

	public int _0002(PageOffice.ExcelReader.DataField _0002)
	{
		return base.List.Add(_0002);
	}

	public void _0002(string _0002)
	{
		this.m__0002 = _0002;
	}

	public void _0002(bool _0002)
	{
		_0003 = _0002;
	}
}
internal sealed class _000F : CollectionBase, PageOffice.ExcelWriter.IDataFieldCollection
{
	private string m__0002 = string.Empty;

	public PageOffice.ExcelWriter.DataField this[int _0002] => (PageOffice.ExcelWriter.DataField)base.List[_0002];

	public string KeyValue
	{
		set
		{
			this.m__0002 = value;
		}
	}

	public int _0002(PageOffice.ExcelWriter.DataField _0002)
	{
		return base.List.Add(_0002);
	}

	public string _0002()
	{
		return this.m__0002;
	}
}
