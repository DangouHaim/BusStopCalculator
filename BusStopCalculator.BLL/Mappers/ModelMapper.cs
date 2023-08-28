using System.Linq.Expressions;
using System.Reflection;

namespace  BusStopCalculator.BLL.Mappers;

public static class MapperUtils
{
    public static Func<TInput, TOutput> CreateMapFunc<TInput, TOutput>()
    {
        var source = Expression.Parameter(typeof(TInput), "source");

        var body = Expression.MemberInit(
            Expression.New(typeof(TOutput)),
            source.Type.GetProperties().Select(p => Expression.Bind(
                typeof(TOutput).GetProperty(p.Name), MapProperty(source, p))));

        var expr = Expression.Lambda<Func<TInput, TOutput>>(body, source);

        return expr.Compile();
    }

    private static Expression MapProperty(Expression source, PropertyInfo propertyInfo)
    {
        if (!propertyInfo.PropertyType.IsPrimitive && propertyInfo.PropertyType != typeof(string))
        {
            // Handle non-primitive or nested types recursively
            var mapFuncType = typeof(Map<>).MakeGenericType(propertyInfo.PropertyType);
            var mapFuncConstructor = mapFuncType.GetConstructor(new[] { propertyInfo.PropertyType });
            var mapFunc = Expression.New(mapFuncConstructor, Expression.Property(source, propertyInfo));
            var toMethod = mapFuncType.GetMethod("To");
            return Expression.Call(mapFunc, toMethod.MakeGenericMethod(typeof(object)));
        }
        else
        {
            // Map primitive types directly
            return Expression.Property(source, propertyInfo);
        }
    }
}

public static class MapFunc<TInput, TOutput>
{
    public static readonly Func<TInput, TOutput> Instance = MapperUtils.CreateMapFunc<TInput, TOutput>();
}

public struct Map<TSource>
{
    public readonly TSource Value;
    public Map(TSource value) { Value = value; }
    public TDestination To<TDestination>() { return MapFunc<TSource, TDestination>.Instance(Value); }
}