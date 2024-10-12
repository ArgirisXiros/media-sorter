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

public static class ContentTypeExtensions
{
    private static readonly HashSet<ContentType> ImageContentTypes = [ ContentType.jpg,
                                                                       ContentType.jpeg,
                                                                       ContentType.png,
                                                                       ContentType.gif ];

    private static readonly HashSet<ContentType> VideoContentTypes = [ ContentType.mp4 ];

    public static bool IsImage(this ContentType type) => ImageContentTypes.Contains(type);

    public static bool IsVideo(this ContentType type) => VideoContentTypes.Contains(type);
}
