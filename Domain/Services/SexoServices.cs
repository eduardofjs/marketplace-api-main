
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class SexoServices : ISexoServices
    {
        private readonly ISexoRepository _SexoRepo;

        public SexoServices(ISexoRepository SexoRepo)
        {
            _SexoRepo = SexoRepo;
        }
		
        public Sexo InsertSexo(Sexo objSexo)
        {
            return _SexoRepo.InsertSexo(objSexo);
        }

        public bool UpdateSexo(Sexo objSexo)
        {
            return _SexoRepo.UpdateSexo(objSexo);
        }

        public bool AtivarSexo(int SEX_Id)
        {
            return _SexoRepo.AtivarSexo(SEX_Id);
        }

        public bool DeletarSexo(int SEX_Id)
        {
            return _SexoRepo.DeletarSexo(SEX_Id);
        }
        
        public Sexo GetSexoById(int SEX_Id, bool join)
        {
            return _SexoRepo.GetSexoById(SEX_Id, join);
        }

        public IEnumerable<Sexo> GetAllSexo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SexoRepo.GetAllSexo(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Sexo> GetAllSexoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SexoRepo.GetAllSexoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Sexo> GetAllSexoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _SexoRepo.GetAllSexoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

