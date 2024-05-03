
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class CidadeAppServices : ICidadeAppServices
    {
        private readonly ICidadeServices _CidadeServices;
          private readonly IEstadoServices _EstadoServices;
              

        public CidadeAppServices(ICidadeServices CidadeServices   , IEstadoServices EstadoServices      )
        {
            _CidadeServices = CidadeServices;
              _EstadoServices = EstadoServices;
                
        }

        public Cidade InsertCidade(Cidade objCidade)
        {
              if (objCidade.Estado != null)
            {
                objCidade.Estado = _EstadoServices.InsertEstado(objCidade.Estado);
                objCidade.CDD_EstadoId = objCidade.Estado.ESD_Id;
            }
                  
            
            return _CidadeServices.InsertCidade(objCidade);
        }

        public bool UpdateCidade(Cidade objCidade)
        {            
              if (objCidade.Estado != null)
            {
                if (objCidade.Estado.ESD_Id == 0)
                {
                    objCidade.Estado = _EstadoServices.InsertEstado(objCidade.Estado);
                    objCidade.CDD_EstadoId = objCidade.Estado.ESD_Id;
                }
                else
                {
                    bool flagEstado = _EstadoServices.UpdateEstado(objCidade.Estado);
                }
            }
                 
            return _CidadeServices.UpdateCidade(objCidade);
        }

        public bool AtivarCidade(int CDD_Id)
        {
            return _CidadeServices.AtivarCidade(CDD_Id);
        }

        public bool DeletarCidade(int CDD_Id)
        {
            return _CidadeServices.DeletarCidade(CDD_Id);
        }

        public Cidade GetCidadeById(int CDD_Id, bool join)
        {
            return _CidadeServices.GetCidadeById(CDD_Id, join);
        }

        public IEnumerable<Cidade> GetAllCidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CidadeServices.GetAllCidade(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Cidade> GetAllCidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CidadeServices.GetAllCidadeByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Cidade> GetAllCidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _CidadeServices.GetAllCidadeByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

