using MediaSorter.Core.Enumerations;
using MediaSorter.Core.Extensions;

namespace MediaSorter.Core.Entities.EntriesAggregate;

public class Item : Entry
{
    public ContentType Type { get; }

    public Item(string name) : base(name)
    {
        Type = name.ToContentType();
    }
}
