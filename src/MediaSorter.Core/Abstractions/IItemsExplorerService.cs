using MediaSorter.Core.Entities;
using MediaSorter.Core.Entities.EntriesAggregate;

namespace MediaSorter.Core.Abstractions;

public interface IItemsExplorerService
{
    Item[] GetAll(Folder folder);
}