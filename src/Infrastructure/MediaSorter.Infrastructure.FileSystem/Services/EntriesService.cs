using MediaSorter.Core.Entities.EntriesAggregate;
using MediaSorter.Core.Enumerations;
using MediaSorter.Core.Extensions;
using MediaSorter.Infrastructure.Abstractions;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.QuickTime;
using System.Globalization;
using Directory = System.IO.Directory;

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

    public DateTime? ExtractCreationDate(Folder folder, Item item)
    {
        var filePath = Path.Combine(folder.Representation, item.Name);
        if (!File.Exists(filePath) || (!item.Type.IsImage() && !item.Type.IsVideo()))
        {
            return null;
        }
        
        var directories = ImageMetadataReader.ReadMetadata(filePath);
    
        if (item.Type.IsImage())
        {
            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            var dateTime = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);

            return dateTime;
        }
    
        if (item.Type.IsVideo())
        {
            var quickTimeDirectory = directories.OfType<QuickTimeMovieHeaderDirectory>().FirstOrDefault();
            if (quickTimeDirectory != null &&
                quickTimeDirectory.TryGetDateTime(QuickTimeMovieHeaderDirectory.TagCreated, out var createdDate))
            {
                return createdDate;
            }
        }
        
        return null;
    }
}