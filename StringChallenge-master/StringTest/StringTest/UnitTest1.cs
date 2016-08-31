using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace StringTest
{

    [TestClass]
    public class UnitTest1
    {
        public string FirstName(string fullName)
        {
            string[] splitArray = fullName.Split(' ');

            string firstName;


            if (splitArray.Count() == 3)
            {
                firstName = splitArray[0] + " " + splitArray[1];
            }
            else
            {
                firstName = splitArray[0];
            }


            return firstName;
        }


        public string LastName(string fullName)
        {
            string[] splitArray = fullName.Split(' ');


            string lastName;


            if (splitArray.Count() == 1)
            {
                lastName = splitArray[0];
            }
            else if (splitArray.Count() == 3)
            {
                lastName = splitArray[2];
            }
            else
            {
                lastName = splitArray[1];
            }


            return lastName;
        }


        [TestMethod]
        public void TestFirstName()
        {
            Assert.AreEqual("Daniel", FirstName("Daniel Pollock"));
        }



        [TestMethod]
        public void TestLastName()
        {
            Assert.AreEqual("Pollock", LastName("Daniel Pollock"));
        }

        [TestMethod]
        public void TestOneWordName()
        {
            Assert.AreEqual("Moby", FirstName("Moby"));
            Assert.AreEqual("Moby", LastName("Moby"));
        }



        [TestMethod]
        public void TestThreeWordName()
        {
            Assert.AreEqual("John Quincy", FirstName("John Quincy Adams"));
            Assert.AreEqual("Adams", LastName("John Quincy Adams"));
        }

        [TestMethod]
        public void TestNoWordName()
        {
            Assert.AreEqual("", FirstName(""));
            Assert.AreEqual("", LastName(""));
        }
    }


}

