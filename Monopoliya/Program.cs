using Monopoliya.Objects;

namespace Monopoliya
{
    class Program
    {
        private static Generator _generator = 
            new WarehouseGenerator(
                new(100, new(5, 5, 5), 0.5f),
                new(10, new(7, 7, 7), 2.5f));

        public static void Main(string[] args)
        {
            var objs = _generator.Generate();

            Tasks.Task1(objs);
            Tasks.Task2(objs);
        }
    }
}