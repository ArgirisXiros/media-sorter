using MediaSorter.Core.Abstractions;
using MediaSorter.Core.Entities;

namespace MediaSorter.Infrastructure.FileSystem.Services;

public class FoldersExplorerService : IFoldersExplorerService
{
    private static char[] _directorySeparators =
    [
        Path.DirectorySeparatorChar,  
        Path.AltDirectorySeparatorChar
    ];
    
    public Folder CreateFromRepresentation(string representation)
    {
        if (!Directory.Exists(representation))
        {
            throw new DirectoryNotFoundException($"Directory {representation} not found");
        }
        
        return new Folder(representation, Path.GetFileName(representation));
    }
    
    public Folder[] GetAllSubFolders(Folder root)
    {
        var folders = Directory.GetDirectories(root.Representation, "*", SearchOption.TopDirectoryOnly)
            .Select(CreateFromRepresentation)
            .ToArray();

        return folders;
    }
}