using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileReader;
using System.IO;
using System.Reflection;

namespace TestFileReader
{
    [TestClass]
    public class UnitTestFileReader
    {
        private string file0 = @".txt";
        private string file1 = @"testtext.txt";
        private string file2 = @"≈ƒ÷Â‰ˆ.gfdgdf2.txt";
        private string file3 = @"gdrfbfd.txt";

        // TODO Validate whole program seq.

        [TestMethod]
        public void RunFullSeqTrue()
        {
            // Arrange
            string fullPath = CreatePath(file1);
            string[] args = new string[] { fullPath };

            // Act
            bool success = new FileReader.FileReader().Run(args);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void RunFilePathValidatePathIsNotNull()
        {
            // Arrange
            string fullPath = CreatePath(file1);
            string[] args = new string[] { fullPath };

            // Act
            var validatedArgs = new ValidateInput().Validate(args);
            // Assert
            Assert.IsNotNull(validatedArgs);
        }

        [TestMethod]
        public void RunFilePathValidatePathNoArguments()
        {
            // Arrange
            string[] args = new string[] { };

            // Act
            var validatedArgs = new ValidateInput().Validate(args);

            // Assert
            Assert.IsNull(validatedArgs);
        }

        [TestMethod]
        public void RunFilePathValidatePathInvalidArguments()
        {
            // Arrange
            string[] args = new string[] { };

            // Act
            var validatedArgs = new ValidateInput().Validate(args);

            // Assert
            Assert.IsNull(validatedArgs);
        }

        [TestMethod]
        public void RunFilePathValidatePathIsIncorrect()
        {
            // Arrange
            string[] args = new string[] { @"c:\.fsdgfsd\sd&*-&\*.txt" };

            // Act
            var validatedArgs = new ValidateInput().Validate(args);

            // Assert
            Assert.IsNull(validatedArgs);
        }

        [TestMethod]
        public void RunFilePathValidateResultZero()
        {
            // Arrange
            var fileHandler = new FileHandler();
            string fullPath = CreatePath(file0);

            // Act
            var result = fileHandler.Run(fullPath);

            // Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void RunFilePathValidateResultOne()
        {
            // Arrange
            var fileHandler = new FileHandler();
            string fullPath = CreatePath(file1);

            // Act
            var result = fileHandler.Run(fullPath);

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void RunFilePathValidateResultTwo()
        {
            // Arrange
            var fileHandler = new FileHandler();
            string fullPath = CreatePath(file2);

            // Act
            var result = fileHandler.Run(fullPath);

            // Assert
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void RunFilePathValidateResultThree()
        {
            // Arrange
            var fileHandler = new FileHandler();
            string fullPath = CreatePath(file3);

            // Act
            var result = fileHandler.Run(fullPath);

            // Assert
            Assert.AreEqual(result, 3);
        }

        private static string CreatePath(string file)
        {
            var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] paths = { folder, file };
            return Path.Combine(paths);
        }
    }
}
