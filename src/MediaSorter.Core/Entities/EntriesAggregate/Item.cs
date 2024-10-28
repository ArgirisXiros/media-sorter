using MediaSorter.Core.Enumerations;

namespace MediaSorter.Core.Entities.EntriesAggregate;

public class Item : Entry
{
    public ContentType Type { get; init; }

    public Item(string name, ContentType type) : base(name)
    {
        Type = type;
    }
}
