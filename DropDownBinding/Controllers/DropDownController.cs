using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownBinding.Controllers
{
    public class DropDownController : Controller
    {
        DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
        // GET: DropDown
        public ActionResult Index()
        {
            Country_Bind();
            return View();
        }

        public void Country_Bind()
        {
            DataSet ds = DAL.Get_Country();
            List<SelectListItem> countryList = new List<SelectListItem>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                countryList.Add(new SelectListItem { Text = dataRow["CountryName"].ToString(), Value = dataRow["CountryID"].ToString() });
            }
            ViewBag.Country = countryList;
        }
        public JsonResult State_Bind(String country_id)
        {
            DataSet ds = DAL.Get_State(country_id);
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                stateList.Add(new SelectListItem { Text = dataRow["StateName"].ToString(), Value = dataRow["StateID"].ToString() });
            }
            return Json(stateList , JsonRequestBehavior.AllowGet);

        }

        public JsonResult City_Bind(String state_id)
        {
            DataSet ds = DAL.Get_City(state_id);
            List<SelectListItem> cityList = new List<SelectListItem>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                cityList.Add(new SelectListItem { Text = dataRow["CityName"].ToString(), Value = dataRow["CityID"].ToString() });
            }
            return Json(cityList, JsonRequestBehavior.AllowGet);

        }
    }
}