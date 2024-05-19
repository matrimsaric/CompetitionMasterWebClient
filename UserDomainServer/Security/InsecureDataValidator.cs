using System.Globalization;
using System.Text.RegularExpressions;

namespace UserDomainServer.Security
{
    public static class InsecureDataValidator
    {
        /// <summary>
        /// Use when incorrect incoming text is not intended to stop operation.
        /// Not to be used for parameter validation.
        /// </summary>
        /// <param name="usIncoming"></param>
        /// <returns></returns>
        public static string SecureStringAlphaNumericSpace(string usIncoming)
        {
            string sIncoming = Regex.Replace(usIncoming, @"[^a-zA-Z0-9\s]", string.Empty);

            return sIncoming;
        }

        /// <summary>
        /// Use for Immutable object check. If result of validation is not a valid object
        /// then this throws a 500 error with message indicating an InvalidParameter
        /// </summary>
        /// <param name="usIncoming"></param>
        /// <returns></returns>
        //public static string ValidateImmutableStringAlphaNumericSpace(string usIncoming)
        //{
        //    var comp = SecureStringAlphaNumericSpace(usIncoming);
        //    if (comp != usIncoming) throw new HttpRequestException($"Invalid Parameter: {usIncoming} ");

        //    return comp;
        //}

        public static bool SecureStringSqlColumn(string usIncoming, out string sIncoming)
        {
            Regex regex = new Regex("[^a-zA-Z0-9_]");
            sIncoming = regex.Replace(usIncoming, "_");//number and letters only(-)\1{1}", "_"

            if (sIncoming.Equals(usIncoming)) return true;
            else return false;


        }



        //public static string ValidateStringAlphaNumericDash(string usIncoming)
        //{
        //    if (string.IsNullOrEmpty(usIncoming))
        //    {
        //        // if null or empty then passes security check DAFR-2514
        //        return usIncoming;
        //    }
        //    if (Regex.IsMatch(usIncoming, @"(-)\1{1}"))
        //        throw new HttpRequestException($"Invalid Parameter: {usIncoming} ");

        //    bool matched = Regex.IsMatch(usIncoming, @"^[\w_]*$");

        //    if (!matched)
        //        throw new HttpRequestException($"Invalid Parameter: {usIncoming} ");

        //    return usIncoming;
        //}

        //public static string ValidateSqlColumn(string usIncoming)
        //{
        //    // internal method, strips characters that are illegal for sql only permitting 
        //    // character, numbers, drops to lower case as per sql requirements
        //    // and removes all spaces. left brackets replaced with underscore
        //    if (string.IsNullOrEmpty(usIncoming))
        //    {
        //        // if null or empty then passes security check DAFR-2514
        //        return usIncoming;
        //    }
        //    usIncoming = usIncoming.Trim();
        //    string sIncoming = usIncoming.ToLower().Replace(" ", "_");// all lower case, no spaces
        //    Regex regex = new Regex("[^a-zA-Z0-9_]");
        //    sIncoming = regex.Replace(sIncoming, "_");//number and letters only(-)\1{1}", "_"

        //    return sIncoming;
        //}

        //public static bool ValidateSqlName(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return false;

        //    return Regex.IsMatch(name, @"^[\w_]*$");
        //}

        //public static string ValidateStringAlphaNumericDashUnderscoreSpace(string usIncoming, bool accptNull = false)
        //{
        //    if (string.IsNullOrEmpty(usIncoming) && accptNull)
        //    {
        //        // if null or empty then passes security check DPIM-8669
        //        return usIncoming;
        //    }
        //    if (Regex.IsMatch(usIncoming, @"(-)\1{1}"))
        //        throw new HttpRequestException($"Invalid Parameter: {usIncoming} ");

        //    bool matched = Regex.IsMatch(usIncoming, @"^[\w_\-\s]*$");

        //    if (!matched)
        //        throw new HttpRequestException($"Invalid Parameter: {usIncoming} ");

        //    return usIncoming;
        //}

        ///// <summary>
        ///// seperate method in case needs changing (called a lot)
        ///// allows easier adjustment moving forward.
        ///// </summary>
        ///// <param name="usIncoming"></param>
        ///// <returns></returns>
        //public static string ValidateFieldId(string usIncoming)
        //{
        //    return ValidateStringAlphaNumericDash(usIncoming);
        //}

        //public static string ValidateCulture(string usIncomingCultureCode)
        //{
        //    if (CultureInfo.GetCultures(CultureTypes.AllCultures).Any(culture => string.Equals(culture.Name,
        //        usIncomingCultureCode, StringComparison.CurrentCultureIgnoreCase)) == true)
        //    {
        //        return usIncomingCultureCode;
        //    }
        //    return String.Empty;
        //}


    }
}
