using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Models
{
    [MetadataType(typeof(VagaStatusMetaData))]
    public partial class StatusVaga
    {
    }


    public class VagaStatusMetaData
    {


        public int Id { get; set; }
        [Display(Name = "Estado de publicação do Anúncio")]
        public string Status { get; set; }
        public string descricao { get; set; }
    
    }
}