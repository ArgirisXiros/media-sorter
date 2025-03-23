using MediaSorter.Core.Abstractions;
using MediaSorter.Core.Entities.EntriesAggregate;
using MediaSorter.Infrastructure.FileSystem.Services;

namespace MediaSorter.APP.Services;

public class ExplorerService : IExplorerService
{
    private static EntriesService _entriesService = new ();
    
    public Folder? Analyze(string rootPath)
    {
        var result = Analyze(rootPath, null);
        return result;
    }

    public Folder? Analyze(string path, Folder? parent)
    {
        var folderName = _entriesService.GetFolderRepresentationName(path);
        if (folderName is null)
        {
            return null;
        }
        
        var result = new Folder(folderName, path, parent);
        
        var subFolders = _entriesService.GetAllFolderRepresentations(path)
            .Select(subFolderPath => Analyze(subFolderPath, result))
            .Where(subFolder => subFolder is not null).Select(subFolder => subFolder!);
        result.ResetSubFolders(subFolders);
        
        var items = _entriesService.GetAllItems(path);
        result.ResetItems(items);
        
        return result;
    }
}