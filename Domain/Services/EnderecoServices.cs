
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        private readonly IEnderecoRepository _EnderecoRepo;

        public EnderecoServices(IEnderecoRepository EnderecoRepo)
        {
            _EnderecoRepo = EnderecoRepo;
        }
		
        public Endereco InsertEndereco(Endereco objEndereco)
        {
            return _EnderecoRepo.InsertEndereco(objEndereco);
        }

        public bool UpdateEndereco(Endereco objEndereco)
        {
            return _EnderecoRepo.UpdateEndereco(objEndereco);
        }

        public bool AtivarEndereco(int END_Id)
        {
            return _EnderecoRepo.AtivarEndereco(END_Id);
        }

        public bool DeletarEndereco(int END_Id)
        {
            return _EnderecoRepo.DeletarEndereco(END_Id);
        }
        
        public Endereco GetEnderecoById(int END_Id, bool join)
        {
            return _EnderecoRepo.GetEnderecoById(END_Id, join);
        }

        public IEnumerable<Endereco> GetAllEndereco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EnderecoRepo.GetAllEndereco(fVerTodos, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Endereco> GetAllEnderecoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EnderecoRepo.GetAllEnderecoByPartial(strPartial, ColunaParaPartial, fSomenteAtivos, join, maxInstances, order_by);
        }

        public IEnumerable<Endereco> GetAllEnderecoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "")
        {
            return _EnderecoRepo.GetAllEnderecoByValorExato(strValorExato, ColunaParaValorExato, fSomenteAtivos, join, maxInstances, order_by);
        }
    }
}

