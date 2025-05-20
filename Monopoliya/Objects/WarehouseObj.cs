using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya.Objects
{
    public abstract class WarehouseObj
    {
        public int Id;
        public int Width;
        public int Height;
        public int Depth;
        public float Weight;

        public abstract float Volume { get; }
        public abstract DateOnly ExpirationDate { get; }

        public WarehouseObj(int id, int width, int height, int depth, float weight) 
            => (Id, Width, Height, Depth, Weight) = (id, width, height, depth, weight);
        public WarehouseObj(int width, int height, int depth, float weight)
            => (Width, Height, Depth, Weight) = (width, height, depth, weight);
    }
}
