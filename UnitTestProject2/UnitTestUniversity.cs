using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Лаб_12;

//тест класса University (список объектов Student) 

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestUniversity
    {
        [TestMethod]
        public void TestMethodAverageHeight()
        {
            University U1 = new University();
            Student Ivan = new Student("Ваня", 2, 45.5, 140);
            Student Konstantin = new Student("Костя", 3, 62, 169);
            Student Alexander = new Student("Саша", 1, 77, 173.7);
            U1.Add(Ivan);
            U1.Add(Konstantin);
            U1.Add(Alexander);
            double actual = U1.find_avg_ht();
            double expected = 160.9;
            Assert.AreEqual(expected, actual, "Вычисление среднего роста прошло неудачно!");
        }

        [TestMethod]
        public void TestMethodAverageWeight()
        {
            University U1 = new University();
            Student Ivan = new Student("Ваня", 2, 45.5, 140);
            Student Konstantin = new Student("Костя", 3, 62, 169);
            Student Alexander = new Student("Саша", 1, 77, 173.7);
            U1.Add(Ivan);
            U1.Add(Konstantin);
            U1.Add(Alexander);
            double actual = U1.find_avg_wt();
            double expected = 61.5;
            Assert.AreEqual(expected, actual, "Вычисление среднего роста прошло неудачно!");
        }
    }
}
