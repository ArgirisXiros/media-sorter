using MediaSorter.Core.Entities.EntriesAggregate;

namespace MediaSorter.Core.Abstractions;

public interface IExplorerService
{
    Folder? Scan(bool extractCreationDateTime, string path, Folder? parent = null);
}