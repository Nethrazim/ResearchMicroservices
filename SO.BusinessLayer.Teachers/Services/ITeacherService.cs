﻿using SO.BusinessLayer.Services;
using SO.BusinessLayer.Teachers.Entities.DTOs;
using SO.DataLayer.Teachers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Teachers.Services
{
    public interface ITeacherService : IGenericService<TeacherDTO, Teacher, int>
    {
    }
}
