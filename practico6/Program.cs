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
double convertirDouble(string txt){
    bool esNumero = false;
    double numero = 0;
    esNumero = double.TryParse(txt, out numero);
    return numero;
}
double resultado = 0, a = 0 , b = 0;
int indice = 0, numOpcion;
string texto = "";
string ? operacion = "1";
string[] opciones = {"abs ", "sin ", "cos ", "^2", "^1/2", "+", "-", "*", "/", "round "};
bool valido;
while(operacion == "1"){
    do{
        valido = false;
        Console.WriteLine("\nIngrese una operacion: \n(a+b; a-b; a*b; a/b; a^2; a^1/2; sin a; cos a; abs a; round a,b)");
        operacion = Console.ReadLine();
        numOpcion = -1;
        if(operacion != null){
            operacion = operacion.ToLower();
            foreach (var op in opciones){
                numOpcion ++;
                indice = operacion.IndexOf(op);
                if(indice >= 0){
                    break;
                }
            }
        // Console.WriteLine($"{operacion.Substring(0,indice)}");
        // Console.WriteLine($"{operacion.Substring(indice, 1)}");
        // Console.WriteLine($"{operacion.Substring(indice+1)}");
            if(numOpcion < 9 | operacion.IndexOf("round ") != -1){
                valido = true;
                if(numOpcion < 3){
                    a = convertirDouble(operacion.Substring(indice+4));
                    operacion = operacion.Substring(0, 4);
                }else if (numOpcion < 5){
                    a = convertirDouble(operacion.Substring(0, indice));
                    operacion = operacion.Substring(indice);
                }else if(numOpcion < 9){
                    a = convertirDouble(operacion.Substring(0, indice));
                    b = convertirDouble(operacion.Substring(indice+1));
                    operacion = operacion.Substring(indice, 1);
                }else{
                    a = convertirDouble(operacion.Substring(indice+6));
                    operacion = "round ";
                }
            }
        }
        // Console.WriteLine($"\n{a}, {b} \n{operacion}");
    }while(!valido);

    switch(operacion){
        case "+": 
            resultado = a + b;
            texto += "La suma de " + a.ToString() + " y de " + b.ToString(); 
            break;
        case "-":
            resultado = a - b;
            texto += "La resta de " + a.ToString() + " menos " + b.ToString(); 
            break;
        case "*": 
            resultado = a * b;
            texto += "El producto de " + a.ToString() + " por " + b.ToString(); 
            break;
        case "/": 
            if(b != 0){
                resultado = a/b;
            }else{
                resultado = 0;
                Console.WriteLine("\nNo se puede dividir en 0");
            }
                texto += "La division de " + a.ToString() + " en " + b.ToString(); 
            break;
        case "abs ":
            resultado = Math.Abs(a);
            texto += "El valor absoluto de " + a.ToString(); 
            break;
        case "^2":
            resultado = Math.Pow(a, 2);
            texto += a.ToString() + " al cuadrado"; 
            break;
        case "^1/2":
            resultado = Math.Sqrt(a);
            texto += "La raiz cuadrada de " + a.ToString(); 
            break;
        case "sin ":
            texto += "El seno de " + a.ToString();
            a = a*Math.PI/180;//porque las funciones trigonométricas usan radianes
            resultado = Math.Sin(a);
            break;
        case "cos ":
            texto += "El coseno de " + a.ToString(); 
            a = a*Math.PI/180;//porque las funciones trigonométricas usan radianes
            resultado = Math.Cos(a);
            break;
        case "round ":
            texto += a.ToString() + " redondeado";  
            resultado = Math.Round(a);
            break;
    }

    Console.WriteLine("\n {0} es igual a: {1} \n", texto, resultado.ToString());

    texto = "";
    do{
        Console.WriteLine("\nDesea realizar otro calculo?: \n  1: Si \n  0: No");
        operacion = Console.ReadLine();
    }while(operacion != "1" && operacion != "0");
}

// // //dotnet run