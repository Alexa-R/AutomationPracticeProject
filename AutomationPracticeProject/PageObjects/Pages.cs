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

        public static RegistrationForm RegistrationForm => GetPage<RegistrationForm>();

        public static ContactPage ContactPage => GetPage<ContactPage>();

        public static HomePage HomePage => GetPage<HomePage>();

        public static MyAccountPage MyAccountPage => GetPage<MyAccountPage>();

        public static PersonalInformationForm PersonalInformationForm => GetPage<PersonalInformationForm>();

        public static AddressesPage AddressesPage => GetPage<AddressesPage>();

        public static AddressForm AddressForm => GetPage<AddressForm>();

        public static MyWishListsPage MyWishListsPage => GetPage<MyWishListsPage>();

        public static CheckoutPage CheckoutPage => GetPage<CheckoutPage>();

        public static OrderHistoryPage OrderHistoryPage => GetPage<OrderHistoryPage>();

        public static ProductPage ProductPage => GetPage<ProductPage>();

        public static ProductCartPopup ProductCartPopup => GetPage<ProductCartPopup>();

        public static ReviewPopup ReviewPopup => GetPage<ReviewPopup>();

        public static SearchResultPage SearchResultPage => GetPage<SearchResultPage>();

        public static ForgotPasswordPage ForgotPasswordPage => GetPage<ForgotPasswordPage>();
    }
}