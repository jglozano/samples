namespace InferredPoco.Controllers {
    using System;
    using System.Collections;
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public class PocoResult : ActionResult {
        public PocoResult() { }

        public PocoResult(object pocoModel) {
            Model = pocoModel;
        }

        public object Model { get; set; }

        public override void ExecuteResult(ControllerContext context) {
            if (context == null) {
                throw new ArgumentNullException("context");
            }

            var response = context.HttpContext.Response;
            response.ContentType = "application/json";

            // Avoid JSON hijacking
            if (Model is IEnumerable) {
                var tempModel = Model as IEnumerable;
                Model = new {Data = tempModel};
            }

            // Use JSON.NET from Newtonsoft to handle the JSON serialization for us
            // You could use the default JSON serialization, or 
            // even make PocoResult inherit from JsonResult if you're more comfortable.
            var writer = new JsonTextWriter(response.Output) { Formatting = Formatting.None };
            var serializer = JsonSerializer.Create(new JsonSerializerSettings());
            serializer.Serialize(writer, Model);

            writer.Flush();
        }
    }
}

