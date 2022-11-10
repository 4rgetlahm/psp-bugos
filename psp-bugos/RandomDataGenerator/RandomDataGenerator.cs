namespace psp_bugos.RandomDataGenerator;

public class RandomDataGenerator : IRandomDataGenerator
{
    public T GenerateValues<T>() where T : class, new()
    {
        var result = new T();
        var properties = typeof(T).GetProperties();
        var random = new Random();
        foreach (var property in properties)
        {
            switch (property.PropertyType)
            {
                case { } t when t == typeof(string):
                    property.SetValue(result, $"Test {property.Name}");
                    break;
                case { } t when t == typeof(int):
                    property.SetValue(result, random.Next());
                    break;
                case { } t when t == typeof(decimal):
                    property.SetValue(result, new decimal(random.NextDouble()));
                    break;
                case { } t when t == typeof(DateTime):
                    property.SetValue(result, DateTime.Now);
                    break;
                case { } t when t == typeof(bool):
                    property.SetValue(result, random.Next(0, 2) == 1);
                    break;
                case { } t when t == typeof(Guid):
                    property.SetValue(result, Guid.NewGuid());
                    break;
                case { } t when t == typeof(Enum):
                    property.SetValue(result,
                        Enum.GetValues(property.PropertyType)
                            .GetValue(random.Next(0, Enum.GetValues(property.PropertyType).Length)));
                    break;
                default:
                    property.SetValue(result, null);
                    break;
            }
        }
        return result;
    }
}