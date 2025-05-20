using Monopoliya.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya
{
    public static class Tasks
    {
        public static Action<string> Log = Console.WriteLine;

        private static readonly string Task1Str = 
            "1) Сгруппировать все паллеты по сроку годности, " + 
            "отсортировать по возрастанию срока годности, " + 
            "в каждой группе отсортировать паллеты по весу";
        private static readonly string Task2Str =
            "2) 3 паллеты, " +
            "которые содержат коробки с наибольшим сроком годности, " +
            "отсортированные по возрастанию объема";

        public static void Task1(IReadOnlyCollection<WarehouseObj> objs)
        {
            var sortedGroups = objs
                .GroupBy(pallet => pallet.ExpirationDate)
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    ExpirationDate = group.Key,
                    Pallets = group.OrderBy(pallet => pallet.Weight).ToArray()
                })
                .ToArray();

            var strBuilder = new StringBuilder();
            strBuilder.AppendLine(Task1Str);

            foreach (var group in sortedGroups)
            {
                strBuilder.AppendLine($"Group:{group.ExpirationDate}");

                foreach (var pallet in group.Pallets)
                    strBuilder.AppendLine(pallet.ToString());
            }

            Log(strBuilder.ToString());
        }

        public static void Task2(IReadOnlyCollection<WarehouseObj> objs)
        {
            var sortedPallets = objs
                .OrderByDescending(pallet => pallet.ExpirationDate)
                .Take(3)
                .OrderBy(pallet => pallet.Weight)
                .ToArray();

            var strBuilder = new StringBuilder();
            strBuilder.AppendLine(Task2Str);

            foreach (var pallet in sortedPallets)
                strBuilder.AppendLine(pallet.ToString());

            Log(strBuilder.ToString());
        }
    }
}
