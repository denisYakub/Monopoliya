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

        private DateOnly? _expirationDate;
        private DateOnly? _productionDate;

        public Box(int width, int height, int depth, float weight, DateOnly? expirationDate, DateOnly? productionDate) 
            : base(width, height, depth, weight)
        {
            _expirationDate = expirationDate;//!
            _productionDate = productionDate;//!
        }
        public Box(int id, int width, int height, int depth, float weight, DateOnly? expirationDate, DateOnly? productionDate) 
            : base(id, width, height, depth, weight)
        {
            _expirationDate = expirationDate;//!
            _productionDate = productionDate;//!
        }

        public override string ToString()
            => $"Box:\n\tHeight={Height}\n\tWidth={Width}\n\tDepth={Depth}\n\t" +
            $"Volume={Volume}\n\tExpirationDate={ExpirationDate}";
    }
}
