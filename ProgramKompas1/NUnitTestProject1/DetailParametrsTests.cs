using System;
using NUnit.Framework;
using MouseSettings.cs;
namespace NUnitTestProject1
{
    [TestFixture]
    public class DetailParametrsTests
    {

        [Test]
        [TestCase(99, TestName = "Тест комп. мыши нижней грани")]
        public void SetLengthMouse_NegativLessTest(double LengthOfMouseCount)
        {
            var programKompas = new MouseSetting();
            Assert.Throws<ProgramKompas.ExceptionFolder.LengthOfMouseException>(() =>
            programKompas.LengthOfMouseProperty = LengthOfMouseCount);
        }
        [TestCase(151, TestName = "Тест комп.мыши верхней грани")]
        public void SetLengthMouse_NegativMoreTest(double LengthOfMouseCount)
        {
            var programKompas = new MouseSetting();
            Assert.Throws<ProgramKompas.ExceptionFolder.LengthOfMouseException>(() =>
            programKompas.LengthOfMouseProperty = LengthOfMouseCount);
        }

        [TestCase(120, TestName = "PositivTest Mouse")]
        public void SetLengthMouse_PositivTest(double LengthOfMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = LengthOfMouseCount;
        }
        //Передняя часть компьютерной мыши
        [TestCase(29, 100, TestName = "Тест перед.части нижней грани")]
        public void SetFrontLengthMouse_NegativLessTest(double FrontOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            Assert.Throws<ProgramKompas.ExceptionFolder.FrontOfTheMouseException>(() =>
            programKompas.FrontOfTheMouseProperty = FrontOfTheMouse);
        }
        [TestCase(41, 100, TestName = "Тест перед.части верхней грани")]
        public void SetFrontLengthMouse_NegativMoreTest(double FrontOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            Assert.Throws<ProgramKompas.ExceptionFolder.FrontOfTheMouseException>(() =>
            programKompas.FrontOfTheMouseProperty = FrontOfTheMouse);
        }
        [TestCase(35, 100, TestName = "Positiv перед.части")]
        public void SetFrontLengthMouse_PositivTest(double FrontOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            programKompas.FrontOfTheMouseProperty = FrontOfTheMouse;
        }
        
      //Задняя часть компьютерной мыши
        [TestCase(59, 100, TestName = "Тест зад.части нижней грани")]
        [TestCase(71, 100, TestName = "Тест зад.части верхней грани")]
        public void SetBackLengthMouse_NegativLessTest(double BackOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            Assert.Throws<ProgramKompas.ExceptionFolder.BackOfTheMouseException>(() =>
            programKompas.BackOfTheMouseProperty = BackOfTheMouse);
        }

               
        [TestCase(65, 100, TestName = "PositivTest задней части")]
        public void SetBackLengthMouse_PositivTest(double BackOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            programKompas.BackOfTheMouseProperty = BackOfTheMouse;
        }
        //Первый ярус мыши
        [TestCase(19, 100, TestName = "Тест 1 уровня нижней грани")]
        public void SetTheHeightOfTheFirstLevelOfTheMouse_NegativLessTest(double TheHeightOfTheFirstLevelOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            Assert.Throws<ProgramKompas.ExceptionFolder.TheHeightOfTheFirstLevelOfTheMouseException> (() =>
            programKompas.TheHeightOfTheFirstLevelOfTheMouseProperty = TheHeightOfTheFirstLevelOfTheMouse);
        }

        [TestCase(31, 100, TestName = "Тест 1 уровня верхней грани")]
        public void SetTheHeightOfTheFirstLevelOfTheMouse_NegativMoreTest(double TheHeightOfTheFirstLevelOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            Assert.Throws<ProgramKompas.ExceptionFolder.TheHeightOfTheFirstLevelOfTheMouseException>(() =>
           programKompas.TheHeightOfTheFirstLevelOfTheMouseProperty = TheHeightOfTheFirstLevelOfTheMouse);
        }

        [TestCase(25, 100, TestName = "PositivTest 1 уровня")]
        public void SetTheHeightOfTheFirstLevelOfTheMouse_PositivTest(double TheHeightOfTheFirstLevelOfTheMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
           programKompas.TheHeightOfTheFirstLevelOfTheMouseProperty= TheHeightOfTheFirstLevelOfTheMouse ;
        }

        //Второй уровень компьютерной мыши
        [TestCase(15, 100, TestName = "PositivTest 2 уровня")]
        public void SetHeightOfTheSecondMouse_PositivTest(double HeightOfTheSecondMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            programKompas.HeightOfTheSecondMouseProperty = HeightOfTheSecondMouse;
        }
        [TestCase(9, 100, TestName = "Тест 2 уровня нижней грани")]
        public void SetHeightOfTheSecondMouse_NegativLessTest(double HeightOfTheSecondMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            Assert.Throws<ProgramKompas.ExceptionFolder.ExceptionHeightOfTheSecondMouse>(() =>
             programKompas.HeightOfTheSecondMouseProperty = HeightOfTheSecondMouse);
        }
        [TestCase(21, 100, TestName = "Тест 2 уровня верхней грани")]
        public void SetHeightOfTheSecondMouse_NegativMoreTest(double HeightOfTheSecondMouse, double lengthMouseCount)
        {
            var programKompas = new MouseSetting();
            programKompas.LengthOfMouseProperty = lengthMouseCount;
            Assert.Throws<ProgramKompas.ExceptionFolder.ExceptionHeightOfTheSecondMouse>(() =>
                programKompas.HeightOfTheSecondMouseProperty = HeightOfTheSecondMouse);
        }
    }
    
}