//-----------------------------------------------------------------------
// <copyright file="RegularExpression.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class will provide information about the details by taking user input name and mobile number
    /// </summary>
    public class RegularExpression
    {
        /// <summary>
        /// Shows the match.
        /// </summary>
        /// <param name="text">The text of string </param>
        /// <param name="expr">The expressions of string </param>
        /// <param name="pattern">The pattern of string</param>
        /// <returns>string return type</returns>
        public static string ShowMatch(string text, string expr, string pattern)
        {
            ////creating regex class object for passing pattern
            Regex rgx = new Regex(pattern);
            string newString = rgx.Replace(text, expr);
            return newString;
        }

        /// <summary>
        /// Operations this instance.
        /// </summary>
        public void Operation()
        {
            this.ReadData();
        }

        /// <summary>
        /// Retrieves the information.
        /// </summary>
        /// <param name="fname"> The first name string </param>
        /// <param name="lname"> The last name string  </param>
        /// <param name="mno"> The mobile no string </param>
        /// <param name="date"> The date string </param>
        public void RetrieveInfo(string fname, string lname, string mno, string date)
        {
            try
            {
                ////The sentence in which we have to make changes
                string message = "Hello <<name>>, We have your full name as <<full name>> in our system your contact number is <<91-xxxxxxxxx>>, Please,let us know in case of any clarification Thank you BridgeLabz <<dd/mm/yyyy>>.";
                ////pattern for change inside the string
                string patternForName = "<<name>>";
                ////using showmatch static method of regularexexpression class to replace the pattern with valid data
                message = RegularExpression.ShowMatch(message, fname, patternForName);
                ////Pattern for changing full name from the sentence       
                string patternForfame = "<<full name>>";
                ////using showmatch static method of regularexexpression class to replace the pattern with valid data
                message = RegularExpression.ShowMatch(message, fname + " " + lname, patternForfame);
                ////Pattern for changing mobile number from the sentence   
                string contactNumber = "<<91-xxxxxxxxx>>";
                ////using showmatch static method of regularexexpression class to replace the pattern with valid data
                message = RegularExpression.ShowMatch(message, "91" + " " + mno, contactNumber);
                ////Pattern for changing Currrent date from the sentence   
                string currentdate = "<<dd/mm/yyyy>>";
                DateTime today = DateTime.Today;
                ////using showmatch static method of regularexexpression class to replace the pattern with valid data
                message = RegularExpression.ShowMatch(message, today.ToString(), currentdate);

                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Reads the data.
        /// </summary>
        public void ReadData()
        {
            try
            {
                ////Taking user input for first name
                Console.WriteLine("Enter your First name");
                string fname = Console.ReadLine();
                ////Taking user input for last name
                Console.WriteLine("Enter your Last name");
                string lname = Console.ReadLine();
                ////Taking user input for mobile
                Console.WriteLine("Enter your mobile number");
                string mobineno = Console.ReadLine();
                ////creating object of dateTime class to calculate current date
                DateTime thisDay = DateTime.Today;
                ////storing current date in date variable
                string date = thisDay.ToString("d");
                if (Regex.IsMatch(mobineno, @"[0-9]{10}") && Regex.IsMatch(fname, @"[a-zA-z]") && Regex.IsMatch(lname, @"[a-zA-z]"))
                {
                    this.RetrieveInfo(fname, lname, mobineno, date);
                }
                else
                {
                    Console.WriteLine("Data is invalid,Try again");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
