
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IPessoaServices
    {
        Pessoa InsertPessoa(Pessoa objPessoa);
        bool UpdatePessoa(Pessoa objPessoa);
        bool AtivarPessoa(int PES_Id);
        bool DeletarPessoa(int PES_Id);
        Pessoa GetPessoaById(int PES_Id, bool join);
        IEnumerable<Pessoa> GetAllPessoa(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Pessoa> GetAllPessoaByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Pessoa> GetAllPessoaByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
