using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Modelos
{
    [MetadataType(typeof(LocalMetaData))]
    public partial class Local
    {
    }

    public class LocalMetaData
    {

        public int Id { get; set; }

        [Display(Name="Local")]
        public string Name { get; set; }
        public bool isSelected { get; set; }
        public Nullable<int> Provincia { get; set; }
    }
}