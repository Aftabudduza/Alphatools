using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileList : System.Web.UI.Page
{
    string sFiles = "";
    string sFileURL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         string[] DirectoryEntries = {"Admin"};
         foreach (string DirectoryName in DirectoryEntries)
         {
             string path = Server.MapPath("/Files/Members/" + DirectoryName);

             if (File.Exists(path))
             {
                 // This path is a file
                // ProcessFile(path);

                 if (File.Exists(path))
                 {
                     sFileURL = "<ul><a target='_blank' href='/Files/Members/" + DirectoryName + "'>" + DirectoryName.ToString() + "</a></ul>";
                     sFiles += sFileURL;
                 }
             }
             else if (Directory.Exists(path))
             {
                 // This path is a directory
                // ProcessDirectory(path);

                 sFiles += "<ul>";
                 sFiles += DirectoryName;
                 GetFilesFromDirectory(path, DirectoryName);
                 sFiles += "</ul>";
             }
         }

         spanFile.InnerHtml = sFiles;
    }

    public void ProcessDirectory(string targetDirectory)
    {
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
        {
           // string path = Server.MapPath(targetDirectory + fileName);
            if (File.Exists(fileName))
            {
                sFiles += fileName;
            }
          //  ProcessFile(fileName);
        }

        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
        {
            string path = Server.MapPath(targetDirectory + subdirectory);
            ProcessDirectory(path);
        }
    }

    // Insert logic for processing found files here.
    public void ProcessFile(string path)
    {
       
        Console.WriteLine("Processed file '{0}'.", path);
    }

    private void GetFilesFromDirectory(string DirPath, string DirName)
    {
        try
        {
            DirectoryInfo Dir = new DirectoryInfo(DirPath);
            FileInfo[] FileList = Dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo FI in FileList)
            {
                sFileURL = "<li><a target='_blank' href='/Files/Members/" + DirName + "/" + FI.Name + "'>" + FI.Name.ToString() + "</a></li>";
          //      sFiles += "<li><a target='_blank' href='" + FI.Name + "'>" + FI.Name.ToString() + "</a></li>";
                sFiles += sFileURL;

              //  Console.WriteLine(FI.FullName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}