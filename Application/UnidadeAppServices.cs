
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class UnidadeAppServices : IUnidadeAppServices
    {
        private readonly IUnidadeServices _UnidadeServices;
            private readonly IEnderecoServices _EnderecoServices;
               

        public UnidadeAppServices(IUnidadeServices UnidadeServices     , IEnderecoServices EnderecoServices       )
        {
            _UnidadeServices = UnidadeServices;
                _EnderecoServices = EnderecoServices;
                 
        }

        public Unidade InsertUnidade(Unidade objUnidade)
        {
                if (objUnidade.Endereco != null)
            {
                objUnidade.Endereco = _EnderecoServices.InsertEndereco(objUnidade.Endereco);
                objUnidade.UNI_EnderecoId = objUnidade.Endereco.END_Id;
            }
                   
            
            return _UnidadeServices.InsertUnidade(objUnidade);
        }

        public bool UpdateUnidade(Unidade objUnidade)
        {            
                if (objUnidade.Endereco != null)
            {
                if (objUnidade.Endereco.END_Id == 0)
                {
                    objUnidade.Endereco = _EnderecoServices.InsertEndereco(objUnidade.Endereco);
                    objUnidade.UNI_EnderecoId = objUnidade.Endereco.END_Id;
                }
                else
                {
                    bool flagEndereco = _EnderecoServices.UpdateEndereco(objUnidade.Endereco);
                }
            }
                  
            return _UnidadeServices.UpdateUnidade(objUnidade);
        }

        public bool AtivarUnidade(int UNI_Id)
        {
            return _UnidadeServices.AtivarUnidade(UNI_Id);
        }

        public bool DeletarUnidade(int UNI_Id)
        {
            return _UnidadeServices.DeletarUnidade(UNI_Id);
        }

        public Unidade GetUnidadeById(int UNI_Id, bool join)
        {
            return _UnidadeServices.GetUnidadeById(UNI_Id, join);
        }

        public IEnumerable<Unidade> GetAllUnidade(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadeServices.GetAllUnidade(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Unidade> GetAllUnidadeByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadeServices.GetAllUnidadeByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Unidade> GetAllUnidadeByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _UnidadeServices.GetAllUnidadeByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

