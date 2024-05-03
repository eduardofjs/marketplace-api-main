
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class PessoaAppServices : IPessoaAppServices
    {
        private readonly IPessoaServices _PessoaServices;
        private readonly ISexoServices _SexoServices;
        private readonly IEnderecoServices _EnderecoServices;
        private readonly IPronomeTratamentoServices _PronomeTratamentoServices;


        public PessoaAppServices(IPessoaServices PessoaServices, ISexoServices SexoServices, IEnderecoServices EnderecoServices, IPronomeTratamentoServices PronomeTratamentoServices)
        {
            _PessoaServices = PessoaServices;
            _SexoServices = SexoServices;
            _EnderecoServices = EnderecoServices;
            _PronomeTratamentoServices = PronomeTratamentoServices;

        }

        public Pessoa InsertPessoa(Pessoa objPessoa)
        {
            if (objPessoa.Sexo != null)
            {
                objPessoa.Sexo = _SexoServices.InsertSexo(objPessoa.Sexo);
                objPessoa.PES_SexoId = objPessoa.Sexo.SEX_Id;
            }
            if (objPessoa.Endereco != null)
            {
                objPessoa.Endereco = _EnderecoServices.InsertEndereco(objPessoa.Endereco);
                objPessoa.PES_EnderecoId = objPessoa.Endereco.END_Id;
            }
            if (objPessoa.PronomeTratamento != null)
            {
                objPessoa.PronomeTratamento = _PronomeTratamentoServices.InsertPronomeTratamento(objPessoa.PronomeTratamento);
                objPessoa.PES_PronomeTratamentoId = objPessoa.PronomeTratamento.PRT_Id;
            }


            return _PessoaServices.InsertPessoa(objPessoa);
        }

        public bool UpdatePessoa(Pessoa objPessoa)
        {
            if (objPessoa.Sexo != null)
            {
                if (objPessoa.Sexo.SEX_Id == 0)
                {
                    objPessoa.Sexo = _SexoServices.InsertSexo(objPessoa.Sexo);
                    objPessoa.PES_SexoId = objPessoa.Sexo.SEX_Id;
                }
                else
                {
                    bool flagSexo = _SexoServices.UpdateSexo(objPessoa.Sexo);
                }
            }
            if (objPessoa.Endereco != null)
            {
                if (objPessoa.Endereco.END_Id == 0)
                {
                    objPessoa.Endereco = _EnderecoServices.InsertEndereco(objPessoa.Endereco);
                    objPessoa.PES_EnderecoId = objPessoa.Endereco.END_Id;
                }
                else
                {
                    bool flagEndereco = _EnderecoServices.UpdateEndereco(objPessoa.Endereco);
                }
            }
            if (objPessoa.PronomeTratamento != null)
            {
                if (objPessoa.PronomeTratamento.PRT_Id == 0)
                {
                    objPessoa.PronomeTratamento = _PronomeTratamentoServices.InsertPronomeTratamento(objPessoa.PronomeTratamento);
                    objPessoa.PES_PronomeTratamentoId = objPessoa.PronomeTratamento.PRT_Id;
                }
                else
                {
                    bool flagPronomeTratamento = _PronomeTratamentoServices.UpdatePronomeTratamento(objPessoa.PronomeTratamento);
                }
            }

            return _PessoaServices.UpdatePessoa(objPessoa);
        }

        public bool AtivarPessoa(int PES_Id)
        {
            return _PessoaServices.AtivarPessoa(PES_Id);
        }

        public bool DeletarPessoa(int PES_Id)
        {
            return _PessoaServices.DeletarPessoa(PES_Id);
        }

        public Pessoa GetPessoaById(int PES_Id, bool join)
        {
            return _PessoaServices.GetPessoaById(PES_Id, join);
        }

        public IEnumerable<Pessoa> GetAllPessoa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PessoaServices.GetAllPessoa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Pessoa> GetAllPessoaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PessoaServices.GetAllPessoaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Pessoa> GetAllPessoaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PessoaServices.GetAllPessoaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

