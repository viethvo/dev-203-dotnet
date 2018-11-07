using SecurityCoding.Models;
using SecurityCoding.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityCoding.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer, HttpPostedFileBase fileUpload)
        {
            // validate customer
            if (!TryValidateModel(customer))
            {
                return View();
            }

            var saveFileName = string.Empty;

            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                // validate file upload
                if (!IsImage(fileUpload))
                {
                    ModelState.AddModelError("File Error", "This file is invalid");
                    return View();
                }

                var fileName = fileUpload.FileName;
                saveFileName = Guid.NewGuid() + fileName;

                using (var fileStream = System.IO.File.Create(Server.MapPath("~/App_Data/images/" + saveFileName)))
                {
                    fileUpload.InputStream.Seek(0, SeekOrigin.Begin);
                    fileUpload.InputStream.CopyTo(fileStream);
                }
            }

            var repository = new CustomerRepository();
            customer.Image = saveFileName;
            repository.Add(customer);
            TempData["CreateStatus"] = "Create completed";

            return View("Create", customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var repository = new CustomerRepository();
            var customer = repository.FindById(id);
            return View("Edit", customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var repository = new CustomerRepository();
            repository.Update(customer);

            TempData["EditStatus"] = "Save completed.";

            return View("Edit", customer);
        }

        // GET: Customer
        public ActionResult ListCustomers()
        {
            return View("SearchCustomers");
        }

        // GET: Customer
        [HttpPost]
        public ActionResult ListCustomers(SearchTerm term)
        {
            var repository = new CustomerRepository();

            var customers = new List<Customer>();

            if (!string.IsNullOrEmpty(term.Name))
            {
                customers = repository.FindByName(term.Name);
            }

            return View("AllCustomers", customers);
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }

            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg", ".bmp"};

            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}
