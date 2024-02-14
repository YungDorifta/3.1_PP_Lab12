using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//класс "студент" (DONE)


namespace Лаб_12
{
    public class Student : IComparable
    {
        //поля (DONE)
        string surname;
        int group;
        double weight;
        double height;
        


        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Student() { }

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="n">ФИО</param>
        /// <param name="g">Группа</param>
        /// <param name="w">Вес</param>
        /// <param name="h">Рост</param>
        public Student(string n, int g, double w, double h)
        {
            surname = String.Format("{0,-15}", n);
            group = g;
            weight = w;
            height = h;
            
        }

        /// <summary>
        /// Преобразование объекта в строку
        /// </summary>
        /// <returns>Строка с информацией об объекте</returns>
        public override string ToString()
        {
            return (surname + "\t" + group + "\t" + weight + "\t" + height );
        }
        
        /// <summary>
        /// Проверка на равенство двух объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                if (surname == ((Student)obj).surname && group == ((Student)obj).group && height == ((Student)obj).height && weight == ((Student)obj).weight) return true;
                else return false;
            }
            else throw new Exception("Объект не является студентом!");
        }

        /// <summary>
        /// Определение уникального Хэш-кода для объекта
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return surname.GetHashCode();
        }
        
        /// <summary>
        /// Сравнение объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Student))
                throw new ArgumentException("Объект не является студентом!");
            if (height > ((Student)obj).height) return 1;
            if (height < ((Student)obj).height) return -1;
            return 0;
        }
        


        //перегрузка операторов равенства/неравенства (DONE)
        public static bool operator ==(Student a1, Student a2)
        {
            return a1.Equals(a2);
        }

        public static bool operator !=(Student a1, Student a2)
        {
            return !(a1.Equals(a2));
        }



        //перегрузка операторов сравнения (DONE)
        public static bool operator >(Student a1, Student a2)
        {
            return a1.CompareTo(a2) > 0;
        }

        public static bool operator >=(Student a1, Student a2)
        {
            return a1.CompareTo(a2) >= 0;
        }

        public static bool operator <(Student a1, Student a2)
        {
            return a1.CompareTo(a2) < 0;
        }

        public static bool operator <=(Student a1, Student a2)
        {
            return a1.CompareTo(a2) <= 0;
        }



        //сортировка по критериям объекта
        /// <summary>
        /// Сортировка по имени студента
        /// </summary>
        public class MySurnameComparer : IComparer<Student> 
        {
            public int Compare(Student obj1, Student obj2)
            {
                return String.Compare(obj1.surname, obj2.surname);
            }
        }

        /// <summary>
        /// Сортировка по росту студента
        /// </summary>
        public class MyHeightСomparer : IComparer<Student>
        {
            public int Compare(Student obj1, Student obj2)
            {
                if (obj1.height < obj2.height) return 1;
                if (obj1.height > obj2.height) return -1;
                return 0;
            }
        }

        /// <summary>
        /// Сортировка по весу студента
        /// </summary>
        public class MyWeightComparer : IComparer<Student>
        {
            public int Compare(Student obj1, Student obj2)
            {
                if (obj1.weight < obj2.weight) return 1;
                if (obj1.weight > obj2.weight) return -1;
                return 0;
            }
        }


        //геттеры (DONE)
        /// <summary>
        /// Геттер роста студента
        /// </summary>
        /// <returns></returns>
        public double get_height()
        {
            return height;
        }

        /// <summary>
        /// Геттер веса студента
        /// </summary>
        /// <returns></returns>
        public double get_weight()
        {
            return weight;
        }

    }
}
