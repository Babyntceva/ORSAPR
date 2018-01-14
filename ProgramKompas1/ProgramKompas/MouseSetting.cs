using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramKompas.ExceptionFolder;

namespace ProgramKompas
{
    /// <summary>
    /// Параметры мыши
    /// </summary>
    public struct MouseSetting
    {
        /// <summary>
        /// Передняя часть
        /// </summary>
        private double _frontOfTheMouse;

        /// <summary>
        /// Задняя часть
        /// </summary>
        private double _backOfTheMouse;

        /// <summary>
        /// Длина мыши
        /// </summary>
        private double _lengthOfMouse;

        /// <summary>
        /// Высота первого радиуса
        /// </summary>
        private double _theHeightOfTheFirstLevelOfTheMouse;

        /// <summary>
        /// Высота второго радиуса
        /// </summary>
        private double _heightOfTheSecondMouse;

        /// <summary>
        /// cвойства для передней части мыши
        /// </summary>
        public double FrontOfTheMouseProperty
        {
            get
            {
                if (_backOfTheMouse > 0)
                {
                    return _frontOfTheMouse = _lengthOfMouse - _backOfTheMouse;
                }
                return _frontOfTheMouse;
            }
            set
            {
                if (value > _lengthOfMouse * 0.4 || value < _lengthOfMouse * 0.3)
                {
                    throw new FrontOfTheMouseException();
                }
                _frontOfTheMouse = value;
            }
        }

        /// <summary>
        /// Свойства задней части мыши
        /// </summary>
        public double BackOfTheMouseProperty
        {
            get
            {
                if (_frontOfTheMouse > 0)
                {
                    return _backOfTheMouse = _lengthOfMouse - _frontOfTheMouse;
                }
                return _backOfTheMouse;
            }
            set
            {
                if (value > _lengthOfMouse * 0.7 || value < _lengthOfMouse * 0.6)
                {
                    throw new BackOfTheMouseException();
                }
                _backOfTheMouse = value;
            }
        }

        /// <summary>
        /// Свойства длины мыши
        /// </summary>
        public double LengthOfMouseProperty
        {
            get
            {
                return _lengthOfMouse;
            }
            set
            {
                if (value < 100 || value > 150)
                {
                    throw new LengthOfMouseException();
                }                
                _lengthOfMouse = value;
            }
        }

        /// <summary>
        /// Свойства первого уровня мыши
        /// </summary>
        public double TheHeightOfTheFirstLevelOfTheMouseProperty
        {
            get
            {
               return _theHeightOfTheFirstLevelOfTheMouse;
            }
            set
            {
                if (value > _lengthOfMouse * 0.3 || value < _lengthOfMouse * 0.2)
                {
                    throw new TheHeightOfTheFirstLevelOfTheMouseException();
                }
                _theHeightOfTheFirstLevelOfTheMouse = value;
            }
        }

        /// <summary>
        /// Свойства второго уровня мыши
        /// </summary>
        public double HeightOfTheSecondMouseProperty
        {
            get
            { 
                return _heightOfTheSecondMouse;
            }
            set
            {
                if (value > _lengthOfMouse * 0.2 || value < _lengthOfMouse * 0.1)
                {
                    throw new ExceptionHeightOfTheSecondMouse();
                }
                _heightOfTheSecondMouse = value;
            }
        }
    }
}