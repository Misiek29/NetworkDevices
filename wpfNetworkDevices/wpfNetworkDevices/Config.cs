namespace wpfNetworkDevices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Config")]
    public partial class Config
    {
        public int id { get; set; }

        public int? ip { get; set; }

        public int? mask { get; set; }

        public int? Gateway { get; set; }

        public int? DNS { get; set; }

        public bool? active { get; set; }

        public virtual Device Device { get; set; }
    }
}
