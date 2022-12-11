using NUnit.Framework;

namespace Homework11.Data
{
    public class TestContextValues
    {
        public static string ExecutableClassName => TestContext.CurrentContext.Test.ClassName;
    }
}
