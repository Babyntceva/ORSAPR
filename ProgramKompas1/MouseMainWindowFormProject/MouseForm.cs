using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgramKompas;
using MouseSettings.cs;

namespace MouseMainWindowFormProject
{
    public partial class MouseForm : Form
    {
        ProgramKompas.ProgramKompas programKompasClass = new ProgramKompas.ProgramKompas();
        private MouseSetting mouseSettingClass =
            new MouseSetting();
        private ToolTip toolTip = new ToolTip();

        public MouseForm()
        {
            InitializeComponent();
        }

        private void SelectClose(TextBox textBox)
        {
            textBox.Clear();
            textBox.Select();
        }

        private void ButtonBuild_Click(object sender, EventArgs e)
        {
            try
            {
                programKompasClass.ProgramKompasClassParamMethod(mouseSettingClass);
                programKompasClass.COnstruct();
            }
            catch(Exception)
            {
                MessageBox.Show("Непредвиденная ошибка");
            }
                 
        }

        // Валидация всех параметров 
        private void TextBoxLengthOfMouseLeave(object sender, EventArgs e)
        {
            try
            {              
                mouseSettingClass.LengthOfMouseProperty =
                    Convert.ToDouble(_textBoxLengthOfMouse.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный формат ввода");
                SelectClose(_textBoxLengthOfMouse);
            }
            catch (ProgramKompas.ExceptionFolder.LengthOfMouseException)
            {
                MessageBox.Show("Длина мыши должна иметь длину от 100 до 150 милиметров", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectClose(_textBoxLengthOfMouse);
            }
        }

        private void TextBoxFrontOfTheMouseLeave(object sender, EventArgs e)
        {
            try
            {
                mouseSettingClass.FrontOfTheMouseProperty =
                    Convert.ToDouble(_textBoxFrontOfTheMouse.Text);
                _textBoxBackOfTheMouse.Text = Convert.ToString(mouseSettingClass.BackOfTheMouseProperty);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный формат ввода");
                SelectClose(_textBoxFrontOfTheMouse);
            }
            catch (ProgramKompas.ExceptionFolder.FrontOfTheMouseException)
            {
                MessageBox.Show("Длина передней части мыши не должна превышать 40% и быть меньше 30% от компьютерной мыши", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectClose(_textBoxFrontOfTheMouse);
            }
        }

        private void TextBoxBackOfTheMouseLeave(object sender, EventArgs e)
        {
            try
            {
                mouseSettingClass.BackOfTheMouseProperty =
                    Convert.ToDouble(_textBoxBackOfTheMouse.Text);
                _textBoxFrontOfTheMouse.Text = Convert.ToString(mouseSettingClass.FrontOfTheMouseProperty);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный формат ввода");
                SelectClose(_textBoxBackOfTheMouse);
            }
            catch (ProgramKompas.ExceptionFolder.BackOfTheMouseException)
            {
                MessageBox.Show("Длина задней части мыши не должна превышать 70% и быть меньше 60% от длины мыши ",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectClose(_textBoxBackOfTheMouse);
            }
        }

        private void TextBoxHeightFirstLevelOfTheMouseLeave
            (object sender, EventArgs e)
        {
            try
            {
                mouseSettingClass.TheHeightOfTheFirstLevelOfTheMouseProperty =
                    Convert.ToDouble(_textBoxTheHeightOfTheFirstLevelOfTheMouse.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный формат ввода");
                SelectClose(_textBoxTheHeightOfTheFirstLevelOfTheMouse);
            }
            catch (ProgramKompas.ExceptionFolder.TheHeightOfTheFirstLevelOfTheMouseException)
            {
                MessageBox.Show("Высота первого уровня не должна привышать 30% и быть меньше 20% от длины компьютеной мыши", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectClose(_textBoxTheHeightOfTheFirstLevelOfTheMouse);
            }

        }
       
        private void TextBoxHeightOfTheSecondMouseLeave(object sender,
                    EventArgs e)
        {
            try
            {
                mouseSettingClass.HeightOfTheSecondMouseProperty =
                    Convert.ToDouble(_textBoxHeightOfTheSecondMouse.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный формат ввода");
                SelectClose(_textBoxBackOfTheMouse);
            }
            catch (ProgramKompas.ExceptionFolder.ExceptionHeightOfTheSecondMouse)
            {
                MessageBox.Show("Второй уровень компьютерной мыши  больше 20% или меньше 10% от компьютерной мыши", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SelectClose(_textBoxHeightOfTheSecondMouse);
            }
        }

        //Подсказки при наведении
        private void TextBoxLengthOfMouseMouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxLengthOfMouse, "Длина мышки должна быть" +
                " \nв интервале 100...150");
        }

        private void TextBoxFrontOfTheMouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxFrontOfTheMouse, "Передняя часть не должна\n" +
                " превышать значение 40%\n или меньше 30% от длины мыши");
        }

        private void TextBoxBackOfTheMouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxBackOfTheMouse, "Длина задней части не должна\n" +
                " превышать значение 70%\n или быть меньше 60% от длины мышки ");
        }

        private void TextBoxTheHeightOfTheFirstLevelOfTheMouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxTheHeightOfTheFirstLevelOfTheMouse,
                "Первый уровень не должен превышать значение 30%\n " +
                "и быть меньше 20% от длины мыши");
        }

        private void TextBoxHeightOfTheSecondMouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(_textBoxHeightOfTheSecondMouse,
               "Первый уровень не должен превышать значение 20%\n " +
               "и быть меньше 10% от длины мыши");
        }

       
    }
}
