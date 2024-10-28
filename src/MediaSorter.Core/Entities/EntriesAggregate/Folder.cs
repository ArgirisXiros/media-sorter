using System.Collections.Immutable;

namespace MediaSorter.Core.Entities.EntriesAggregate;

public class Folder : Entry
{
    public string Representation { get; init; }
    
    public Folder? Parent { get; private set; }
    public ImmutableArray<Item> Items { get; private set; }
    public ImmutableArray<Folder> SubFolders { get; private set; }
    
    public Folder(string representation, string name) : base(name)
    {
        ArgumentException.ThrowIfNullOrEmpty(representation);
        
        Representation = representation;

        Items = [];
        SubFolders = [];
    }

    public void UpdateItems(IEnumerable<Item> items)
    {
        Items = items.ToImmutableArray();
    }

    public void UpdateSubFolders(Folder[] subFolders)
    {
        foreach (var subFolder in subFolders)
        {
            subFolder.Parent = this;
        }
        SubFolders = subFolders.ToImmutableArray();
    }
}
