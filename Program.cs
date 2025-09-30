using System;

namespace GeometryShapes
{
    class Trykutnyk
    {
        protected (double x, double y) A, B, C;

        /// <summary>
        /// Метод для задання координат трикутника
        /// </summary>
        public virtual void ZadatyKoordynaty()
        {
            Console.WriteLine("Введіть координати трикутника:");

            A = ZapytatyTochku("A");
            B = ZapytatyTochku("B");
            C = ZapytatyTochku("C");
        }

        /// <summary>
        /// Метод для виведення координат трикутника
        /// </summary>
        public virtual void VyvestyKoordynaty()
        {
            Console.WriteLine($"A({A.x}, {A.y}) B({B.x}, {B.y}) C({C.x}, {C.y})");
        }

        /// <summary>
        /// Метод для обчислення площі трикутника
        /// </summary>
        public virtual double ObchyslytyPloschu()
        {
            // Формула площі за координатами (1/2)*|x1(y2−y3)+x2(y3−y1)+x3(y1−y2)|
            double ploscha = 0.5 * Math.Abs(
                A.x * (B.y - C.y) +
                B.x * (C.y - A.y) +
                C.x * (A.y - B.y)
            );
            return ploscha;
        }

        protected (double x, double y) ZapytatyTochku(string name)
        {
            Console.WriteLine($"Введіть координати точки {name}:");
            Console.Write("x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y: ");
            double y = double.Parse(Console.ReadLine());
            return (x, y);
        }
    }

    class OpuklyiChotyrykutnyk : Trykutnyk
    {
        protected (double x, double y) D;

        /// <summary>
        /// Метод для задання координат опуклого чотирикутника
        /// </summary>
        public override void ZadatyKoordynaty()
        {
            Console.WriteLine("Введіть координати опуклого чотирикутника:");

            A = ZapytatyTochku("A");
            B = ZapytatyTochku("B");
            C = ZapytatyTochku("C");
            D = ZapytatyTochku("D");
        }

        /// <summary>
        /// Метод для виведення координат опуклого чотирикутника
        /// </summary>
        public override void VyvestyKoordynaty()
        {
            Console.WriteLine($"A({A.x}, {A.y}) B({B.x}, {B.y}) C({C.x}, {C.y}) D({D.x}, {D.y})");
        }

        /// <summary>
        /// Метод для обчислення площі опуклого чотирикутника як сума площ двох трикутників (ABC і ACD)
        /// </summary>
        public override double ObchyslytyPloschu()
        {
            double ploscha1 = 0.5 * Math.Abs(
                A.x * (B.y - C.y) +
                B.x * (C.y - A.y) +
                C.x * (A.y - B.y)
            );

            double ploscha2 = 0.5 * Math.Abs(
                A.x * (C.y - D.y) +
                C.x * (D.y - A.y) +
                D.x * (A.y - C.y)
            );

            return ploscha1 + ploscha2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть фігуру: 1 - Трикутник, 2 - Опуклий чотирикутник");
            string vibor = Console.ReadLine();

            Trykutnyk figura;

            if (vibor == "2")
                figura = new OpuklyiChotyrykutnyk();
            else
                figura = new Trykutnyk();

            figura.ZadatyKoordynaty();
            figura.VyvestyKoordynaty();

            double ploscha = figura.ObchyslytyPloschu();
            Console.WriteLine($"Площа фігури: {ploscha}");
        }
    }
}
