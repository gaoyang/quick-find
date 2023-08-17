// See https://aka.ms/new-console-template for more information

Console.WriteLine($"{args[0]}");

var dir = args[0];

var entries = Directory.EnumerateFileSystemEntries(dir, "*", SearchOption.AllDirectories);
var count = entries.Count();
Console.WriteLine(count);



// foreach (var entry in entries)
// {
//     Console.Clear();
//     Console.WriteLine(count++);
// }