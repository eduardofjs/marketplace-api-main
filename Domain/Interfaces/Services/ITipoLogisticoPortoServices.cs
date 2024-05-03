
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface ITipoLogisticoPortoServices
    {
        TipoLogisticoPorto InsertTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto);
        bool UpdateTipoLogisticoPorto(TipoLogisticoPorto objTipoLogisticoPorto);
        bool AtivarTipoLogisticoPorto(int TLP_Id);
        bool DeletarTipoLogisticoPorto(int TLP_Id);
        TipoLogisticoPorto GetTipoLogisticoPortoById(int TLP_Id, bool join);
        IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPorto(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoLogisticoPorto> GetAllTipoLogisticoPortoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
