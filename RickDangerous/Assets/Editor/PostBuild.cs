using System.IO;
using UnityEditor.Build.Reporting;
using UnityEditor.Build;
using UnityEngine;

public class PostBuild : IPostprocessBuildWithReport
{
    public int callbackOrder => 0;

    public void OnPostprocessBuild(BuildReport report)
    {
        string buildPath = report.summary.outputPath;
        string buildDirectory = Path.GetDirectoryName(buildPath);

        // Path to the source Level Files folder
        string sourcePath = Path.Combine(Application.dataPath, "Level Files");

        // Path to the destination Level Files folder in the Data directory
        string destinationPath = Path.Combine(buildDirectory, "RickDangerous_Data/Level Files");

        // Copy the Level Files folder to the Data directory in the build directory
        CopyDirectory(sourcePath, destinationPath);
    }

    private void CopyDirectory(string sourceDir, string destinationDir)
    {
        // Create the destination directory if it doesn't exist
        Directory.CreateDirectory(destinationDir);

        // Copy all files from the source to the destination directory
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        // Copy all subdirectories from the source to the destination directory
        foreach (string dir in Directory.GetDirectories(sourceDir))
        {
            string destDir = Path.Combine(destinationDir, Path.GetFileName(dir));
            CopyDirectory(dir, destDir);
        }
    }
}
