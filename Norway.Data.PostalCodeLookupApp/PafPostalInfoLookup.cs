using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Norway.Data.PostalCodeLookupApp
{
    public class PafPostalInfoLookup : IPostalInfoLookup
    {
        private readonly string _pafFilePath;
        private IEnumerable<PostalInfo> _pafData;

        public PafPostalInfoLookup(string pafFilePath)
        {
            _pafFilePath = pafFilePath;
        }

        public PostalInfo Lookup(string postalCode)
        {
            if (_pafData == null)
            {
                LoadPafdata();
            }

            return _pafData.FirstOrDefault(x => x.PostalNumber == postalCode);
        }

        private void LoadPafdata()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var pafEncoding = Encoding.GetEncoding(1252); // windows-1252
            var pafEntries = new List<PostalInfo>();

            using (var reader = new StreamReader(_pafFilePath, pafEncoding))
            {
                do
                {
                    var line = reader.ReadLine();
                    var p = PostalInfo.Parse(line);

                    pafEntries.Add(p);

                } while (!reader.EndOfStream);
            }

            _pafData = pafEntries;
        }
    }

}
