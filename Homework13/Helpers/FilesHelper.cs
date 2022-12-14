namespace Homework13.Helpers
{
    public class FilesHelper
    {
        public static string GetFilesForUploadDir()
        {
            var uploadsFolder = AppContext.BaseDirectory + "FilesForUpload\\";

            return uploadsFolder;
        }
    }
}
