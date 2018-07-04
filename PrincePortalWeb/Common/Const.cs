using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class Const
    {
        public enum Dates
        {
            Start,
            End
        }

        public enum StockPrintableList
        {
            ALL,
            EXPIRING,
            NONE
        }

        public enum Permission
        {
            STOCKLIST,
            ORDERS,
            QUOTELINE,
            CAPACITYPLANNER,
            WIPLIST,
            CONTRACTPRICING,
            QUALITY,
            KANBAN,
            DOCS,
            NSCR,
            RPTPARTS
        }

        public static class Quote
        {
            public enum Status
            {
                Live = 1,
                Archive = 2,
                Sent = 3,
                Actioned = 4
            }

            public enum Questions
            {
                Thickness = 1,
                FinishedCUWeight = 2,
                MinGapTrack = 3,
                HolesPanels =  4, 
                MinHoleSize = 5,
                Scoring = 6,
                MetalFinish = 7,
                Resist = 8,
                IdentSides = 9,
                PlugVias = 10,
                Routing = 11,
                Test = 12,
                CounterSinkHoles = 13,
                XOutsAllowed = 14,
                ImpedeControl = 15,
                IPCClass = 16,
                QualityReport = 17,
                InnerFinishedCUWeight = 18,
                //OuterFinishedCUWeight = 19,
                White = 21,
                Green = 22,
                GoldFinger = 23,
                NewOrRepeatPart = 24,
                Specials = 26,
                HolesPerCircuit = 28,
                ASDocumentation = 32,
                BlindVias = 35,
                BuriedVias = 36,
                Peelable = 37,
                FirstStageRout = 38,
                CarbonInk = 39,
                Chamfer = 40,
                ImmersionGoldSolderResist = 41,
                Flex = 43
            }


            public enum BoardTypes
            {
                SingleSided = 1,
                PTH = 2,
                Multilayer4 = 3,
                Multilayer6 = 4,
                Multilayer8 = 8,
                Multilayer10 = 9,
                Multilayer12 = 10,
                Multilayer14 = 11,
                Multilayer16 = 12,
                Multilayer18 = 13,
                FlexRigid = 18
            }

            public static IDictionary<int, Double> boardTypePercentageMap = new Dictionary<int, Double>
            {
                {(int)Const.Quote.BoardTypes.SingleSided,   0},
                {(int)Const.Quote.BoardTypes.PTH,           0},
                {(int)Const.Quote.BoardTypes.Multilayer4,   0},
                {(int)Const.Quote.BoardTypes.Multilayer6,   1.40},
                {(int)Const.Quote.BoardTypes.Multilayer8,   1.80},
                {(int)Const.Quote.BoardTypes.Multilayer10,  0},
                {(int)Const.Quote.BoardTypes.Multilayer12,  0},
                {(int)Const.Quote.BoardTypes.Multilayer14,  0},
                {(int)Const.Quote.BoardTypes.Multilayer16,  0},
                {(int)Const.Quote.BoardTypes.Multilayer18,  0}
            };

            public enum Materials
            {
                FR4 = 1,
                HighTG = 2,
                Rogers4003 = 3,
                Polyimide = 4,
                AlumimiumTherm = 7
            }

            public enum SupportRequestStatus
            {
                Open = 1,
                Responded = 2,
                Closed = 3
            }

            public enum SupportRequestPriority
            {
                High = 1,
                Medium = 2,
                Low = 3
            }
        }

        public static class Web_Config
        {
            public enum configSections
            {
                appSettings
            }

            public enum AppSettings
            {
                EmailErrorNotificationToEmailAddress,
                SystemEmailAddressFrom,
                SystemEmailAddressTo,
                EmailErrorNotification,
                ShowMultiPanelsOnLayout,
                QuotesFilesPath,
                IsOrderSendingEnabled,
                XMLFilesPath,
                IsShutdownLoggingOn,
                PDFFilesPath,
                PDFBaseURL,
                NSCRFilesPath,
                NSCRBaseURL
            }
        }

        public static class Admin
        {
            public const int CUSTOM_TOOLING_LEVEL_ID = 3;
            public const int CUSTOM_PREMIUM_LEVEL_ID = 3;

            public const string ENTITY_CREATED_SUFFIX = "succesfully created";
            public const string ENTITY_UPDATED_SUFFIX = "succesfully updated";

            public enum Roles
            {
                Administrator,
                User,
                SuperAdmin
            }

            public enum Modes
            {
                Edit,
                Delete
            }

            public enum Section
            {
                BOARDTYPES = 1,
                PANELSIZES = 2,
                COSTINGTYPES = 3,
                COSTDRIVERQUESTIONS = 4,
                BASEPRICES = 5,
                PREMIUMTYPES = 6,
                TOOLING = 7,
                DELIVERY = 8,
                SPECIALS = 9,
                DATASHEETS = 10,
                SYSTEMTEXT = 11,
                CUSTOMERS = 12,
                QUOTES = 13,
                HELPTEXT = 14,
                NONDATES = 15,
                ACTIVITYMONITOR = 16,
                WHATSNEW = 17,
                SUPPORTREQUESTS = 18,
                REPORTS = 19,
                CONTACTS = 20,
                ACCOUNT = 21,
                UNKNOWN = 0
            }
        }

        public static class Database
        {
            public enum AppSettings
            {
                BoardGap,
                ImpedeControl,
                ValueOfGold,
                SetupFee, 
                GoldThickness,
                MultiPanelGap,
                ProductionQuantity,
                MultipanelPanelSizeID,
                GlobalSwitch,
                SupportRequests,
                NewPartSingleBoardSize,
                RepeatPartSingleBoardSize,
                PolyimideCoreAddition,
                PolyimidePrePregAddition,
                AluminiumThermAddition
            }

            public enum LoggingCode
            {
                LOG001,
                ORD001,
                STK001,
                PSS001,
                CAP001,
                WIP001,
                REC001,
                CTP001,
                QTY001,
                QTL001,
                QTL002,
                QTL003,
                QTL004,
                QTL005,
                QTL006,
                DOC001,
                KBN001,
                NSC001,
                RPT001
            }
        }

        public static class UserMessages
        {
            public const string CONFIRM_DELETE = "Are you sure you want to delete this item";
            public const string CONFIRM_DELETE_ENTITY = "Are you sure you want to delete this {0}?";
            public const string SESSION_TIMEOUT_MESSAGE = "Your session has timed out due to inactivity, please try again.";
        }

        public static class GetParameterIdentifiers
        {
            public const string DATABASE_TABLE_IDENTIFIER = "PkId";
            public const string SUPPORT_REQUEST_IDENTIFIER = "SId";
            public const string SESSION_USER_MESSAGE = "sum";
            public const string SESSION_ID_IDENTIFIER = "sessionID";
            public const string CIRCUIT_AMOUNT_REQUEST = "amount";
            public const string CIRCUIT_WIDTH_REQUEST = "width";
            public const string CIRCUIT_HEIGHT_REQUEST = "height";
            public const string ENTITY_ID_IDENTIFIER = "eID";
            public const string QUOTE_ID_IDENTIFIER = "qID";
            public const string PANEL_CONFIGURATIONS = "PanelConfigurations";
            public const string MULTI_PANEL_CONFIGURATIONS = "MultiPanelConfigurations";
            public const string TEMP_FILES_PATH_IDENTIFIER = "TempFilesPath";
            public const string ROOT_PATH_WINDOWS_FILE_FORMAT_IDENTIFIER = "RootPathWindowsFileFormat";
            public const string ROOT_PATH_URL_FILE_FORMAT_IDENTIFIER = "RootPathURLFileFormat";
            public const string TAB_IDENTIFIER = "Tab";
            public const string SELECTED_PANEL_CONFIGURATION = "SelectedPanelConfiguration";
            public const string USER_ID_IDENTIFIER = "uID";
            public const string CUSTOMER_ID_IDENTIFIER = "cID";
            public const string DATA_SHEET_ID_IDENTIFIER = "dsID";
            public const string PDF_LINK_IDENTIFIER = "hLinkPDF";
            public const string STOCK_PRINT_TYPE = "printlist";
        }

        public enum LogLevel
        {
            Debug,
            Info,
            Warn,
            Err,
            Fatal
        }

        /// <summary>
        /// Holds Const specifically relating to Errors
        /// </summary>
        public static class Error
        {
            /// <summary>
            /// exception Message text
            /// </summary>
            public const string EXC_UNEXPECTED = "Unexpected exception: ";
            public const string EXC_COMMAND_NOT_RECOGNISED = "Command not recognised: ";
            public const string MSG_PROBLEM_PERSISTS = "Please try again.  If the problem persists please contact the administrator";
            public const string GENERIC_ACTION_ERROR = "There was a problem performing this action. " + MSG_PROBLEM_PERSISTS;
            public const string FAILED_TO_OPEN = "Data could not be retreived from the uploaded file.  File type or format was incorrect.";
            public const string NO_XML_INPUT_ERROR = "No XML was input can't create order, please try again.";
            public const string COULD_NOT_CONVERT_XML_ERROR = "The import failed for the following reason - ";
        }

        public const string RETURN_URL_IDENTIFIER = "ReturnUrl";
    }
}
