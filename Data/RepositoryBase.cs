using Data.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using System.Data;

namespace Data.Repositories
{
    public class RepositoryBase
    {
        protected IDbConnection _db;
        public static int calcularIdade(DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age)) age--;

            return age;
        }

        public static string ReadString_old(string key)
        {
            try
            {
                System.Configuration.AppSettingsReader rd = new System.Configuration.AppSettingsReader();
                return rd.GetValue(key, typeof(String)).ToString();
            }
            catch (Exception ex)
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

        public static void salvaLog(Log Log, string LogText, string Metodo = "", string Query = "", string Parametros = "")
        {
            /*var filename = ReadString_old("Log");

            bool exists = System.IO.Directory.Exists(filename);

            if (!exists)
                System.IO.Directory.CreateDirectory(filename);

            var sw = new System.IO.StreamWriter(filename + "log.txt", true);
            try
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + Log);
                sw.Close();
            }
            catch (Exception e)
            {
                sw.Close();
                sw.Dispose();

                sw = new System.IO.StreamWriter(filename + "log.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + " " + Log);
                sw.Close();
            }*/

            if (Log == null && Metodo != "")
            {
                Log = new Log();
                Log.LOG_Metodo = Metodo;
                Log.LOG_ParametroJson = Parametros;
                Log.LOG_QueryString = Query;
                Log.LOG_DataHora = DateTime.Now;
            }

            if (Log != null)
            {
                LogRepository _LogRepo = new LogRepository();
                _LogRepo.InsertLog(Log);
            }
            //sw.Close();

        }

        public static void salvaLog(Log Log)
        {
            LogRepository _LogRepo = new LogRepository();
            _LogRepo.InsertLog(Log);

        }

        public static void salvaLogError(Log Log, string Classe, string Funcao, string erro, string erroMensagem, string erroStackTrace, string QueryString)
        {
            var LogErro = new LogErro();
            if (Log != null)
            {
                LogErro.LGE_UsuarioId = Log.LOG_UsuarioId;
                LogErro.LGE_token = Log.LOG_Token;
                LogErro.LGE_SubMenuId = Log.LOG_SubMenuId;
                LogErro.LGE_PlataformaId = Log.LOG_PlataformaId;
                LogErro.LGE_VersaoPlataforma = Log.LOG_VersaoPlataforma;
                LogErro.LGE_VersaoApi = Log.LOG_VersaoApi;
                LogErro.LGE_QueryString = Log.LOG_QueryString;
            }

            LogErro.LGE_className = Classe;
            LogErro.LGE_functionName = Funcao;
            LogErro.LGE_erroFullName = erro;
            LogErro.LGE_erroMessage = erroMensagem;
            LogErro.LGE_erroStackTrace = erroStackTrace;
            LogErro.LGE_QueryString = QueryString;
            LogErro.LGE_DataHora = DateTime.Now;
            LogErro.LGE_erroData = DateTime.Now.ToString("yyyy-MM-dd HH:ss");

            var _LogErroRepo = new LogErroRepository();
            _LogErroRepo.InsertLogErro(LogErro);
        }


        public static void salvaLog(string Log)
        {
            //var filename = ReadString_old("Log");

            //bool exists = System.IO.Directory.Exists(filename);

            //if (!exists)
            //    System.IO.Directory.CreateDirectory(filename);

            //var sw = new System.IO.StreamWriter(filename + "log.txt", true);
            //try
            //{
            //    sw.WriteLine(DateTime.Now.ToString() + " " + Log);
            //    sw.Close();
            //}
            //catch (Exception e)
            //{
            //    sw.Close();
            //    sw.Dispose();

            //    sw = new System.IO.StreamWriter(filename + "log.txt", true);
            //    sw.WriteLine(DateTime.Now.ToString() + " " + Log);
            //    sw.Close();
            //}
        }

        public string TiraAcento(string toRemoveAcentos)
        {
            const string StrComAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç'";
            const string StrSemAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc ";
            int i = 0;

            foreach (Char c in StrComAcentos)
            {
                toRemoveAcentos = toRemoveAcentos.Replace(c.ToString().Trim(), StrSemAcentos[i].ToString().Trim());
                i++;
            }

            return toRemoveAcentos;
        }
    }
}
