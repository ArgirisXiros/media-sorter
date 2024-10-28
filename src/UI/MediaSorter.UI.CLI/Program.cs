using MediaSorter.APP.Services;
using System.Globalization;

namespace MediaSorter.UI.CLI;

internal class Program
{
    private static ExplorerService _explorerService = new ();
    
    static void Main(string[] args)
    {
        var verboseLogging = false;
        var fromRootPath = "\\\\192.168.0.100\\MediaStorageTemp\\family\\Photos\\2014";
        var toRootPath = "\\\\192.168.0.100\\family\\photos";

        var rootFolder = _explorerService.Analyze(fromRootPath);
        
        // foreach (var folder in folders)
        // {
        //     if (!TryExtractDateFromPath(folder, out var dateInFolder))
        //     {
        //         Console.WriteLine($"Unable to extract date from path: {folder}");
        //         continue;
        //     }
        //
        //     if (verboseLogging) Console.WriteLine($"{folder} - {dateInFolder}");
        //
        //     var folderParts = GetLastPartOfPath(folder);
        //     var files = FindContentsInFolder(folder);
        //     foreach (var file in files)
        //     {
        //         if (verboseLogging) Console.WriteLine($"--{file}");
        //
        //         if (!TryExtractDateFromFile(file, out var dateTakenInFile))
        //         {
        //             Console.WriteLine($"Unable to extract date from file: {file}");
        //             continue;
        //         }
        //
        //         var isFileInCorrectFolder = IsFileInCorrectFolder(dateInFolder, dateTakenInFile);
        //         if (isFileInCorrectFolder)
        //         {
        //             if (verboseLogging) Console.WriteLine($"{file} - OK");
        //
        //             var directoryToCopy = $"{toRootPath}\\{dateInFolder.Year}\\{dateTakenInFile.ToString("yyyy-MM-dd")}{(string.IsNullOrEmpty(folderParts.Item2) ? string.Empty : $" - {folderParts.Item2}")}";
        //             System.IO.Directory.CreateDirectory(directoryToCopy);
        //             
        //             var fileName = GetFileName(file);
        //             // File.Copy(file, $"{directoryToCopy}\\{fileName}");
        //         }
        //         else
        //         {
        //             Console.WriteLine($"{file} - Taken: {dateTakenInFile} - Unmatched Folder");
        //         }
        //     }
        // }
    }

    private static bool TryExtractDateFromPath(string path, out DateTime date)
    {
        var validDateFormats = new string[] { "yyyy-MM-dd" };

        var dateString = GetLastPartOfPath(path).Item1;
        return DateTime.TryParseExact(dateString, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    }

    // private static bool TryExtractDateFromFile(string file, out DateTime date)
    // {
    //     var validDateFormats = new string[] { "yyyy-MM-dd HH:mm:ss", "yyyy:MM:dd HH:mm:ss" };
    //
    //     //if (IsImage(file))
    //     //{
    //     //using (var reader = new ExifReader(pathName))
    //     //{
    //     //    var isValidDate = reader.GetTagValue<DateTime>(ExifTags.DateTimeOriginal, out DateTime dateTaken);
    //     //    if (isValidDate)
    //     //    {
    //     //        return dateTaken;
    //     //    }
    //
    //     //    //// Editing Date Taken
    //     //    //reader.SetTagValue(ExifTags.DateTimeOriginal, newDateTaken);
    //     //    //reader.SetTagValue(ExifTags.DateTimeDigitized, newDateTaken);
    //
    //     //    //// Save the updated EXIF data
    //     //    //reader.Save(filePath);
    //     //    //Console.WriteLine("New Date Taken set: " + newDateTaken);
    //     //}
    //     //}
    //
    //     var directories = ImageMetadataReader.ReadMetadata(file);
    //
    //     var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
    //     var dateTimeString = subIfdDirectory?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);
    //
    //     if (string.IsNullOrEmpty(dateTimeString))
    //     {
    //         date = default;
    //         return false;
    //     }
    //
    //     //foreach (var directory in directories)
    //     //{
    //     //    foreach (var tag in directory.Tags)
    //     //    {
    //     //        if (tag.Name.ToLower().Contains("date"))
    //     //        {
    //     //            Console.WriteLine($"{directory.Name} - {tag.Name} = {tag.Description}");
    //     //        }
    //     //    }
    //     //}
    //
    //     return DateTime.TryParseExact(dateTimeString, validDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
    // }

    private static bool IsImage(string file)
    {
        var validImageExtansions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
        foreach (var validImageExtansion in validImageExtansions)
        {
            if (file.ToLower().EndsWith(validImageExtansion))
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsFileInCorrectFolder(DateTime dateInFolder, DateTime dateTakenInFile)
    {
        return dateInFolder.Year == dateTakenInFile.Year
            && dateInFolder.Month == dateTakenInFile.Month
            && dateInFolder.Day == dateTakenInFile.Day;
    }

    private static (string, string?) GetLastPartOfPath(string path)
    {
        var parts = path.Split('\\')[^1].Split(" - ");
        if (parts.Length > 1)
        {
            return (parts[0], parts[1]);
        }
        return (parts[0], null);
    }

    private static string GetFileName(string file)
    {
        return file.Split('\\')[^1];
    }
}
