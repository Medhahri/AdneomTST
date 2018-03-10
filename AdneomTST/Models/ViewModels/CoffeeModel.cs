using AdneomTST.Models.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdneomTST.Models.ViewModels
{
    public class CoffeeModel
    {
        public int Id { get; set; }
        public int Sucre { get; set; }
        public bool UseMug { get; set; }

        [Required]
        public int IdType { get; set; }
        public String TypeCaffee { get; set; }
    }

    public class TypeCoffeeModel
    {
        public int Id { get; set; }
        public String TypeDescription { get; set; }
    }

}