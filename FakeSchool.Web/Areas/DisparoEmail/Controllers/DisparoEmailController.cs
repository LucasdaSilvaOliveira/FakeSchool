using FakeSchool.Domain.Escola;
using FakeSchool.Web.Areas.DisparoEmail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace FakeSchool.Web.Areas.DisparoEmail.Controllers
{
    [Area("DisparoEmail")]
    public class DisparoEmailController : Controller
    {
        public IActionResult Index()
        {
            return View(new DisparoEmailViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Disparar(DisparoEmailViewModel model)
        {
            
            try
            {
                // Construindo os dados do formulário
                var formData = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("recipient", model.Destinatario),
                new KeyValuePair<string, string>("subject", model.Assunto),
                new KeyValuePair<string, string>("email", model.Remetente),
                new KeyValuePair<string, string>("replyto", model.Remetente),
                new KeyValuePair<string, string>("Conteudo", model.Conteudo)
            });

                // URL do FormMail da KingHost
                var formMailUrl = "https://formmail.kinghost.net/formmail.cgi";

                using (var httpClient = new HttpClient())
                {
                    // Enviando o formulário para o FormMail
                    var response = await httpClient.PostAsync(formMailUrl, formData);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Erro ao enviar o e-mail.");
                    }
                    else
                    {
                        return View("Index");
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        //[HttpPost]
        //public IActionResult DispararDois(DisparoEmailViewModel model)
        //{
        //    try
        //    {

              

        //        // Configuração do cliente SMTP
        //        var clienteSmtp = new SmtpClient("smtp.gmail.com", 587)
        //        {
        //            Credentials = new NetworkCredential(model.Remetente, ""),
        //            EnableSsl = true, // O Outlook (Hotmail) requer SSL
        //            UseDefaultCredentials = false
        //        };

        //        // Criando a mensagem de e-mail
        //        var mensagem = new MailMessage(model.Remetente, model.Destinatario)
        //        {
        //            Subject = model.Assunto,
        //            //ReplyTo = null,
        //            Body = model.Conteudo,
        //            IsBodyHtml = true, // Se o corpo do e-mail contém HTML
        //            BodyEncoding = Encoding.GetEncoding("UTF-8"),
        //            SubjectEncoding = Encoding.GetEncoding("UTF-8"),
        //        };

        //        // Envio do e-mail
        //        clienteSmtp.Send(mensagem);

        //    } catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return View("Index");
        //}
    }
}
