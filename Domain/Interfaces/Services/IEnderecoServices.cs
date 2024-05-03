
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IEnderecoServices
    {
        Endereco InsertEndereco(Endereco objEndereco);
        bool UpdateEndereco(Endereco objEndereco);
        bool AtivarEndereco(int END_Id);
        bool DeletarEndereco(int END_Id);
        Endereco GetEnderecoById(int END_Id, bool join);
        IEnumerable<Endereco> GetAllEndereco(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Endereco> GetAllEnderecoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Endereco> GetAllEnderecoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
