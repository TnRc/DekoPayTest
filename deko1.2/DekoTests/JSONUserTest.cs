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
    public class JSONUserTest : TestLogic
    {
        [TestMethod]
        public void JSONUser_ReadUsers_DoesReadJohnDoeJSON()
        {
            var path = "../../testData/reading/JSON/johndoe.json";

            JSONUser actualUser = new JSONUser();
            List<JSONUser> actual = actualUser.readUsers(path);


            JSONUser expectedUser = new JSONUser()
            {
                UserID = 1,
                FirstName = "John",
                LastName = "Doe",
                Username = "John1",
                UserType = "Employee"
            };
            List<JSONUser> expected = new List<JSONUser>();
            expected.Add(expectedUser);

            CollectionAssert.Equals(expected, actual);

        }

        [TestMethod]
        public void JSONUser_WriteUsers_DoesWriteJohnDoeJSON()
        {
            const string expectedFile = @"../../testData/writing/expectedData/JSON/johndoe.json";
            const string actualFile = @"../../testData/writing/actualData/JSON/johndoe.json";
            JSONUser user = new JSONUser();

            // prepare expected collection
            List<JSONUser> expected = new List<JSONUser>()
            {
                new JSONUser()
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
