using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramKompas.ExceptionFolder
{
    /// <summary>
    /// Перехват исключения передней части компьютерной мыши если больше 40%
    /// или меньше 30% от длины мыши
    /// </summary>
    public class FrontOfTheMouseException : ApplicationException
    {
    }
}
