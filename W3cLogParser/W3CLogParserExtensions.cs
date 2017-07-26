using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace W3cLogParser
{
    internal static class W3CLogParserExtensions
    {
        internal static T ToLogEntry<T>(this string logLine, IReadOnlyDictionary<int, string> mappings) where T : new()
        {
            var entry = new T();
            var lineArray = logLine.Split(' ');
            foreach (var keyValuePair in mappings)
            {
                var index = keyValuePair.Key;
                var propertyName = keyValuePair.Value;
                var propertyInfo = entry.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (propertyInfo == null)
                {
                    throw new ArgumentOutOfRangeException(propertyName);
                }
                var propertyValue = lineArray[index] == "-" ? "" : lineArray[index];
                propertyInfo.SetValue(entry, propertyValue.CastValue(propertyInfo.PropertyType));
            }
            return entry;
        }

        internal static IReadOnlyDictionary<int, string> GetLogFileFields(this string filePath, IReadOnlyDictionary<string, string> entityMappings)
        {
            var line = ReadHeadingLine(filePath);
            var fields = new Dictionary<int, string>();
            for (var i = 0; i < line.Length; i++)
            {
                if (entityMappings.ContainsKey(line[i]))
                    fields.Add(i, entityMappings[line[i]]);
            }
            return fields;
        }

        private static object CastValue(this string stringValue, Type propertyType)
        {
            var converter = TypeDescriptor.GetConverter(propertyType);
            return converter.CanConvertFrom(typeof(string)) ? converter.ConvertFrom(stringValue) : default(object);
        }

        private static string[] ReadHeadingLine(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                while (true)
                {
                    var line = streamReader.ReadLine();
                    if (line == null) break;
                    if (!line.StartsWith("#Fields:")) continue;
                    return line.Replace("#Fields:", "").Trim().Split(' ');
                }
                throw new InvalidDataException("Cannot read header line");
            }
        }
    }
}