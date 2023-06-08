using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides;

public class ControlCollection : ICollection, IEnumerable, IEnumerable<IControl>, IControlCollection
{
	private readonly List<IControl> list_0 = new List<IControl>();

	internal BaseSlide baseSlide_0;

	public int Count => list_0.Count;

	public IControl this[int index] => list_0[index];

	IEnumerable IControlCollection.AsIEnumerable => this;

	ICollection IControlCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal ControlCollection(BaseSlide parent)
	{
		baseSlide_0 = parent;
	}

	public IControl AddControl(ControlType controlType, float x, float y, float width, float height)
	{
		Control control = null;
		if (controlType == ControlType.WindowsMediaPlayer)
		{
			control = method_0();
			if (control != null)
			{
				control.Frame = new ShapeFrame(x, y, width, height, NullableBool.False, NullableBool.False, 0f);
				list_0.Add(control);
			}
			return control;
		}
		throw new PptxException("Support of this control type is not implemented for PPTX yet.");
	}

	internal IControl Add()
	{
		Control control = new Control(this);
		list_0.Add(control);
		return control;
	}

	public void Remove(IControl item)
	{
		list_0.Remove(item);
	}

	public void RemoveAt(int index)
	{
		list_0.RemoveAt(index);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	private Control method_0()
	{
		Control control = new Control(this);
		control.PPTXUnsupportedProps.ClassId = new Guid("6BF52A52-394A-11D3-B153-00C04F79FAA6");
		control.Name = "WindowsMediaPlayer";
		control.Properties.Add("URL", "");
		control.Properties.Add("rate", "1");
		control.Properties.Add("balance", "0");
		control.Properties.Add("currentPosition", "0");
		control.Properties.Add("defaultFrame", "");
		control.Properties.Add("playCount", "1");
		control.Properties.Add("autoStart", "-1");
		control.Properties.Add("currentMarker", "0");
		control.Properties.Add("invokeURLs", "-1");
		control.Properties.Add("baseURL", "");
		control.Properties.Add("volume", "50");
		control.Properties.Add("mute", "0");
		control.Properties.Add("uiMode", "full");
		control.Properties.Add("stretchToFit", "0");
		control.Properties.Add("windowlessVideo", "0");
		control.Properties.Add("enabled", "-1");
		control.Properties.Add("enableContextMenu", "-1");
		control.Properties.Add("fullScreen", "0");
		control.Properties.Add("SAMIStyle", "");
		control.Properties.Add("SAMILang", "");
		control.Properties.Add("SAMIFilename", "");
		control.Properties.Add("captioningID", "");
		control.Properties.Add("enableErrorDialogs", "0");
		control.Properties.Add("_cx", "15663");
		control.Properties.Add("_cy", "11642");
		return control;
	}

	IEnumerator<IControl> IEnumerable<IControl>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
