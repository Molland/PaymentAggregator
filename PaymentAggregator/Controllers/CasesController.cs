using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using PaymentAggregator.Models;

namespace PaymentAggregator.Controllers
{
    public class CasesController : Controller
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // GET: /cases
        public ActionResult Index()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sql = "SELECT Id, Alias, Title, BriefDescription, ImageUrl, Category, CreatedDate FROM Cases ORDER BY CreatedDate DESC";
                var cases = db.Query<Case>(sql).ToList();
                return View(cases);
            }
        }

        // GET и POST: /cases/{alias}
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Details(string alias, Review review)
        {
            if (string.IsNullOrEmpty(alias))
                return RedirectToAction("Index");

            using (var db = new SqlConnection(_connectionString))
            {
                var caseSql = "SELECT * FROM Cases WHERE Alias = @Alias";
                var currentCase = db.QueryFirstOrDefault<Case>(caseSql, new { Alias = alias });

                if (currentCase == null)
                    return HttpNotFound();

                if (Request.HttpMethod == "POST")
                {
                    if (ModelState.IsValid && review != null && !string.IsNullOrEmpty(review.Name))
                    {
                        try
                        {
                            review.Name = HttpUtility.HtmlEncode(review.Name);
                            review.Email = HttpUtility.HtmlEncode(review.Email);
                            review.Text = HttpUtility.HtmlEncode(review.Text);

                            var insertSql = "INSERT INTO Reviews (Name, Email, [Text], CreatedDate) VALUES (@Name, @Email, @Text, @CreatedDate)";
                            db.Execute(insertSql, new { review.Name, review.Email, review.Text, CreatedDate = DateTime.Now });

                            ViewBag.SuccessMessage = "Ваш отзыв успешно отправлен!";
                        }
                        catch (Exception)
                        {
                            ViewBag.ErrorMessage = "Ошибка при отправке отзыва.";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Пожалуйста, заполните все поля корректно.";
                    }
                }

                var similarSql = "SELECT Id, Alias, Title, BriefDescription, ImageUrl, Category, CreatedDate " +
                                 "FROM Cases WHERE Category = @Category AND Alias != @Alias ORDER BY CreatedDate DESC";
                var similarCases = db.Query<Case>(similarSql, new { Category = currentCase.Category, Alias = alias }).ToList();

                ViewBag.SimilarCases = similarCases;
                return View(currentCase);
            }
        }
    }
}