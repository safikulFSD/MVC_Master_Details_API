using Evidence_api01_witAthentication.AuthAttribute;
using Evidence_api01_witAthentication.Models;
using Evidence_api01_witAthentication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Evidence_api01_witAthentication.Controllers
{
    public class MedicinesController : ApiController
    {
        private MedicineDbContext db = new MedicineDbContext();
        [BasicAthentication]
        //api/Medicines
        [HttpGet]
        public IQueryable<Medicine> GetMedicines()
        {
            return db.Medicines.Include(x=>x.Specs).AsQueryable();
        }

        //api/Medicines/5
        [HttpGet]
        public IHttpActionResult GetMedicines(int id)
        {
            var medicine =db.Medicines.Include(x=>x.Specs).FirstOrDefault(x=>x.MedicineId == id);
            if(medicine != null)
            {
                return Ok(medicine);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult PostMedicine(MedicineViewModel model)
        {
            if(ModelState.IsValid)
            {
                var medicine = new Medicine()
                {
                    MedicineName=model.MedicineName,
                    CompanyName =model.CompanyName,
                    ProductionDate = model.ProductionDate,
                    ExpireDate = model.ExpireDate,
                    Price = model.Price,
                    Onsale = model.Onsale,
                    Picture = model.Picture,
                };
                model.Specs.ForEach(s =>
                {
                    medicine.Specs.Add(new Spec
                    {
                        SpecName = s.SpecName,
                        Value = s.Value,
                    });
                });
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return Ok(medicine);
            }
            return BadRequest("Inbalid data");
        }
        [Route("Image/Upload")]
        [HttpPost]
        public IHttpActionResult Upload()
        {
            var file = HttpContext.Current.Request.Files.Count> 0 ? HttpContext.Current.Request.Files[0] : null;
            if(file != null)
            {
                string ext = Path.GetExtension(file.FileName);
                string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                string savePath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), f);
                file.SaveAs(savePath);
                return Ok(f);
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult PutMedicine(int id, MedicineViewModel model)
        {
            if (id != model.MedicineId) return BadRequest("id mismatch");
            if(ModelState.IsValid)
            {
                var medicine = db.Medicines.Include(x => x.Specs).First(x => x.MedicineId == id);
                if (medicine == null) return NotFound();

                medicine.MedicineName= model.MedicineName;
                medicine.CompanyName = model.CompanyName;
                medicine.ProductionDate = model.ProductionDate;
                medicine.ExpireDate = model.ExpireDate;
                medicine.Price = model.Price;
                medicine.Onsale = model.Onsale;
                medicine.Picture = model.Picture;

                db.Specs.RemoveRange(medicine.Specs);


                model.Specs.ForEach(s =>
                {
                    medicine.Specs.Add(new Spec
                    {
                        SpecName = s.SpecName,
                        Value = s.Value,
                    });
                });
                db.SaveChanges();
                return Ok(medicine);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMedicine(int id)
        {
            var medicine =db.Medicines.FirstOrDefault(x=>x.MedicineId == id);
            if(medicine == null) return NotFound();
            db.Medicines.Remove(medicine );
            db.SaveChanges();
            return Ok("Deleted");
        }
    }
}
