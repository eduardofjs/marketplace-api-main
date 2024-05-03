using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Pagar
{
    public class customers
    {
        public string id { get; set; }
        public string email { get; set; }//*obrigatorio para cadastro
        public string name { get; set; }//*obrigatorio para cadastro
        public string document { get; set; }//*obrigatorio para cadastro - CPF, CNPJ, PASSAPORTE do cliente.
        public string document_type { get; set; } //Tipo de documento. Valores possíveis: PASSPORT , CPF, CNPJ.
        public string type { get; set; } //Tipo de cliente. Valores possíveis: individual e company. Na documentacao é tipo enum
        public string gender { get; set; } //Sexo do cliente. Valores possíveis: male ou female
        public phones phones { get; set; }
        public address address { get; set; }
        public int fb_id { get; set; } //Código do cliente no Facebook.
        public string fb_access_token { get; set; } //Token de acesso do Facebook. Usado para fazer chamadas da GraphAPI e obter informações do usuário.
        public bool delinquent { get; set; } //Indica se o cliente está inadimplente.
        public string code { get; set; } //Código de referência do cliente no sistema da loja.
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime birthdate { get; set; }
        public metadata metadata { get; set; }
        public List<object> custom_variables { get; set; }
    }

    public class address
    {
        public string id { get; set; } //Código do endereço. Formato: addr_XXXXXXXXXXXXXXXX
        public string line_1 { get; set; } //Dados principais do endereço. Neste campo deve ser informado Número, Rua, Bairro, nesta ordem e separados por vírgula.
        public string line_2 { get; set; } //Dados complementares do endereço. Neste campo pode ser informado complemento, referências.
        public string zip_code { get; set; } //CEP
        public string city { get; set; } 
        public string state { get; set; }
        public string country { get; set; }
        public string status { get; set; } //Status do endereço. Valores possíveis: active ou deleted -- Documentacao é tipo enum
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deleted_at { get; set; }
        public customers customer { get; set; }
        public metadata metadata { get; set; }
    }

    public class metadata
    {
        public string campo1 { get; set; }
        public string campo2 { get; set; }
    }

    public class phones
    {
        public home_phone home_phone { get; set; }
        public mobile_phone mobile_phone { get; set; }
    }

    public class home_phone
    {
        public string country_code { get; set; } //Código do País (Apenas numérico). -- Ex: 55
        public string area_code { get; set; } //Código da área (Apenas numérico). --Ex: 21
        public string number { get; set; } //Número do telefone (Apenas numérico). --Ex: 000000000
    }

    public class mobile_phone
    {
        public string country_code { get; set; } //Código do País (Apenas numérico). -- Ex: 55
        public string area_code { get; set; } //Código da área (Apenas numérico). --Ex: 21
        public string number { get; set; } //Número do telefone (Apenas numérico). --Ex: 000000000
    }

    public class customers_creditCard
    {
        public int IdPatient { get; set; }//*obrigatorio para cadastro
        public string email { get; set; }//*obrigatorio para cadastro
        public string name { get; set; }//*obrigatorio para cadastro
        public string notes { get; set; }
        public string cpf_cnpj { get; set; }//*obrigatorio para cadastro 
        public string phone { get; set; }//*obrigatorio para cadastro
        public string phone_prefix { get; set; }

        public string brand { get; set; }
        public string nameCard { get; set; }
        public string numberCard { get; set; }
        public string verification_value { get; set; }
        public int month { get; set; }
        public int year { get; set; }

    }


}
