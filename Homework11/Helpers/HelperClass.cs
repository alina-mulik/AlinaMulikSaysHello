namespace Homework11.Helpers
{
    public static class HelperClass
    {
        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newRandomString = Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray();

            return new string(newRandomString);
        }

        public static string RootDir() => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
    }
}
