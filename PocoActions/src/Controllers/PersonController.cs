namespace InferredPoco.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;

    [HandleError]
    public class PersonController : Controller {
        private static readonly IList<Person> personList = new List<Person>();

        #region Boring ActionResult-based code

        public ActionResult Index() {
            return View(personList);
        }

        public ActionResult CreateNew() {
            return View(new Person());
        }

        public ActionResult Delete(Person person) {
            if (person != null) {
                personList.Remove(person);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Create(Person person) {
            if (person != null) {
                person.Id = Guid.NewGuid();
                personList.Add(person);
            }

            return RedirectToAction("index");
        }

        #endregion

        public IList<Person> GetList() {
            return personList;
        }
    }
}
