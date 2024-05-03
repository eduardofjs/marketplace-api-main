
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IEstadoServices
    {
        Estado InsertEstado(Estado objEstado);
        bool UpdateEstado(Estado objEstado);
        bool AtivarEstado(int ESD_Id);
        bool DeletarEstado(int ESD_Id);
        Estado GetEstadoById(int ESD_Id, bool join);
        IEnumerable<Estado> GetAllEstado(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Estado> GetAllEstadoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Estado> GetAllEstadoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
