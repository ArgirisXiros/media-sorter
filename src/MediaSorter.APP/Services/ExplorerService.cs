using MediaSorter.Core.Abstractions;
using MediaSorter.Core.Entities.EntriesAggregate;
using MediaSorter.Core.Enumerations;
using MediaSorter.Infrastructure.FileSystem.Services;

namespace MediaSorter.APP.Services;

public class ExplorerService : IExplorerService
{
    private readonly EntriesService _entriesService;

    public ExplorerService(EntriesService entriesService)
    {
        _entriesService = entriesService;
    }
    
    public Folder? Scan(bool extractCreationDateTime, string path, Folder? parent = null)
    {
        var folderName = _entriesService.GetFolderRepresentationName(path);
        if (folderName is null)
        {
            return null;
        }
        
        var result = new Folder(folderName, path, parent);
        
        var subFolders = _entriesService.GetAllFolderRepresentations(path)
            .Select(subFolderPath => Scan(extractCreationDateTime, subFolderPath, result))
            .Where(subFolder => subFolder is not null).Select(subFolder => subFolder!);
        result.ResetSubFolders(subFolders);
        
        var items = _entriesService.GetAllItems(path);
        if (extractCreationDateTime)
        {
            foreach (var item in items)
            {
                var creationDateTime = _entriesService.ExtractCreationDate(result, item);
                if (creationDateTime is not null)
                {
                    item.Metadata.Add(MetadataType.Undefined, creationDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
        }
        result.ResetItems(items);
        
        return result;
    }

    public void ScanMetadata(Item item)
    {
        
    }
}