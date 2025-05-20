using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya.Objects
{
    public class Pallet<T> : WarehouseObj where T : Box
    {
        private ICollection<T> _boxes = new List<T>(100);

        public override DateOnly ExpirationDate
        {
            get
            {
                if (_boxes.Any())
                    return _boxes.OrderBy(box => box.ExpirationDate).First().ExpirationDate;
                else
                    return DateOnly.FromDateTime(DateTime.Now);//!
            }
        }
        public override float Volume
        {
            get
            {
                if (_boxes != null && _boxes.Any())
                    return _boxes.Sum(box => box.Volume) + Height * Width * Depth;
                else
                    return Height * Width * Depth;
            }
        }

        public Pallet(int width, int height, int depth, float weight) : base(width, height, depth, weight)
        {

        }
        public Pallet(int id, int width, int height, int depth, float weight) : base(id, width, height, depth, weight)
        {

        }

        public bool AddBox(T box)
        {
            if (!Fits(box))
                return false;

            _boxes.Add(box);

            return true;
        }

        public bool AnyBox()
            => _boxes.Any();

        private bool Fits(T box)
            => box.Width <= Width && box.Depth <= Depth;

        public override string ToString()
            => $"Pallet:\n\tHeight={Height}\n\tWidth={Width}\n\tDepth={Depth}\n\t" +
            $"Volume={Volume}\n\tExpirationDate={ExpirationDate}\n\tBoxesCount={_boxes.Count}";
    }
}
