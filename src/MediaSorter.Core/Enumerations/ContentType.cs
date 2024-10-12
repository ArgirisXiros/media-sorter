using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSorter.Core.Enumerations;

public enum ContentType : short
{
    undefined = 0,
    unknown = 1,

    jpg = 10,
    jpeg = 11,

    png = 20,

    gif = 30,

    mp4 = 40
}
