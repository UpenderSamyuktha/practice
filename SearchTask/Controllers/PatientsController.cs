using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SearchTask.Models;
using SearchTask.BusinessLogicLayer;
using System.Web.Http.Cors;
//using System.Web.Mvc;
using SearchTask.DataAccessLayer;
using Newtonsoft.Json;
//using System.Web.Mvc;
//using System.Web.Mvc;

namespace SearchTask.Controllers
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientsController : ApiController
    {
        BAL objbal = new BAL();
        DA obj1 = new DA();

        //public List<Patient> GetAllEmployees()
        //{
        //    List<Patient> ptslist = new List<Patient>();
        //    try
        //    {

        //        ptslist = objbal.AllPatients();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return ptslist;
        //}

        //public List<Country1> GetAllData()
        //{
        //    List<Country1> countrylist = new List<Country1>();
        //    try
        //    {
        //        countrylist = obj1.GetCountries();
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //    //return Json(countrylist, JsonRequestBehavior.AllowGet);
        //    return countrylist;
        //}
        [HttpGet]
        public List<Country1> GetData()
        {
            List<Country1> clist = new List<Country1>();
            DA objdb = new DA();
            clist = objdb.GetAllCountriesnew();

            return clist;


        }


        //[HttpGet]
        //public JsonResult GetData()
        //{
        //    List<Country1> clist = new List<Country1>();
        //    db objdb = new db();
        //    clist = objdb.GetAllCountries();

        //    return Json(clist, JsonRequestBehavior.AllowGet);


        //}

        [HttpGet]
        [Route("api/Patients/GetAllPatients")]
        public HttpResponseMessage GetAllPatients()
        {
            try
            {
                var PatientList = objbal.AllPatients();
                if (PatientList.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, PatientList);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patients Data was not there in Employees Table from database...!");
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        

        [HttpGet]
        [Route("api/Patients/AllHospitals")]
        public HttpResponseMessage AllHospitals()
        {
            try
            {
                var hospitallist = objbal.AllHospitals();
                if (hospitallist.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, hospitallist);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Hospital data was not avilable in the hospital tablre in the database..!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Patients/InsertPatient")]
        public HttpResponseMessage InsertPatient( Patient pnt)
        {
            var patient = objbal.InsertPatient(pnt);
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, patient);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Patients/GetPatientById/{id}")]
       public HttpResponseMessage GetPatientById(string id)
        {
            var patient = objbal.GetPatient(id);
            try
            {
                
                if (patient != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, patient);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The Patient by Id=" + id + " was not found...!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
       }
        [HttpDelete]
        [Route("api/Patients/DeletePatient/{id}")]
        public HttpResponseMessage DeletePatient(string id)
        {
            var patient = objbal.GetPatient(id);
            try
            {
                if(patient!=null)
                {
                    objbal.DeletePatient(id);

                    return Request.CreateResponse(HttpStatusCode.OK, patient);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The Patient by Id=" + id + " was not found...!");
                }
            } catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("api/Patients/UpdatePatient")]
        public HttpResponseMessage UpdatePatient(Patient pt)
        {
            //var patient = objbal.GetPatient(pt.MobileNumber);
            try
            {
                if(objbal.GetPatient(pt.MobileNumber) !=null)
                { 
                objbal.UpdatePatient(pt);
                return Request.CreateResponse(HttpStatusCode.OK,pt);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "the Patient of" + pt.MobileNumber + "is not founded");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }
        // [HttpGet]
       

    }
}
