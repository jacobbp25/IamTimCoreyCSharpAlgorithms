/*
Manipulate files using cSharpt

Copy all files from one folder to another folder, do not overwrite

Bonus: ensure that all sub-folders and files are copied as well
Include a switch in your method that allows you to flatten the file structure (all in one folder).
- when doing so, rename the files to include the folder names 
-- like so: Folder1_FileName.txt if it came from subfolder Folder1
*/
string source = @"C:\projects\CSharpAlgos\9FileManagement\source";
string dest = @"C:\projects\CSharpAlgos\9FileManagement\destination";

CopyFiles(source, dest, includeSubFolders: false, flattenStructure: true);
System.Console.WriteLine("Files copied");
Cleanup(dest);
System.Console.WriteLine("Files cleaned up");

static void Cleanup(string dest) => Directory.Delete(dest, true);

static void CopyFiles(string sourceDirectory, string destinationDirectory, bool includeSubFolders, bool flattenStructure)
{
    var searchOption = SearchOption.TopDirectoryOnly;

    if (includeSubFolders)
        searchOption = SearchOption.AllDirectories;

    var fileList = Directory.GetFiles(sourceDirectory, "*", searchOption);

    foreach (var fileToCopy in fileList)
    {
        CopyFile(sourceDirectory, fileToCopy, destinationDirectory, flattenStructure);
    }
}

static void CopyFile(string sourceDirectory, string sourceFile, string destinationDirectory, bool flattenStructure)
{
    var subfolders = GetSubfolders(sourceDirectory, sourceFile);
    var newFileName = GetFileName(subfolders, flattenStructure);
    var destinationFile = Path.Combine(destinationDirectory, newFileName += Path.GetFileName(sourceFile));
    DoCopy(destinationFile, sourceFile);
}

static string GetFileName(List<string> subfolders, bool flattenStructure)
{
    var seperator = flattenStructure ? "_" : "\\";
    string newFileName = "";
    foreach (var subfolder in subfolders)
    {
        newFileName += subfolder + seperator;
    }
    return newFileName;
}

static List<string> GetSubfolders(string sourceDirectory, string sourceFile)
{
    var sourceFolders = sourceDirectory.Split('\\');
    var sourceFileFolders = Path.GetDirectoryName(sourceFile)?.Split('\\');
    List<string> subfolders = new List<string>();
    for (int i = sourceFolders.Length; i < sourceFileFolders?.Length; i++)
    {
        subfolders.Add(sourceFileFolders[i]);
    }
    return subfolders;
}

static void DoCopy(string destinationFile, string sourceFile)
{
    if (!Directory.Exists(Path.GetDirectoryName(destinationFile)))
    {
        var path = Path.GetDirectoryName(destinationFile) ?? null;
        if (!String.IsNullOrEmpty(path))
            Directory.CreateDirectory(path);
    }


    File.Copy(sourceFile, destinationFile, false);
}


