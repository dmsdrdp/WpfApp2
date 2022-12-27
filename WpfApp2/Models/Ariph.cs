using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2.Models
{
    static class Ariph
        //класс расчета данных с дисплея
    {

        public static double Result(string display)      // Калькулятор
        {
            var a = 0;
            try
            {
                var dataTable = new DataTable();
                var value = dataTable.Compute(display, "");
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return a;
            }

        }

        public static double Squared(string display)     // Возведение в квадрат
        {
            var dataTable = new DataTable();
            var a = 0;
            try
            {
                var value = Convert.ToDouble(display) * Convert.ToDouble(display);
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return a;
            }
            
        }

        public static double SquareRoot(string display)     // Корень квадратный
        {
            var a = 0;
            var dataTable = new DataTable();
            try
            {
              var value = Math.Sqrt(Convert.ToDouble(display));
                return Convert.ToDouble(value);
            }
           
             catch (Exception)
            {
                return a;
            }

        }
        public static double Memory(string m)                    // Запоминание значения
        {
            try
            {
                return Convert.ToDouble(m);
            }
            catch (Exception)
            {
                return Result(m);
            }
        }

        public static double CallMemory(double a)          //Вывод значения из памяти
        {
            var value = (Convert.ToString(a));
            return a;
        }
    }
}
