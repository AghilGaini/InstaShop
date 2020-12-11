using System.Configuration;

namespace Utilities
{
    public static class Constants
    {
        public static class FileInfo
        {
            public static class FilePath
            {
                public static class ImageRequest
                {
                    public const string Base = @"C:\TJCFiles\Requests\Images";
                    public const string BaseURL = @"TJCFiles\Requests\Images";
                    public const string Temp = @"C:\TJCFiles\Requests\Images\biksxnjmdjhios";
                    public const string TempURL = @"TJCFiles\Requests\Images\biksxnjmdjhios";
                }

                public static class ProfileImages
                {
                    public const string Base = @"C:\TJCFiles\Profiles\Images";
                    public const string BaseURL = @"TJCFiles\Profiles\Images";
                }

                public static class ProfileDocuments
                {
                    public const string Base = @"C:\TJCFiles\Profiles\Documents";
                    public const string BaseURL = @"TJCFiles\Profiles\Documents";
                }

                public static class RequestDocuments
                {
                    public const string Base = @"C:\TJCFiles\Requests\Documents";
                    public const string BaseURL = @"TJCFiles\Requests\Documents";

                }

                public static class GeneralFile
                {
                    public const string Base = @"C:\TJCFiles\other";
                    public const string BaseURL = @"TJCFiles\other";
                }

            }
            public static class FileType
            {
                public const int UserProfileImage = 1;
                public const int UserProfileDocumets = 2;
                public const int DemandDocuments = 3;
                public const int DemandImages = 4;
            }
        }

        public static class SMSApiInfo
        {
            public const string URL = "https://RestfulSms.com/api/MessageSend";
            public const string UserApiKey = "277754cb84461739187b594d";
            public const string SecretKey = "cpFE>qP[9g";
            public const string LineNumber = "30002101000942";

        }

        public static class SMSStatus
        {
            public static int Inserted = 0;
            public static int Processing = 1;
            public static int Success = 2;
            public static int Fail = 3;
        }

        public static class NotificationStatus
        {
            public static int Inserted = 0;
            public static int Processing = 1;
            public static int Success = 2;
            public static int Fail = 3;
        }

        public static class SenderType
        {
            public static byte SMS = 1;
            public static byte Notification = 2;
        }

        public static class NotificationApiInfo
        {
            public const string URL = "https://fcm.googleapis.com/fcm/send";
            public const string ServerKey = "key=AAAAODlq4dI:APA91bHcEJqhqV7NENd5XC_210mSir6piqK2C-NTugIeGvuXy0K7Om4W4Smh3pla973e8k4kQMygtNZID3XT3Adl86wDTORbhIrgvYgTNhMOMJCGCYjuGNgpZIB3lGsWFdEef-xGctBS";
        }

        public static class GenerateRandomNumber
        {
            public const int DefaulLength = 4;
            public const string DefaultStringPass = "8267";
            public const short DefaultShortPass = 8267;
        }

        public static class VerificationCode
        {
            public const int TimeOutSecondes = 360000;
        }

        public static class LogInfo
        {
            public static class LogPath
            {
                public static class Directories
                {
                    public static string BaseLogPath = string.Format(@"{0}:\{1}", "C", "InstaShopLogFolder");
                    public static string ErrorPath
                    {
                        get
                        {
                            string Res = ConfigurationManager.AppSettings["ErrorPath"].ToNullableString();
                            if (!string.IsNullOrEmpty(Res))
                                return Res;
                            return string.Format(@"{0}\{1}", BaseLogPath, "Error");
                        }
                    }

                    public static string WarningPath
                    {
                        get
                        {
                            string Res = ConfigurationManager.AppSettings["WarningPath"].ToNullableString();
                            if (!string.IsNullOrEmpty(Res))
                                return Res;
                            return string.Format(@"{0}\{1}", BaseLogPath, "Warning");
                        }
                    }

                    public static string InfoPath
                    {
                        get
                        {
                            string Res = ConfigurationManager.AppSettings["InfoPath"].ToNullableString();
                            if (!string.IsNullOrEmpty(Res))
                                return Res;
                            return string.Format(@"{0}\{1}", BaseLogPath, "Info");
                        }
                    }

                    public static string DebugPath
                    {
                        get
                        {
                            string Res = ConfigurationManager.AppSettings["DebugPath"].ToNullableString();
                            if (!string.IsNullOrEmpty(Res))
                                return Res;
                            return string.Format(@"{0}\{1}", BaseLogPath, "Debug");
                        }
                    }
                    public static string FatalPath
                    {
                        get
                        {
                            string Res = ConfigurationManager.AppSettings["FatalPath"].ToNullableString();
                            if (!string.IsNullOrEmpty(Res))
                                return Res;
                            return string.Format(@"{0}\{1}", BaseLogPath, "Fatal");
                        }
                    }
                }
            }

        }

        public static class UserRole
        {
            public const byte Demander = 2;
            public const byte Offer = 4;
        }

        public static class ServerInfo
        {
            public const string IP = "http://185.81.96.107/";
            public const string ApplicationName = "TJC";
        }

        public static class NotificationMessages
        {
            public const int BasicTypeID = 3;
            public const int NewDemandSubmited = 1;
            public const int NewDemandSubmitedType = 101;
            public const int NewOfferSubmited = 2;
            public const int NewOfferSubmitedType = 102;
            public const int OfferEdited = 3;
        }

        public static class JobSchedulerInfo
        {
            public static int SMSCount = 5;
        }

        public static class ApplicationInfo
        {
            public static int BasicTypeID = 4;
            public static int AboutUsIdentifier = 1;
            public static int Telegram = 2;
            public static int Twitter = 3;
            public static int FaceBook = 4;
            public static int Instagram = 5;
            public static int LinkedIn = 6;
            public static int Email = 7;
            public static int Address = 8;
            public static int SupportPhone = 9;
        }

        public static class ControllerLevels
        {
            public static class Level1
            {
                public static string Category_Shop { get { return "Category,Shop,CategoryID"; } }
            }
            public static class Level2
            {
            }
        }

        public static class BasicType
        {
            public static int ApiMethodType { get { return 100; } }
        }

        public static class BasicValue
        {
            public static class ApiMethodType
            {
                public static int GET { get { return 1; } }
                public static int POST { get { return 2; } }
                public static int PUT { get { return 3; } }
                public static int DELETE { get { return 4; } }

            }
        }

    }
}
