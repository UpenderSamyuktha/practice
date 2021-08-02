using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchTask.Models;
using SearchTask.IRepository;
using SearchTask.Repository;

namespace SearchTask.BusinessLogicLayer
{
    public class BAL
    {
        IReposite IobjRep = new Reposite();
        public List<Patient> AllPatients()
        {
            return IobjRep.AllPatients();
        }
        public List<hospital> AllHospitals()
        {
            return IobjRep.AllHospitals();
        }
        public Patient InsertPatient(Patient pnt)
        {
            return IobjRep.InsertPatient(pnt);
        }
        public Patient GetPatient(string id)
        {
            return IobjRep.GetPatient(id);
        }
        public Patient DeletePatient(string id)
        {
            return IobjRep.DeletePatient(id);
        }
        public Patient UpdatePatient(Patient pt)
        {
            return IobjRep.UpdatePatient(pt);
        }
    }
}