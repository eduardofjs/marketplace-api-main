using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class OfertaServices : IOfertaServices
    {
        private readonly IOfertaRepository _OfertaRepo;

        public OfertaServices(IOfertaRepository OfertaRepo)
        {
            _OfertaRepo = OfertaRepo;
        }

        public Oferta InsertOferta(Oferta objOferta)
        {
            return _OfertaRepo.InsertOferta(objOferta);
        }

        public bool UpdateOferta(Oferta objOferta)
        {
            return _OfertaRepo.UpdateOferta(objOferta);
        }

        public bool AtivarOferta(int OFE_Id)
        {
            return _OfertaRepo.AtivarOferta(OFE_Id);
        }

        public bool DeletarOferta(int OFE_Id)
        {
            return _OfertaRepo.DeletarOferta(OFE_Id);
        }

        public Oferta GetOfertaById(int OFE_Id, bool join)
        {
            return _OfertaRepo.GetOfertaById(OFE_Id, join);
        }

        public IEnumerable<Oferta> GetAllOferta(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaRepo.GetAllOferta(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Oferta> GetAllOfertaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaRepo.GetAllOfertaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Oferta> GetAllOfertaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _OfertaRepo.GetAllOfertaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
        public bool AprovarOferta(int OFE_Id)
        {
            return _OfertaRepo.AprovarOferta(OFE_Id);
        }

        public bool ReprovarOferta(int OFE_Id)
        {
            return _OfertaRepo.ReprovarOferta(OFE_Id);
        }

        public Oferta GetOfertaEditarById(int OFE_Id, bool join)
        {
            return _OfertaRepo.GetOfertaEditarById(OFE_Id, join);
        }
    }
}

