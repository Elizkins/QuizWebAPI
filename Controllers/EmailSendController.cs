using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSendController : ControllerBase
    {
        [HttpPost]
        public async Task<string> Post([FromForm] string email)
        {
            try
            {
                var a = email;
                Random random = new Random();
                int randomInt = random.Next(100000, 999999);

                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("QuizApp", "QuizApp@u1685554.plsk.regruhosting.ru"));
                message.To.Add(MailboxAddress.Parse(email));
                message.Subject = "Сообщение от QuizApp";
                message.Body = new BodyBuilder() { HtmlBody = "<h2>Привет!&nbsp;</h2><h4>Мы получили запрос на изменение пароля.</h4><p style='font-size:1.5em;'>Ваш код подтверждения:</p>" +
                                                              $"<h1 style='font-size:1.5em;'>{randomInt}</h1><p>Если Вы не запрашивали этот код, просто проигнорируйте письмо.</p>" +
                                                              "<h4>Спасибо, что Вы с нами, с уважение QuizApp!</h4>"}.ToMessageBody();

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("mail.hosting.reg.ru", 465, true);
                    client.Authenticate("QuizApp@u1685554.plsk.regruhosting.ru", "");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return randomInt.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
