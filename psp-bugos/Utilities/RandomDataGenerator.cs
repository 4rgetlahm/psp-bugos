using Microsoft.AspNetCore.Server.IISIntegration;
using psp_bugos.Utilities;

namespace psp_bugos.RandomDataGenerator;

public class RandomDataGenerator : IRandomDataGenerator
{
    public T GenerateValues<T>(Guid? id = null) where T : class, new()
    {
        var seed = 0;
        var random = new Random(seed);

        var result = new T();
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var prop = property.GetValue(result);

            if (property.Name != "Id")
            {
                var type = property.PropertyType;
                if (type == typeof(string))
                {
                    if(property.Name.Contains("PhoneNumber"))
                        property.SetValue(result, "+37064464425");
                    else if (property.Name.Contains("Email"))
                        property.SetValue(result, "test.email@mail.com");
                    else if (property.Name.Contains("Address"))
                        property.SetValue(result, "evergreen 123");
                    else if (property.Name.Contains("City"))
                        property.SetValue(result, "Florida");
                    else if (property.Name.Contains("ZipCode"))
                        property.SetValue(result, "12345");
                    else if (property.Name.Contains("ImageUrl"))
                        property.SetValue(result, "https://indianmemetemplates.com/wp-content/uploads/sad-pepe-the-frog.jpg");
                    else
                        property.SetValue(result, $"Test {property.Name}");
                }
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