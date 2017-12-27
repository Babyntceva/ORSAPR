using System;
using Kompas6API5;
using Kompas6Constants3D;
using MouseSettings.cs;
using Kompas6Constants;
using System.Diagnostics;

namespace ProgramKompas
{
    public class ProgramKompas
    {
        /// <summary>
        /// осн.Интерфейс
        /// </summary>
        private KompasObject _kompasObject;
       
        /// <summary>
        /// Интерфейс по сборке детали
        /// </summary>
        private ksDocument3D _ksDocument3D;

        /// <summary>
        /// Указатель на интерфейс.Компонент сборки
        /// </summary>
        private ksPart _ksPart;

        /// <summary>
        /// Параметры мыши
        /// </summary>
        private MouseSetting mouseSetting = new MouseSetting();

        /// <summary>
        /// Координата для первой точки отрезка
        /// </summary>
        private const double _onePointLine = 0.35;

        /// <summary>
        /// Координата для второй точки отрезка
        /// </summary>
        private const double _twoPointLine = 0.2;

        /// <summary>
        /// Константа при формировании отклонения второго эскида
        /// </summary>
        private const double _deviation = 0.5;

   /// <summary>
   /// Присвоение параметров мыши
   /// </summary>
   /// <param name="Setting">Параметр</param>
        public void ProgramKompasClassParamMethod(MouseSetting Setting)
        {
            mouseSetting = Setting;
        }

