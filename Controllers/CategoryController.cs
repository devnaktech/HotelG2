using Dapper;
using HotelG2.Data;
using HotelG2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelG2.Controllers
{
    public class CategoryController(DapperFactory database) : Controller
    {
    
        public IActionResult Index(string? filter = null)
        {
            var db = database.CreateConnection();
            var sql = @"SELECT * FROM Categories WHERE LoancategoryCode LIKE '%' + @filter + '%' OR @filter IS NULL";
            var categories = db.Query<LoanCategory>(sql, new { filter });
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LoanCategory req)
        {
            var db = database.CreateConnection();
            var sql = @"
                        INSERT INTO Categories (LoancategoryCode, Description, DesInKhmer, Code, CreatedDT, IsActive) 
                        VALUES (@LoancategoryCode, @Description, @DesInKhmer, @Code, GETDATE(), @IsActive);";

            int rowEffection = db.Execute(sql, new
            {
                req.LoancategoryCode,
                req.Description,
                req.DesInKhmer,
                req.Code,
                req.CreatedDT,
                req.IsActive
            });
            return rowEffection > 0 ? RedirectToAction(nameof(Index)) : View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int LoanCategoryID)
        {
            if (!IsCategoryExist(LoanCategoryID))
            {
                return NotFound();
            }

            var db = database.CreateConnection();
            string sql = "SELECT * FROM Categories WHERE LoanCategoryID=@LoanCategoryID;";
            var cat = db.QueryFirst<LoanCategory>(sql, new { LoanCategoryID });
            return cat is not null ? View("Edit", cat) : NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int LoanCategoryID, LoanCategory req)
        {
            if (!IsCategoryExist(LoanCategoryID))
            {
                return NotFound();
            }
            using var db = database.CreateConnection();
            var sql = @" UPDATE Categories SET LoancategoryCode=@LoancategoryCode, Description=@Description, DesInKhmer=@DesInKhmer, Code=@Code, EditSeq=ISNULL(EditSeq, 0) + 1, CreatedDT=GETDATE() , ModifiedDT=GETDATE() , IsActive=@IsActive WHERE LoanCategoryID=@LoanCategoryID;";
            int rowEffection = db.Execute(sql, new
            {
                LoanCategoryID,
                req.LoancategoryCode,
                req.Description,
                req.DesInKhmer,
                req.Code,
                req.IsActive
            });

            return rowEffection > 0 ? RedirectToAction(nameof(Index)) : View("Create");
        }

        [HttpGet]
        public IActionResult Delete(int LoanCategoryID)
        {
            if (!IsCategoryExist(LoanCategoryID))
            {
                return NotFound();
            }
            var db = database.CreateConnection();
            string sql = "SELECT * FROM Categories WHERE LoanCategoryID=@LoanCategoryID;";
            var cat = db.QueryFirst<LoanCategory>(sql, new { LoanCategoryID });
            return cat is not null ? View("Delete", cat) : NotFound();
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int LoanCategoryID)
        {
            if (!IsCategoryExist(LoanCategoryID))
            {
                return NotFound();
            }
            using var db = database.CreateConnection();
            string sql = "DELETE FROM Categories WHERE LoanCategoryID=@LoanCategoryID";
            int deletedRow = db.Execute(sql, new { LoanCategoryID });
            return deletedRow > 0 ? RedirectToAction(nameof(Index)) : BadRequest();
        }
        [HttpGet]
        //public IActionResult Details(int LoanCategoryID)
        //{
        //    if (!IsCategoryExist(LoanCategoryID))
        //    {
        //        return NotFound();
        //    }
        //    var db = database.CreateConnection();
        //    string sql = "SELETE * FROM Categories WHERE LoanCategoryID=@LoanCategoryID";
        //    var cat = db.QueryFirst<LoanCategory>(sql, new { LoanCategoryID });
        //    return cat is not null ? View("Details", cat) : NotFound();
        //}
        [HttpGet]
        public IActionResult Details(int LoanCategoryID)
        {
            if (!IsCategoryExist(LoanCategoryID))
            {
                return NotFound();
            }

            var db = database.CreateConnection();
            string sql = "SELECT * FROM Categories WHERE LoanCategoryID=@LoanCategoryID"; // Corrected typo
            var cat = db.QueryFirstOrDefault<LoanCategory>(sql, new { LoanCategoryID });

            return cat is not null ? View("Details", cat) : NotFound();
        }
        private bool IsCategoryExist(int LoanCategoryID)
        {
            try
            {
                var db = database.CreateConnection();
                string sql = "SELECT * FROM Categories WHERE LoanCategoryID=@LoanCategoryID";
                var cats = db.Query<LoanCategory>(sql, new { LoanCategoryID });
                return cats.Any();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
