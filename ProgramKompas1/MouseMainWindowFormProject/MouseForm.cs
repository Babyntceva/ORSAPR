using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgramKompas.ExceptionFolder;
using ProgramKompas;

namespace MouseMainWindowFormProject
{
    /// <summary>
    /// Форма для графического интерфейса
    /// </summary>
    public partial class MouseForm : Form
    {
        /// <summary>
        /// Создание объекта для конструирования детали
        /// </summary>
        KompasProgram programKompasClass = 
            new KompasProgram();

        /// <summary>
        /// Создание объекта параметров мыши
        /// </summary>
        private MouseSetting mouseSettingClass =
            new MouseSetting();

        /// <summary>
        /// Объект для подсказок
        /// </summary>
        private ToolTip toolTip = new ToolTip();

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public MouseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка построить деталь
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ButtonBuildClick(object sender, EventArgs e)
        {
            try
            {
                programKompasClass.ProgramKompasClassParamMethod
                    (mouseSettingClass);
                programKompasClass.COnstruct();
            }
            catch(Exception)
            {
                MessageBox.Show("Непредвиденная ошибка");
            }    
        }

        /// <summary>
        /// Тексбокс Длины мыши
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void TextBoxLengthOfMouseLeave(object sender, EventArgs e)
        {
            try
            {              
                mouseSettingClass.LengthOfMouseProperty =
                    Convert.ToDouble(_textBoxLengthOfMouse.Text);
            }
            catch (FormatException)
            {
                SelectedCloseTexBox
                   (_textBoxLengthOfMouse,
                  "Неверный формат ввода");
            }
            catch (LengthOfMouseException)
            {
                SelectedCloseTexBox
                    (_textBoxLengthOfMouse,
                   "Длина мыши должна иметь длину от 100 до 150 милиметров");
            }
        }

        /// <summary>
        /// Тексбокс передней части мыши
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxFrontOfTheMouseLeave(object sender, EventArgs e)
        {
            try
            {
                mouseSettingClass.FrontOfTheMouseProperty =
                    Convert.ToDouble(_textBoxFrontOfTheMouse.Text);
                _textBoxBackOfTheMouse.Text = Convert.ToString
                    (mouseSettingClass.BackOfTheMouseProperty);
            }
            catch (FormatException)
            {
                SelectedCloseTexBox
                      (_textBoxFrontOfTheMouse,
                     "Неверный формат ввода");
            }
            catch (FrontOfTheMouseException)
            {
                SelectedCloseTexBox
                    (_textBoxBackOfTheMouse,
                   "Длина передней части мыши не должна превышать 40% и" +
                    "быть меньше 30% от компьютерной мыши");
            }
        }

        /// <summary>
        /// Тексбокс задней части мыши
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxBackOfTheMouseLeave(object sender, EventArgs e)
        {
            try
            {
                mouseSettingClass.BackOfTheMouseProperty =
                    Convert.ToDouble(_textBoxBackOfTheMouse.Text);
                _textBoxFrontOfTheMouse.Text = Convert.ToString
                    (mouseSettingClass.FrontOfTheMouseProperty);
            }
            catch (FormatException)
            {
                SelectedCloseTexBox
                     (_textBoxBackOfTheMouse,"Неверный формат ввода");
            }
            catch (BackOfTheMouseException)
            {
                SelectedCloseTexBox
                    (_textBoxBackOfTheMouse,
                   "Длина задней части мыши не должна превышать 70% и" +
                    " быть меньше 60% от длины мыши ");
            }
        }

        /// <summary>
        /// тексбокс первого уровня мыши
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxHeightFirstLevelOfTheMouseLeave
            (object sender, EventArgs e)
        {
            try
            {
                mouseSettingClass.
                    TheHeightOfTheFirstLevelOfTheMouseProperty =
                    Convert.ToDouble
                    (_textBoxTheHeightOfTheFirstLevelOfTheMouse.Text);
            }
            catch (FormatException)
            {
                SelectedCloseTexBox(_textBoxTheHeightOfTheFirstLevelOfTheMouse,
                    "Неверный формат ввода");
            }
            catch (TheHeightOfTheFirstLevelOfTheMouseException)
            {
                SelectedCloseTexBox
                    (_textBoxTheHeightOfTheFirstLevelOfTheMouse,
                    "Высота первого уровня не должна привышать 30% и быть" +
                    "меньше 20% от длины компьютеной мыши");
            }
        }
       
        /// <summary>
        /// текстбокс второго уровня мыши
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxHeightOfTheSecondMouseLeave
            (object sender,EventArgs e)
        {
            try
            {
                mouseSettingClass.HeightOfTheSecondMouseProperty =
                    Convert.ToDouble(_textBoxHeightOfTheSecondMouse.Text);
            }
            catch (FormatException)
            {
                SelectedCloseTexBox(_textBoxHeightOfTheSecondMouse,
                    "Неправильный формат ввода");
            }
            catch (ExceptionHeightOfTheSecondMouse)
            {
                SelectedCloseTexBox(_textBoxHeightOfTheSecondMouse, "Второй" +
                    " уровень компьютерной мыши  больше" +
                    "20% или меньше 10% от компьютерной мыши");
            }
        }

        /// <summary>
        /// Метод свойства для вывода сообщения и выделение,удаление
        /// в текстбоксе информации
        /// </summary>
        /// <param name="textBox">Текстбокс</param>
        /// <param name="message">Сообщение</param>
        private void SelectedCloseTexBox(TextBox textBox, string message )
        {
            MessageBox.Show(message, "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox.Clear();
            textBox.Select();
        }

        /// <summary>
        /// Подсказка на длине
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxLengthOfMouseMouseHover
            (object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxLengthOfMouse, "Длина мышки" +
                " должна быть \nв интервале 100...150");
        }

        /// <summary>
        /// Подсказка для передней части
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxFrontOfTheMouseHover
            (object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxFrontOfTheMouse, "Передняя часть "+
                "не должна\n превышать значение 40%\n или меньше 30% от"+
                " длины мыши");
        }

        /// <summary>
        /// Подсказка для задней части
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxBackOfTheMouseHover
            (object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxBackOfTheMouse, "Длина задней части" +
                "не должна\n превышать значение 70%\n или быть меньше 60%" +
                " от длины мышки ");
        }

        /// <summary>
        /// Подсказка для первого уровня мыши
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxTheHeightOfTheFirstLevelOfTheMouseHover
            (object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxTheHeightOfTheFirstLevelOfTheMouse,
                "Первый уровень не должен превышать значение 30%\n " +
                "и быть меньше 20% от длины мыши");
        }

        /// <summary>
        /// Подсказка для второго уровня мыши
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TextBoxHeightOfTheSecondMouseHover
            (object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxHeightOfTheSecondMouse,
               "Первый уровень не должен превышать значение 20%\n " +
               "и быть меньше 10% от длины мыши");
        }       
    }
}