using MediaSorter.APP.Abstractions;
using MediaSorter.Core.Entities;
using MediaSorter.Infrastructure.FileSystem.Services;

namespace MediaSorter.APP.Services;

public class ExplorerService : IExplorerService
{
    private static FoldersExplorerService _foldersExplorerService = new ();
    private static ItemsExplorerService _itemsExplorerService = new ();
    
    public Folder Analyze(string rootPath)
    {
        var rootFolder = _foldersExplorerService.CreateFromRepresentation(rootPath);
        return Analyze(rootFolder);
    }

    public Folder Analyze(Folder rootFolder)
    {
        var items = _itemsExplorerService.GetAll(rootFolder);
        rootFolder.UpdateItems(items);
        
        var subFolders = _foldersExplorerService.GetAllSubFolders(rootFolder);
        foreach (var subFolder in subFolders)
        {
            Analyze(subFolder);
        }
        rootFolder.UpdateSubFolders(subFolders);

        return rootFolder;
    }
}