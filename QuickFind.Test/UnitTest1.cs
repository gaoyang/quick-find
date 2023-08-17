using System.IO.Enumeration;
using NUnit.Framework;

namespace QuickFind.Test;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(@"D:\SourceCode")]
    public void EnumerateFilesTest(string dir)
    {
        var fileSystemEnumerable = new FileSystemEnumerable<string>(dir, (ref FileSystemEntry entry) => default, new()
        {
            RecurseSubdirectories = true
        })
        {
            ShouldIncludePredicate = (ref FileSystemEntry entry) => true
        };
        Console.WriteLine(fileSystemEnumerable.Count());
    }
}