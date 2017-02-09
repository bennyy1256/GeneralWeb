using General.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace General.Web.Models.ViewModels
{
    public class SignUpViewModel
    {
        [UIHint("GenderDropDownList")]
        public GenderEnum Gender { get; set; }
    }
}