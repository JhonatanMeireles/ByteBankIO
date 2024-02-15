using ByteBankIO;
using System.Text;

partial class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDoArquivo);
            //var linha = leitor.ReadLine();
            //var texto = leitor.ReadToEnd();
            //var numero = leitor.Read();
            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);
                var msg = $"Conta número: {contaCorrente.Numero}, agência: {contaCorrente.Agencia}, saldo: {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }


            //Console.WriteLine(numero);
        }

        Console.ReadLine();

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {

            var campos = linha.Split(',');

            var agencia = campos[0];
            var conta = campos[1];
            string saldo = campos[2].Replace('.', ',');
            var titular = campos[3];

            var agenciaComInt = int.Parse(agencia);
            var contaComInt = int.Parse(conta);
            var saldoComoDouble = double.Parse(saldo);

            var titular1 = new Cliente();
            titular1.Nome = titular;


            var resultado = new ContaCorrente(agenciaComInt, contaComInt);
            resultado.Depositar(saldoComoDouble);
            resultado.Titular = titular1;

            return resultado;
        }

       



    }

    
}