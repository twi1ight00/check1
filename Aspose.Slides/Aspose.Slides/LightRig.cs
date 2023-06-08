using System;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("5C094089-BE08-42E6-9145-8E35F16D8421")]
public class LightRig : ILightRig
{
	internal LightingDirection lightingDirection_0 = LightingDirection.NotDefined;

	internal LightRigPresetType lightRigPresetType_0 = LightRigPresetType.NotDefined;

	private bool bool_0;

	private uint uint_0;

	internal float[] float_0 = new float[3];

	public LightingDirection Direction
	{
		get
		{
			return lightingDirection_0;
		}
		set
		{
			lightingDirection_0 = value;
			bool_0 = false;
			method_1();
		}
	}

	public LightRigPresetType LightType
	{
		get
		{
			return lightRigPresetType_0;
		}
		set
		{
			lightRigPresetType_0 = value;
			bool_0 = false;
			method_1();
		}
	}

	internal bool IsRigDirLoadedApproximately
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal uint Version => uint_0;

	public void SetRotation(float latitude, float longitude, float revolution)
	{
		float_0[0] = latitude;
		float_0[1] = longitude;
		float_0[2] = revolution;
		method_1();
	}

	public float[] GetRotation()
	{
		return float_0;
	}

	internal void method_0(LightRig lightRig)
	{
		float_0 = ((lightRig.float_0 == null) ? null : ((float[])lightRig.float_0.Clone()));
		lightingDirection_0 = lightRig.lightingDirection_0;
		lightRigPresetType_0 = lightRig.lightRigPresetType_0;
		method_1();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is LightRig lightRig))
		{
			return base.Equals(obj);
		}
		if ((float_0 == null && lightRig.float_0 != null) || (float_0 != null && lightRig.float_0 == null))
		{
			return false;
		}
		if (float_0 != null && lightRig.float_0 != null)
		{
			if (float_0.Length != lightRig.float_0.Length)
			{
				return false;
			}
			for (int i = 0; i < float_0.Length; i++)
			{
				if (float_0[i] != lightRig.float_0[i])
				{
					return false;
				}
			}
		}
		if (lightingDirection_0 == lightRig.lightingDirection_0)
		{
			return lightRigPresetType_0 == lightRig.lightRigPresetType_0;
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
