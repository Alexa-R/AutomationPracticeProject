﻿namespace AutomationPracticeProject.PageObjects
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
    }
}