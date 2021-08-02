using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchTask.Models;

namespace SearchTask.IRepository
{
    interface IReposite
    {
        List<Patient> AllPatients();
        Patient GetPatient(string id);
        List<hospital> AllHospitals();
        Patient InsertPatient(Patient pt);
        Patient UpdatePatient(Patient pt);
        Patient DeletePatient(string id);
    }
}
