using MediaSorter.Core.Abstractions;
using MediaSorter.Core.Entities;
using MediaSorter.Core.Extensions;

namespace MediaSorter.Infrastructure.FileSystem.Services;

public class ItemsExplorerService : IItemsExplorerService
{
    public Item[] GetAll(Folder folder)
    {
        var items = Directory.GetFiles(folder.Representation, "*.*", SearchOption.TopDirectoryOnly)
            .Select(Path.GetFileName)
            .Where(fileName => !string.IsNullOrEmpty(fileName))
            .Select(fileName => new Item(fileName!, fileName!.ToContentType()))
            .ToArray();

        return items;
    }
}
