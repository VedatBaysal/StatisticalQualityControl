using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StatisticalQualityControl.Models;

namespace StatisticalQualityControl.Services
{
    public static class SingletonDbModel
    {
        private static StatisticalQualityControlModel _db = null;

        public static StatisticalQualityControlModel Db => _db ?? (_db = new StatisticalQualityControlModel());
    }
}