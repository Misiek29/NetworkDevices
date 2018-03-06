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

        public int? id_device { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        [StringLength(50)]
        public string mask { get; set; }

        [StringLength(50)]
        public string Gateway { get; set; }

        [StringLength(50)]
        public string DNS { get; set; }

        public bool? active { get; set; }

        public DateTime? date { get; set; }

        public virtual Device Device { get; set; }
    }
}
