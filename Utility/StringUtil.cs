namespace DTH.App.Utility
{
    public static class StringUtil
    {
        /// <summary>
        /// Returns the numerical substring of the passed address parameter.
        /// A malformed address string will instead return the first 8 characters of a new Guid. 
        /// </summary>
        /// <param name="address">string</param>
        /// <returns>string</returns>
        public static string CreateAddressSubstring(string? address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return CreateGuidSubstring();
            }
            int lastAlphaIndex = GetIndexOfFirstAlpha(address);
            if (lastAlphaIndex <= 1)
            {
                return CreateGuidSubstring();
            }
            return address.Substring(0, lastAlphaIndex - 1);
        }

        /// <summary>
        /// Gets the index of the first alpha character in a string.
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>int</returns>
        public static int GetIndexOfFirstAlpha(string s)
        {
            return s.IndexOf(s.FirstOrDefault(char.IsLetter));
        }

        /// <summary>
        /// Returns the first 8 character of a new Guid.
        /// </summary>
        /// <returns>string</returns>
        public static string CreateGuidSubstring()
        {
            return Guid.NewGuid().ToString().Split('-')[0];
        }

        /// <summary>
        /// Removes all whitespace from a string.
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>string</returns>
        public static string RemoveWhitespace(string s)
        {
            return s.Replace(" ", "");
        }

        public static string RemoveSpecialCharacters(this string s)
        {
            return s.Replace("'", "");
        }
    }
}
