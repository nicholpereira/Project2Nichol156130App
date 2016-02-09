using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace LayeredApplication.DataLayer.Infrastructure.Helper
{
    public static class Extensions
    {
        private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> _Properties =
            new Dictionary<Type, IEnumerable<PropertyInfo>>();

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static IEnumerable<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                var objType = typeof(T);
                IEnumerable<PropertyInfo> properties;

                lock (_Properties)
                {
                    if (!_Properties.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite);
                        _Properties.Add(objType, properties);
                    }
                }

                var list = new List<T>(table.Rows.Count);

                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        try
                        {
                            prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                        }
                        catch
                        {
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return Enumerable.Empty<T>();
            }
        }

        public static List<SqlParameter> ToSqlParameters<T>(this T obj, params string[] ignoreProperties) where T : class, new()
        {
            if (obj == null) return new List<SqlParameter>();

            PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (var item in properties)
            {
                if (ignoreProperties != null && ignoreProperties.Contains(item.Name)) continue;
                var val = item.GetValue(obj, null);
                SqlParameter para = new SqlParameter(item.Name, val);
                parameters.Add(para);
            }

            return parameters;
        }
    }
}
