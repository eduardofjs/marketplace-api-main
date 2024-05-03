
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IPessoaRepository _PessoaRepo;

        public PessoaServices(IPessoaRepository PessoaRepo)
        {
            _PessoaRepo = PessoaRepo;
        }
		
        public Pessoa InsertPessoa(Pessoa objPessoa)
        {
            return _PessoaRepo.InsertPessoa(objPessoa);
        }

        public bool UpdatePessoa(Pessoa objPessoa)
        {
            return _PessoaRepo.UpdatePessoa(objPessoa);
        }

        public bool AtivarPessoa(int PES_Id)
        {
            return _PessoaRepo.AtivarPessoa(PES_Id);
        }

        public bool DeletarPessoa(int PES_Id)
        {
            return _PessoaRepo.DeletarPessoa(PES_Id);
        }
        
        public Pessoa GetPessoaById(int PES_Id, bool join)
        {
            return _PessoaRepo.GetPessoaById(PES_Id, join);
        }

        public IEnumerable<Pessoa> GetAllPessoa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PessoaRepo.GetAllPessoa(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Pessoa> GetAllPessoaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PessoaRepo.GetAllPessoaByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Pessoa> GetAllPessoaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _PessoaRepo.GetAllPessoaByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

