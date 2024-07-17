using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyInfoApi.Data;
using CompanyInfoApi.Models;

namespace CompanyInfoApi.Controllers
{
    public class CompanyInfoController : Controller
    {
        private readonly CompanyInfoApiContext _context;

        public CompanyInfoController(CompanyInfoApiContext context)
        {
            _context = context;
        }


        
    }
}
