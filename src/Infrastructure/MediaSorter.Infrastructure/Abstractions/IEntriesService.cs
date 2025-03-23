using MediaSorter.Core.Entities.EntriesAggregate;

namespace MediaSorter.Infrastructure.Abstractions;

public interface IEntriesService
{
    bool IsValidFolderRepresentation(string path);
    string[] GetAllFolderRepresentations(string folderRepresentation);
    Item[] GetAllItems(string path);
}