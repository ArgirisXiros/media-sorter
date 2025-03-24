using MediaSorter.Core.Extensions;
using System.Collections.Immutable;

namespace MediaSorter.Core.Entities.EntriesAggregate;

public class Folder : Entry
{
    public string Representation { get; }
    
    public Folder? Parent { get; }
    public ImmutableArray<Folder> SubFolders { get; private set; }
    public ImmutableArray<Item> Items { get; private set; }
    
    public Folder(string name, string representation, Folder? parent) : base(name)
    {
        ArgumentException.ThrowIfNullOrEmpty(representation);
        
        Representation = representation;
        
        Parent = parent;
        SubFolders = ImmutableArray<Folder>.Empty;
        Items = ImmutableArray<Item>.Empty;

        foreach (var metadataPair in Name.ToMetadata())
        {
            Metadata.Add(metadataPair.type, metadataPair.value);
        }
    }

    public ImmutableArray<Folder> ResetSubFolders(IEnumerable<Folder> subFolders)
    {
        SubFolders = subFolders.ToImmutableArray();
        return SubFolders;
    }

    public ImmutableArray<Item> ResetItems(IEnumerable<Item> items)
    {
        Items = items.ToImmutableArray();
        return Items;
    }
}
