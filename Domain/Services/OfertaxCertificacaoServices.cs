using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaxCertificacaoServices : IOfertaxCertificacaoServices
    {
        private readonly IOfertaxCertificacaoRepository _OfertaxCertificacaoRepo;

        public OfertaxCertificacaoServices(IOfertaxCertificacaoRepository OfertaxCertificacaoRepo)
        {
            _OfertaxCertificacaoRepo = OfertaxCertificacaoRepo;
        }

        public OfertaxCertificacao InsertOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao)
        {
            return _OfertaxCertificacaoRepo.InsertOfertaxCertificacao(objOfertaxCertificacao);
        }

        public bool UpdateOfertaxCertificacao(OfertaxCertificacao objOfertaxCertificacao)
        {
            return _OfertaxCertificacaoRepo.UpdateOfertaxCertificacao(objOfertaxCertificacao);
        }

        public bool AtivarOfertaxCertificacao(int OXC_Id)
        {
            return _OfertaxCertificacaoRepo.AtivarOfertaxCertificacao(OXC_Id);
        }

        public bool DeletarOfertaxCertificacao(int OXC_Id)
        {
            return _OfertaxCertificacaoRepo.DeletarOfertaxCertificacao(OXC_Id);
        }

        public OfertaxCertificacao GetOfertaxCertificacaoById(int OXC_Id, bool join)
        {
            return _OfertaxCertificacaoRepo.GetOfertaxCertificacaoById(OXC_Id, join);
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacao(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxCertificacaoRepo.GetAllOfertaxCertificacao(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxCertificacaoRepo.GetAllOfertaxCertificacaoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<OfertaxCertificacao> GetAllOfertaxCertificacaoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaxCertificacaoRepo.GetAllOfertaxCertificacaoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

