using MediaSorter.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSorter.Core.Extensions;

public static class StringExtensions
{
    public static ContentType ToContentType(this string value, ContentType defaultType = ContentType.Undefined)
    {
        if (string.IsNullOrEmpty(value))
            return defaultType;

        var lastPart = value.Split(".").Last();

        if (Enum.TryParse(lastPart, ignoreCase: true, out ContentType type))
            return type;

        return defaultType;
    }
}
