using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Modelos
{
    [MetadataType(typeof(RecrutadorMetaData))]
    public partial class Recrutador
    {
    }

    public class RecrutadorMetaData
    {
        public int IdRecrutador { get; set; }

        [Display(Name = "Recrutador")]
        public string Nome { get; set; }

        public string Email { get; set; }
        public string WebSite { get; set; }
    }
}