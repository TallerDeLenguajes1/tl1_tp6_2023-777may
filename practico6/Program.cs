﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int a, b;
a = 10;
b = a;
Console.WriteLine("valor de a: " + a);
Console.WriteLine("valor de b: " + b);
// Console.Read(); int
// Console.ReadLine(); cad
// Console.ReadKey(); espera una tecla
// Console.WriteLine("txt"); muestra por pantalla

int x, aux = 0;
Console.WriteLine("Ingrese un numero a invertir: ");
bool control = int.TryParse(Console.ReadLine(), out x);
if (control){
    Console.WriteLine("Valor a invertir: " + x);
    while (x>0){
        aux += x%10;
        x /= 10;
        aux *= 10;
    }
    aux /= 10;
    Console.WriteLine("Valor invertido: " + aux);
}else{
    Console.WriteLine("No ha ingresado un num");
}


