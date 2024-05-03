
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IServicoOpcionalAppServices
    {
        ServicoOpcional InsertServicoOpcional(ServicoOpcional objServicoOpcional);
        bool UpdateServicoOpcional(ServicoOpcional objServicoOpcional);
        bool AtivarServicoOpcional(int SEO_Id);
        bool DeletarServicoOpcional(int SEO_Id);
        ServicoOpcional GetServicoOpcionalById(int SEO_Id, bool join);
        IEnumerable<ServicoOpcional> GetAllServicoOpcional(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ServicoOpcional> GetAllServicoOpcionalByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<ServicoOpcional> GetAllServicoOpcionalByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
