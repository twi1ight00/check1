using System;
using System.Collections;
using System.Runtime.InteropServices;
using ns22;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("4199AC19-4BBC-4893-9A8E-13C810655E63")]
[ComVisible(true)]
public class Camera : ICamera
{
	internal float float_0 = 45f;

	internal float float_1 = 100f;

	internal CameraPresetType cameraPresetType_0 = CameraPresetType.NotDefined;

	internal float[] float_2;

	internal SortedList sortedList_0 = new SortedList(62);

	private Class269 class269_0 = new Class269();

	private uint uint_0;

	internal Class269 PPTUnsupportedProps => class269_0;

	public CameraPresetType CameraType
	{
		get
		{
			return cameraPresetType_0;
		}
		set
		{
			cameraPresetType_0 = value;
			PPTUnsupportedProps.IsCameraTypeChangedAfterLoading = true;
			method_1();
		}
	}

	public float FieldOfViewAngle
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
			method_1();
		}
	}

	public float Zoom
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
			method_1();
		}
	}

	internal uint Version => uint_0;

	public void SetRotation(float latitude, float longitude, float revolution)
	{
		if (!float.IsNaN(latitude + longitude + revolution))
		{
			if (float_2 == null)
			{
				float_2 = new float[3];
			}
			float_2[0] = latitude;
			float_2[1] = longitude;
			float_2[2] = revolution;
		}
		else
		{
			float_2 = null;
		}
		method_1();
	}

	public float[] GetRotation()
	{
		if (float_2 == null)
		{
			return null;
		}
		return (float[])float_2.Clone();
	}

	internal void method_0(Camera camera)
	{
		float_2 = ((camera.float_2 == null) ? null : ((float[])camera.float_2.Clone()));
		CameraType = camera.cameraPresetType_0;
		float_0 = camera.float_0;
		sortedList_0 = (SortedList)camera.sortedList_0.Clone();
		float_1 = camera.float_1;
		method_1();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Camera camera))
		{
			return base.Equals(obj);
		}
		if ((float_2 == null && camera.float_2 != null) || (float_2 != null && camera.float_2 == null))
		{
			return false;
		}
		if (float_2 != null && camera.float_2 != null)
		{
			if (float_2.Length != camera.float_2.Length)
			{
				return false;
			}
			for (int i = 0; i < float_2.Length; i++)
			{
				if (float_2[i] != camera.float_2[i])
				{
					return false;
				}
			}
		}
		if (sortedList_0.Count != camera.sortedList_0.Count)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < sortedList_0.Count)
			{
				if ((sortedList_0[num] == null && camera.sortedList_0[num] != null) || !sortedList_0[num].Equals(camera.sortedList_0[num]))
				{
					break;
				}
				num++;
				continue;
			}
			if (float_0 == camera.float_0 && float_1 == camera.float_1)
			{
				return cameraPresetType_0 == camera.cameraPresetType_0;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	private void method_1()
	{
		uint_0++;
	}
}
