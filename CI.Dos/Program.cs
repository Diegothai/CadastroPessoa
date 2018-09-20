using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {

            var contexto = new Contexto();

            Console.Write("Digite seu Nome ");
            string nome = Console.ReadLine();

            Console.Write("Digite a data de nascimento ");
            string data = Console.ReadLine();

            Console.Write("Digite o número do RG ");
            string rg = Console.ReadLine();

            Console.Write("Digite o cnpj de sua Empresa ");
            string cnpj = Console.ReadLine();

            Console.Write("Digite o Endereço ");
            string endereco = Console.ReadLine();

            string strQueryInsert = string.Format("INSERT INTO Pessoa (Nome, DataNascimento, Num_rg, Num_cnpj, Endereco) VALUES ('{0}','{1}','{2}','{3}','{4}')",
                nome, data, rg, cnpj, endereco);

            contexto.ExecutaComando(strQueryInsert);

            string strQuerySelect = "SELECT * FROM PESSOA";

            SqlDataReader dados = contexto.ExecuteComandoComRetorno(strQuerySelect);


            while (dados.Read())
            {
                Console.WriteLine("Id: {0}, Nome: {1}, DataNascimento {2}, Num_rg {3}, Num_cnpj {4}, Endereco {5}", dados["PessoaId"], dados["Nome"], dados["DataNascimento"], dados["Num_rg"], dados["Num_cnpj"], dados["Endereco"]);
            }


        }
    }
}
