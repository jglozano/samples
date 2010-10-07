namespace InferredPoco.Controllers {
    using System;
    using System.Web.Mvc;
    using Newtonsoft.Json;

    public class PocoResult : ActionResult {
		public PocoResult () { }

		public PocoResult (object pocoModel) {
			Model = pocoModel;
		}

		public object Model { get; set; }

		public override void ExecuteResult (ControllerContext context) {
			if (context == null) {
				throw new ArgumentNullException ("context");
			}
			
			var response = context.HttpContext.Response;
			response.ContentType = "application/json";
			
			var writer = new JsonTextWriter (response.Output) { Formatting = Formatting.None };
			var serializer = JsonSerializer.Create (new JsonSerializerSettings ());
			serializer.Serialize (writer, Model);
			
			writer.Flush ();
		}
	}
}

