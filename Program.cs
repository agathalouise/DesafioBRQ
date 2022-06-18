using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sua missão será criar um algoritmo para gerar um diagnóstico prévio para o programa de emagrecimento

            //Definindo as variáveis
            String nome, sexo, categoria, recomendacao, classificacao, riscos, alturaString, pesoString;
            int idade, controlador = 0, auxSexo = 0, confirmacaoDados = 0;
            double altura, peso, imc;



            // Lendo os dados do úsuario e atribuindo as variaveis

            //Do While para perguntar para o usuario se ele deseja gerar um novo diagnostico após o resultado do diagnostico atual. 
            do
            {

                // do-while para imprimir e confirmar os dados do usuário no final
                do
                {

                    // Lendo o Nome
                    do
                    {
                        Console.WriteLine("\nDigite o nome do(a) paciente:");
                        nome = Console.ReadLine();

                        //retirando os caracteres especiais da String, se houver:
                        Regex rsx = new Regex(@"[^a-zA-Záéíóúàèìòùâêîôûãõç\s]"); //Regra para só aceitar letras minusculas e maiusculas e letras com acento.
                        nome = rsx.Replace(nome, "");

                        //verificando se o nome está em branco
                        if (nome == "")
                        {
                            Console.WriteLine("Nome inválido, digite novamente\n");
                        }

                    } while (nome == "");


                    // Lendo o Sexo
                    do
                    {
                        Console.WriteLine("Digite o Sexo do(a) paciente (Feminino ou Masculino):");
                        sexo = Console.ReadLine();


                        //Vamos aceitar somente as palavras: feminino ou Feminino, Masculino ou masculino.
                        if ((sexo == "Feminino") || (sexo == "feminino") || (sexo == "Masculino") || (sexo == "masculino"))
                        {
                            auxSexo = 1;
                        }
                        else
                        {

                            Console.WriteLine("Sexo inválido, digite novamente\n");
                        }
                    } while (auxSexo != 1);


                    // Lendo a Idade
                    do
                    {
                        Console.WriteLine("Digite a idade do(a) paciente em anos:");
                        idade = int.Parse(Console.ReadLine());


                        //Vamos aceitar somente um valor positivo e menor que 135.
                        if (idade < 0 || idade > 135)
                        {
                            Console.WriteLine("Idade inválida, digite novamente\n");
                        }

                    } while (idade < 0 || idade > 140);


                    // Lendo a altura
                    do
                    {
                        Console.WriteLine("Digite a altura do(a) paciente (ex: 1,60):");
                        alturaString = (Console.ReadLine());

                        //Caso o usuário digite um numero com um ponto, vamos substituir por virgula:
                        alturaString = alturaString.Replace('.', ',');
                        altura = double.Parse(alturaString);

                        //Verificando se a altura é valida (Valor positivo e menor que 3 metros)
                        if (altura < 0 || altura >= 3)
                        {
                            Console.WriteLine("Altura inválida, digite novamente\n");
                        }

                    } while (altura < 0 || altura >= 3);


                    // Lendo o Peso
                    do
                    {
                        Console.WriteLine("Digite o peso do(a) paciente (ex: 80,2):");
                        pesoString = Console.ReadLine();

                        //Caso o usuário digite um numero com um ponto, vamos substituir por virgula:
                        pesoString = pesoString.Replace('.', ',');
                        peso = double.Parse(pesoString);

                        //Verificando se o peso é valido (Valor positivo e menor que 620 Kgs)
                        if (peso < 0 || peso > 620)
                        {
                            Console.WriteLine("Peso inválido, digite novamente\n");
                        }

                    } while (peso < 0 || peso > 620);



                    // saída de dados para o Usuario confirmar:
                    Console.WriteLine("---------- Confirmação de Dados --------------\n");
                    Console.WriteLine($"Nome: {nome}");
                    Console.WriteLine($"Sexo: {sexo}");
                    Console.WriteLine($"Idade: {idade}");
                    Console.WriteLine($"Altura: {altura}");
                    Console.WriteLine($"Peso: {peso}\n");
                    Console.WriteLine("Para corrigir os dados digite 0 (Zero), para prosseguir digite qualquer número inteiro diferente que 0\n");
                    confirmacaoDados = int.Parse(Console.ReadLine());

                } while (confirmacaoDados == 0);


                //Chamando as funçoes para gerar o Diagnostico do (a) paciente.
                imc = CalcularIMC(peso, altura);
                categoria = VerificarCategoria(idade);
                recomendacao = VerificarRecomendacao(peso, altura);
                classificacao = VerificarClassificacao(peso, altura);
                riscos = VerificarRiscos(peso, altura);


                //saída de dados formatada:
                Console.WriteLine("--------------DIAGNÓSTICO PRÉVIO -------------- \n");
                Console.WriteLine($"Nome: {nome}");
                Console.WriteLine($"Sexo: {sexo}");
                Console.WriteLine($"Idade: {idade}");
                Console.WriteLine($"Altura: {altura}");
                Console.WriteLine($"Peso: {peso}");
                Console.WriteLine($"Categoria: {categoria}\n");

                Console.WriteLine($"IMC Desejável: entre 20 e 24\n");

                Console.WriteLine($"Resultado IMC: {imc.ToString("F")}\n"); //Formatando a saida do Imc p/ mostrar apenas duas casas decimais com o to.String
                Console.WriteLine($"Sua Classificação do IMC: {classificacao}\n");

                Console.WriteLine($"Riscos: {riscos} \n");
                Console.WriteLine($"Recomendação Inicial: {recomendacao} \n");

                //Controle do laço de repetição
                Console.WriteLine("Digite 1 para gerar o diagnostico de outro paciente, ou qualquer outro numero inteiro para finalizar o programa:");
                controlador = int.Parse(Console.ReadLine());

            } while (controlador == 1);



            //------- Vou dividir o programa em funcões, cada função ficará responsalvel por uma parte do diagnóstico. -------------

            // ------ Criando função que calcula o IMC --------
            static double CalcularIMC(double peso, double altura)
            {
                double imc;
                //formula do calculo do imc
                return imc = peso / (altura * altura);

            }



            /*  ----- Criando função para verificar a categoria ------
            * IDADE CATEGORIA
            * Abaixo de 12 anos Infantil
            * De 12 a 20 anos Juvenil
            * De 21 a 65 anos Adulto
            * Acima de 65 anos Idoso */



            static String VerificarCategoria(int idade)
            {
                String categoria;

                if (idade < 12)
                {
                    categoria = "Infantil";
                }
                else if (idade < 21)
                {
                    categoria = "Juvenil";
                }
                else if (idade <= 65)
                {
                    categoria = "Adulto";
                }
                else
                {
                    categoria = "Idoso";
                }

                return categoria;
            }


            //------- Criando uma função que define a Classificação do IMC --------
            static String VerificarClassificacao(double peso, double altura)
            {
                double imc = CalcularIMC(peso, altura);
                String classificacao;

                if (imc < 20)
                {
                    classificacao = "Abaixo do peso ideal";
                }
                else if (imc < 25)
                {
                    classificacao = "Peso normal";
                }
                else if (imc < 30)
                {
                    classificacao = "Excesso de Peso";
                }
                else if (imc <= 35)
                {
                    classificacao = "Obesidade";
                }
                else
                {
                    classificacao = "Super Obesidade";
                }

                return classificacao;
            }


            // --------- Criando uma função que verifica os riscos de acordo com o IMC ------------
            static String VerificarRiscos(double peso, double altura)
            {
                double imc = CalcularIMC(peso, altura);
                String riscos;

                if (imc < 20)
                {
                    riscos = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.";
                }
                else if (imc < 25)
                {
                    riscos = "Seu peso está ideal para suas referências.";
                }
                else if (imc < 30)
                {
                    riscos = "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.";
                }
                else if (imc <= 35)
                {
                    riscos = "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.";
                }
                else
                {
                    riscos = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
                }

                return riscos;
            }



            // --------- Criando uma função que define a Recomendação do IMC ------------
            static String VerificarRecomendacao(double peso, double altura)
            {
                double imc = CalcularIMC(peso, altura);
                String recomencadao;

                if (imc < 20)
                {
                    recomencadao = "Inclua carboidratos simples em sua dieta, além de proteínas indispensáveis para ganho de massa magra. Procure um profissional.";
                }
                else if (imc < 25)
                {
                    recomencadao = "Mantenha uma dieta saudável e faça seus exames periódicos.";
                }
                else if (imc < 30)
                {
                    recomencadao = "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante.";
                }
                else if (imc <= 35)
                {
                    recomencadao = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista (endócrino).";
                }
                else
                {
                    recomencadao = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista(endócrino)";
                }

                return recomencadao;
            }


        }
    }
}
