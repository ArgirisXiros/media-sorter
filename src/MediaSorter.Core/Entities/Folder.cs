using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MediaSorter.Core.Entities;

public class Folder
{
    public string Name { get; init; }
    public string Representation { get; init; }
    
    public Folder? Parent { get; private set; }
    public ImmutableArray<Item> Items { get; private set; }
    public ImmutableArray<Folder> SubFolders { get; private set; }
    
    public Folder(string representation, string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(representation);
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Representation = representation;
        Name = name;

        Items = [];
        SubFolders = [];
    }

    public Folder(string representation, string name, Folder parent)
        : this(representation, name)
    {
        Parent = parent;
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
