using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorPageNewTest.Data;
using RazorPageNewTest.Interface;
using RazorPageNewTest.Models;

namespace RazorPageNewTest.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly INterfaceClassFile _allFile;
        public HomeController(INterfaceClassFile allFile)
        {
            _allFile = allFile;
        }
        public CryptoBack cb = new CryptoBack();
        public string cbFun(int id)
        {
            ClassFileViewModel obj = new ClassFileViewModel
            {
                AllFile = _allFile.AllFiles
            };
            foreach (var temp in obj.AllFile)
            {
                if (temp.Id == id)
                {
                    cb.ConvertCrypt_DOCX_2_PDFA(temp.FullName);
                    cb.Generate_Sig_Key(temp.FullName);
                    Response.Redirect("/../../..");
                    return cb.Validate_After_All(Path.ChangeExtension(temp.FullName, ".pdf"));
                }
            }
            return "Возникла ошибка повторите позже";
        }
        public IActionResult List() 
        {
            ClassFileViewModel obj = new ClassFileViewModel
            {
                AllFile = _allFile.AllFiles
            };
            return View(obj);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPut("{id}")]
        public void CalledMethod(int id)
        {
            cbFun(id);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
