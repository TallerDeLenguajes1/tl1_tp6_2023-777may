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

bool solicitarNumero(double numero){
    return double.TryParse(Console.ReadLine(), out numero);
}

int opcion=1;
double numero = 0, resultado = 0;

// while(opcion > 0){
    bool esOpcion = false, esNumero = false;

    Console.WriteLine("Ingrese un num: ");
    esNumero = solicitarNumero(&numero);
    Console.WriteLine("El num es: " + numero);

    // while(!esOpcion || opcion > 6 || opcion < 1){
    //     if (opcion != 1){
    //         Console.WriteLine("\nHa ingresado un valor incorrecto");
    //     }
//         Console.WriteLine("\nIngrese una operacion: \n  1: Valor Absoluto \n  2: Cuadrado \n  3: Raiz cuadrada \n  4: Seno \n  5: Coseno \n  6: La parte entera del numero");
//         esOpcion = solicitarNumero(opcion);
//     }
//     while(!esNumero){
//         Console.WriteLine("\nIngrese el numero a operar: ");
//         esNumero = solicitarNumero(numero);
//     }

//     switch(opcion){
//         case 1:
//             resultado = Math.Abs(numero);
//             break;
//         case 2:
//             resultado = Math.Pow(numero, 2);
//             break;
//         case 3:
//             resultado = Math.Sqrt(numero);
//             break;
//         case 4:
//             numero = numero*Math.PI/180;//porque las funciones trigonométricas usan radianes
//             resultado = Math.Sin(numero);
//             break;
//         case 5:
//             numero = numero*Math.PI/180;//porque las funciones trigonométricas usan radianes
//             resultado = Math.Cos(numero);
//             break;
//         case 6:
//             resultado = Math.Round(numero);
//             break;
//     }
//     Console.WriteLine("\nEl resultado es: " + resultado);
// }

// solicite dos números al usuario y determine:
// ● El Máximo entre los dos números
// ● El Mínimo entre los dos números
// //dotnet run
