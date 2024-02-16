using System.Reflection;

namespace Helmer.Shared.Common.Extensions;

public static class ObjectExtensions
{
    public static T ToObject<T>(this IDictionary<string, object> source)
        where T : class, new()
    {
        var someObject = new T();
        var someObjectType = someObject.GetType();

        foreach (var item in source)
            someObjectType
                .GetProperty(item.Key)
                .SetValue(someObject, item.Value, null);

        return someObject;
    }

    public static IDictionary<string, object> AsDictionary(this object source,
        BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
    {
        return source.GetType().GetProperties(bindingAttr).ToDictionary
        (
            propInfo => propInfo.Name,
            propInfo => propInfo.GetValue(source, null)
        );
    }

    /// <summary>
    ///     Check if an interface is implemented on a <see cref="System.Type" />
    /// </summary>
    /// <typeparam name="I">The interface</typeparam>
    /// <param name="source">The source object</param>
    /// <returns></returns>
    public static bool Implements<I>(this object source) where I : class
    {
        return typeof(I).IsAssignableFrom(source.GetType());
    }

    /// <summary>
    ///     Checks if the object is equal to any of the supplied values
    /// </summary>
    /// <param name="source">The source object</param>
    /// <param name="values">The values to check the object against</param>
    /// <returns>True if the object is equal to any of the values,otherwise returns false</returns>
    public static bool IsAnyOf<T>(this T source, params T[] values)
    {
        var result = false;
        foreach (var val in values)
        {
            result = source.Equals(val);

            if (result) break;
        }

        return result;
    }
}