namespace psp_bugos.Utilities;

public static class DtoMapper
{
    public static T2 MapDtoOnDto<T1, T2>(T1 fromDto, T2 toDto)
        where T1: notnull
        where T2: notnull
    {
        var fromDtoProperties = fromDto
            .GetType()
            .GetProperties()!;
        var toDtoProperties = toDto
            .GetType()
            .GetProperties()
            .ToDictionary(property => property.Name)!;

        foreach (var fromDtoProperty in fromDtoProperties)
        {
            var newValue = fromDtoProperty.GetValue(fromDto);

            if (IsDefault(newValue))
                continue;

            if (toDtoProperties.TryGetValue(fromDtoProperty.Name, out var toDtoProperty))
                toDtoProperty.SetValue(toDto, newValue);
        }

        return toDto;
    }

    private static bool IsDefault(object? obj)
    {
        var type = obj?.GetType();

        if (type == typeof(string))
            return string.IsNullOrEmpty((string)obj!);
        if (type == typeof(decimal))
            return (decimal)obj! == 0;
        if (type == typeof(int))
            return (int)obj! == 0;
        if (type == typeof(Guid))
            return Guid.Empty.Equals((Guid)obj!);
        return false;
    }
}
