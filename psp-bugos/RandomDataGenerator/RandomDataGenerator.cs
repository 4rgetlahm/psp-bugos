namespace psp_bugos.RandomDataGenerator;

public class RandomDataGenerator : IRandomDataGenerator
{
    public T GenerateValues<T>(Guid? id = null) where T : class, new()
    {
        var result = new T();
        var properties = typeof(T).GetProperties();
        var random = new Random();
        foreach (var property in properties)
        {
            if (property.Name != "Id")
            {
                var type = property.PropertyType;
                if (type == typeof(string))
                    property.SetValue(result, $"Test {property.Name}");
                else if (type == typeof(int))
                    property.SetValue(result, random.Next());
                else if (type == typeof(decimal))
                    property.SetValue(result, new decimal(random.NextDouble()));
                else if (type == typeof(DateTime))
                    property.SetValue(result, DateTime.Now);
                else if (type == typeof(bool))
                    property.SetValue(result, random.Next(0, 2) == 1);
                else if (type == typeof(Guid))
                    property.SetValue(result, Guid.NewGuid());
                else if (type == typeof(Enum))
                    property.SetValue(result,
                        Enum.GetValues(property.PropertyType)
                            .GetValue(random.Next(0, Enum.GetValues(property.PropertyType).Length)));
                else
                    property.SetValue(result, null);
            }
            else
            {
                property.SetValue(result, id ?? Guid.NewGuid());
            }
        }
        return result;
    }
}