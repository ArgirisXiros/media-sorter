using MediaSorter.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaSorter.Core.Extensions;

public static class StringExtensions
{
    public static ContentType ToContentType(this string name, ContentType defaultType = ContentType.Undefined)
    {
        if (string.IsNullOrEmpty(name))
        {
            return defaultType;
        }
        
        var extension = Path.GetExtension(name).ToLower();
        var result = extension switch
        {
            ".jpg" or ".jpeg" => ContentType.Jpeg,
            ".png" => ContentType.Png,
            ".gif" => ContentType.Gif,
            ".bmp" => ContentType.Bmp,
            ".tiff" or ".tif" => ContentType.Tiff,
            ".webp" => ContentType.Webp,
            ".svg" => ContentType.Svg,
            
            ".mp4" => ContentType.Mp4,
            ".avi" => ContentType.Avi,
            ".mov" => ContentType.Mov,
            ".wmv" => ContentType.Wmv,
            ".mkv" => ContentType.Mkv,
            ".webm" => ContentType.Webm,
            ".flv" => ContentType.Flv,
                
            ".json" => ContentType.Json,
            _ => ContentType.Unknown,
        };
        
        return result;
    }
}
