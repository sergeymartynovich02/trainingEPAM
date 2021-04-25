using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_Collections
{
    public class Pupils : Human
    {
        #region Properties
        public double Averagescore { get; set; }
        #endregion
        #region Methods
        public void DoWord() { }
        public override string ToString()
        {
            return string.Format("Класс Pupil: \nПолное имя: {0}, Рост: {1}, Вес: {2}, Средний балл: {3}",
                FullName,
                Height,
                Weight,
                Averagescore);
        }
    }
}
#endregion