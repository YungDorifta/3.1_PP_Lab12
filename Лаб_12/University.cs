using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//класс "Университет" - контейнер списка элементов класса "Студент" (DONE)


namespace Лаб_12
{
    public class University  : IEnumerable<Student>
    {
        //поля (DONE)
        List<Student> students = new List<Student>();
        int count = 0;


        /// <summary>
        /// Метод вывода на экран списка
        /// </summary>
        public string show()
        {
            string show_university = "";
            for (int i = 0; i < count; i++)
            {
                show_university += students[i].ToString();
                show_university += "\n";
            }
            return show_university;
        }

        /// <summary>
        /// Метод добавления студента в список
        /// </summary>
        /// <param name="S">Добавляемый студент</param>
        public void Add(Student S)
        {
            students.Add(S);
            count++;
        }

        /// <summary>
        /// Метод удаления студента из списка
        /// </summary>
        /// <param name="S">Удаляемый студент</param>
        public void Remove(Student S)
        {
            students.Remove(S);
            count--;
        }




        /// <summary>
        /// Метод сравнения списков
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is University)
            {
                if (this.count != ((University)obj).count) return false;
                for (int i = 0; i < this.count; i++)
                {
                    if (this.students[i] != ((University)obj).students[i]) return false;
                }
                return true;
            }
            else throw new Exception("Объект не является экземпляром класса University!");
        }

        /// <summary>
        /// метод определения уникального хэш-кода для списка
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        /// <summary>
        /// перегрузка метода для перебора списка с помощью цикла foreach
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = 0; i < students.Count; i++) yield return students[i];
        }

        /// <summary>
        /// перегрузка метода для перебора списка с помощью цикла foreach
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < students.Count; i++) yield return students[i];
        }




        //методы сортировки списка разными способами (DONE)
        /// <summary>
        /// сортирует список студентов по их именам
        /// </summary>
        public void SortBySurname()
        {
            students.Sort(new Student.MySurnameComparer());
        }

        /// <summary>
        /// сортирует список список студентов по их росту
        /// </summary>
        public void SortByHeight()
        {
            students.Sort(new Student.MyHeightСomparer());
        }

        /// <summary>
        /// сортирует список список студентов по их весу
        /// </summary>
        public void SortByWeight()
        {
            students.Sort(new Student.MyWeightComparer());
        }

        
        

        //методы по варианту: (DONE)
        /// <summary>
        /// Найти средний рост студента в списке
        /// </summary>
        /// <returns></returns>
        public double find_avg_ht()
        {
            if (this is University)
            {
                double avg_ht = 0;
                for (int i = 0; i < count; i++)
                    avg_ht += students[i].get_height();
                avg_ht /= (double)count;
                return avg_ht;
            }
            else throw new Exception("Объект не является экземпляром класса University!");
        }

        /// <summary>
        /// найти средний рост студента в списке
        /// </summary>
        /// <returns></returns>
        public double find_avg_wt()
        {
            if (this is University)
            {
                double avg_wt = 0;
                for (int i = 0; i < count; i++)
                    avg_wt += students[i].get_weight();
                avg_wt /= (double)count;
                return avg_wt;
            }
            else throw new Exception("Объект не является экземпляром класса University!");
        }

    }
}
