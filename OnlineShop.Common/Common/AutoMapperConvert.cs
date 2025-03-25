using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Common.Common
{
    public static class AutoMapperConvert
    {
        public static TDistince ConfigMap<TSource,TDistince>(object Source )
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDistince>());
            var mapper = new Mapper(config);
            var Result = mapper.Map<TDistince>(Source);
            return Result;
        }

         

        public static List<TDistince> ConfigMapList<TSource, TDistince>(List<TSource> Source)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource,TDistince>());
            var mapper = new Mapper(config);
            var Result = mapper.Map<List<TDistince>>(Source);
            return Result;
        }
    }
}
