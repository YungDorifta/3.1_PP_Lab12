using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Лаб_12;


//Тест сравнения и методов по варианту (DONE)


namespace UnitTestProject1
{
    
    [TestClass]
    public class UnitTestMethods
    {
        /// <summary>
        /// Тест сравнения объектов 1
        /// </summary>
        [TestMethod]
        public void TestCompare1()
        {
            Student a = new Student("Костя", 3, 66.1, 187);
            Student b = new Student("Ваня", 4, 71, 170);
            bool actual = a > b;
            bool expected = true;
            Assert.AreEqual(expected, actual, "Операция '>' неверна!");
        }

        /// <summary>
        /// Тест сравнения объектов 2
        /// </summary>
        [TestMethod]
        public void TestCompare2()
        {
            Student a = new Student("Костя", 3, 66.1, 187);
            Student b = new Student("Саша", 3, 45.1, 137);
            bool actual = a <= b;
            bool expected = false;
            Assert.AreEqual(expected, actual, "Операция '<=' неверна!");
        }

        /// <summary>
        /// Тест метода нахождения среднего роста
        /// </summary>
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

            /// <summary>
            /// Тест метода нахождения среднего веса
            /// </summary>
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
}
