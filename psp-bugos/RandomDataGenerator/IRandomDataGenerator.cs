namespace psp_bugos.RandomDataGenerator;

public interface IRandomDataGenerator
{
   T GenerateValues<T>(Guid? id = null) where T : class, new();
}
