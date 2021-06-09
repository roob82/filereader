using System;

namespace FileReader
{
    public class FileReader
    {
        public bool Run(string[] args)
        {
            var validatedPath = new ValidateInput().Validate(args);

            if (validatedPath != null)
            {
                var matches = new FileHandler().Run(validatedPath);

                if (matches != null)
                {
                    Console.WriteLine($"Found {matches} matching pattern");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to read file.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No file path included, program will exit.");
                return false;
            }
        }
    }
}