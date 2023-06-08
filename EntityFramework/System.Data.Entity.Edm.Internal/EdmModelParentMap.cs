using System.Collections.Generic;

namespace System.Data.Entity.Edm.Internal;

internal class EdmModelParentMap
{
	private readonly EdmModel model;

	private readonly Dictionary<EdmNamespaceItem, EdmNamespace> itemToNamespaceMap = new Dictionary<EdmNamespaceItem, EdmNamespace>();

	private readonly Dictionary<EdmEntityContainerItem, EdmEntityContainer> itemToContainerMap = new Dictionary<EdmEntityContainerItem, EdmEntityContainer>();

	internal IEnumerable<EdmNamespaceItem> NamespaceItems => itemToNamespaceMap.Keys;

	internal EdmModelParentMap(EdmModel edmModel)
	{
		model = edmModel;
	}

	internal void Compute()
	{
		itemToNamespaceMap.Clear();
		if (model.HasNamespaces)
		{
			foreach (EdmNamespace @namespace in model.Namespaces)
			{
				foreach (EdmNamespaceItem namespaceItem in @namespace.NamespaceItems)
				{
					if (namespaceItem != null)
					{
						itemToNamespaceMap[namespaceItem] = @namespace;
					}
				}
			}
		}
		itemToContainerMap.Clear();
		if (!model.HasContainers)
		{
			return;
		}
		foreach (EdmEntityContainer container in model.Containers)
		{
			foreach (EdmEntityContainerItem containerItem in container.ContainerItems)
			{
				if (containerItem != null)
				{
					itemToContainerMap[containerItem] = container;
				}
			}
		}
	}

	internal bool TryGetEntityContainer(EdmEntityContainerItem item, out EdmEntityContainer container)
	{
		if (item != null)
		{
			return itemToContainerMap.TryGetValue(item, out container);
		}
		container = null;
		return false;
	}

	internal bool TryGetNamespace(EdmNamespaceItem item, out EdmNamespace itemNamespace)
	{
		if (item != null)
		{
			return itemToNamespaceMap.TryGetValue(item, out itemNamespace);
		}
		itemNamespace = null;
		return false;
	}
}
