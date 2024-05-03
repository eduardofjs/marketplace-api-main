
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IMeioTransporteServices
    {
        MeioTransporte InsertMeioTransporte(MeioTransporte objMeioTransporte);
        bool UpdateMeioTransporte(MeioTransporte objMeioTransporte);
        bool AtivarMeioTransporte(int MTR_Id);
        bool DeletarMeioTransporte(int MTR_Id);
        MeioTransporte GetMeioTransporteById(int MTR_Id, bool join);
        IEnumerable<MeioTransporte> GetAllMeioTransporte(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<MeioTransporte> GetAllMeioTransporteByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<MeioTransporte> GetAllMeioTransporteByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
