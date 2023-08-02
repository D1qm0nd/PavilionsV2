using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionsData.Extentions
{
    public static class EntityExtention
    {
        public static Dictionary<string, object> GetPropertyValues(this object entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties();

            Dictionary<string, object> result = new();

            foreach ( var property in properties ) 
            {
                var value = property.GetValue(entity);
                result.Add(property.Name, value);
            }

            return result;
        }
    }
}
