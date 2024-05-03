[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DIRECTTO.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DIRECTTO.App_Start.NinjectWebCommon), "Stop")]

namespace DIRECTTO.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;

    using Domain.Services;
    using Application.Interfaces;
    using Application;
    using Data.Repositories;
    using Domain.Interfaces.Services;
    using Domain.Interfaces.Repositories;
    using Data;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

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

            kernel.Bind<IDigitalTwinAppServices>().To<DigitalTwinAppServices>();
        }
    }
}
