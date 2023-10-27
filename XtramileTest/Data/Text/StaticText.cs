using System;
using System.Collections.Generic;
using System.Text;

namespace XtramileTest.Data.Text
{
    static class StaticText
    {
        //JS Alert
        public static string AlertText = "I am a JS Alert";
        public static string AlertTextResult = "You successfully clicked an alert";

        public static string AlertConfirm = "I am a JS Confirm";
        public static string AlertConfirmOK = "You clicked: Ok";
        public static string AlertConfirmCancel = "You clicked: Cancel";

        public static string AlertPrompt = "I am a JS prompt";
        public static string AlertPromptOK = "You entered: ";
        public static string AlertPromptCancel = "You entered: null";

        //Database
        public static string DatabaseURL = "http://computer-database.gatling.io/computers";
        
        public static string HeaderAdd = "Add a computer";
        public static string HeaderEdit = "Edit computer";
        public static string HeaderFilter = "One computer found";
        public static string HeaderFilters = " computers found";

        public static string AddComputerMessage1 = "Done ! Computer ";
        public static string AddComputerMessageCreated = " has been created";
        public static string AddComputerMessageUpdated = " has been updated";
        public static string AddComputerMessageDeleted = " has been deleted";

        //Database pagination
        public static string Pagination1 = "Displaying ";
        public static string Pagination2 = " to ";
        public static string Pagination3 = " of ";
    }
}
