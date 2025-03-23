using MediaSorter.Core.Enumerations;
using System.Collections.Frozen;

namespace MediaSorter.Core.Extensions;

public static class ContentTypeExtensions
{
    private static readonly FrozenSet<ContentType> ImageContentTypes = new HashSet<ContentType>
    {
        ContentType.Jpeg,
        ContentType.Png,
        ContentType.Gif,
        ContentType.Bmp,
        ContentType.Tiff,
        ContentType.Webp,
        ContentType.Svg,
    }.ToFrozenSet();

    private static readonly FrozenSet<ContentType> VideoContentTypes = new HashSet<ContentType>
    {
        ContentType.Mp4,
        ContentType.Avi,
        ContentType.Mov,
        ContentType.Wmv,
        ContentType.Mkv,
        ContentType.Webm,
        ContentType.Flv,
    }.ToFrozenSet();

    public static bool IsImage(this ContentType type) => ImageContentTypes.Contains(type);
    public static bool IsVideo(this ContentType type) => VideoContentTypes.Contains(type);
}
