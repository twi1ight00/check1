using System.Runtime.InteropServices;
using ns51;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("ba169cbc-a81c-41d5-acd1-bf86fe58a782")]
public class Backdrop3DScene : IBackdrop3DScene
{
	private Class1134 class1134_0 = new Class1134(0f, 0f, 0f);

	private Class1134 class1134_1 = new Class1134(0f, 0f, 0f);

	private Class1134 class1134_2 = new Class1134(0f, 0f, 0f);

	private uint uint_0;

	public float[] NormalVector
	{
		get
		{
			return new float[3] { class1134_0.float_0, class1134_0.float_1, class1134_0.float_2 };
		}
		set
		{
			class1134_0 = new Class1134(value[0], value[1], value[2]);
			class1134_0.method_0();
			method_1();
		}
	}

	public float[] AnchorPoint
	{
		get
		{
			return new float[3] { class1134_1.float_0, class1134_1.float_1, class1134_1.float_2 };
		}
		set
		{
			class1134_1 = new Class1134(value[0], value[1], value[2]);
			method_1();
		}
	}

	public float[] UpVector
	{
		get
		{
			return new float[3] { class1134_2.float_0, class1134_2.float_1, class1134_2.float_2 };
		}
		set
		{
			class1134_2 = new Class1134(value[0], value[1], value[2]);
			class1134_2.method_0();
			method_1();
		}
	}

	internal uint Version => uint_0;

	internal void method_0(Backdrop3DScene backdrop3DScene)
	{
		class1134_1 = new Class1134(backdrop3DScene.class1134_1.float_0, backdrop3DScene.class1134_1.float_1, backdrop3DScene.class1134_1.float_2);
		class1134_0 = new Class1134(backdrop3DScene.class1134_0.float_0, backdrop3DScene.class1134_0.float_1, backdrop3DScene.class1134_0.float_2);
		class1134_2 = new Class1134(backdrop3DScene.class1134_2.float_0, backdrop3DScene.class1134_2.float_1, backdrop3DScene.class1134_2.float_2);
		method_1();
	}

	private void method_1()
	{
		uint_0++;
	}
}
