using System;
using System.Collections.Generic;
using System.Linq.Expressions;



//void Menu()

Console.WriteLine("Salve cachorra");
    Console.Write("\nDigite o nome do seu personagem: ");
    string nomeDoPersonagem = Console.ReadLine()!;
Console.Write("\nDigite a vida do seu personagem: ");
    uint vidaDoPersonagem = uint.Parse(Console.ReadLine()!);
    Console.Write("\nDigite a energia do seu personagem: ");
    uint energiaDoPersonagem = uint.Parse(Console.ReadLine()!);



Dictionary<string, uint> atributosTotais = new Dictionary<string, uint>();
atributosTotais.Add("vidaDoPersonagem", vidaDoPersonagem);
atributosTotais.Add("energiaDoPersonagem", energiaDoPersonagem);
atributosTotais.Add("EnergiaMaxima", atributosTotais["energiaDoPersonagem"]);
atributosTotais.Add("EnergiaPorTurno", atributosTotais["EnergiaMaxima"]);
bool estouroDeEnergia = false;

Interface();

void Interface()
{
    Console.Clear();
    Console.WriteLine(nomeDoPersonagem + "\n");
    Console.Write("Vida: " + vidaDoPersonagem + "             "); Console.Write("Energia: " + atributosTotais["EnergiaPorTurno"] + "\n\n\n\n");
    OpçõesInterface();


}
void OpçõesInterface()
{
    Console.WriteLine("Sistema de Turnos");

    Console.WriteLine("\nDigite 1 para tirar vida");
    Console.WriteLine("Digite 2 para tirar energia");
    Console.WriteLine("Digite 3 para finalizar turno");
    Console.WriteLine("Digite 4 para fazer um descanso longo");
    Console.WriteLine("Digite 5 para sair");

    Console.Write("\nDigite a sua opção ");
    string opçãoEscolhida = Console.ReadLine()!;
    int opçãoNumerica = int.Parse(opçãoEscolhida);


    switch (opçãoNumerica)
    {
        case 1:
            Console.WriteLine("Você escolheu a opção " + opçãoNumerica);TirarVida();
            break;
        case 2:
            Console.WriteLine("Você escolheu a opção " + opçãoNumerica);TirarEnergia();
            break;
        case 3:
            Console.WriteLine("Você escolheu a opção " + opçãoNumerica);FinalizarTurno();
            break;
        case 4:
            Console.WriteLine("Você escolheu a opção " + opçãoNumerica);DescansoLongo();
            break;
        case 5:
            Console.WriteLine("Você escolheu a opção " + opçãoNumerica); Queporratarrolando();
            break;
        default:
            Console.WriteLine("opção invalida"); OpçõesInterface();
            break;
    }
    void TirarVida()
    {
        Console.Write("Total de pontos de vida perdidos: ");
        uint vidaARetirar = uint.Parse(Console.ReadLine()!);
        if(vidaDoPersonagem <= vidaARetirar)
        {
            vidaDoPersonagem = 0;
        } else
        {
            vidaDoPersonagem -= vidaARetirar;
        }
            Interface();
    }
   void TirarEnergia()
    {
        Console.Write("Total de pontos de energia gastos: ");
        uint energiaARetirar = uint.Parse(Console.ReadLine()!);
        if (atributosTotais["EnergiaPorTurno"] <= energiaARetirar)
        {
            atributosTotais["EnergiaPorTurno"] = 0;
        }
        else
        {
            atributosTotais["EnergiaPorTurno"] -= energiaARetirar;
        }


            Interface();
    }

    void FinalizarTurno()
    {
        uint energiaPorTurno = atributosTotais["EnergiaPorTurno"];
        uint energiaMaxima = atributosTotais["EnergiaMaxima"];
        if (energiaPorTurno >= 1 && estouroDeEnergia == true)
        {
            estouroDeEnergia = false;
            atributosTotais["EnergiaPorTurno"] = energiaMaxima;
        }else if(estouroDeEnergia == true)
        {
            atributosTotais["EnergiaMaxima"] /= 2;
            atributosTotais["EnergiaPorTurno"] = energiaMaxima;
            estouroDeEnergia = false;
        }
        if (energiaPorTurno >= 1 && estouroDeEnergia == false)
        {

            atributosTotais["EnergiaPorTurno"] = energiaMaxima;
        }
        else if (estouroDeEnergia == false)
        {
            energiaMaxima /= 2;
            atributosTotais["EnergiaPorTurno"] = energiaMaxima;
            estouroDeEnergia = true;
        }        
            Console.WriteLine("Finalizando turno...");
        Thread.Sleep(1000);
        Interface();
    }
    void DescansoLongo()
    {
        uint ResetVida = atributosTotais["vidaDoPersonagem"];
        uint ResetEnergia = atributosTotais["energiaDoPersonagem"];
        Console.Clear();
        Console.WriteLine("Descansando...");
        vidaDoPersonagem = ResetVida;
        atributosTotais["EnergiaMaxima"] = ResetEnergia;
        atributosTotais["EnergiaPorTurno"] = ResetEnergia;
        Thread.Sleep(2000);
        Console.WriteLine("Descanso concluído!");
        Interface();
    }
    void Queporratarrolando()
    {
        Console.WriteLine(atributosTotais["EnergiaMaxima"]);
        Console.WriteLine(atributosTotais["EnergiaPorTurno"]);
    }

    /*void PuxarDicionario()
    {
        uint vidaMaxima = atributosTotais["vidaDoPersonagem"];
        Console.WriteLine(vidaMaxima);
    }*/
}