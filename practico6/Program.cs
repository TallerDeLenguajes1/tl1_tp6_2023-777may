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

double opcion = 1, resultado = 0, a = 0 , b = 0;
float flotante = 0;

while(opcion == 1){
    do{
        opcion = solicitarDouble("\nIngrese una opción: \n  1: Suma \n  2: Resta \n  3: Multiplicacion \n  4: Division \n  5: Valor Absoluto \n  6: Cuadrado \n  7: Raiz cuadrada \n  8: Seno \n  9: Coseno \n  10: La parte entera del numero");
    }while(opcion > 10 || opcion < 1);

    if(opcion < 5){
        a = solicitarDouble("\nIngrese el 1er numero: ");
        b = solicitarDouble("\nIngrese el 2do numero: ");
    }else if (opcion == 10){
        flotante = solicitarFloat("\nIngrese el numero a operar: \n(use \",\" para los decimales)");
    }else{
        a = solicitarDouble("\nIngrese el numero a operar: ");
    }

    switch(opcion){
        case 1: 
            resultado = a + b;
            break;
        case 2:
            resultado = a - b;
            break;
        case 3: 
            resultado = a * b;
            break;
        case 4: 
            if(b != 0){
                resultado = a/b;
            }else{
                resultado = 0;
                Console.WriteLine("\nNo se puede dividir en 0");
            }
            break;
        case 5:
            resultado = Math.Abs(a);
            break;
        case 6:
            resultado = Math.Pow(a, 2);
            break;
        case 7:
            resultado = Math.Sqrt(a);
            break;
        case 8:
            a = a*Math.PI/180;//porque las funciones trigonométricas usan radianes
            resultado = Math.Sin(a);
            break;
        case 9:
            a = a*Math.PI/180;//porque las funciones trigonométricas usan radianes
            resultado = Math.Cos(a);
            break;
        case 10:
            resultado = Math.Round(flotante);
            break;
    }
    Console.WriteLine("\nEl resultado es: " + resultado + "\n");

    do{
        opcion = solicitarDouble("\nDesea realizar otro calculo?: \n  1:Si \n  0: No");
    }while(opcion != 1 && opcion != 0);
}

Console.WriteLine("\nIngrese dos numeros a comparar:");
a = solicitarDouble("\nIngrese el primer numero: ");
b = solicitarDouble("\nIngrese el segundo numero: ");
Console.WriteLine("\n El maximo entre el 1er numero (" + a + ") y 2do numero (" + b + ") es:  " + Math.Max(a, b));
Console.WriteLine("\n El minimo entre el 1er numero (" + a + ") y 2do numero (" + b + ") es:  " + Math.Min(a, b));

// //dotnet run