using MediaSorter.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediaSorter.Core.Entities;

public class Record
{
    public required string Name { get; init; }
    public required ContentType Type { get; init; }

    public Record(string name, ContentType type)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNull(type);

        Name = name;
        Type = type;
    }
}
