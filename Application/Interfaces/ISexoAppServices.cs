
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface ISexoAppServices
    {
        Sexo InsertSexo(Sexo objSexo);
        bool UpdateSexo(Sexo objSexo);
        bool AtivarSexo(int SEX_Id);
        bool DeletarSexo(int SEX_Id);
        Sexo GetSexoById(int SEX_Id, bool join);
        IEnumerable<Sexo> GetAllSexo(bool fVerTodos, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Sexo> GetAllSexoByPartial(string strPartial, string ColunaParaPartial, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
        IEnumerable<Sexo> GetAllSexoByValorExato(string strValorExato, string ColunaParaValorExato, bool fSomenteAtivos, bool join, int maxInstances = 0, string order_by = "");
    }
}
