using System;
using System.IO;

namespace FileReader
{
    public class ValidateInput
    {
        public string Validate(string[] input)
        {
            string path = null;

            if (input == null || input.Length == 0)
            {
                return path;
            }

            try
            {
                var fileInfo = new FileInfo(input[0]);
            }
            catch (Exception)
            {
                //TODO Not a valid path
                return null;
            }

            //TODO
            path = input[0];
            return path;
        }
    }
}
