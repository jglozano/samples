using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace inferredPoco.Controllers
{
	using Models;

	[HandleError]
	public class HomeController : Controller
	{
		private static IList<Person> personList = new List<Person>();
		
		public ActionResult Index () {
			ViewData["Message"] = "Welcome to ASP.NET MVC on Mono!";
			return View ();
		}
		
		public IList<Person> GetList() {
			return personList;
		}
		
	}
}

