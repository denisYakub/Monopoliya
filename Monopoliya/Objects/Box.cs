using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya.Objects
{
    public class Box : WarehouseObj
    {
        public override DateOnly ExpirationDate
        {
            get
            {
                if (_expirationDate.HasValue)
                    return _expirationDate.Value;
                else if (_productionDate.HasValue)
                    return _productionDate.Value.AddDays(100);
                else
                    throw new ArgumentException("Expiration Date and Production Date aren't set!");//!
            }
        }
        public override float Volume
        {
            get
            {
                return Height * Width * Depth;
            }
        }

        public override float Weight
        {
            get
            {
                return _weight;
            }
        }

        private float _weight;

        private DateOnly? _expirationDate;
        private DateOnly? _productionDate;

        public Box(int width, int height, int depth, float weight, DateOnly? expirationDate, DateOnly? productionDate) 
            : base(width, height, depth)
        {
            _expirationDate = expirationDate;//!
            _productionDate = productionDate;//!

            _weight = weight;
        }
        public Box(int id, int width, int height, int depth, float weight, DateOnly? expirationDate, DateOnly? productionDate) 
            : base(id, width, height, depth)
        {
            _expirationDate = expirationDate;//!
            _productionDate = productionDate;//!

            _weight = weight;
        }

        public override string ToString()
            => $"Box:\n\tHeight={Height}\n\tWidth={Width}\n\tDepth={Depth}\n\t" +
            $"Weight={Weight}\n\tVolume={Volume}\n\tExpirationDate={ExpirationDate}";
    }
}
