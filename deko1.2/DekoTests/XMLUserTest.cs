using deko1._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekoTests
{
    [TestClass]
    public class XMLUserTest : TestLogic
    {
        [TestMethod]
        public void XMLUser_ReadUsers_DoesReadJohnDoeXML()
        {
            var path = "../../testData/reading/XML/johndoe.xml";

            XMLUser actualUser = new XMLUser();
            List<XMLUser> actual = actualUser.readUsers(path);


            XMLUser expectedUser = new XMLUser()
            {
                UserID = 1,
                FirstName = "John",
                LastName = "Doe",
                Username = "John1",
                UserType = "Employee"
            };
            List<XMLUser> expected = new List<XMLUser>();
            expected.Add(expectedUser);

            CollectionAssert.Equals(expected, actual);

        }

        [TestMethod]
        public void XMLUser_WriteUsers_DoesWriteJohnDoeXML()
        {
            const string expectedFile = @"../../testData/writing/expectedData/XML/johndoe.xml";
            const string actualFile = @"../../testData/writing/actualData/XML/johndoe.xml";
            XMLUser user = new XMLUser();

            // prepare expected collection
            List<XMLUser> expected = new List<XMLUser>()
            {
                new XMLUser()
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
    }
}
