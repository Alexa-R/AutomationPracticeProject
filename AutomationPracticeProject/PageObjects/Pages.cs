namespace AutomationPracticeProject.PageObjects
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();

            return page;
        }

        public static BasePage BasePage => GetPage<BasePage>();

        public static AuthenticationPage AuthenticationPage => GetPage<AuthenticationPage>();

        public static RegistrationPage RegistrationPage => GetPage<RegistrationPage>();

        public static ContactPage ContactPage => GetPage<ContactPage>();

        public static HomePage HomePage => GetPage<HomePage>();

        public static MyAccountPage MyAccountPage => GetPage<MyAccountPage>();

        public static PersonalInformationPage PersonalInformationPage => GetPage<PersonalInformationPage>();
    }
}