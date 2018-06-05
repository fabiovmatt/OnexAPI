using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index()
        {
            IEnumerable<MvcMaterialModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Material").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcMaterialModel>>().Result;
            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new MvcMaterialModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Material/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcMaterialModel>().Result);
            }
                                 
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcMaterialModel mat)
        {
            if (mat.MaterialID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Material", mat).Result;
                TempData["SuccessMessage"] = "Salvo com sucesso!";
                return RedirectToAction("Index");
            }
            else
            {

                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Material/" + mat.MaterialID, mat).Result;
                TempData["SuccessMessage"] = "Atualizado com sucesso!";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Material/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deletado com sucesso!";
            return RedirectToAction("Index");
        }

      }
}