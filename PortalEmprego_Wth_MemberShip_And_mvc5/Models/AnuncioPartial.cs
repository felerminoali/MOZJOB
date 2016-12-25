using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PortalEmprego_Wth_MemberShip_And_mvc5.Models
{
    [MetadataType(typeof(AnuncioMetaData))]
    public partial class Anuncio
    {
    }

    public class AnuncioMetaData
    {

        public int Id { get; set; }

        [DisplayAttribute(Name = "Código")]
        //[Required(ErrorMessage = "O Campo Código é obrigatório")]
        public string Codigo { get; set; }

        [DisplayAttribute(Name = "Titulo")]
        [Required(ErrorMessage = "O Campo Titulo é obrigatório")]
        public string title { get; set; }

        [DataType(DataType.Date)]
        [DisplayAttribute(Name = "Inicio de Publicação")]
        [Required(ErrorMessage = "O Campo Inicio de Publicação é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> startPub { get; set; }

        [DataType(DataType.Date)]
        [DisplayAttribute(Name = "Válida ate")]
        [Required(ErrorMessage = "O Campo Válida ate é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> finishPub { get; set; }

        [DataType(DataType.Date)]
        [DisplayAttribute(Name = "Criado em")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> created { get; set; }

        [DataType(DataType.Date)]
        [DisplayAttribute(Name = "Ultima Modificacao")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Modified { get; set; }


        public Nullable<System.DateTime> publish_up { get; set; }


        public Nullable<System.DateTime> publish_down { get; set; }


        public string UrlImg { get; set; }

        [DisplayAttribute(Name = "Detalhes da Vaga")]
        [Required(ErrorMessage = "O Campo Conteúdo é obrigatório")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Conteudo { get; set; }

        


        public Nullable<int> category { get; set; }

        public Nullable<int> tipoAnuncio { get; set; }
       
        //public Nullable<int> created_by { get; set; }        
        //public Nullable<int> Modified_by { get; set; }
        //public Nullable<int> Location { get; set; }
        //public Nullable<int> Status { get; set; }
        //public Nullable<int> Lang { get; set; }
       
    
    }
}