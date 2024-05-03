
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class TipoEmpresaServices : ITipoEmpresaServices
    {
        private readonly ITipoEmpresaRepository _TipoEmpresaRepo;

        public TipoEmpresaServices(ITipoEmpresaRepository TipoEmpresaRepo)
        {
            _TipoEmpresaRepo = TipoEmpresaRepo;
        }
		
        public TipoEmpresa InsertTipoEmpresa(TipoEmpresa objTipoEmpresa)
        {
            return _TipoEmpresaRepo.InsertTipoEmpresa(objTipoEmpresa);
        }

        public bool UpdateTipoEmpresa(TipoEmpresa objTipoEmpresa)
        {
            return _TipoEmpresaRepo.UpdateTipoEmpresa(objTipoEmpresa);
        }

        public bool AtivarTipoEmpresa(int TEM_Id)
        {
            return _TipoEmpresaRepo.AtivarTipoEmpresa(TEM_Id);
        }

        public bool DeletarTipoEmpresa(int TEM_Id)
        {
            return _TipoEmpresaRepo.DeletarTipoEmpresa(TEM_Id);
        }
        
        public TipoEmpresa GetTipoEmpresaById(int TEM_Id, bool join)
        {
            return _TipoEmpresaRepo.GetTipoEmpresaById(TEM_Id, join);
        }

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoEmpresaRepo.GetAllTipoEmpresa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoEmpresaRepo.GetAllTipoEmpresaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<TipoEmpresa> GetAllTipoEmpresaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _TipoEmpresaRepo.GetAllTipoEmpresaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

