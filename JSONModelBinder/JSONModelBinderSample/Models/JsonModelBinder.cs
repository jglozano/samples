namespace JSONModelBinderSample.Models {
    using System.IO;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;

    /// <summary>
    /// Model binder that does the mapping for any JSON request or basic request
    /// </summary>
    public class JsonModelBinder : DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            if(!IsJSONRequest(controllerContext)) {
                return base.BindModel(controllerContext, bindingContext);
            }

            // Get the JSON data that's been posted
            var request = controllerContext.HttpContext.Request;
            var jsonStringData = new StreamReader(request.InputStream).ReadToEnd();
 
            // Use the built-in serializer to do the work for us
            return new JavaScriptSerializer()
                .Deserialize(jsonStringData, bindingContext.ModelMetadata.ModelType);

            // -- REQUIRES .NET4
            // If you want to use the .NET4 version of this, change the target framework and uncomment the line below
            // and uncomment the above return statement
            //return new JavaScriptSerializer().Deserialize(jsonStringData, bindingContext.ModelMetadata.ModelType);            
        }

        private static bool IsJSONRequest(ControllerContext controllerContext) {
            var contentType = controllerContext.HttpContext.Request.ContentType;
            return contentType.Contains("application/json");
        }
    }
}