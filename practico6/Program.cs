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

int num = 1, resultado=0, a, b;
while(num == 1){
    Console.WriteLine("\nIngrese una opción: \n  1: Suma \n  2: Resta \n  3: Multiplicacion \n  4: Division");
    bool control = int.TryParse(Console.ReadLine(), out num);
    if (control){
        Console.WriteLine("\nIngrese el 1er numero: ");
        bool controlA = int.TryParse(Console.ReadLine(), out a);
        Console.WriteLine("\nIngrese el 2do numero: ");
        bool controlB = int.TryParse(Console.ReadLine(), out b);
        if (controlA && controlB){
            switch(num){
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
            }
            Console.WriteLine("\nEl resultado es: " + resultado + "\n");
        }else{
            Console.WriteLine("\nNo ha ingresado un numero");
        }
    }else{
        Console.WriteLine("\nNo ha ingresado una opcion valida");
        num = 1;
    }
    do{
        Console.WriteLine("\nDesea realizar otro calculo?: \n  1:Si \n  0: No");
        control = int.TryParse(Console.ReadLine(), out num);
    }while(!control || num != 1 && num != 0);
}
//dotnet run