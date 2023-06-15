// See https://aka.ms/new-console-template for more information
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


// int x, aux = 0;
// Console.WriteLine("Ingrese un numero a invertir: ");
// bool control = int.TryParse(Console.ReadLine(), out x);
// if (control){
//     Console.WriteLine("Valor a invertir: " + x);
//     while (x>0){
//         aux += x%10;
//         x /= 10;
//         aux *= 10;
//     }
//     aux /= 10;
//     Console.WriteLine("Valor invertido: " + aux);
// }else{
//     Console.WriteLine("No ha ingresado un num");
// }

string  texto1, texto2, texto3;
string[] separados;
Console.WriteLine("Ingrese una oracion: \n");
texto1 = txtNoNulo();
Console.WriteLine($"La longitud de la oracion {texto1} es: {(texto1 != null ? texto1.Length : 0)}.\n");
Console.WriteLine("Ingrese otra oracion: \n");
texto2 = txtNoNulo();

texto1 += texto2;
Console.WriteLine($"La nueva cadena es: {texto1}.\n");

texto3 = texto2.Substring(3);
Console.WriteLine($"SubString texto1 desde posicion 2 a 5: {texto1.Substring(2,5)}\n SubString texto2 a partir de posicion 3: {texto3}\n");

Console.WriteLine($"Recorriendo {texto1} con foreach\n");
foreach (var caracter in texto1)
{
    Console.WriteLine(caracter + " ");
}

Console.WriteLine($"\nIngrese un texto a buscar en {texto1}: ");
texto2 = txtNoNulo();
Console.WriteLine($"Existe {texto2} en {texto1}? \n   {(texto1.IndexOf(texto2) > -1 ? "Si" : "No")}\n");

Console.WriteLine($"Mayusculas: {texto1.ToUpper()} , minusculas: {texto1.ToLower()}\n");

Console.WriteLine("Ingrese una oracion con \"-\" a separar: \n");
texto3 = txtNoNulo();
Console.WriteLine("Texto separado: \n");
separados = texto3.Split('-');
foreach (var txt in separados){
    Console.WriteLine( txt + " ");
}

//----------------------------------------------------
//COMO NO ENTIENDO LA CONSIGNA, TODOS LOS EJERCICIOS DE TEXTO CON CALCULADORA LO HARE EN CalculadoraV3 
//----------------------------------------------------



string txtNoNulo(){
    string? aux;
    aux = Console.ReadLine();
    return ( aux != null ? aux : "");
}
