using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Services.Interfaces;

namespace Test.Data.Services
{
    public class MapperService : IMapperService
    {
        public MapperService() { }
        public TDestination SimpleMap<TSource, TDestination>(TSource source)
        {
            

            Type sourceType = typeof(TSource);
            Type destinationType = typeof(TDestination);

            TDestination destination = Activator.CreateInstance<TDestination>();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = Array.Find(destinationProperties, prop => prop.Name == sourceProperty.Name);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    object value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }

            return destination;
        }
    }
}
