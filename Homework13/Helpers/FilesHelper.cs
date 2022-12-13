namespace Homework13.Helpers
{
    public class FilesHelper
    {
        public static string RootDir() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));

        public static string FilesForUploadDir()
        {
            var uploadsFolder = "FilesForUpload\\";

            return RootDir() + uploadsFolder;
        }
    }
}
