using MediaSorter.Core.Entities.EntriesAggregate;

namespace MediaSorter.Core.Abstractions;

public interface IExplorerService
{
    Folder? Analyze(string rootPath);

    Folder? Analyze(string path, Folder? parent);
}