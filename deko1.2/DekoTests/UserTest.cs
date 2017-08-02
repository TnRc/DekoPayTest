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
        //tests
            //merging user lists
            //sorting user list
            


        [TestMethod]
        public void User_sortUsersAsc_DoesSortUsersAsc()
        {
            //Arrnage
            User user = new User();
            List<User> actual = new List<User>();
            List<User> expected = new List<User>();

            User user1 = new User() { UserID = 1 };
            User user2 = new User() { UserID = 2 };
            User user3 = new User() { UserID = 3 };

            actual.Add(user2);
            actual.Add(user3);
            actual.Add(user1);

            expected.Add(user1);
            expected.Add(user2);
            expected.Add(user3);

            //Act
            user.sortUsersAsc(actual);
            
            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void User_mergeUsers_DoesMergeUsers()
        {
            User u = new User();
            List<User> expected = new List<User>();
            List<CSVUser> cUser = new List<CSVUser>();
            List<JSONUser> jUser = new List<JSONUser>();
            List<XMLUser> xUser = new List<XMLUser>();


            CSVUser john = new CSVUser()
            {
                UserID = 1,
                FirstName = "John",
                LastName = "Doe",
                Username = "John1",
                UserType = "Employee"
            };

            JSONUser mary = new JSONUser()
            {
                UserID = 2,
                FirstName = "Mary",
                LastName = "Jane",
                Username = "Mary23",
                UserType = "Employee"
            };

            XMLUser david = new XMLUser()
            {
                UserID = 3,
                FirstName = "David",
                LastName = "Payne",
                Username = "DPayne",
                UserType = "Manager"
            };

            expected.Add(john);
            expected.Add(mary);
            expected.Add(david);

            cUser.Add(john);
            jUser.Add(mary);
            xUser.Add(david);
            
            List<User> actual = u.mergeUsers(cUser, jUser, xUser);

            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
