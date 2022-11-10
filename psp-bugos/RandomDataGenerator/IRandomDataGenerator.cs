namespace psp_bugos.RandomDataGenerator;

public interface IRandomDataGenerator
{
   T GenerateValues<T>() where T : class, new();
}
