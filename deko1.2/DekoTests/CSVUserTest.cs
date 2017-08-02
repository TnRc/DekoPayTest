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
    public class CSVUserTest : TestLogic
    {
        //test serializing/deserializing
        //test nonexistent file path
        
        [TestMethod]
        public void CSVUser_ReadUsers_DoesReadJohnDoeCSV()
        {
            var path = "../../testData/reading/CSV/johndoe.csv";

            CSVUser actualUser = new CSVUser();
            List<CSVUser> actual = actualUser.readUsers(path);


            CSVUser expectedUser = new CSVUser()
            {
                UserID = 1,
                FirstName ="John",
                LastName = "Doe",
                Username = "John1",
                UserType = "Employee"
            };         
            List<CSVUser> expected = new List<CSVUser>();
            expected.Add(expectedUser);

            CollectionAssert.Equals(expected, actual);

        }

        [TestMethod]
        public void CSVUser_WriteUsers_DoesWriteJohnDoeCSV()
        {
            const string expectedFile = @"../../testData/writing/expectedData/CSV/johndoe.csv";
            const string actualFile = @"../../testData/writing/actualData/CSV/johndoe.csv";
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

            CollectionAssert.Equals(expectedHash, actualHash);
        }



        //test
        [TestMethod]
        public void TEMP_CompareTwoFiles()
        {
            const string expectedFile = @"../../testData/reading/CSV/johndoe.csv";
            const string actualFile = @"../../testData/reading/CSV/johndoe.csv";

            var expectedHash = GetFileHash(expectedFile);
            var actualHash = GetFileHash(actualFile);

            Assert.AreEqual(expectedFile, actualFile);
        }





        

    }
}
