using CriptoODGT.Class;
using Data.Repositories;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using Domain.Entities;
using Application.Interfaces;
using System.Net;

namespace DIRECTTO.Controllers
{
    public class SendMail
    {
        public static bool sendMailRecovery(string sEmail, string sToken)
        {

            try
            {
                string senha = ReadString("CGL_SendMailSenha");

                string EmailSender = ReadString("CGL_SendMailFrom");
                string EmailSenderName = ReadString("CGL_SendMailLogin");
                string EmailSenderPass = Cripto.DecryptString(senha, ReadStringWeb("ChaveCripto"));

                string Host = ReadString("CGL_SendMailSmtpCliente");
                int iPort = Convert.ToInt32(ReadString("CGL_SendMailPorta"));
                string CCOS = ReadString("CGL_SendMailCCOS");

                string pathFisico = ReadString("CGL_PathImagem");
                string pasta = ReadEmail("TME_PathTemplateEmail", 1);

                string pathFull = pathFisico + pasta;

                //pathFull = "D:\\RocketStudio\\Directto\\TemplateEmail\\TemplatePadrao.html"; //remover teste local
                //string urlValidaEmailToken = System.Configuration.ConfigurationManager.AppSettings["urlValidaEmailToken"];
                string urlValidaEmailToken = ReadString("CGL_UrlWEB");

                string Assunto = "[Recuperação de Senha] Directto";

                var mail = new MailMessage();
                mail.To.Add(sEmail);

                mail.From = new MailAddress(EmailSender, EmailSenderName, System.Text.Encoding.UTF8);

                mail.Subject = Assunto;

                string ccoS = CCOS;
                var listaCCOS = ccoS.Split(';');

                foreach (var item in listaCCOS)
                {
                    if (!string.IsNullOrEmpty(item))
                        mail.Bcc.Add(new MailAddress(item, "[Recuperação de Senha] Directto", System.Text.Encoding.UTF8));
                }



                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                string assemblyFile = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                assemblyFile = Path.GetDirectoryName(assemblyFile);
                string complementoMail = "";


                var html = new HtmlDocument();
                //html.LoadHtml(File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["mailBodyLocation"]));
                //pathFull = "C:\\Users\\anand\\OneDrive\\Área de Trabalho\\Sistema - Email Template.html"; //remover teste local
                html.LoadHtml(File.ReadAllText(pathFull));

                string mensagem = "Olá, " + sEmail + "!<br>";
                mensagem += "Foi feito um pedido para alterar a sua senha de acesso a plataforma da Directto.Você pode fazer a alteração acessando o link abaixo";
                html.GetElementbyId("spanMensagem").InnerHtml = mensagem;
                //recuperar-senha
                string button = "<a href='" + urlValidaEmailToken + "recuperar-senha?sToken=" + sToken + "' target='_blank' style='text-decoration:none; color:#000000; line-height:18px; display:block;' object='link-editable'>Recuperar Senha</a>";
                html.GetElementbyId("spanButton").InnerHtml = button;

                string mensagem2 = "Se a solicitação não foi feita por você, por favor desconsidere esse email.<br>";
                mensagem2 += "A sua senha não será alterada até que você acesse o link acima e defina uma nova.<br><br>";
                mensagem2 += "Equipe da Directto";
                html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;

                mail.IsBodyHtml = true;
                mail.Body = html.DocumentNode.InnerHtml;


                //Adicionando as credenciais da conta do remetente
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPass); // <<<<<<<<<<<< colocar email e senha do gmail

                client.Port = iPort; // Esta porta é a utilizada pelo Gmail para envio

                client.Host = Host; //Definindo o provedor que irá disparar o e-mail

                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

                // client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;



                try
                {
                    client.Send(mail);


                    return true;
                }
                catch (SmtpException ex)
                {
                    return false;
                    throw ex;
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static bool sendMailMessage(string sEmail, string sToken, string message, string assunto, int id)
        {

            try
            {
                string senha = ReadString("CGL_SendMailSenha");

                string EmailSender = ReadString("CGL_SendMailFrom");
                string EmailSenderName = ReadString("CGL_SendMailLogin");
                string EmailSenderPass = Cripto.DecryptString(senha, ReadStringWeb("ChaveCripto"));

                string Host = ReadString("CGL_SendMailSmtpCliente");
                int iPort = Convert.ToInt32(ReadString("CGL_SendMailPorta"));
                string CCOS = ReadString("CGL_SendMailCCOS");

                string pathFisico = ReadString("CGL_PathImagem");
                string pasta = ReadEmail("TME_PathTemplateEmail", id);//linha dois do template

                string pathFull = pathFisico + pasta;

                string urlValidaEmailToken = ReadString("CGL_UrlWEB");

                string Assunto = "[Notificação - Directto] " + assunto;

                var mail = new MailMessage();
                mail.To.Add(sEmail);

                mail.From = new MailAddress(EmailSender, EmailSenderName, System.Text.Encoding.UTF8);

                mail.Subject = Assunto;

                string ccoS = CCOS;
                var listaCCOS = ccoS.Split(';');

                foreach (var item in listaCCOS)
                {
                    if (!string.IsNullOrEmpty(item))
                        mail.Bcc.Add(new MailAddress(item, "[Notificação - Directto] " + assunto, System.Text.Encoding.UTF8));
                }



                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                string assemblyFile = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                assemblyFile = Path.GetDirectoryName(assemblyFile);
                string complementoMail = "";

                //pathFull = "C:\\Users\\Ananda\\Desktop\\Work-Night\\TemplateEmail\\1\\TME_Id_1_202005210029.html"; //remover teste local
                var html = new HtmlDocument();
                html.LoadHtml(File.ReadAllText(pathFull));


                html.GetElementbyId("spanMensagem").InnerHtml = message;
                //html.GetElementbyId("spnButton").InnerHtml = "<a href='" + urlValidaEmailToken + "/Account/Recovery?sToken=" + sToken + "' target='_blank' style='text-decoration:none; color:#ffffff; line-height:18px; display:block;' object='link-editable'>Recuperar Senha</a>";


                mail.IsBodyHtml = true;
                mail.Body = html.DocumentNode.InnerHtml;


                //Adicionando as credenciais da conta do remetente
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPass); // <<<<<<<<<<<< colocar email e senha do gmail

                client.Port = iPort; // Esta porta é a utilizada pelo Gmail para envio

                client.Host = Host; //Definindo o provedor que irá disparar o e-mail

                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

                // client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;



                try
                {
                    client.Send(mail);


                    return true;
                }
                catch (SmtpException ex)
                {
                    return false;
                    throw ex;
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static bool sendMailMessagePass(string sEmail, string sToken, string message, string assunto)
        {

            try
            {
                string senha = ReadString("CGL_SendMailSenha");

                string EmailSender = ReadString("CGL_SendMailFrom");
                string EmailSenderName = ReadString("CGL_SendMailLogin");
                string EmailSenderPass = Cripto.DecryptString(senha, ReadStringWeb("ChaveCripto"));

                string Host = ReadString("CGL_SendMailSmtpCliente");
                int iPort = Convert.ToInt32(ReadString("CGL_SendMailPorta"));
                string CCOS = ReadString("CGL_SendMailCCOS");

                string pathFisico = ReadString("CGL_PathImagem");
                string pasta = ReadEmail("TME_PathTemplateEmail", 1);

                string pathFull = pathFisico + pasta;

                //pathFull = "D:\\RocketStudio\\Directto\\TemplateEmail\\TemplatePadrao.html"; //remover teste local
                //string urlValidaEmailToken = System.Configuration.ConfigurationManager.AppSettings["urlValidaEmailToken"];
                string urlValidaEmailToken = ReadString("CGL_UrlWEB");

                string Assunto = "[Notificação e Recuperação de Senha - Directto] " + assunto;

                var mail = new MailMessage();
                mail.To.Add(sEmail);

                mail.From = new MailAddress(EmailSender, EmailSenderName, System.Text.Encoding.UTF8);

                mail.Subject = Assunto;

                string ccoS = CCOS;
                var listaCCOS = ccoS.Split(';');

                foreach (var item in listaCCOS)
                {
                    if (!string.IsNullOrEmpty(item))
                        mail.Bcc.Add(new MailAddress(item, Assunto, System.Text.Encoding.UTF8));
                }



                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                string assemblyFile = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                assemblyFile = Path.GetDirectoryName(assemblyFile);
                string complementoMail = "";


                var html = new HtmlDocument();
                //html.LoadHtml(File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["mailBodyLocation"]));
                html.LoadHtml(File.ReadAllText(pathFull));

                string mensagem = "Olá, " + sEmail + "!<br>";
                mensagem += "Foi feito um pedido para alterar a sua senha de acesso a plataforma da Directto.Você pode fazer a alteração acessando o link abaixo";
                html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                string button = "<a href='" + urlValidaEmailToken + "/Account/Recovery?sToken=" + sToken + "' target='_blank' style='text-decoration:none; color:#000000; line-height:18px; display:block;' object='link-editable'>Recuperar Senha</a>";
                html.GetElementbyId("spanButton").InnerHtml = button;

                string mensagem2 = "Se a solicitação não foi feita por você, por favor desconsidere esse email.<br>";
                mensagem2 += "A sua senha não será alterada até que você acesse o link acima e defina uma nova.<br><br>";
                mensagem2 += "Equipe da Directto";
                html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;

                mail.IsBodyHtml = true;
                mail.Body = html.DocumentNode.InnerHtml;


                //Adicionando as credenciais da conta do remetente
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPass); // <<<<<<<<<<<< colocar email e senha do gmail

                client.Port = iPort; // Esta porta é a utilizada pelo Gmail para envio

                client.Host = Host; //Definindo o provedor que irá disparar o e-mail

                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

                // client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;



                try
                {
                    client.Send(mail);


                    return true;
                }
                catch (SmtpException ex)
                {
                    return false;
                    throw ex;
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static bool sendMailMessageRedesSociais(string sEmail, int iTipo, string assunto, int id, int idComplemento)
        {

            try
            {
                string UrlWEB = System.Configuration.ConfigurationManager.AppSettings["UrlWEB"];
                string senha = ReadString("CGL_SendMailSenha");

                string EmailSender = ReadString("CGL_SendMailFrom");
                string EmailSenderName = ReadString("CGL_SendMailLogin");
                string EmailSenderPass = Cripto.DecryptString(senha, ReadStringWeb("ChaveCripto"));

                string Host = ReadString("CGL_SendMailSmtpCliente");
                int iPort = Convert.ToInt32(ReadString("CGL_SendMailPorta"));
                string CCOS = ReadString("CGL_SendMailCCOS");

                string pathFisico = ReadString("CGL_PathImagem");
                string pasta = ReadEmail("TME_PathTemplateEmail", id);//linha dois do template

                string pathFull = pathFisico + pasta;

                //pathFull = "D:\\RocketStudio\\Directto\\TemplateEmail\\TemplatePadrao.html"; //remover teste local
                string urlValidaEmailToken = ReadString("CGL_UrlWEB");

                string Assunto = "[Notificação - Directto] " + assunto;

                var mail = new MailMessage();
                mail.To.Add(sEmail);

                mail.From = new MailAddress(EmailSender, EmailSenderName, System.Text.Encoding.UTF8);

                mail.Subject = Assunto;

                string ccoS = CCOS;
                var listaCCOS = ccoS.Split(';');

                foreach (var item in listaCCOS)
                {
                    if (!string.IsNullOrEmpty(item))
                        mail.Bcc.Add(new MailAddress(item, "[Notificação - Directto] " + assunto, System.Text.Encoding.UTF8));
                }



                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                string assemblyFile = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                assemblyFile = Path.GetDirectoryName(assemblyFile);
                string complementoMail = "";

                //pathFull = "C:\\Users\\Ananda\\Desktop\\Work-Night\\TemplateEmail\\1\\TME_Id_1_202005210029.html"; //remover teste local
                var html = new HtmlDocument();
                html.LoadHtml(File.ReadAllText(pathFull));

                string mensagem = "";
                string button = "";
                string mensagem2 = "";
                string sLink = "";

                if (iTipo == 1)//Bem vindo a Directto
                {
                    sLink = UrlWEB + "cadastro?usr-id-token=" + idComplemento;

                    mensagem = "Obrigado por se registrar na Directto. Seja bem vindo!<br><br>";
                    mensagem += "Faltam alguns passos para você começar a fazer bons negócios na bioeconomia. Vamos prosseguir?<br><br>";
                    mensagem += "Clique no botão abaixo para fazer o login e completar os dados na plataforma.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Cadastro da Empresa</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Ainda precisa de ajuda? Nós estamos disponíveis no email<br>info@directto.tech<br><br>";
                    mensagem2 += "Bons negócios, de forma responsável.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 2)//Validação de informações adicionais
                {
                    //sLink = UrlWEB + "login";

                    mensagem = "Estamos felizes por você ter completado o seu cadastro na Directto. Como parte do processo precisamos realizar uma breve validação de informações.<br><br>";
                    mensagem += "O nosso time vai entrar em contato para entender o seu perfil e assim proporcionar a melhor experiência de negócios na bioeconomia.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "A gente conecta negócios, impacta pessoas.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 3)//Validação completada com sucesso
                {
                    sLink = UrlWEB + "login";

                    mensagem = "As suas informações foram validadas com sucesso. Para acessar o marketplace no link abaixo";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Login</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "A partir de agora você conta com o apoio de um time especializado que está empenhado em garantir a melhor experiência ao longo de toda a jornada de comercialização de produtos da bieoeconomia.<br><br>";
                    mensagem2 += "Você pode nos contactar pelo email info@directto.tech ou pelas redes sociais.<br><br>";
                    mensagem2 += "Bons negócios, de forma responsável.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 4)//Informações inconsistentes
                {
                    mensagem = "O nosso time identificou informações inconsistentes no seu cadastro, e para garantir que você faça bons negócios com segurança nós pedimos que você entre em contato pelo email info@directto.tech";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Esperamos que em breve você possa fazer bons negócios na nossa plataforma.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 5)//Jornada "eu desejo vender " - Email 6 - Recebemos dados da sua oferta
                {
                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O nosso time já está processando os dados da sua oferta. Vamos verificar algumas informações e assim que o processo for concluído você será notificado.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "A gente conecta negócios, impacta pessoas.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 6)//Jornada "eu desejo comprar " - Email 6 - Recebemos dados demanda
                {
                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O nosso time já está processando os dados da sua demanda. Vamos verificar algumas informações e assim que o processo for concluído você será notificado."; 
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "A gente conecta negócios, impacta pessoas.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 7)//Jornada eu desejo "vender" - Email 7 - Sua oferta já foi publicada
                {
                    sLink = UrlWEB;

                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "A sua oferta já foi publicada no marketplace da Directto. Para visualizar basta acessar o link abaixo."; 
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Link da oferta publicada</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "O nosso time de inteligência de negócio já está em ação para encontrar as melhores oportunidades.E como na Directto toda a jornada de comercialização é transparente, então a gente mantém você informado sobre cada possibilidade de negócio.<br><br>";
                    mensagem2 += "A gente conecta negócios, impacta pessoas.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 8)//Jornada eu desejo "comprar" - Email 7 - Sua demanda já foi publicada
                {
                    sLink = UrlWEB;

                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "A sua demanda já foi publicada no marketplace da Directto. Para visualizar basta acessar o link abaixo."; 
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Link da oferta publicada</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "O nosso time de inteligência de negócio já está em ação para encontrar as melhores oportunidades.E como na Directto toda a jornada de comercialização é transparente, então a gente mantém você informado sobre cada possibilidade de negócio.<br><br>";
                    mensagem2 += "A gente conecta negócios, impacta pessoas.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 9)//Jornada eu desejo "vender" - Email 8 - Informações da oferta inconsistentes
                {
                    mensagem = "O nosso time identificou informações inconsistentes no cadastro do sua oferta, e para garantir que você faça bons negócios com segurança nós pedimos que você entre em contato pelo email info@directto.tech";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Esperamos que em breve você possa fazer bons negócios na nossa plataforma.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 10)//Jornada eu desejo "comprar" - Email 8 - Informações da demanda inconsistentes
                {
                    mensagem = "O nosso time identificou informações inconsistentes no cadastro do sua oferta, e para garantir que você faça bons negócios com segurança nós pedimos que você entre em contato pelo email info@directto.tech";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Esperamos que em breve você possa fazer bons negócios na nossa plataforma.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 11)//EN - Bem vindo a Directto
                {
                    sLink = UrlWEB + "cadastro?usr-id-token=" + idComplemento;

                    mensagem = "Thank you for registering with Directto. Welcome!<br><br>";
                    mensagem += "You’re a couple of steps away to start to make good businesses in the bioeconomy. Let’s go on ?<br><br>";
                    mensagem += "Click on the link below to login and complete the needed data in the platform.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Company Info</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Still need help ? We are available by email: info@directto.tech<br><br>";
                    mensagem2 += "Make good businesses, responsibly.<br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 12)//EN - Validação de informações adicionais
                {
                    //sLink = UrlWEB + "login";

                    mensagem = "We are happy you completed your profile with Directto. As part of the process we need to do a quick information validation.<br><br>";
                    mensagem += "Our team will contact you to better understand your profile aiming to provide the best experience of business in the bioeconomy.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "We connect businesses, impact people. <br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 13)//EN - Validação completada com sucesso
                {
                    sLink = UrlWEB + "login";

                    mensagem = "Your information was successfully validated. To access the maketplace, please click on the link below";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Login</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "From now on, you can count on the support of a specialized team that is committed to guaranteeing the best experience throughout the whole journey of commercialization of bioeconomy products.<br><br>";
                    mensagem2 += "You can contact us at info@directto.tech or through social media.<br><br>";
                    mensagem2 += "Make good businesses, responsibly.<br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 14)//EN - Informações inconsistentes
                {
                    mensagem = "Our team has identified inconsistent information in your profile registration, and to ensure that you do good business safely, we ask that you contact us at info@directto.tech ";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "We hope that you will soon be able to do good business on our platform.<br><br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 15)//EN - Jornada "eu desejo vender " - Email 6 - Recebemos dados da sua oferta
                {
                    mensagem = "Hello " + sEmail + ",<br><br>";
                    mensagem += "Our team is already processing your offer data. We will verify some information and once the process is completed, you will be notified.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "We connect businesses, impact people.<br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 16)//EN - Jornada "eu desejo comprar " - Email 6 - Recebemos dados demanda
                {
                    mensagem = "Hello " + sEmail + ",<br><br>";
                    mensagem += "Our team is already processing your demand data. We will verify some information and once the process is completed, you will be notified.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "We connect businesses, impact people.<br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 17)//EN - Jornada eu desejo "vender" - Email 7 - Sua oferta já foi publicada
                {
                    sLink = UrlWEB;

                    mensagem = "Hello " + sEmail + ",<br><br>";
                    mensagem += "Your offer has already been published on the Directto marketplace.To view it, just access the link below.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Link to published offer</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Our business intelligence team is already in action to find the best opportunities. At Directto, the entire marketing journey is transparent, so we keep you informed about every business possibility.<br><br>";
                    mensagem2 += "We connect businesses, impact people.<br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 18)//EN - Jornada eu desejo "comprar" - Email 7 - Sua demanda já foi publicada
                {
                    sLink = UrlWEB;

                    mensagem = "Hello " + sEmail + ",<br><br>";
                    mensagem += "Your demand has already been published on the Directto marketplace.To view it, just access the link below.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Link to published demand</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Our business intelligence team is already in action to find the best opportunities. At Directto, the entire marketing journey is transparent, so we keep you informed about every business possibility.<br><br>";
                    mensagem2 += "We connect businesses, impact people.<br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 19)//EN - Jornada eu desejo "vender" - Email 8 - Informações da oferta inconsistentes
                {
                    mensagem = "Our team has identified some inconsistent information in your offer registration, and to ensure that you make good deals safely, we ask you to contact us at info @directto.tech";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "We hope that you will soon be able to do good business on our platform.<br><br>";
                    mensagem2 += "Direct team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 20)//EN - Jornada eu desejo "comprar" - Email 8 - Informações da demanda inconsistentes
                {
                    mensagem = "Our team has identified inconsistent information in your demand registration, and to ensure that you make good deals safely, we ask you to contact us at info @directto.tech ";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "We hope that you will soon be able to do good business on our platform.<br><br>";
                    mensagem2 += "Direct team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                
                mail.IsBodyHtml = true;
                mail.Body = html.DocumentNode.InnerHtml;


                //Adicionando as credenciais da conta do remetente
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPass); // <<<<<<<<<<<< colocar email e senha do gmail

                client.Port = iPort; // Esta porta é a utilizada pelo Gmail para envio

                client.Host = Host; //Definindo o provedor que irá disparar o e-mail

                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

                // client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;



                try
                {
                    client.Send(mail);


                    return true;
                }
                catch (SmtpException ex)
                {
                    return false;
                    throw ex;
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static bool sendMailMessageNegociacao(string sEmail, int iTipo, string assunto, int id, string complemento)
        {

            try
            {
                string UrlWEB = System.Configuration.ConfigurationManager.AppSettings["UrlWEB"];
                string senha = ReadString("CGL_SendMailSenha");

                string EmailSender = ReadString("CGL_SendMailFrom");
                string EmailSenderName = ReadString("CGL_SendMailLogin");
                string EmailSenderPass = Cripto.DecryptString(senha, ReadStringWeb("ChaveCripto"));

                string Host = ReadString("CGL_SendMailSmtpCliente");
                int iPort = Convert.ToInt32(ReadString("CGL_SendMailPorta"));
                string CCOS = ReadString("CGL_SendMailCCOS");

                string pathFisico = ReadString("CGL_PathImagem");
                string pasta = ReadEmail("TME_PathTemplateEmail", id);//linha dois do template

                string pathFull = pathFisico + pasta;

                //pathFull = "D:\\RocketStudio\\Directto\\TemplateEmail\\TemplatePadrao.html"; //remover teste local
                string urlValidaEmailToken = ReadString("CGL_UrlWEB");

                string Assunto = "[Notificação - Directto] " + assunto;

                var mail = new MailMessage();
                mail.To.Add(sEmail);

                mail.From = new MailAddress(EmailSender, EmailSenderName, System.Text.Encoding.UTF8);

                mail.Subject = Assunto;

                string ccoS = CCOS;
                var listaCCOS = ccoS.Split(';');

                foreach (var item in listaCCOS)
                {
                    if (!string.IsNullOrEmpty(item))
                        mail.Bcc.Add(new MailAddress(item, "[Notificação - Directto] " + assunto, System.Text.Encoding.UTF8));
                }



                mail.SubjectEncoding = System.Text.Encoding.UTF8;

                string assemblyFile = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                assemblyFile = Path.GetDirectoryName(assemblyFile);
                string complementoMail = "";

                //pathFull = "C:\\Users\\Ananda\\Desktop\\Work-Night\\TemplateEmail\\1\\TME_Id_1_202005210029.html"; //remover teste local
                var html = new HtmlDocument();
                html.LoadHtml(File.ReadAllText(pathFull));

                string mensagem = "";
                string button = "";
                string mensagem2 = "";
                string sLink = "";

                
                if (iTipo == 1)//Contra oferta feita com sucesso
                {
                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "A contra oferta ("+ complemento + ") foi realizada com sucesso.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Você será automaticamente informado quando o vendedor responder a sua contraoferta. E se você tiver alguma questão entre com o nosso time pelo email info@directto.tech.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 2)//Counter offer successfully created
                {
                    mensagem = "Hello " + sEmail + ",<br><br>";
                    mensagem += "You successfully created the counter offer reference of the counter - offer ("+ complemento + ").";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "You will be automatically informed when the seller responds to your counter offer.If you have further questions, contact our team at info @directto.tech.<br>";
                    mensagem2 += "Directto team.";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 3)//Email 10 - Você tem uma contra oferta - Vendedor
                {
                    sLink = UrlWEB + "dashboard/negociacoes";

                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O produto que você está negociando recebeu uma contraoferta.Acesse o link abaixo para ter acesso aos detalhes.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Acessar contraoferta</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Você será automaticamente informado quando o comprador se manifestar sobre a sua decisão. E se você tiver alguma questão entre com o nosso time pelo email info@directto.tech.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 4)//Email 11 - Contra oferta aprovada - Vendedor
                {
                    sLink = UrlWEB + "dashboard/negociacoes";

                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O vendedor do produto ("+ complemento + ") aprovou a contra oferta feita por você.O nosso time entrará em contato para auxiliar nos próximos passos e você já pode acessar board operacional para acompanhar os trâmites de receber o seu produto.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Acompanhar</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Você será notificado em cada etapa do processo, e se você tiver alguma questão entre com o nosso time pelo email info @directto.tech.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 5)//Email 11E - Counter offer approved - Vendedor
                {
                    sLink = UrlWEB + "dashboard/negociacoes";

                    mensagem = "Hello " + sEmail + ",<br><br>";
                    mensagem += "The seller of the product ("+ complemento + ") has approved the counter offer made by you.Our team will contact you to help with the next steps.And also, you can access the operational board to follow the procedures for receiving your product.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Follow</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "We will notify you in each step of the process, and if you have any questions, do not hesitate to contact our team at info @directto.tech. <br><br>";
                    mensagem2 += "Directto team";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 6)//Email 12E - Contra oferta recusada - Vendedor
                {
                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O vendedor do produto ("+ complemento + ") recusou a contra oferta feita por você.O nosso time entrará em contato para maiores detalhes.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Caso você tenha alguma questão entre em contato conosco pelo email info @directto.tech.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 7)//Email 12E - Counter offer not accepted - Vendedor
                {
                    mensagem = "Dear " + sEmail + ",<br><br>";
                    mensagem += "We apologize in advance, but unfortunately, the seller of the product("+ complemento + ") has refused the counter offer you created.Our team will contact you to give more details.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "If you have any questions, do not hesitate to email us at info @directto.tech. <br><br>";
                    mensagem2 += "Directto team.";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 8)//Email 13 - Contra oferta aprovada - Comprador
                {
                    sLink = UrlWEB + "dashboard/negociacoes";

                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O comprador interessado no produto ("+ complemento + ") aprovou a contra oferta feita por você.O nosso time entrará em contato para auxiliar nos próximos passos e você já pode acessar board operacional para acompanhar os trâmites de receber o seu produto.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Acompanhar</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Você será notificado em cada etapa do processo, e se você tiver alguma questão entre com o nosso time pelo email info @directto.tech.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 9) //Email 14 - Contra oferta recusada - Comprador
                {
                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O comprador interessado no produto ofertado ("+ complemento + ") recusou a contra oferta feita por você.O nosso time entrará em contato para maiores detalhes.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Caso você tenha alguma questão entre em contato conosco pelo email info @directto.tech.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 10)//Contra oferta feita com sucesso - Vendedor
                {
                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "A contra oferta (" + complemento + ") foi realizada com sucesso.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Você será automaticamente informado quando o comprador responder a sua contraoferta. E se você tiver alguma questão entre com o nosso time pelo email info@directto.tech.<br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 11)//Email 10 - Você tem uma contra oferta - Comprador
                {
                    sLink = UrlWEB + "dashboard/negociacoes";

                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "O produto que você está negociando recebeu uma contraoferta.Acesse o link abaixo para ter acesso aos detalhes.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Acessar contraoferta</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Você será automaticamente informado quando o vendedor se manifestar sobre a sua decisão. E se você tiver alguma questão entre com o nosso time pelo email info@directto.tech.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 12)//Email 15 - Nova Notificação
                {
                    sLink = UrlWEB + "dashboard/board-operacional";

                    mensagem = "Olá " + sEmail + ",<br><br>";
                    mensagem += "Você tem uma nova notificação referente ao processo de conclusão da operação de entrega do produto.<br><br>";
                    mensagem += complemento + "<br><br>";
                    mensagem += "Acesse o link abaixo para ter acesso ao board operacional.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Acessar o board operacional</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "Caso você tenha alguma questão entre em contato conosco pelo email info@directto.tech.<br><br>";
                    mensagem2 += "Equipe da Directto";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                else if (iTipo == 13)//15E - New Notification
                {
                    sLink = UrlWEB + "dashboard/board-operacional";

                    mensagem = "Dear " + sEmail + ",<br><br>";
                    mensagem += "You have a new notification regarding the product deliveryoperation. <br><br>";
                    mensagem += complemento + "<br><br>";
                    mensagem += "Click on the link below to access the operating board.";
                    html.GetElementbyId("spanMensagem").InnerHtml = mensagem;

                    button = "<a href = \"" + sLink + "\" target = \"_blank\" style = \"font-family:'Helvetica Neue', 'Helvetica', 'Arial', 'Lucida Grande', 'sans-serif'; font-size:14px; font-weight:600; color:#d72c2c; text-decoration: underline;\">Access the operating board</a>";
                    html.GetElementbyId("spanButton").InnerHtml = button;

                    mensagem2 = "If you have any questions, please contact us at info@directto.tech.<br><br>";
                    mensagem2 += "Direct team.";
                    html.GetElementbyId("spanMensagem2").InnerHtml = mensagem2;
                }
                mail.IsBodyHtml = true;
                mail.Body = html.DocumentNode.InnerHtml;


                //Adicionando as credenciais da conta do remetente
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailSender, EmailSenderPass); // <<<<<<<<<<<< colocar email e senha do gmail

                client.Port = iPort; // Esta porta é a utilizada pelo Gmail para envio

                client.Host = Host; //Definindo o provedor que irá disparar o e-mail

                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

                // client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;



                try
                {
                    client.Send(mail);


                    return true;
                }
                catch (SmtpException ex)
                {
                    return false;
                    throw ex;
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public static string ReadStringWeb(string key)
        {
            try
            {
                System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
                return rd.GetValue(key, typeof(String)).ToString();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static string ReadString(string key)
        {
            try
            {
                String valor;
                System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
                valor = rd.GetValue("ConfigGlobal", typeof(String)).ToString();

                String value;
                var _ConfiguracaoGlobalRepo = new ConfiguracaoGlobalRepository();
                value = _ConfiguracaoGlobalRepo.getCampoConfiguracaoGlobal(key, Convert.ToInt32(valor));

                return value;

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string ReadEmail(string key, int id)
        {
            try
            {
                String value;
                var _TemplateEmailRepo = new TemplateEmailRepository();
                value = _TemplateEmailRepo.getTemplateEmail(key, id);

                return value;

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

       

    }   
}