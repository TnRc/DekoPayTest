using deko1._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DekoTests
{
    [TestClass]
    public class CSVUserTest : User
    {
        //test serializing/deserializing
        //test nonexistent file path
        //add try catch block




        //[TestMethod]
        //public void CSVUsertTest_ReadUsers_DoesReadJohnDoeCSV()
        //{
        //    //Arrange
        //    User u = new User(1, "John", "Doe", "John1", "Employee");


        //    CSVUser user = new CSVUser();
        //    var path = "../../testData/johndoe.csv";

        //    //Act
        //    List<CSVUser> result = user.readUsers(path);
        //    List<CSVUser> expected = new List<CSVUser>();
        //    expected.Add(u);


        //    //Assert
        //    Assert.AreEqual(expected, result);

        //}

        [TestMethod]
        public void CSVUser_WriteUsers_DoesWriteJohnDoeCSV()
        {
            const string expectedFile = @"../../../DekoTests/testData/expectedData/johndoe.csv";
            const string actualFile = @"../../../DekoTests/testData/actualData/johndoe.csv";
            CSVUser user = new CSVUser();

            // prepare expected collection
            List<CSVUser> expected = new List<CSVUser>()
            {
                new CSVUser()
                {
                    UserID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Username = "John1",
                    UserType = "Employee"
                    //LastLoginTime = 12/01/2015 12:01:34
                }
            };


            user.writeUsers(expected, expectedFile);

            var expectedHash = GetFileHash(expectedFile);
            var actualHash = GetFileHash(actualFile);

            Assert.AreEqual(expectedHash, actualHash);
        }




        [TestMethod]
        public void CompareTwoFiles()
        {
            const string expectedFile = @"../../../DekoTests/testData/expectedData/johndoe.csv";
            const string actualFile = @"../../../DekoTests/testData/actualData/johndoe.csv";

            var expectedHash = GetFileHash(expectedFile);
            var actualHash = GetFileHash(actualFile);

            Assert.AreEqual(expectedFile, actualFile);
        }





        public string GetFileHash(string filename)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(filename);
            var hashedBytes = hash.ComputeHash(clearBytes);
            return ConvertBytesToHex(hashedBytes);
        }

        public string ConvertBytesToHex(byte[] bytes)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }

    }
}
