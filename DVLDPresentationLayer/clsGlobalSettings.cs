using DVLDBusinessLayer;
namespace DVLDDataAccessLayer
{
    public static class clsGlobalSettings
    {
        public static clsUser CurrentUser { get; set; }

        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        // 🔥 Property احترافي
        public static int CurrentUserID
        {
            get { return CurrentUser?.UserID ?? -1; }
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}