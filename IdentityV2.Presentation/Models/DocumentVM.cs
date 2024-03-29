﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityV2.Presentation.Models
{
    public enum TypeVm
    {
        Pdf,
        Doc,
        Images

    }

    public enum ChoixVMS { Name, Project };

    public class DocumentVM
    {

        public int DocumentId { get; set; }
        public DateTime DateDoc { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        [Display Description]
        public string ImageUrl { get; set; }
        public TypeVm TypeVm { get; set; }
        public string Extension { get; set; }

        public string ProjectName { get; set; }

        public int ProjectId { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

    }

}