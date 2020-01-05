using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FormDataKVPCreator
{
    public class Creator<T> where T : class
    {
        public void addKVP(List<KeyValuePair<string, object>> original_object, object obj, string prefix = "")
        {
            if (obj == null)
            {
                return;
            }

            Type type = obj.GetType();

            bool isObjectValueTypeOrString = type.IsValueType || type == typeof(string);

            if (isObjectValueTypeOrString)
            {
                prefix = removeLastAppearanceOfPeriod(prefix);
                addKeyValueToCollection(prefix, obj, original_object);
                return;
            }

            List<PropertyInfo> publicPropertiesOfClass = obj.GetType().GetProperties().ToList();

            foreach (var property in publicPropertiesOfClass)
            {
                var formDataValue = new List<KeyValuePair<string, object>>();

                bool isPropertyACollection = property.PropertyType != typeof(string) && IsList(property);

                bool isPropertyReferenceToAnotherReferenceType = !property.PropertyType.IsValueType && property.PropertyType != typeof(string);

                if (isPropertyACollection)
                {
                    var castedList = (IList)property.GetValue(obj, null);
                    int sn = 0;
                    foreach (var value in castedList)
                    {
                        string propertyPrefix = $"{property.Name}[{sn}].";
                        addKVP(original_object, value, propertyPrefix);
                        sn++;
                    }
                }

                else if (isPropertyReferenceToAnotherReferenceType)
                {
                    string propertyPrefix = $"{property.Name}.";
                    var valueOfProperty = property.GetValue(obj, null);
                    addKVP(original_object, valueOfProperty, propertyPrefix);
                }
                else
                {
                    var valueOfProperty = property.GetValue(obj, null);
                    string propertyKey = $"{prefix}{property.Name}";

                    addKeyValueToCollection(propertyKey, valueOfProperty, original_object);
                }
            }
        }

        private string removeLastAppearanceOfPeriod(string prefix)
        {
            int lastIndexOfPeriod = prefix.LastIndexOf('.');
            if (lastIndexOfPeriod != -1)
            {
                prefix = prefix.Remove(lastIndexOfPeriod, 1);
            }
            return prefix;
        }

        private void addKeyValueToCollection(string key, object value, List<KeyValuePair<string, object>> collection)
        {
            collection.Add(new KeyValuePair<string, object>(key, value));
        }

        private bool IsList(PropertyInfo value)
        {
            return value.PropertyType is IList || IsGenericList(value);
        }

        private bool IsGenericList(PropertyInfo value)
        {
            return value.PropertyType.IsGenericType
                && typeof(List<>) == value.PropertyType.GetGenericTypeDefinition();
        }
    }
}
