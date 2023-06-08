using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ns10;
using ns71;

namespace Aspose.Slides.Vba;

[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
[Guid("D9841EF7-1913-46DF-BEB0-6E5F2DACCEE2")]
public sealed class VbaProject : IVbaProject
{
	private readonly Class3542 class3542_0;

	private VbaModuleCollection vbaModuleCollection_0;

	private VbaReferenceCollection vbaReferenceCollection_0;

	public string Name => class3542_0.VbaStorage.DirStream.ProjectInformation.ProjectName.ProjectName;

	public IVbaModuleCollection Modules => vbaModuleCollection_0;

	public IVbaReferenceCollection References => vbaReferenceCollection_0;

	internal Class3542 VbaProjectRootStorage => class3542_0;

	public VbaProject()
		: this(new Class3542(1252, "VBAProject"))
	{
	}

	public VbaProject(byte[] data)
		: this(new Class3542(data))
	{
	}

	internal VbaProject(Class3542 vbaContainer)
	{
		if (vbaContainer == null)
		{
			throw new ArgumentNullException();
		}
		vbaModuleCollection_0 = new VbaModuleCollection(this);
		vbaReferenceCollection_0 = new VbaReferenceCollection(this);
		class3542_0 = vbaContainer;
		method_2();
		method_3();
	}

	public byte[] ToBinary()
	{
		return class3542_0.ToBinary();
	}

	internal VbaModule AddEmptyModule(string name)
	{
		Class3526 moduleStream = class3542_0.AddEmptyModule(name);
		return new VbaModule(name, moduleStream);
	}

	internal void method_0(IVbaReference reference)
	{
		if (!(reference is VbaReferenceOleTypeLib vbaReferenceOleTypeLib))
		{
			throw new NotSupportedException("Only OLE TypeLib references allowed");
		}
		class3542_0.method_1(vbaReferenceOleTypeLib.Name, vbaReferenceOleTypeLib.Libid);
	}

	internal void method_1(string name)
	{
		class3542_0.method_2(name);
	}

	private void method_2()
	{
		foreach (KeyValuePair<string, Class3526> module in class3542_0.VbaStorage.Modules)
		{
			Class3526 value = module.Value;
			if (value.Module.Type.IsProceduralModule)
			{
				VbaModule value2 = new VbaModule(module.Key, value);
				vbaModuleCollection_0.Add(value2);
			}
		}
	}

	private void method_3()
	{
		if (class3542_0.VbaStorage.DirStream.ProjectReferences == null)
		{
			throw new InvalidOperationException();
		}
		foreach (Class3513 reference in class3542_0.VbaStorage.DirStream.ProjectReferences.References)
		{
			string name = "";
			if (reference.ReferenceName != null && reference.ReferenceName.Name != null)
			{
				name = reference.ReferenceName.Name;
			}
			if (reference.ReferenceRecord is Class3514)
			{
				Class156 item = new Class156(name);
				vbaReferenceCollection_0.References.Add(item);
				continue;
			}
			if (reference.ReferenceRecord is Class3510 class2)
			{
				VbaReferenceOleTypeLib item2 = new VbaReferenceOleTypeLib(name, class2.Libid);
				vbaReferenceCollection_0.References.Add(item2);
				continue;
			}
			if (reference.ReferenceRecord is Class3509)
			{
				Class158 item3 = new Class158(name);
				vbaReferenceCollection_0.References.Add(item3);
				continue;
			}
			throw new InvalidOperationException("Unknown VBA Project reference type");
		}
	}
}
