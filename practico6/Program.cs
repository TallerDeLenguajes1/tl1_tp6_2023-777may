// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// int a, b;
// a = 10;
// b = a;
// Console.WriteLine("valor de a: " + a);
// Console.WriteLine("valor de b: " + b);
// // Console.Read(); int
// // Console.ReadLine(); cad
// // Console.ReadKey(); espera una tecla
// // Console.WriteLine("txt"); muestra por pantalla

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

double solicitarDouble(string txt){
    bool esNumero = false;
    double numero = 0;
    while (!esNumero){
        Console.WriteLine(txt);
        esNumero = double.TryParse(Console.ReadLine(), out numero);
    }
    return numero;
}
float solicitarFloat(string txt){
    bool esNumero = false;
    float numero = 0;
    while (!esNumero){
        Console.WriteLine(txt);
        esNumero = float.TryParse(Console.ReadLine(), out numero);
    }
    return numero;
}
double opcion=1, numero = 0, resultado = 0;
float flotante = 0;

while(opcion > 0){
    do
    {
        opcion = solicitarDouble("\nIngrese una operacion: \n  1: Valor Absoluto \n  2: Cuadrado \n  3: Raiz cuadrada \n  4: Seno \n  5: Coseno \n  6: La parte entera del numero \n  0: Salir");
    }while(opcion > 6 || opcion < 0);
    if (opcion != 0){
        if(opcion == 6){
            flotante = solicitarFloat("\nIngrese el numero a operar: \n(use \",\" para los decimales)");
            Console.WriteLine("El num es: " + flotante);
        }else{
            numero = solicitarDouble("\nIngrese el numero a operar: ");
        }

        switch(opcion){
            case 1:
                resultado = Math.Abs(numero);
                break;
            case 2:
                resultado = Math.Pow(numero, 2);
                break;
            case 3:
                resultado = Math.Sqrt(numero);
                break;
            case 4:
                numero = numero*Math.PI/180;//porque las funciones trigonométricas usan radianes
                resultado = Math.Sin(numero);
                break;
            case 5:
                numero = numero*Math.PI/180;//porque las funciones trigonométricas usan radianes
                resultado = Math.Cos(numero);
                break;
            case 6:
                resultado = Math.Round(flotante);
                break;
        }
        Console.WriteLine("\nEl resultado es: " + resultado);
    }
}
double num1 = 0, num2 = 0;
Console.WriteLine("\nIngrese dos numeros a comparar:");
num1 = solicitarDouble("\nIngrese el primer numero: ");
num2 = solicitarDouble("\nIngrese el segundo numero: ");
Console.WriteLine("\n El maximo entre num1 (" + num1 + ") y num2 (" + num2 + ") es:  " + Math.Max(num1, num2));
Console.WriteLine("\n El minimo entre num1 (" + num1 + ") y num2 (" + num2 + ") es:  " + Math.Min(num1, num2));

// //dotnet run
