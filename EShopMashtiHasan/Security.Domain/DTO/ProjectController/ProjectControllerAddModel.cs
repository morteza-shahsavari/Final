﻿using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.ProjectController
{
    public class ProjectControllerAddModel
    {
        public string ProjectControllerName { get; set; }
        public string PersianTitle { get; set; }
        public int ProjectAreaID { get; set; }
    }
}
