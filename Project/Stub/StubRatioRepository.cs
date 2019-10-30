using Insurance.BL.Intefaces;
using Insurance.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class StubRatioRepository : IRatioRepository
    {
        public Ratio GetRatio(string carNumber)
        {
            return new Ratio(1.2, 1.1, 0.8, 1.0);
        }
    }
}
