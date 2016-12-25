using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Modelos
{
    [MetadataType(typeof(languageMetaData))]
    public partial class language
    {
    }

    public class languageMetaData
    {

        public int Id { get; set; }

        [DisplayAttribute(Name = "Lingua")]
        [Required(ErrorMessage = "O Campo Lingua é obrigatório")]
        public string description { get; set; }
        public bool isSelected { get; set; }
        public string lang_code { get; set; }
        public string image { get; set; }
    }
}