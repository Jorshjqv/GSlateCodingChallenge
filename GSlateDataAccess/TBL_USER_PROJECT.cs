//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GSlateDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_USER_PROJECT
    {
        public int USER_ID { get; set; }
        public int PROJECT_ID { get; set; }
        public bool IS_ACTIVE { get; set; }
        public System.DateTime ASSIGNED_DATE { get; set; }
    
        public virtual TBL_PROJECT TBL_PROJECT { get; set; }
        public virtual TBL_USER TBL_USER { get; set; }
    }
}
