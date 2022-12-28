using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalDiary.Data;
using DigitalDiary.Models;

namespace DigitalDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        public DataContextClass Diary { get; set; }
        public EntryController(DataContextClass contextClass)
        {
            this.Diary = contextClass;

        }
        [HttpPost("insEntry")]
        public async Task<ActionResult> insEntry(Entry cu)
        {

            Diary.tblentry.Add(cu);
            await Diary.SaveChangesAsync();
            return Ok(cu);
        }


        [HttpGet("viewdata")]
        public async Task<List<Entry>> ViewData()
        {
            return Diary.tblentry.ToList();
        }

        [HttpGet("ViewdataByid/{id}")]
        public IActionResult ViewCourseByid(int id)
        {
            return Ok(Diary.tblentry.Find(id));
        }

        [HttpPost("Update")]
        public IActionResult Update(Entry cu)
        {

            Diary.tblentry.Update(cu);
            Diary.SaveChanges();
            return Ok(cu);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Entry cu)
        {

            Diary.tblentry.Remove(cu);
            Diary.SaveChanges();
            return Ok(cu);
        }
    }
}
