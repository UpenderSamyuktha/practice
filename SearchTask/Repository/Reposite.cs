using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchTask.Models;
using SearchTask.IRepository;

namespace SearchTask.Repository
{
    public class Reposite : IReposite
    {
        public List<hospital> AllHospitals()
        {
            List<hospital> hospitals = new List<hospital>();
            try
            {
                using(OutPatientTrackingSystemEntities es=new OutPatientTrackingSystemEntities())
                {
                    hospitals = es.hospitals.ToList();
                }

            }
            catch(Exception ex)
            {

            }
            return hospitals;
        }

        public List<Patient> AllPatients()
        {
            List<Patient> Patients = new List<Patient>();
            try
            {
               using(OutPatientTrackingSystemEntities pt=new OutPatientTrackingSystemEntities())
                {
                    Patients = pt.Patients.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return Patients;
        }

        public Patient DeletePatient(string id)
        {
            Patient pt1 = new Patient();
            try
            {
                using (OutPatientTrackingSystemEntities ot = new OutPatientTrackingSystemEntities())
                {
                    pt1 = ot.Patients.Where(x => x.MobileNumber == id).FirstOrDefault();
                    ot.Patients.Remove(pt1);
                    ot.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return pt1;
        }

        public Patient GetPatient(string id)
        {
            Patient pt1 = new Patient();
            try
            {
                using (OutPatientTrackingSystemEntities ot = new OutPatientTrackingSystemEntities())
                {
                    pt1 = ot.Patients.Where(x => x.MobileNumber == id).FirstOrDefault();
                    return pt1;
                }
            }
            catch (Exception ex)
            {

            }
            return pt1;
        }

        public Patient InsertPatient(Patient pnt)
        {
            try
            {
                using(OutPatientTrackingSystemEntities pt = new OutPatientTrackingSystemEntities())
                {
                    pt.Patients.Add(pnt);
                    pt.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
            return pnt;
        }

        public Patient UpdatePatient(Patient pt)
        {
            try
            {
                using (OutPatientTrackingSystemEntities obj = new OutPatientTrackingSystemEntities())
                {
                    obj.Entry(pt).State = System.Data.Entity.EntityState.Modified;
                    obj.SaveChanges();
                }
            }
            catch(Exception ex)
            {

            }
            return pt;
        }
    }
}