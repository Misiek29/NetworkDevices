namespace wpfNetworkDevices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Device
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string manufacturer { get; set; }

        [StringLength(50)]
        public string category { get; set; }

        public virtual Config Config { get; set; }
    }
}
