using Monopoliya.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya
{
    public class WarehouseGenerator(BoxesRequest boxesRequest, PalletsRequest palletsRequest) 
        : Generator
    {
        private readonly Random _random = new();

        public IReadOnlyCollection<WarehouseObj> Generate()
        {
            var boxes =
                 GetBoxes(
                     boxesRequest.MaxSizesOfBoxes.W, 
                     boxesRequest.MaxSizesOfBoxes.H, 
                     boxesRequest.MaxSizesOfBoxes.D, 
                     boxesRequest.BoxWeight)
                 .Take(boxesRequest.NumberOfBoxes)
                 .ToList();

            var pallets =
                GetPallets(
                    palletsRequest.MaxSizesOfPallets.W, 
                    palletsRequest.MaxSizesOfPallets.H, 
                    palletsRequest.MaxSizesOfPallets.D, 
                    palletsRequest.PalletWeight)
                .Take(palletsRequest.NumberOfPallets)
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

            return RemoveEmptyPallets(pallets).ToList();
        }

        private static IEnumerable<Pallet<Box>> RemoveEmptyPallets(IEnumerable<Pallet<Box>> pallets)
            => pallets.Where(pallet => pallet.AnyBox());

        private static IEnumerable<Box> GetBoxes(int maxWidth, int maxHeight, int maxDepth, float boxWeight)
        {
            var random = new Random();

            while (true)
            {
                yield return new(
                    random.Next(1, maxWidth),
                    random.Next(1, maxHeight),
                    random.Next(1, maxDepth),
                    boxWeight,
                    null,
                    DateOnly
                    .FromDateTime(DateTime.Now)
                    .AddDays(-random.Next(1, 100)));
            }
        }
        private static IEnumerable<Pallet<Box>> GetPallets(int maxWidth, int maxHeight, int maxDepth, float palletWeight)
        {
            var random = new Random();

            while (true)
            {
                yield return new(
                    random.Next(1, maxWidth),
                    random.Next(1, maxHeight),
                    random.Next(1, maxDepth),
                    palletWeight);
            }
        }
    }
}
