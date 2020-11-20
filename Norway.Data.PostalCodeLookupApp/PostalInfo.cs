using System;

namespace Norway.Data.PostalCodeLookupApp
{
    public class PostalInfo
    {
        public string RawData { get; private set; }

        public string PostalNumber { get; set; }
        public string PostalTown { get; set; }
        public string KommuneKode { get; set; }
        public string CountyCode { get; set; }
        public string KommuneName { get; set; }
        public string Category { get; set; }

        public static PostalInfo Parse(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException("Cannot be empty.", nameof(s));
            }

            var tokens = s.Split('\t');
            if (tokens.Length != 5)
            {
                throw new PafException("The PAF entry does not contain the expected number of fields.");
            }

            var postNumber = tokens[0];
            var postTown = tokens[1];
            var kommuneInfo = tokens[2];
            var kommuneName = tokens[3];
            var category = tokens[4];

            return new PostalInfo()
            {
                RawData = s,
                PostalNumber = postNumber,
                PostalTown = postTown,
                KommuneKode = kommuneInfo.Substring(2, 2),
                CountyCode = kommuneInfo.Substring(0, 2),
                KommuneName = kommuneName,
                Category = category
            };
        }

        public override string ToString()
        {
            return RawData.Replace('\t', ' ');
        }
    }

}
