using Monopoliya.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya
{
    public interface Generator
    {
        IReadOnlyCollection<WarehouseObj> Generate();
    }
}
