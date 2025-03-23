using MediaSorter.Core.Entities.EntriesAggregate;
using MediaSorter.Infrastructure.Abstractions;

namespace MediaSorter.Infrastructure.FileSystem.Services;

public class EntriesService : IEntriesService
{
    public bool IsValidFolderRepresentation(string folderRepresentation)
    {
        var result = Directory.Exists(folderRepresentation);
        return result;
    }

    public string? GetFolderRepresentationName(string folderRepresentation)
    {
        if (!IsValidFolderRepresentation(folderRepresentation))
        {
            return null;
        }
        
        var directoryInfo = new DirectoryInfo(folderRepresentation);
        return directoryInfo.Name;
    }
    
    public string[] GetAllFolderRepresentations(string folderRepresentation)
    {
        if (!IsValidFolderRepresentation(folderRepresentation))
        {
            return Array.Empty<string>();
        }
        
        var result = Directory.GetDirectories(folderRepresentation, "*", SearchOption.TopDirectoryOnly);
        return result;
    }
    
    public Item[] GetAllItems(string folderRepresentation)
    {
        if (!IsValidFolderRepresentation(folderRepresentation))
        {
            return Array.Empty<Item>();
        }
        
        var items = Directory.GetFiles(folderRepresentation, "*.*", SearchOption.TopDirectoryOnly)
            .Select(Path.GetFileName)
            .Where(fileName => !string.IsNullOrEmpty(fileName))
            .Select(fileName => new Item(fileName!))
            .ToArray();

        return items;
    }
}