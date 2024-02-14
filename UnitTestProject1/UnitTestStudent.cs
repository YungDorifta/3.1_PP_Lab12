using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Лаб_12;


//Тест класса Student


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestStudent
    {
        [TestMethod]
        public void Test1()
        {
            Student a = new Student("Костя", 3, 66.1, 187);
            Student b = new Student("Ваня", 4, 71, 170);
            bool actual = a > b;
            bool expected = true;
            Assert.AreEqual(expected, actual, "Операция '>' неверна!");
        }

        [TestMethod]
        public void Test2()
        {
            Student a = new Student("Костя", 3, 66.1, 187);
            Student b = new Student("Саша", 3, 45.1, 137);
            bool actual = a <= b;
            bool expected = false;
            Assert.AreEqual(expected, actual, "Операция '<=' неверна!");
        }
    }
}
