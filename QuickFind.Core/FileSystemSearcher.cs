using System.IO.Enumeration;

namespace QuickFind.Core;

/// <summary>
/// File system searcher
/// </summary>
public class FileSystemSearcher
{
    private readonly string root;

    /// <summary>
    /// File system searcher
    /// </summary>
    /// <param name="path">The directory to search</param>
    public FileSystemSearcher(string path)
    {
        root = path;
    }

    /// <summary>
    /// Search files
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    public IEnumerable<string> Search(string keyword)
    {
        if (!Directory.Exists(root)) return Array.Empty<string>();

        var fileSystemEnumerable = new FileSystemEnumerable<string>(root, (ref FileSystemEntry entry) => null!, new()
        {
            RecurseSubdirectories = true
        })
        {
            ShouldIncludePredicate = (ref FileSystemEntry entry) =>
            {
                _ = entry.FileName;
                return true;
            }
        };

        return fileSystemEnumerable;
    }
}