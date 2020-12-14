using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeeKawaii.Models
{
    public class Pupilentes
    {
        
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Capture un Modelo")]
        [MaxLength(30)]
        private string _strNombre;
        public string Modelo
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        [Required(ErrorMessage = "Capture un Color")]
        [MaxLength(30)]
        private string _strColor;
        public string Color
        {
            get { return _strColor; }
            set { _strColor = value; }
        }

        [Required(ErrorMessage = "Capture el costo")]
        private double _dblPrecio;
        public double Costo
        {
            get { return _dblPrecio; }
            set { _dblPrecio = value; }
        }
        [Display(Name = "Tamaño de pupila en milimetros")]
        [Required(ErrorMessage = "Capture el tamaño de la pupila")]
        public double TamañoPupila { get; set; }
        [Display(Name = "Tamaño del diametro en milimetros")]
        [Required(ErrorMessage = "Capture el tamaño en diametro")]
        public double TamañoDiametro { get; set; }

        [Display(Name = "Precio de venta")]
        [Required(ErrorMessage = "Capture el precio de venta")]
        public double PrecioVenta { get; set; }

        public  string Imagen { get; set; }
    }
}