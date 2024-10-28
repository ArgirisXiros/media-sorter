using MediaSorter.Core.Entities;

namespace MediaSorter.Core.Abstractions;

public interface IItemsExplorerService
{
    Item[] GetAll(Folder folder);
}