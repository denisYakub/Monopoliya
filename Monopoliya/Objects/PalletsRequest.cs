using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoliya.Objects
{
    public record struct PalletsRequest(
        int NumberOfPallets,
        (int W, int H, int D) MaxSizesOfPallets,
        float PalletWeight);
}
