using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ObraFacilApp.Models;
using System.Web;


namespace ObraFacilApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AutenticarUsuario(string userName, string senha)
        {
            // Conectar ao banco de dados
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Consultar o banco de dados para verificar se o usuário e a senha estão corretos
                string sql = "SELECT Id, Nome FROM login WHERE Nome=@Nome AND Senha=@Senha";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", userName);
                    command.Parameters.AddWithValue("@Senha", senha);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            // Credenciais válidas
                            int idUsuario = (int)dataReader["Id"];
                            string nomeUsuario = (string)dataReader["Nome"];
                            string emailUsuario = (string)dataReader["Email"];

                            // Adicionar o usuário à sessão
                            var identidade = new ClaimsIdentity(new[] {
                                new Claim(ClaimTypes.NameIdentifier, idUsuario.ToString()),
                                new Claim(ClaimTypes.Name, nomeUsuario),
                                new Claim(ClaimTypes.Email, emailUsuario),
                            }, "ApplicationCookie");

                           // var contexto = Request.GetOwinContext();
                           // var autenticador = contexto.Authentication;
                            //autenticador.SignIn(identidade);

                            // Redirecionar para a página principal
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            // Credenciais inválidas
                            ModelState.AddModelError("", "Usuário ou senha incorretos.");
                        }
                    }
                }
            }

            // Retornar para a página de login com uma mensagem de erro
            return View("Index");
        }

        public ActionResult Logout()
        {
            // Remover o usuário da sessão
            //var contexto = Request.GetOwinContext();
            //var autenticador = contexto.Authentication;
            //autenticador.SignOut("ApplicationCookie");

            // Redirecionar para a página de login
            return RedirectToAction("Index", "Login");

        }
    }
}