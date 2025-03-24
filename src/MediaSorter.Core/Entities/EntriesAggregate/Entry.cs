using MediaSorter.Core.Enumerations;

namespace MediaSorter.Core.Entities.EntriesAggregate;

public abstract class Entry
{
    public string Name { get; init; }
    public Dictionary<MetadataType, string> Metadata { get; init; }
    
    public Entry(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;
        Metadata = new Dictionary<MetadataType, string>();
    }
}