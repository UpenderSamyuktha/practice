//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SearchTask.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class hospital
    {
        public int hs_id { get; set; }
        public string hs_name { get; set; }
        public string hs_prefix { get; set; }
        public string hs_suffix { get; set; }
        public Nullable<int> hs_patient_sequence { get; set; }
        public Nullable<int> hs_nextpatient_id { get; set; }
    }
}
