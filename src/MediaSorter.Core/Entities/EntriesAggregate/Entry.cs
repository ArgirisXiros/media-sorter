using MediaSorter.Core.Enumerations;

namespace MediaSorter.Core.Entities.EntriesAggregate;

public abstract class Entry
{
    public string Name { get; init; }
    private Dictionary<MetadataType, object> Metadata { get; init; }
    
    public Entry(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        
        Name = name;
        Metadata = new Dictionary<MetadataType, object>();
    }
}