
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class EnderecoAppServices : IEnderecoAppServices
    {
        private readonly IEnderecoServices _EnderecoServices;
                private readonly ICidadeServices _CidadeServices;
        private readonly IEstadoServices _EstadoServices;
               

        public EnderecoAppServices(IEnderecoServices EnderecoServices         , ICidadeServices CidadeServices, IEstadoServices EstadoServices       )
        {
            _EnderecoServices = EnderecoServices;
                    _CidadeServices = CidadeServices;
            _EstadoServices = EstadoServices;
                 
        }

        public Endereco InsertEndereco(Endereco objEndereco)
        {
                    if (objEndereco.Cidade != null)
            {
                objEndereco.Cidade = _CidadeServices.InsertCidade(objEndereco.Cidade);
                objEndereco.END_CidadeId = objEndereco.Cidade.CDD_Id;
            }
            if (objEndereco.Estado != null)
            {
                objEndereco.Estado = _EstadoServices.InsertEstado(objEndereco.Estado);
                objEndereco.END_EstadoId = objEndereco.Estado.ESD_Id;
            }
                   
            
            return _EnderecoServices.InsertEndereco(objEndereco);
        }

        public bool UpdateEndereco(Endereco objEndereco)
        {            
                    if (objEndereco.Cidade != null)
            {
                if (objEndereco.Cidade.CDD_Id == 0)
                {
                    objEndereco.Cidade = _CidadeServices.InsertCidade(objEndereco.Cidade);
                    objEndereco.END_CidadeId = objEndereco.Cidade.CDD_Id;
                }
                else
                {
                    bool flagCidade = _CidadeServices.UpdateCidade(objEndereco.Cidade);
                }
            }
            if (objEndereco.Estado != null)
            {
                if (objEndereco.Estado.ESD_Id == 0)
                {
                    objEndereco.Estado = _EstadoServices.InsertEstado(objEndereco.Estado);
                    objEndereco.END_EstadoId = objEndereco.Estado.ESD_Id;
                }
                else
                {
                    bool flagEstado = _EstadoServices.UpdateEstado(objEndereco.Estado);
                }
            }
                  
            return _EnderecoServices.UpdateEndereco(objEndereco);
        }

        public bool AtivarEndereco(int END_Id)
        {
            return _EnderecoServices.AtivarEndereco(END_Id);
        }

        public bool DeletarEndereco(int END_Id)
        {
            return _EnderecoServices.DeletarEndereco(END_Id);
        }

        public Endereco GetEnderecoById(int END_Id, bool join)
        {
            return _EnderecoServices.GetEnderecoById(END_Id, join);
        }

        public IEnumerable<Endereco> GetAllEndereco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EnderecoServices.GetAllEndereco(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Endereco> GetAllEnderecoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EnderecoServices.GetAllEnderecoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Endereco> GetAllEnderecoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EnderecoServices.GetAllEnderecoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

