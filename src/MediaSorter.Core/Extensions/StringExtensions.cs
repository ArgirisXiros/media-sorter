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
            ".mts" => ContentType.Mts,
                
            ".json" => ContentType.Json,
            _ => ContentType.Unknown,
        };
        
        return result;
    }
    
    public static IEnumerable<(MetadataType type, string value)> ToMetadata(this string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            yield break;
        }
        
        var parts = name.Split(new[] { '-' }, 4, StringSplitOptions.RemoveEmptyEntries);
        
        if (parts.Length >= 1 && int.TryParse(parts[0], out var y))
        {
            yield return (MetadataType.Year, y.ToString());
        }
        
        if (parts.Length >= 2 && int.TryParse(parts[1], out var m) && m is >= 1 and <= 12)
        {
            yield return (MetadataType.Month, m.ToString());
        }
        
        if (parts.Length >= 3 && int.TryParse(parts[2], out var d) && d is >= 1 and <= 31)
        {
            yield return (MetadataType.Day, d.ToString());
        }

        var descriptionIndex = name.IndexOf(" - ", StringComparison.Ordinal);
        if (descriptionIndex >= 0)
        {
            var description = name.Substring(descriptionIndex + 3).Trim();
            yield return (MetadataType.Description, description);
        }
        else if (parts.Length > 3)
        {
            var description = parts[3].Trim();
            yield return (MetadataType.Description, description);
        }
    }
}
