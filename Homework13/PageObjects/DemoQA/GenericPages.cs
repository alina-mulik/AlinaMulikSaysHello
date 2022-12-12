using Homework13.PageObjects.DemoQA.Elements;

namespace Homework13.PageObjects.DemoQA
{
    public static class GenericPages
    {
        public static TextBoxPage TextBoxPage => GetPage<TextBoxPage>();

        public static LinksPage LinksPage => GetPage<LinksPage>();

        public static UploadAndDownloadPage UploadAndDownloadPage => GetPage<UploadAndDownloadPage>();

        public static DynamicPropertiesPage DynamicPropertiesPage => GetPage<DynamicPropertiesPage>();

        public static BrokenLinksImagesPage BrokenLinksImagesPage => GetPage<BrokenLinksImagesPage>();

        public static HomePage HomePage => GetPage<HomePage>();

        public static ButtonsPage ButtonsPage => GetPage<ButtonsPage>();

        public static WebTablesPage WebTablesPage => GetPage<WebTablesPage>();

        public static CheckBoxPage CheckBoxPage => GetPage<CheckBoxPage>();

        public static RadioButtonPage RadioButtonPage => GetPage<RadioButtonPage>();

        public static BaseDemoQaPage BaseDemoQaPage => GetPage<BaseDemoQaPage>();

        public static T GetPage<T>() where T: new() => new T();
    }
}
