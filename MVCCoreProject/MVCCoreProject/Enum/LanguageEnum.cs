using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreProject.Enum
{
    public enum LanguageEnum
    {
        [Display(Name ="English Language")]
        English=1,
        [Display(Name = "Hindhi Language")]
        Hindhi =2,
        [Display(Name = "Telugu Language")]
        Telugu =3,
        [Display(Name = "Urdhu Language")]
        Urdhu =4,
        [Display(Name = "German Language")]
        German =5,
        [Display(Name = "TAmil Language")]
        TAmil =6,
        [Display(Name = "Kannada Language")]
        Kannada =7,

    }
}
