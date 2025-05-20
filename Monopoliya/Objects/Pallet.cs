using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya.Objects
{
    public class Pallet<T> : WarehouseObj where T : WarehouseObj
    {
        private ICollection<T> _items = new List<T>(100);

        public override DateOnly ExpirationDate
        {
            get
            {
                if (_items.Any())
                    return _items.OrderBy(item => item.ExpirationDate).First().ExpirationDate;
                else
                    return DateOnly.FromDateTime(DateTime.Now);//!
            }
        }
        public override float Volume
        {
            get
            {
                if (_items != null && _items.Any())
                    return _items.Sum(item => item.Volume) + Height * Width * Depth;
                else
                    return Height * Width * Depth;
            }
        }

        public override float Weight
        {
            get
            {
                if (_items != null && _items.Any())
                    return _items.Sum(item => item.Weight) + _weight;
                else
                    return _weight;
            }
        }

        private float _weight;

        public Pallet(int width, int height, int depth, float weight) : base(width, height, depth)
        {
            _weight = weight;
        }
        public Pallet(int id, int width, int height, int depth, float weight) : base(id, width, height, depth)
        {
            _weight = weight;
        }

        public bool AddItem(T item)
        {
            if (!Fits(item))
                return false;

            _items.Add(item);

            return true;
        }

        public bool AnyBox()
            => _items.Any();

        private bool Fits(T item)
            => item.Width <= Width && item.Depth <= Depth;

        public override string ToString()
            => $"Pallet:\n\tHeight={Height}\n\tWidth={Width}\n\tDepth={Depth}\n\t" +
            $"Weight={Weight}\n\tVolume={Volume}\n\tExpirationDate={ExpirationDate}\n\tBoxesCount={_items.Count}";
    }
}
