using Application;
using Application.Interfaces;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using DIRECTTO.Quartz;
using DIRECTTO.Handlers;
using Application.Handlers;
using Ninject;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Net.Http;

namespace DIRECTTO
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new ControllerHttpHandler());

            // initialize kernel and create the scheduler
            var kernel = InitializeNinjectKernel();
            var schedulerJob01 = kernel.Get<IScheduler>();

            // Below this line should be whatever code you are using today to schedule jobs, triggers, etc. and start the scheduler. This is just here for context

            // add jobs and start scheduler
            schedulerJob01.ScheduleJob(
                JobBuilder.Create<Service01Job>().Build(),
                TriggerBuilder.Create().WithCronSchedule(ReadString("CGL_CronScheduleJob01")).Build());
            //WithSimpleSchedule(s => s.WithIntervalInHours(12).RepeatForever()).Build());

            /* schedulerJob02.ScheduleJob(
                 JobBuilder.Create<Service02Job>().Build(),
                 TriggerBuilder.Create().WithCronSchedule(ReadString("CGL_CronScheduleJob02")).Build());

             schedulerJob03.ScheduleJob(
                 JobBuilder.Create<Service03Job>().Build(),
                 TriggerBuilder.Create().WithCronSchedule(ReadString("CGL_CronScheduleJob03")).Build());

             schedulerJob02.Start();
             schedulerJob03.Start();
             */
            schedulerJob01.Start();
            
        }
        protected void Application_BeginRequest()
        {
            try
            {
                System.Web.HttpResponse response = HttpContext.Current.Response;
                HttpRequest request = HttpContext.Current.Request;
                //OutputFilterStream filter = new OutputFilterStream(response.Filter);

                RepositoryBase.salvaLog("{\"requrl\":\"" + request.Url + "\",\"queryString\":\"" + request.QueryString.ToString() + "\",\"body\":\"" + request.Form.ToString() + "\"}");

            }
            catch (Exception)
            {
            }

            //Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (Request.HttpMethod == "OPTIONS")
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                Response.AddHeader("Access-Control-Allow-Credentials", "true");
                Response.AddHeader("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
                Response.AddHeader("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers");

                Response.End();
            }


        }

        static IKernel InitializeNinjectKernel()
        {
            var kernel = new StandardKernel();

            // setup Quartz scheduler that uses our NinjectJobFactory
            kernel.Bind<IScheduler>().ToMethod(x =>
            {
                var sched = new StdSchedulerFactory().GetScheduler();
                sched.JobFactory = new JobsQuartz(kernel);
                return sched;
            });


            // add our bindings as we normally would (these are the bindings that our jobs require)

            kernel.Bind<IBancoAppServices>().To<BancoAppServices>();
            kernel.Bind<IBancoServices>().To<BancoServices>();
            kernel.Bind<IBancoRepository>().To<BancoRepository>();

            kernel.Bind<ICategoriaAppServices>().To<CategoriaAppServices>();
            kernel.Bind<ICategoriaServices>().To<CategoriaServices>();
            kernel.Bind<ICategoriaRepository>().To<CategoriaRepository>();

            kernel.Bind<ICidadeAppServices>().To<CidadeAppServices>();
            kernel.Bind<ICidadeServices>().To<CidadeServices>();
            kernel.Bind<ICidadeRepository>().To<CidadeRepository>();

            kernel.Bind<IConfiguracaoGlobalAppServices>().To<ConfiguracaoGlobalAppServices>();
            kernel.Bind<IConfiguracaoGlobalServices>().To<ConfiguracaoGlobalServices>();
            kernel.Bind<IConfiguracaoGlobalRepository>().To<ConfiguracaoGlobalRepository>();

            kernel.Bind<IDocumentoAppServices>().To<DocumentoAppServices>();
            kernel.Bind<IDocumentoServices>().To<DocumentoServices>();
            kernel.Bind<IDocumentoRepository>().To<DocumentoRepository>();

            kernel.Bind<IEnderecoAppServices>().To<EnderecoAppServices>();
            kernel.Bind<IEnderecoServices>().To<EnderecoServices>();
            kernel.Bind<IEnderecoRepository>().To<EnderecoRepository>();

            kernel.Bind<IEmpresaAppServices>().To<EmpresaAppServices>();
            kernel.Bind<IEmpresaServices>().To<EmpresaServices>();
            kernel.Bind<IEmpresaRepository>().To<EmpresaRepository>();

            kernel.Bind<IEmpresaxDocumentoAppServices>().To<EmpresaxDocumentoAppServices>();
            kernel.Bind<IEmpresaxDocumentoServices>().To<EmpresaxDocumentoServices>();
            kernel.Bind<IEmpresaxDocumentoRepository>().To<EmpresaxDocumentoRepository>();

            kernel.Bind<IEmpresaxLogisticaAppServices>().To<EmpresaxLogisticaAppServices>();
            kernel.Bind<IEmpresaxLogisticaServices>().To<EmpresaxLogisticaServices>();
            kernel.Bind<IEmpresaxLogisticaRepository>().To<EmpresaxLogisticaRepository>();

            kernel.Bind<IEmpresaxProdutoAppServices>().To<EmpresaxProdutoAppServices>();
            kernel.Bind<IEmpresaxProdutoServices>().To<EmpresaxProdutoServices>();
            kernel.Bind<IEmpresaxProdutoRepository>().To<EmpresaxProdutoRepository>();

            kernel.Bind<IEmpresaxServicoAdicionalAppServices>().To<EmpresaxServicoAdicionalAppServices>();
            kernel.Bind<IEmpresaxServicoAdicionalServices>().To<EmpresaxServicoAdicionalServices>();
            kernel.Bind<IEmpresaxServicoAdicionalRepository>().To<EmpresaxServicoAdicionalRepository>();

            kernel.Bind<IEmpresaxServicoFinanceiroAppServices>().To<EmpresaxServicoFinanceiroAppServices>();
            kernel.Bind<IEmpresaxServicoFinanceiroServices>().To<EmpresaxServicoFinanceiroServices>();
            kernel.Bind<IEmpresaxServicoFinanceiroRepository>().To<EmpresaxServicoFinanceiroRepository>();

            kernel.Bind<IEstadoAppServices>().To<EstadoAppServices>();
            kernel.Bind<IEstadoServices>().To<EstadoServices>();
            kernel.Bind<IEstadoRepository>().To<EstadoRepository>();

            kernel.Bind<ILogAppServices>().To<LogAppServices>();
            kernel.Bind<ILogServices>().To<LogServices>();
            kernel.Bind<ILogRepository>().To<LogRepository>();

            kernel.Bind<ILogErroAppServices>().To<LogErroAppServices>();
            kernel.Bind<ILogErroServices>().To<LogErroServices>();
            kernel.Bind<ILogErroRepository>().To<LogErroRepository>();

            kernel.Bind<ILogLoginAppServices>().To<LogLoginAppServices>();
            kernel.Bind<ILogLoginServices>().To<LogLoginServices>();
            kernel.Bind<ILogLoginRepository>().To<LogLoginRepository>();

            kernel.Bind<IMeioTransporteAppServices>().To<MeioTransporteAppServices>();
            kernel.Bind<IMeioTransporteServices>().To<MeioTransporteServices>();
            kernel.Bind<IMeioTransporteRepository>().To<MeioTransporteRepository>();

            kernel.Bind<IMenuAppServices>().To<MenuAppServices>();
            kernel.Bind<IMenuServices>().To<MenuServices>();
            kernel.Bind<IMenuRepository>().To<MenuRepository>();

            kernel.Bind<IModoCultivoModoProducaoAppServices>().To<ModoCultivoModoProducaoAppServices>();
            kernel.Bind<IModoCultivoModoProducaoServices>().To<ModoCultivoModoProducaoServices>();
            kernel.Bind<IModoCultivoModoProducaoRepository>().To<ModoCultivoModoProducaoRepository>();

            kernel.Bind<IModoCultivoSistemaProdutivoAppServices>().To<ModoCultivoSistemaProdutivoAppServices>();
            kernel.Bind<IModoCultivoSistemaProdutivoServices>().To<ModoCultivoSistemaProdutivoServices>();
            kernel.Bind<IModoCultivoSistemaProdutivoRepository>().To<ModoCultivoSistemaProdutivoRepository>();

            //kernel.Bind<INotificacaoAppServices>().To<NotificacaoAppServices>();
            //kernel.Bind<INotificacaoServices>().To<NotificacaoServices>();
            //kernel.Bind<INotificacaoRepository>().To<NotificacaoRepository>();

            kernel.Bind<IOfertaAppServices>().To<OfertaAppServices>();
            kernel.Bind<IOfertaServices>().To<OfertaServices>();
            kernel.Bind<IOfertaRepository>().To<OfertaRepository>();

            kernel.Bind<IOfertaxCertificacaoAppServices>().To<OfertaxCertificacaoAppServices>();
            kernel.Bind<IOfertaxCertificacaoServices>().To<OfertaxCertificacaoServices>();
            kernel.Bind<IOfertaxCertificacaoRepository>().To<OfertaxCertificacaoRepository>();

            kernel.Bind<IOfertaxDocumentoAppServices>().To<OfertaxDocumentoAppServices>();
            kernel.Bind<IOfertaxDocumentoServices>().To<OfertaxDocumentoServices>();
            kernel.Bind<IOfertaxDocumentoRepository>().To<OfertaxDocumentoRepository>();

            kernel.Bind<IOfertaxQuantidadeProdutoAppServices>().To<OfertaxQuantidadeProdutoAppServices>();
            kernel.Bind<IOfertaxQuantidadeProdutoServices>().To<OfertaxQuantidadeProdutoServices>();
            kernel.Bind<IOfertaxQuantidadeProdutoRepository>().To<OfertaxQuantidadeProdutoRepository>();

            kernel.Bind<IOfertaxServicoAdicionalAppServices>().To<OfertaxServicoAdicionalAppServices>();
            kernel.Bind<IOfertaxServicoAdicionalServices>().To<OfertaxServicoAdicionalServices>();
            kernel.Bind<IOfertaxServicoAdicionalRepository>().To<OfertaxServicoAdicionalRepository>();

            kernel.Bind<IOfertaxServicoOpcionalAppServices>().To<OfertaxServicoOpcionalAppServices>();
            kernel.Bind<IOfertaxServicoOpcionalServices>().To<OfertaxServicoOpcionalServices>();
            kernel.Bind<IOfertaxServicoOpcionalRepository>().To<OfertaxServicoOpcionalRepository>();

            kernel.Bind<IPerfilAppServices>().To<PerfilAppServices>();
            kernel.Bind<IPerfilServices>().To<PerfilServices>();
            kernel.Bind<IPerfilRepository>().To<PerfilRepository>();

            kernel.Bind<IPerfilxSubMenuAppServices>().To<PerfilxSubMenuAppServices>();
            kernel.Bind<IPerfilxSubMenuServices>().To<PerfilxSubMenuServices>();
            kernel.Bind<IPerfilxSubMenuRepository>().To<PerfilxSubMenuRepository>();

            kernel.Bind<IPerfilxUsuarioAppServices>().To<PerfilxUsuarioAppServices>();
            kernel.Bind<IPerfilxUsuarioServices>().To<PerfilxUsuarioServices>();
            kernel.Bind<IPerfilxUsuarioRepository>().To<PerfilxUsuarioRepository>();

            kernel.Bind<IPessoaAppServices>().To<PessoaAppServices>();
            kernel.Bind<IPessoaServices>().To<PessoaServices>();
            kernel.Bind<IPessoaRepository>().To<PessoaRepository>();

            kernel.Bind<IPoliticaPrivacidadeAppServices>().To<PoliticaPrivacidadeAppServices>();
            kernel.Bind<IPoliticaPrivacidadeServices>().To<PoliticaPrivacidadeServices>();
            kernel.Bind<IPoliticaPrivacidadeRepository>().To<PoliticaPrivacidadeRepository>();

            kernel.Bind<IPoliticaPrivacidadexUsuarioAppServices>().To<PoliticaPrivacidadexUsuarioAppServices>();
            kernel.Bind<IPoliticaPrivacidadexUsuarioServices>().To<PoliticaPrivacidadexUsuarioServices>();
            kernel.Bind<IPoliticaPrivacidadexUsuarioRepository>().To<PoliticaPrivacidadexUsuarioRepository>();

            kernel.Bind<IProdutoAppServices>().To<ProdutoAppServices>();
            kernel.Bind<IProdutoServices>().To<ProdutoServices>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();

            kernel.Bind<IPronomeTratamentoAppServices>().To<PronomeTratamentoAppServices>();
            kernel.Bind<IPronomeTratamentoServices>().To<PronomeTratamentoServices>();
            kernel.Bind<IPronomeTratamentoRepository>().To<PronomeTratamentoRepository>();

            kernel.Bind<IServicoAdicionalAppServices>().To<ServicoAdicionalAppServices>();
            kernel.Bind<IServicoAdicionalServices>().To<ServicoAdicionalServices>();
            kernel.Bind<IServicoAdicionalRepository>().To<ServicoAdicionalRepository>();

            kernel.Bind<IServicoOpcionalAppServices>().To<ServicoOpcionalAppServices>();
            kernel.Bind<IServicoOpcionalServices>().To<ServicoOpcionalServices>();
            kernel.Bind<IServicoOpcionalRepository>().To<ServicoOpcionalRepository>();

            kernel.Bind<IServicoFinanceiroAppServices>().To<ServicoFinanceiroAppServices>();
            kernel.Bind<IServicoFinanceiroServices>().To<ServicoFinanceiroServices>();
            kernel.Bind<IServicoFinanceiroRepository>().To<ServicoFinanceiroRepository>();

            kernel.Bind<ISexoAppServices>().To<SexoAppServices>();
            kernel.Bind<ISexoServices>().To<SexoServices>();
            kernel.Bind<ISexoRepository>().To<SexoRepository>();

            kernel.Bind<IStatusDocumentoAppServices>().To<StatusDocumentoAppServices>();
            kernel.Bind<IStatusDocumentoServices>().To<StatusDocumentoServices>();
            kernel.Bind<IStatusDocumentoRepository>().To<StatusDocumentoRepository>();

            kernel.Bind<IStatusNegociacaoAppServices>().To<StatusNegociacaoAppServices>();
            kernel.Bind<IStatusNegociacaoServices>().To<StatusNegociacaoServices>();
            kernel.Bind<IStatusNegociacaoRepository>().To<StatusNegociacaoRepository>();

            kernel.Bind<IStatusPagamentoAppServices>().To<StatusPagamentoAppServices>();
            kernel.Bind<IStatusPagamentoServices>().To<StatusPagamentoServices>();
            kernel.Bind<IStatusPagamentoRepository>().To<StatusPagamentoRepository>();

            kernel.Bind<IStatusProdutoAppServices>().To<StatusProdutoAppServices>();
            kernel.Bind<IStatusProdutoServices>().To<StatusProdutoServices>();
            kernel.Bind<IStatusProdutoRepository>().To<StatusProdutoRepository>();

            kernel.Bind<ISubMenuAppServices>().To<SubMenuAppServices>();
            kernel.Bind<ISubMenuServices>().To<SubMenuServices>();
            kernel.Bind<ISubMenuRepository>().To<SubMenuRepository>();

            kernel.Bind<ITemplateEmailAppServices>().To<TemplateEmailAppServices>();
            kernel.Bind<ITemplateEmailServices>().To<TemplateEmailServices>();
            kernel.Bind<ITemplateEmailRepository>().To<TemplateEmailRepository>();

            kernel.Bind<ITermoUsoAppServices>().To<TermoUsoAppServices>();
            kernel.Bind<ITermoUsoServices>().To<TermoUsoServices>();
            kernel.Bind<ITermoUsoRepository>().To<TermoUsoRepository>();

            kernel.Bind<ITermoUsoxUsuarioAppServices>().To<TermoUsoxUsuarioAppServices>();
            kernel.Bind<ITermoUsoxUsuarioServices>().To<TermoUsoxUsuarioServices>();
            kernel.Bind<ITermoUsoxUsuarioRepository>().To<TermoUsoxUsuarioRepository>();

            kernel.Bind<ITipoCertificacaoAppServices>().To<TipoCertificacaoAppServices>();
            kernel.Bind<ITipoCertificacaoServices>().To<TipoCertificacaoServices>();
            kernel.Bind<ITipoCertificacaoRepository>().To<TipoCertificacaoRepository>();

            kernel.Bind<ITipoDocumentoAppServices>().To<TipoDocumentoAppServices>();
            kernel.Bind<ITipoDocumentoServices>().To<TipoDocumentoServices>();
            kernel.Bind<ITipoDocumentoRepository>().To<TipoDocumentoRepository>();

            kernel.Bind<ITipoEmpresaAppServices>().To<TipoEmpresaAppServices>();
            kernel.Bind<ITipoEmpresaServices>().To<TipoEmpresaServices>();
            kernel.Bind<ITipoEmpresaRepository>().To<TipoEmpresaRepository>();

            kernel.Bind<ITipoLogisticoPortoAppServices>().To<TipoLogisticoPortoAppServices>();
            kernel.Bind<ITipoLogisticoPortoServices>().To<TipoLogisticoPortoServices>();
            kernel.Bind<ITipoLogisticoPortoRepository>().To<TipoLogisticoPortoRepository>();

            kernel.Bind<ITipoLogisticoSistemaProdutivoAppServices>().To<TipoLogisticoSistemaProdutivoAppServices>();
            kernel.Bind<ITipoLogisticoSistemaProdutivoServices>().To<TipoLogisticoSistemaProdutivoServices>();
            kernel.Bind<ITipoLogisticoSistemaProdutivoRepository>().To<TipoLogisticoSistemaProdutivoRepository>();

            kernel.Bind<ILogisticaAppServices>().To<LogisticaAppServices>();
            kernel.Bind<ILogisticaServices>().To<LogisticaServices>();
            kernel.Bind<ILogisticaRepository>().To<LogisticaRepository>();

            kernel.Bind<ITipoNotificacaoAppServices>().To<TipoNotificacaoAppServices>();
            kernel.Bind<ITipoNotificacaoServices>().To<TipoNotificacaoServices>();
            kernel.Bind<ITipoNotificacaoRepository>().To<TipoNotificacaoRepository>();

            kernel.Bind<IOfertaNegociacaoAppServices>().To<OfertaNegociacaoAppServices>();
            kernel.Bind<IOfertaNegociacaoServices>().To<OfertaNegociacaoServices>();
            kernel.Bind<IOfertaNegociacaoRepository>().To<OfertaNegociacaoRepository>();

            kernel.Bind<IOfertaNegociacaoxDocumentoAppServices>().To<OfertaNegociacaoxDocumentoAppServices>();
            kernel.Bind<IOfertaNegociacaoxDocumentoServices>().To<OfertaNegociacaoxDocumentoServices>();
            kernel.Bind<IOfertaNegociacaoxDocumentoRepository>().To<OfertaNegociacaoxDocumentoRepository>();

            kernel.Bind<IOfertaNegociacaoxStatusNegociacaoAppServices>().To<OfertaNegociacaoxStatusNegociacaoAppServices>();
            kernel.Bind<IOfertaNegociacaoxStatusNegociacaoServices>().To<OfertaNegociacaoxStatusNegociacaoServices>();
            kernel.Bind<IOfertaNegociacaoxStatusNegociacaoRepository>().To<OfertaNegociacaoxStatusNegociacaoRepository>();

            kernel.Bind<ITipoProdutoAppServices>().To<TipoProdutoAppServices>();
            kernel.Bind<ITipoProdutoServices>().To<TipoProdutoServices>();
            kernel.Bind<ITipoProdutoRepository>().To<TipoProdutoRepository>();

            kernel.Bind<ITipoServicoAdicionalAppServices>().To<TipoServicoAdicionalAppServices>();
            kernel.Bind<ITipoServicoAdicionalServices>().To<TipoServicoAdicionalServices>();
            kernel.Bind<ITipoServicoAdicionalRepository>().To<TipoServicoAdicionalRepository>();

            kernel.Bind<ITipoTransacaoLogAppServices>().To<TipoTransacaoLogAppServices>();
            kernel.Bind<ITipoTransacaoLogServices>().To<TipoTransacaoLogServices>();
            kernel.Bind<ITipoTransacaoLogRepository>().To<TipoTransacaoLogRepository>();

            kernel.Bind<IUnidadeAppServices>().To<UnidadeAppServices>();
            kernel.Bind<IUnidadeServices>().To<UnidadeServices>();
            kernel.Bind<IUnidadeRepository>().To<UnidadeRepository>();

            kernel.Bind<IUnidadePesoAppServices>().To<UnidadePesoAppServices>();
            kernel.Bind<IUnidadePesoServices>().To<UnidadePesoServices>();
            kernel.Bind<IUnidadePesoRepository>().To<UnidadePesoRepository>();

            kernel.Bind<IUsuarioAppServices>().To<UsuarioAppServices>();
            kernel.Bind<IUsuarioServices>().To<UsuarioServices>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();

            return kernel;
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
    }
}
