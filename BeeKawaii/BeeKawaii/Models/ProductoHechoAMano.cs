using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeeKawaii.Models
{
    public class ProductoHechoAMano
    {
        public int Id { get; set; }

        private string _strNombre;

        [Display(Name = "Tipo de producto")]
        [MaxLength(30)]
        [Required(ErrorMessage = "Capture el tipo")]
        public string Tipo { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Capture el Nombre")]
        public string Nombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        private string _strCaracteristicas;
        [MaxLength(90)]
        [Required(ErrorMessage = "Capture alguna caracteristica del producto")]
        public string Caracteristicas
        {
            get { return _strCaracteristicas; }
            set { _strCaracteristicas = value; }
        }
        [MaxLength(30)]
        [Required(ErrorMessage = "Capture el materia")]
        public string Material { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Capture el tamaño")]
        public string Tamaño { get; set; }
        [MaxLength(30)]
        [Display(Name = "Tiempo de realización")]
        [Required(ErrorMessage = "Capture el tiempo de realización")]
        public string TiempoRealización { get; set; }
        [Required(ErrorMessage = "Capture el costo")]
        public float Costo { get; set; }
        [Display(Name = "Precio de venta")]
        [Required(ErrorMessage = "Capture el precio de venta")]
        public double PrecioVenta { get; set; }
        
        public string Imagen { get; set; }
    }
}