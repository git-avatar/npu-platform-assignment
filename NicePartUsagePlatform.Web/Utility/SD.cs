namespace NicePartUsagePlatform.Web.Utility
{
    public class SD
    {
        public static string ScoreAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public const string TokenCookie = "token";

        public const string RoleFan = "FAN";
        public const string RoleAdmin = "ADMIN";


        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