        /// <summary>
        /// ПРоверка и запуск компаса
        /// </summary>
        private void RunningTheCompassMethod()
        {
            Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
            if (_kompasObject == null)
            {
                _kompasObject = (KompasObject)Activator.CreateInstance(type);
            }
            else if (_kompasObject != null)
            {
                _kompasObject.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Получение интерфейса документа модели и ее создание
        /// </summary>
        private void CreateNewDocumentMethod()
        {
            _ksDocument3D = (ksDocument3D)_kompasObject.Document3D();
            _ksDocument3D.Create();
        }

        /// <summary>
        /// Интерфейс компонента
        /// </summary>
        private void GetTheComponentInterfaceMethod()
        {
            //Верхний компонент,в состав входит ред.компонент
            //Получение интерфейс модели
            const int pTop_Part = -1;
            _ksPart = (ksPart)_ksDocument3D.GetPart(pTop_Part);
        }

        /// <summary>
        /// Создание эскиза
        /// ksEntityDraw интерфейс элемента модели
        /// </summary>
        /// <param name="part">компонент сборки</param>
        /// <param name="axis">Ось</param>
        private void CreatSketchMethod(ksPart part, int axis,
            ksEntity ksEntityDraw)
        {
            ksSketchDefinition _ksSketchDefinition;
            ksDocument2D _ksDocument2D;
            ksEntity ksEntityPlane;

            // GetDefinition Получение указателя интерфейса парам. объекта
            _ksSketchDefinition = (ksSketchDefinition)ksEntityDraw.GetDefinition();

            // Возращение на интерфейс объекта  ( плоскость ХОУ)
            ksEntityPlane = (ksEntity)part.GetDefaultEntity
                ((short)Obj3dType.o3d_planeXOY);
            _ksSketchDefinition.SetPlane(ksEntityPlane);
            ksEntityDraw.Create();

            //Запуск режима редактирования
            _ksDocument2D = (ksDocument2D)_ksSketchDefinition.BeginEdit();

            _ksDocument2D.ksArcBy3Points(0,
                -mouseSetting.LengthOfMouseProperty * _onePointLine,
                -7, 0,
                0,mouseSetting.LengthOfMouseProperty * _onePointLine, 1);

            _ksDocument2D.ksLineSeg(0,
                mouseSetting.LengthOfMouseProperty * _onePointLine, 
                mouseSetting.LengthOfMouseProperty - 7,
                mouseSetting.LengthOfMouseProperty * _twoPointLine,
                1);

            _ksDocument2D.ksLineSeg(0,
                -mouseSetting.LengthOfMouseProperty * _onePointLine,
                mouseSetting.LengthOfMouseProperty - 7,
                -mouseSetting.LengthOfMouseProperty * _twoPointLine,
                1);

            _ksDocument2D.ksLineSeg(mouseSetting.LengthOfMouseProperty - 7,
                -mouseSetting.LengthOfMouseProperty * _twoPointLine,
                mouseSetting.LengthOfMouseProperty - 7,
                mouseSetting.LengthOfMouseProperty * _twoPointLine, 1);
            _ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Элемент выдавливания
        /// </summary>
        private void ExstrusionMethod(ksEntity ksEntityDraw,
            ksEntity ksEntityExtrusion)
        {
            ksBaseExtrusionDefinition ksBaseExtrusionDefinition = 
                (ksBaseExtrusionDefinition)ksEntityExtrusion.GetDefinition();
            ksBaseExtrusionDefinition.SetSideParam(true, 
                (short)End_Type.etBlind,
                mouseSetting.TheHeightOfTheFirstLevelOfTheMouseProperty, 0, true);
            ksBaseExtrusionDefinition.SetSketch(ksEntityDraw);
            ksEntityExtrusion.Create();
        }

        /// <summary>
        /// Сдвиг плоскости вверх
        /// </summary>
        private void CreatPlaneOffsetMethod(ksEntity ksEntityPlaneOffset,
            short plane, double size)
        {
            ksEntity ksEntityPlaneXOY = (ksEntity)_ksPart.GetDefaultEntity(plane);
            ksPlaneOffsetDefinition ksPlaneOffsetDefinition = 
                (ksPlaneOffsetDefinition)ksEntityPlaneOffset.GetDefinition();
            ksPlaneOffsetDefinition.SetPlane(ksEntityPlaneXOY);
            ksPlaneOffsetDefinition.direction = true;
            ksPlaneOffsetDefinition.offset = size;
            ksEntityPlaneOffset.Create();
        }

        /// <summary>
        /// Выщитывание ближайшей точки
        /// </summary>
        /// <param name="size">размер</param>
        /// <returns></returns>
        private double ClosePointCounter(double size)
        {
            double y = 0;

            for (int i = 0; i < size; i++)
            {
                y += 0.1625;
            }
            return y;
        }

        /// <summary>
        /// Создание второго эскиза
        /// </summary>
        /// <param name="part"></param>
        private void CreatSketchTwoMethod(ksPart part, ksEntity ksEntityDrawTwo, ksEntity ksEntityPlaneOffset)
        {
            ksSketchDefinition ksSketchDefinition;
            ksDocument2D _ksDocument2D;
            ksSketchDefinition = (ksSketchDefinition)ksEntityDrawTwo.GetDefinition();
            ksSketchDefinition.SetPlane(ksEntityPlaneOffset);
            ksEntityDrawTwo.Create();
            _ksDocument2D = (ksDocument2D)ksSketchDefinition.BeginEdit();

            _ksDocument2D.ksArcBy3Points(0 + _deviation,
                -mouseSetting.LengthOfMouseProperty * _onePointLine + 0.5,
                -7 + _deviation, 0 + _deviation,
                0 + _deviation,
                mouseSetting.LengthOfMouseProperty * _onePointLine - 0.5, 1);

            _ksDocument2D.ksLineSeg(0 + _deviation,
                mouseSetting.LengthOfMouseProperty * _onePointLine - _deviation,
                mouseSetting.BackOfTheMouseProperty,
                mouseSetting.LengthOfMouseProperty *
                _onePointLine - ClosePointCounter(mouseSetting.BackOfTheMouseProperty)
                , 1);

            _ksDocument2D.ksLineSeg(0 + _deviation,
                -mouseSetting.LengthOfMouseProperty * _onePointLine + _deviation,
                mouseSetting.BackOfTheMouseProperty,
                -mouseSetting.LengthOfMouseProperty *
                _onePointLine + ClosePointCounter(mouseSetting.BackOfTheMouseProperty),
                1);

            _ksDocument2D.ksLineSeg(mouseSetting.BackOfTheMouseProperty,
                -mouseSetting.LengthOfMouseProperty 
                * _onePointLine + ClosePointCounter(mouseSetting.BackOfTheMouseProperty),
                mouseSetting.BackOfTheMouseProperty,
                mouseSetting.LengthOfMouseProperty 
                * _onePointLine - ClosePointCounter(mouseSetting.BackOfTheMouseProperty),
                1);
            ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Выдавливание 
        /// </summary>
        private void CreatExtrusionOffsetMethod(ksEntity ksEntity, string name,double size,
            short style,short typeExstrusion)
        {
            ksEntity ksEntityBossExtrusionn;

            //Cоздание объекта,который выдавливается и возращает указатель
            ksEntityBossExtrusionn = _ksPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition ksBossExtrusionDefinition =
                (ksBossExtrusionDefinition)ksEntityBossExtrusionn.GetDefinition();
            ksBossExtrusionDefinition.directionType = typeExstrusion;
            ksBossExtrusionDefinition.SetSideParam(true, style, size, 0, true);
            ksBossExtrusionDefinition.SetSketch(ksEntity);
         
            ksEntityBossExtrusionn.name = name;
            ksEntityBossExtrusionn.Create();
        }

        /// <summary>
        /// Выдавливание вырезанием
        /// </summary>
        /// <param name="ksEntity"></param>
        /// <param name="name">Имя</param>
        private void CreatExtrusionOffsetCutMethod(ksEntity ksEntity, string name)
        {
            ksEntity ksEntityBossExtrusionn;
            ksEntityBossExtrusionn = _ksPart.NewEntity((short)Obj3dType.
                o3d_cutExtrusion);
            ksCutExtrusionDefinition ksBossExtrusionDefinition = 
                (ksCutExtrusionDefinition)ksEntityBossExtrusionn.GetDefinition();
            ksBossExtrusionDefinition.SetSideParam(false,
                (short)End_Type.etBlind, mouseSetting.HeightOfTheSecondMouseProperty,
                2, false);
            ksBossExtrusionDefinition.SetSketch(ksEntity);
            ksEntityBossExtrusionn.name = name;
            ksEntityBossExtrusionn.Create();
        }

        /// <summary>
        /// Создание третьего эскиза
        /// </summary>
        /// <param name="part"></param>
        private void CreatSketchThreeMethod(ksPart part, ksEntity ksEntityDrawThree,
            ksEntity ksEntityPlaneOffset)
        {
            ksSketchDefinition ksSketchDefinition;
            ksDocument2D _ksDocument2D;
            ksSketchDefinition = (ksSketchDefinition)ksEntityDrawThree.
                GetDefinition();
            ksSketchDefinition.SetPlane(ksEntityPlaneOffset);
            ksEntityDrawThree.Create();
            _ksDocument2D = (ksDocument2D)ksSketchDefinition.BeginEdit();

            _ksDocument2D.ksLineSeg(mouseSetting.BackOfTheMouseProperty + _deviation,
                mouseSetting.LengthOfMouseProperty * _onePointLine - ClosePointCounter
                (mouseSetting.BackOfTheMouseProperty),
                mouseSetting.LengthOfMouseProperty - 7 - _deviation,
            mouseSetting.LengthOfMouseProperty * _onePointLine - ClosePointCounter
            (mouseSetting.LengthOfMouseProperty) - _deviation, 1);

            _ksDocument2D.ksLineSeg(mouseSetting.BackOfTheMouseProperty + _deviation,
               -mouseSetting.LengthOfMouseProperty * _onePointLine + ClosePointCounter
               (mouseSetting.BackOfTheMouseProperty),
                mouseSetting.LengthOfMouseProperty - 7 - _deviation,
               -mouseSetting.LengthOfMouseProperty * _onePointLine + ClosePointCounter
               (mouseSetting.LengthOfMouseProperty) - _deviation, 1);

            _ksDocument2D.ksLineSeg(mouseSetting.BackOfTheMouseProperty + _deviation,
                mouseSetting.LengthOfMouseProperty * _onePointLine - ClosePointCounter
                (mouseSetting.BackOfTheMouseProperty),
                mouseSetting.BackOfTheMouseProperty + _deviation,
                -mouseSetting.LengthOfMouseProperty * _onePointLine + ClosePointCounter
                (mouseSetting.BackOfTheMouseProperty), 1);

            _ksDocument2D.ksLineSeg(mouseSetting.LengthOfMouseProperty - 7 - _deviation,
                mouseSetting.LengthOfMouseProperty * _onePointLine - ClosePointCounter
                (mouseSetting.LengthOfMouseProperty) - _deviation,
                mouseSetting.LengthOfMouseProperty - 7 - _deviation,
                -mouseSetting.LengthOfMouseProperty * _onePointLine + ClosePointCounter
                (mouseSetting.LengthOfMouseProperty) - _deviation, 1);
            ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Создание 4-го эскиза
        /// </summary>
        /// <param name="part"></param>
        private void CreatSketchFourMethod(ksPart part, ksEntity ksEntityDrawThree1,
            ksEntity ksEntityPlaneOffset)
        {
            ksSketchDefinition ksSketchDefinition;
            ksDocument2D _ksDocument2D;
            ksSketchDefinition = (ksSketchDefinition)ksEntityDrawThree1.GetDefinition();
            ksSketchDefinition.SetPlane(ksEntityPlaneOffset);
            ksRectangleParam ksRectangleParam = 
                (ksRectangleParam)_kompasObject.GetParamStruct
                ((int)StructType2DEnum.ko_RectangleParam);

            ksRectangleParam.ang = 0;
            ksRectangleParam.height = 0.5;
            ksRectangleParam.width = mouseSetting.LengthOfMouseProperty - 7.5;
            ksRectangleParam.style = 1;
            ksRectangleParam.x = mouseSetting.BackOfTheMouseProperty + 1;
            ksRectangleParam.y = 0;
            ksEntityDrawThree1.Create();
            _ksDocument2D = (ksDocument2D)ksSketchDefinition.BeginEdit();
            _ksDocument2D.ksRectangle(ksRectangleParam, 0);
            ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Построение модели
        /// </summary>
        private void CreatSketchFiveMethod(ksPart part, ksEntity ksEntityDrawThree1, ksEntity ksEntityPlaneOffset)
        {
            ksSketchDefinition ksSketchDefinition;
            ksDocument2D _ksDocument2D;
            ksSketchDefinition = (ksSketchDefinition)ksEntityDrawThree1.GetDefinition();
            ksSketchDefinition.SetPlane(ksEntityPlaneOffset);
            ksRectangleParam ksRectangleParam =
                (ksRectangleParam)_kompasObject.GetParamStruct((int)StructType2DEnum.
                ko_RectangleParam);
            ksRectangleParam.ang = 0;
            ksRectangleParam.height = 8;
            ksRectangleParam.width = -mouseSetting.FrontOfTheMouseProperty/1.4 + 7.5;
            ksRectangleParam.style = 1;
            ksRectangleParam.x = mouseSetting.LengthOfMouseProperty - 11;
            ksRectangleParam.y = -4;
            ksEntityDrawThree1.Create();
            _ksDocument2D = (ksDocument2D)ksSketchDefinition.BeginEdit();
            _ksDocument2D.ksRectangle(ksRectangleParam, 0);
            ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="part"></param>
        /// <param name="axis"></param>
        /// <param name="ksEntityDrawSix"></param>
        /// <param name="ksEntityPlane"></param>
        private void CreatSketchSixMethod(ksPart part, int axis, ksEntity ksEntityDrawSix,ksEntity ksEntityPlane)
        {
            //Пере параметры
            ksSketchDefinition ksSketchDefinition;
            // пер 2д документа  
            ksDocument2D _ksDocument2D;
            // Получение параметра эскиза       
            ksSketchDefinition = (ksSketchDefinition)ksEntityDrawSix.GetDefinition();         
            ksSketchDefinition.SetPlane(ksEntityPlane);
            ksEntityDrawSix.Create();
            _ksDocument2D = (ksDocument2D)ksSketchDefinition.BeginEdit();
            _ksDocument2D.ksCircle(mouseSetting.LengthOfMouseProperty - 7 -1.5 - 15,
               - mouseSetting.TheHeightOfTheFirstLevelOfTheMouseProperty - 
               (mouseSetting.HeightOfTheSecondMouseProperty / 1.5), 
               (mouseSetting.FrontOfTheMouseProperty / 1.4 - 7.2)/2, 1);
            ksSketchDefinition.EndEdit();
        }

        /// <summary>
        /// Формирование модели мыши
        /// </summary>
        public void COnstruct()
        {
          
            RunningTheCompassMethod();
            CreateNewDocumentMethod();
            _kompasObject.Visible = true;
            GetTheComponentInterfaceMethod();
            ksEntity ksEntityDraw = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityDrawTwo = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityDrawThree = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityPlaneOffset = (ksEntity)_ksPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            ksEntity ksEntityDrawFour = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityExtrusion = (ksEntity)_ksPart.NewEntity((int)Obj3dType.o3d_baseExtrusion);
            ksEntity ksEntityDrawFive = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityDrawSix = (ksEntity)_ksPart.NewEntity(5);
            ksEntity ksEntityPlaneOffsetTwo = (ksEntity)_ksPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            CreatSketchMethod(_ksPart, (short)Obj3dType.o3d_planeXOY, ksEntityDraw);
            ExstrusionMethod(ksEntityDraw, ksEntityExtrusion);
            CreatPlaneOffsetMethod(ksEntityPlaneOffset, (short)Obj3dType.o3d_planeXOY,
                mouseSetting.TheHeightOfTheFirstLevelOfTheMouseProperty);
            CreatSketchTwoMethod(_ksPart, ksEntityDrawTwo, ksEntityPlaneOffset);
            CreatExtrusionOffsetMethod(ksEntityDrawTwo, "Выдавлиние первого уровня",
                mouseSetting.HeightOfTheSecondMouseProperty, (short)End_Type.etBlind,0);
            CreatSketchThreeMethod(_ksPart, ksEntityDrawThree, ksEntityPlaneOffset);
            CreatExtrusionOffsetMethod(ksEntityDrawThree, "выдавливание 2-го уровня", 
                mouseSetting.HeightOfTheSecondMouseProperty, (short)End_Type.etBlind,0);
            CreatSketchFourMethod(_ksPart, ksEntityDrawFour, ksEntityPlaneOffset);
            CreatExtrusionOffsetCutMethod(ksEntityDrawFour, "Выдавливание вырезанием");
            CreatSketchFiveMethod(_ksPart, ksEntityDrawFive, ksEntityPlaneOffset);
            CreatExtrusionOffsetCutMethod(ksEntityDrawFive, "Выдавливание вырезанием");
            CreatPlaneOffsetMethod(ksEntityPlaneOffsetTwo, (short)Obj3dType.o3d_planeXOZ, -3.9);
            CreatSketchSixMethod(_ksPart, (short)Obj3dType.o3d_planeXOZ, ksEntityDrawSix,ksEntityPlaneOffsetTwo);
            CreatExtrusionOffsetMethod(ksEntityDrawSix, "Выдавлиание калёсика",8,
                (short)End_Type.etBlind,(short)ksDirectionTypeEnum.dtBoth);
        }
    }
}
