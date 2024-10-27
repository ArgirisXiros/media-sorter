using MediaSorter.Core.Enumerations;
using MediaSorter.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediaSorter.Core.Entities;

public class Item
{
    public string Name { get; init; }
    public ContentType Type { get; init; }

    public Item(string name, ContentType type)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        Name = name;
        Type = type;
    }
}
