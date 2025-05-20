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

        public abstract float Weight {  get; }

        public abstract float Volume { get; }
        public abstract DateOnly ExpirationDate { get; }

        public WarehouseObj(int id, int width, int height, int depth) 
            => (Id, Width, Height, Depth) = (id, width, height, depth);
        public WarehouseObj(int width, int height, int depth)
            => (Width, Height, Depth) = (width, height, depth);
    }
}
