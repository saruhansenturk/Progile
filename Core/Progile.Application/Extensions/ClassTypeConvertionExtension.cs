namespace Progile.Application.Extensions
{
    public static class ClassTypeConvertionExtension
    {
        //public static TDest? MapTo<TDest>(this object source)
        //{
        //    var srcProperties = source.GetType().GetProperties();
        //    var destProperties = typeof(TDest).GetProperties();
        //    var destination = Activator.CreateInstance(typeof(TDest));

        //    foreach (var srcProp in srcProperties)
        //    {
        //        var destProp = destProperties.FirstOrDefault(t => t.Name == srcProp.Name && t.PropertyType == srcProp.PropertyType);
        //        if (destProp != null)
        //        {
        //            var value = srcProp.GetValue(source);
        //            destProp.SetValue(destination, value);
        //        }
        //    }

        //    return (TDest?)destination;
        //}

        public static TDest MapTo<TDest>(this object? source) where TDest : new()
        {
            if (source == null)
            {
                return default(TDest);
            }

            var srcProperties = source.GetType().GetProperties();
            var destProperties = typeof(TDest).GetProperties();
            var destination = new TDest();

            foreach (var srcProp in srcProperties)
            {
                var destProp = destProperties.FirstOrDefault(t => t.Name == srcProp.Name && t.PropertyType == srcProp.PropertyType);

                if (destProp == null) continue;
                var value = srcProp.GetValue(source);

                if (value != null)
                {
                    destProp.SetValue(destination, value);
                }
            }

            return destination;
        }

    }
}
