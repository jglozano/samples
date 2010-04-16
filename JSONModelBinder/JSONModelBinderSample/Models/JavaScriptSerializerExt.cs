namespace JSONModelBinderSample.Models {
    using System;
    using System.Reflection;
    using System.Web.Script.Serialization;

    /// <summary>
    /// Extension helper to handle the dirty work of reflection for the 'magic' to just happen
    /// </summary>
    public static class JavaScriptSerializerExt {
        public static object Deserialize(this JavaScriptSerializer serializer, string input, Type objType) {
            var deserializerMethod = serializer.GetType().GetMethod("Deserialize", BindingFlags.NonPublic | BindingFlags.Static);

            // internal static method to do the work for us
            //Deserialize(this, input, null, this.RecursionLimit);

            return deserializerMethod.Invoke(serializer,
                new object[] { serializer, input, objType, serializer.RecursionLimit });
        }
    }
}