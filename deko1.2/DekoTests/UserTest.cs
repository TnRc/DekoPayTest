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
    public class UserTest
    {
        [TestMethod]
        public void User_SortUsersAsc_DoesSortUsersAsc()
        {
            //Arrnage
            User user = new User();
            List<User> result = new List<User>();
            User rUser2 = new User(2);
            result.Add(rUser2);

            User rUser3 = new User(3);
            result.Add(rUser3);

            User rUser1 = new User(1);
            result.Add(rUser1);

            //Act
            user.sortUsersAsc(result);
            var expected = new List<User>();
            User eUser1 = new User(1);
            expected.Add(eUser1);

            User eUser2 = new User(2);
            expected.Add(eUser2);

            User eUser3 = new User(3);
            expected.Add(eUser3);

            //Assert
            CollectionAssert.AreEqual(expected, result);

        }

    }
}
