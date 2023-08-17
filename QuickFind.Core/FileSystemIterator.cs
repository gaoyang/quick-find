using System.IO.Enumeration;

namespace QuickFind.Core;

/// <summary>
/// File system iterator
/// </summary>
public class FileSystemIterator
{
    private readonly string root;

    /// <summary>
    /// File system iterator
    /// </summary>
    /// <param name="path">The directory to iterate over</param>
    public FileSystemIterator(string path)
    {
        root = path;
    }

    public IEnumerable<string> EnumerableFiles()
    {
        if (!Directory.Exists(root)) return Array.Empty<string>();

        var fileSystemEnumerable = new FileSystemEnumerable<string>(root, (ref FileSystemEntry entry) => null!, new()
        {
            RecurseSubdirectories = true
        })
        {
            ShouldIncludePredicate = (ref FileSystemEntry entry) => true
        };
        return fileSystemEnumerable;
    }
}