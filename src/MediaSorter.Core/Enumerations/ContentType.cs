using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSorter.Core.Enumerations;

public enum ContentType : short
{
    Undefined = 0,
    Unknown = 1,

    Jpg = 10,
    Jpeg = 11,

    Png = 20,

    Gif = 30,

    Mp4 = 40
}
