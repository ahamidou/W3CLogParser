using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace W3cLogParser
{
    public class W3CEntityMapper<TEntity> where TEntity : new()
    {
        private readonly Dictionary<string, string> _mappings;

        public W3CEntityMapper()
        {
            _mappings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Used by the parser class to extract the mapping rules
        /// </summary>
        /// <returns></returns>
        public IReadOnlyDictionary<string, string> GetMappings()
        {
            return _mappings;
        }
        
        /// <summary>
        /// Map current object property from a W3C log file field.
        /// </summary>
        /// <param name="objectProperty">Choose a property to map to</param>
        /// <param name="logFieldName">The name of the field found in ParseFields class to be mapped from</param>
        /// <returns></returns>
        public W3CEntityMapper<TEntity> Map<TPropertyType>(Expression<Func<TEntity, TPropertyType>> objectProperty, string logFieldName)
        {
            var memberExpression = objectProperty.Body as MemberExpression;
            if (memberExpression == null) throw new ArgumentNullException(objectProperty.ToString());
            var objectPropertyName = memberExpression.Member.Name;
            _mappings.Add(logFieldName, objectPropertyName);
            return this;
        }
    }
}