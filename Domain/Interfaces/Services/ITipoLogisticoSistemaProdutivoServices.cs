
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface ITipoLogisticoSistemaProdutivoServices
    {
        TipoLogisticoSistemaProdutivo InsertTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo);
        bool UpdateTipoLogisticoSistemaProdutivo(TipoLogisticoSistemaProdutivo objTipoLogisticoSistemaProdutivo);
        bool AtivarTipoLogisticoSistemaProdutivo(int TLS_Id);
        bool DeletarTipoLogisticoSistemaProdutivo(int TLS_Id);
        TipoLogisticoSistemaProdutivo GetTipoLogisticoSistemaProdutivoById(int TLS_Id, bool join);
        IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<TipoLogisticoSistemaProdutivo> GetAllTipoLogisticoSistemaProdutivoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
