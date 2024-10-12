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
    public required string Name { get; init; }
    public required Folder Parent { get; init; }

    public ImmutableArray<Record> Records { get; private set; }
    public ImmutableArray<Folder> SubFolders { get; private set; }

    public Folder(string name, Folder parent)
    {
        Name = name;
        Parent = parent;

        Records = [];
        SubFolders = [];
    }

    public void AddRecords(IEnumerable<Record> records)
    {
        Records = records.ToImmutableArray();
    }

    public void AddSubFolders(IEnumerable<Folder> subFolders)
    {
        SubFolders = subFolders.ToImmutableArray();
    }
}
