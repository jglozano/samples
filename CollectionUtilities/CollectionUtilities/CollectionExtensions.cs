namespace CollectionUtilities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Reflection;

    public static class CollectionExtensions
    {
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            var table = CreateTable<T>();
            var properties = TypeDescriptor.GetProperties(typeof(T));

            foreach (T item in list)
            {
                var row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static IList<T> ToDataTable<T>(this IList<DataRow> rows)
        {
            if (rows == null) return null;

            var list = new List<T>();

            foreach (DataRow row in rows)
            {
                var item = CreateItem<T>(row);
                list.Add(item);
            }

            return list;
        }

        public static IList<T> ToList<T>(this DataTable table)
        {
            if (table == null) return null;

            var rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ToDataTable<T>(rows);
        }

        public static T CreateItem<T>(this DataRow row)
        {
            if (row == null) return default(T);

            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in row.Table.Columns)
            {
                PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                object value = row[column.ColumnName];
                prop.SetValue(obj, value, null);
            }

            return obj;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            var table = new DataTable(entityType.Name);
            var properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            return table;
        }
    }
}