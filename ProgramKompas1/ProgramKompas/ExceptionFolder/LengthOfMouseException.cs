using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramKompas.ExceptionFolder
{
    /// <summary>
    /// Перехват исключения высоты компьютерной мыши если длина больше 150 мм
    /// или меньше 100 мм
    /// </summary>
    public class LengthOfMouseException : ApplicationException
    {
    }
}
