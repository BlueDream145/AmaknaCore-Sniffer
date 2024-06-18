using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaknaProxy.API.IO
{
    public class FinalInt64
    {

        #region Variables

        public double Low;
        public int High;

        #endregion

        #region Builder

        public FinalInt64(double param1 = 0, int param2 = 0)
        {
            Low = param1;
            High = param2;
        }

        #endregion

        #region Methods

        public static FinalInt64 FromNumber(double param1)
        {
            double d = Math.Floor((double)(param1 / 4294967296.0));
            return new FinalInt64(param1, (int)d);
        }

        public Double ToNumber()
        {
            return High * 4.294967296E9 + Low;
        }

        #endregion

    }
}
