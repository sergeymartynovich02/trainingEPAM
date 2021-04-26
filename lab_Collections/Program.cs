using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace lab_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var st1 = new Students
                {
                    Weight = 85,
                    Height = 181,
                    FirstName = "Сергей ",
                    LastName = "Мартынович ",
                    University = "BrSTU"
                };
                var st2 = new Students
                {
                    Weight = 64,
                    Height = 186,
                    FirstName = "Алексей ",
                    LastName = "Зинович ",
                    University = "BSTU "
                };
                var st3 = new Students
                {
                    Weight = 71,
                    Height = 181,
                    FirstName = "Петров ",
                    LastName = "Владимир ",
                    University = "BrSTU "
                };
                var st4 = new Students
                {
                    Weight = 78,
                    Height = 181,
                    FirstName = "Александр ",
                    LastName = "Карабан ",
                    University = "BSEU "
                };
                var st5 = new Students
                {
                    Weight = 81,
                    Height = 0,
                    FirstName = "Данные отсутствуют ",
                    LastName = "Данные отсутствуют ",
                    University = "BrSTU "
                };
                var pu1 = new Pupils
                {
                    Weight = 67,
                    Height = 0,
                    FirstName = "Данные отсутствуют ",
                    LastName = "Данные отсутствуют ",
                    Averagescore = 9.1
                };
                var pu2 = new Pupils
                {
                    Weight = 67,
                    Height = 190,
                    FirstName = "Денис ",
                    LastName = "Зыб  ",
                    Averagescore = 8.4
                };
                var pu3 = new Pupils
                {
                    Weight = 55,
                    Height = 172,
                    FirstName = "Иван ",
                    LastName = "Климов ",
                    Averagescore = 8.2
                };
                var container1 = new HumanContainer<Human> { st1, pu1, st2, pu2, st3, st4, st5, pu3 };

                foreach (var human in container1)
                {
                    Console.WriteLine(human.ToString());
                }


                var list = new List<HumanContainer<Human>>();
                list.Add(container1);

                //OrderBy
                Console.WriteLine("\nLinq To objects: OrderBy by Weight");
                var orderRes = container1.OrderBy(h => h.Weight);
                foreach (var human in orderRes)
                    Console.WriteLine(human);


                //Select
                Console.WriteLine("\nLinq To objects: Select");
                var selectRes = container1.Select((h, i) => new { Index = i + 1, h.FullName });
                foreach (var el in selectRes)
                    Console.WriteLine(el);


                //First
                Console.WriteLine("\nLinq To objects: First");
                var firstRes = container1.First(h => h.FullName.Length > 12);
                Console.WriteLine(firstRes);


                //Минимальная коллекция по заданному полю
                Console.WriteLine("\nLinq To objects: Min Weight");
                var minRes = container1.Min(h => h.Weight);
                Console.WriteLine(minRes);

                //Максимальная коллекция по заданному полю
                Console.WriteLine("\nLinq To objects: Max Weight");
                var maxRes = container1.Max(h => h.Weight);
                Console.WriteLine(maxRes);

                ///Количество коллекций, содержащих только 2 элемента 
                Console.WriteLine("\nLinq To objects: Number of collections with only 2 elements");
                var TwoElem = container1.Count(h => h.FirstName == "Данные отсутствуют " && h.LastName == "Данные отсутствуют " && h.Height == 0);
                Console.WriteLine(TwoElem);
                container1.WriteToFile();
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();

        }
    }

    public class HumanContainer<T> : IEnumerable<T> where T : Human
    {
        #region Fields
        private readonly List<T> _container;
        #endregion
        #region Constructors
        public HumanContainer()
        {
            _container = new List<T>();
        }
        #endregion
        #region Properties
        public int Count
        {
            get { return _container.Count; }
        }
        #endregion
        #region Indexers
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _container[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _container[index] = value;
            }
        }
        #endregion
        #region Methods
        public T GetByName(string name)
        {
            return _container.FirstOrDefault(h => string.Compare(h.FirstName, name, StringComparison.InvariantCultureIgnoreCase) == 0);

        }
        public void Add(T human)
        {
            _container.Add(human);
        }
        public T Remove(T human)
        {
            var element = _container.FirstOrDefault(h => h == human);
            if (element != null)
            {
                _container.Remove(element);
                return element;
            }
            throw new NullReferenceException();
        }

        public void WriteToFile()
        {
            using (var File = new StreamWriter(Path.GetFullPath("Outlet.txt")))
            {
                foreach (var item in _container)
                {

                    File.Write("Имя: " + item.FirstName + "\n");
                    File.Write("Фамилия: " + item.LastName + "\n");
                    File.Write("Рост: " + item.Height + "\n");
                    File.Write("Вес: " + item.Weight + "\n");
                    File.Write("----------------------------" + "\n");

                }
                File.Dispose();
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _container.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
    #endregion

}
