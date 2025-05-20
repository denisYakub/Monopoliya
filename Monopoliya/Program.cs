using Monopoliya.Objects;

namespace Monopoliya
{
    class Program
    {
        public static int NumberOfBoxes = 100;
        public static (int W, int H, int D) MaxSizesOfBoxes = new(5, 5, 5);
        public static float BoxWeight = 0.5f;

        public static int NumberOfPallets = 10;
        public static (int W, int H, int D) MaxSizesOfPallets = new(7, 7, 7);
        public static float PalletWeight = 3.5f;

        public static void Main(string[] args)
        {
            var boxes = 
                GetBoxes(MaxSizesOfBoxes.W, MaxSizesOfBoxes.H, MaxSizesOfBoxes.D)
                .Take(NumberOfBoxes)
                .ToList();

            var pallets = 
                GetPallets(MaxSizesOfPallets.W, MaxSizesOfPallets.H, MaxSizesOfPallets.D)
                .Take(NumberOfPallets)
                .ToList();

            foreach (var pallet in pallets)
            {
                var upDatedBoxes = boxes;

                for (var j = 0; j < boxes.Count; j++)
                {
                    if (pallet.AddItem(boxes.ElementAt(j)))
                        upDatedBoxes.RemoveAt(j);
                }

                boxes = upDatedBoxes;
            }

            var removeEmptyPallets = pallets
                .Where(pallet => pallet.AnyBox());

            Task1(removeEmptyPallets);
            Task2(removeEmptyPallets);
        }

        private static void Task1(IEnumerable<Pallet<Box>> pallets)
        {
            var sortedGroups = pallets
                .GroupBy(pallet => pallet.ExpirationDate)
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    ExpirationDate = group.Key,
                    Pallets = group.OrderBy(pallet => pallet.Weight)
                })
                .ToList();

            Console.WriteLine("\nСгруппировать все паллеты по сроку годности, " +
                "отсортировать по возрастанию срока годности, " +
                "в каждой группе отсортировать паллеты по весу\n");
            foreach (var group in sortedGroups)
            {
                Console.WriteLine($"Group:{group.ExpirationDate}");

                foreach (var pallet in group.Pallets)
                    Console.WriteLine(pallet);
            }
        }

        private static void Task2(IEnumerable<Pallet<Box>> pallets)
        {
            var sortedPallets = pallets
                .OrderByDescending(pallet => pallet.ExpirationDate)
                .Take(3)
                .OrderBy(pallet => pallet.Weight);

            Console.WriteLine("3 паллеты, " +
                "которые содержат коробки с наибольшим сроком годности, " +
                "отсортированные по возрастанию объема\n");
            foreach (var pallet in sortedPallets)
                Console.WriteLine(pallet);
        }

        private static IEnumerable<Box> GetBoxes(int maxWidth, int maxHeight, int maxDepth)
        {
            var random = new Random();

            while (true)
            {
                yield return new(
                    random.Next(1, maxWidth), 
                    random.Next(1, maxHeight), 
                    random.Next(1, maxDepth),
                    BoxWeight,
                    null,
                    DateOnly
                    .FromDateTime(DateTime.Now)
                    .AddDays(-random.Next(1, 100)));
            }
        }
        private static IEnumerable<Pallet<Box>> GetPallets(int maxWidth, int maxHeight, int maxDepth)
        {
            var random = new Random();

            while (true)
            {
                yield return new(
                    random.Next(1, maxWidth),
                    random.Next(1, maxHeight),
                    random.Next(1, maxDepth),
                    PalletWeight);
            }
        }
    }
}