using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace PRACT.Common.IO
{
    public class FileCopier
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
                       out ulong lpFreeBytesAvailable,
                       out ulong lpTotalNumberOfBytes,
                       out ulong lpTotalNumberOfFreeBytes);

        public string DestinationFolder { get; set; }
        public string SourceFolder { get; set; }
        public FileCopier(string SourceFolder, string DestinationFolder)
        {
            this.DestinationFolder = DestinationFolder;
            this.SourceFolder = SourceFolder;
        }

        public long FreeSpace()
        {
            ulong FreeBytesAvailable;
            ulong TotalNumberOfBytes;
            ulong TotalNumberOfFreeBytes;

            bool success = GetDiskFreeSpaceEx(DestinationFolder,
                                              out FreeBytesAvailable,
                                              out TotalNumberOfBytes,
                                              out TotalNumberOfFreeBytes);
            if (!success)
                throw new System.ComponentModel.Win32Exception();
            return Convert.ToInt64(FreeBytesAvailable);
        }

        public string GetRelativePath(string FileName)
        {
            return Path.GetRelativePath(Path.GetPathRoot(FileName), Path.GetDirectoryName(FileName));
        }
        /// <summary>
        /// Copy the file
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns>True if the copy was successfull</returns>
        public bool Copy(string FileName)
        {
            bool result = File.Exists(FileName);
            if (result)
            {
                try
                {
                    // New Full Destination Directory
                    string dir = Path.Combine(DestinationFolder, GetRelativePath(FileName));
                    // Create the destination directory if necessary
                    Directory.CreateDirectory(dir);
                    File.Copy(FileName, Path.Combine(dir,Path.GetFileName(FileName)));
                }
                catch(Exception e)
                {
                    Trace.WriteLine(e.Message);
                    result=false;
                }
            }
            return result;
        }
    }
}
