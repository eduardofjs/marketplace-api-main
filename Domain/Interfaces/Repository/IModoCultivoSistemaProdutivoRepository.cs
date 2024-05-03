using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IModoCultivoSistemaProdutivoRepository
    {
        ModoCultivoSistemaProdutivo InsertModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo);
        bool UpdateModoCultivoSistemaProdutivo(ModoCultivoSistemaProdutivo objModoCultivoSistemaProdutivo);
        bool AtivarModoCultivoSistemaProdutivo(int MCS_Id);
        bool DeletarModoCultivoSistemaProdutivo(int MCS_Id);
        ModoCultivoSistemaProdutivo GetModoCultivoSistemaProdutivoById(int MCS_Id, bool join);
        IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ModoCultivoSistemaProdutivo> GetAllModoCultivoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");

    }
}
