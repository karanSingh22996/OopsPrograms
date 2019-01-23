//-----------------------------------------------------------------------
// <copyright file=" RegularExpression.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Text.RegularExpressions;
    /// <summary>
    /// This class will provide information about the details by taking user input name and mmobile number
    /// </summary>
    class RegularExpression
    {
        /// <summary>
        /// Retrieves the information.
        /// </summary>
        public void RetrieveInfo()
        {
            ////Taking user input for first name
            Console.WriteLine("Enter your First name");
            string fname = Console.ReadLine();
            ////Taking user input for last name
            Console.WriteLine("Enter your Last name");
            string lname = Console.ReadLine();
            ////Taking user input for mobile
            Console.WriteLine("Enter your mobile number");
            string mno = Console.ReadLine();
            ////creating object of dateTime class to calculate current date
            DateTime thisDay = DateTime.Today;
            ////storing current date in date variable
            string date = thisDay.ToString("d");
            ////The sentence in which we have to make changes
            string message = "Hello <<name>>, We have your full name as <<full name>> in our system your contact number is <<91-xxxxxxxxx>>, Please,let us know in case of any clarification Thank you BridgeLabz <<dd/mm/yyyy>>.";
            ////pattern for change inside the string
            string patternForName = "<<name>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpression.showMatch(message, fname, patternForName);
            ////Pattern for changing full name from the sentence       
            string patternForfame = "<<full name>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpression.showMatch(message, fname + " " +lname, patternForfame);
            ////Pattern for changing mobile number from the sentence   
            string contactNumber = "<<91-xxxxxxxxx>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpression.showMatch(message,"91"+" "+ mno, contactNumber);
            ////Pattern for changing Currrent date from the sentence   
            string Currentdate = "<<dd/mm/yyyy>>";
            DateTime today = DateTime.Today;
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpression.showMatch(message, today.ToString(), Currentdate);
            
            Console.WriteLine(message);

        }
        /// <summary>
        /// Shows the match.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="expr">The expr.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>string</returns>
        public static string showMatch(string text, string expr, string pattern)
        {
            ////creating regex class object for passing pattern
            Regex rgx = new Regex(pattern);
            string newString = rgx.Replace(text, expr);
            return newString;
        }
    }
}
