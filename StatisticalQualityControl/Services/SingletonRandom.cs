using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatisticalQualityControl.Services
{
    public class SingletonRandom
    {
        private static Random _rnd;

        public static Random Rnd
        {
            get
            {
                if (_rnd == null)
                {
                    _rnd = new Random();
                }
                return _rnd;
            }
        }
    }
}