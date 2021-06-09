using System;
using System.IO;

namespace FileReader
{
    public class ValidateInput
    {
        public string Validate(string[] args)
        {
            string path = null;

            try
            {
                if (args == null || args.Length == 0)
                {
                    throw new ArgumentNullException(nameof(args), "Missing arguments.");
                }

                if (Path.GetFileName(args[0]).IndexOfAny(Path.GetInvalidFileNameChars()) == -1)
                {
                    path = args[0];
                }
                else
                {
                    throw new IOException("The filename contains invalid characters.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Validation of input args failed: " + ex.Message);
                return null;
            }

            return path;
        }
    }
}
