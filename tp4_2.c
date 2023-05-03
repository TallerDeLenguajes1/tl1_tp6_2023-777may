#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

struct Tarea {
    int TareaID; //Numerado en ciclo iterativo
    char *Descripcion;
    int Duracion; // entre 10 – 100
}typedef Tarea;
struct Nodo{
    Tarea T;
    Nodo *Siguiente;
}typedef Nodo;


void inicializar(Nodo ** lista);
void cargarTareas(Nodo ** lista);

void comprobarEstadoTareas(Nodo ** pendiente, Nodo ** hecho);
void mostrarAmbos(Tarea * pendiente, Tarea * hecho);
void mostrarLista(Tarea * lista, char texto[]);
void mostrarTarea(Tarea * tarea);
Tarea *BuscaTareaPorPalabra(Tarea ** pendiente, Tarea ** hecho, char * clave, int cant);
Tarea *BuscaTareaPorId(Tarea ** pendiente, Tarea ** hecho, int id, int cant);
int menu();
void freeMemoria(Tarea *** pendiente, Tarea *** hecho, int cant);



void main ()
{
    int cantidadTareas, buscado, num;
    char clave[100];

    Nodo *TareasPendientes, *TareasRealizadas;

    inicializar(&TareasPendientes);
    inicializar(&TareasRealizadas);

    cargarTareas(&TareasPendientes);

    num = menu();
    while (num != 0)
    {
        switch (num)
        {
        case 1:
            comprobarEstadoTareas(&TareasPendientes, &TareasRealizadas);
            break;
        case 2:
            mostrarAmbos(TareasPendientes, TareasRealizadas);
            break;
        case 3:
            printf("\nIngrese el ID a buscar: ");
            scanf("%d", &buscado);
            printf("\nBuscando la tarea ID \"%d\": ", buscado);
            mostrarTarea(BuscaTareaPorId(TareasPendientes, TareasRealizadas, buscado, cantidadTareas));
            break;
        case 4:
            printf("\nIngrese la palabra a buscar: ");
            scanf("%s", clave);
            printf("\n Buscando la tarea con la palabra \"%s\"", clave);
            mostrarTarea(BuscaTareaPorPalabra(TareasPendientes, TareasRealizadas, clave, cantidadTareas));
            break;
        }
        num = menu();
    }
    freeMemoria(&TareasPendientes, &TareasRealizadas, cantidadTareas);
    
}



void inicializar(Nodo **lista) 
{
    *lista = NULL;
}

void cargarTareas(Nodo ** lista)
{
    Nodo *nuevo;
    char *texto = malloc(sizeof(char)*100);
    srand(time(NULL));
    nuevo = malloc(sizeof(Nodo));
    if (!(*lista))
    {
        nuevo->T.TareaID = 0;
    }else{
        nuevo->T.TareaID = (*lista)->T.TareaID +1;
    }
    printf("\nIngrese la descripcion de la nueva tarea :");
    fflush(stdin);
    gets(texto);
    fflush(stdin);
    nuevo->T.Descripcion = malloc(sizeof(char)*(strlen(texto)+1));
    strcpy(nuevo->T.Descripcion, texto);
    nuevo->T.Duracion = 10 + rand()%91;
    nuevo->Siguiente = *lista;
    *lista = nuevo;
    free(texto);
}
void comprobarEstadoTareas(Nodo ** pendiente, Nodo ** hecho)
{
    int respuesta;
    Nodo *aux = *pendiente, *anterior = *pendiente;
    if (!*pendiente){
        printf("\n  No quedan tareas pendientes\n");
    }
    while (aux)
    {
        printf("\nHa realizado la tarea %d: \"%s\"? \n", (*pendiente)->T.TareaID, (*pendiente)->T.Duracion);
        do
        {
            printf(" 1: SI \n 0: NO \n" );
            scanf("%d", &respuesta);
        } while (respuesta!= 1 && respuesta!= 0);
        if (respuesta)
        {
            if (!aux->Siguiente)
            {
                *pendiente = aux->Siguiente;
            }else{
                anterior->Siguiente = aux->Siguiente;
            }
            aux->Siguiente = *hecho;
            *hecho = aux;
            aux = anterior->Siguiente;
        }
    }
}
void mostrarAmbos(Tarea * pendiente, Tarea * hecho)
{
    mostrarLista(hecho, "Realizadas");
    mostrarLista(pendiente, "Pendientes");
}
void mostrarLista(Tarea * lista, char texto[])
{
    printf("\n\nTareas %s: ", texto);
    if (!lista)
    {
        printf("\n    No hay tareas %s \n", texto);
    }
    while(lista)
    {
        mostrarTarea(lista);
        lista = 
    }

    
}
void mostrarTarea(Tarea * tarea)
{
    if (tarea)
    {
        printf("\n  ID: %d",tarea->TareaID);
        printf("\n  Descripcion: %s",tarea->Descripcion);
        printf("\n  Duracion: %d",tarea->Duracion);
        printf("\n---------------------------------------------------------------");
    }else{
        printf("\n    No se ha encontrado la tarea\n");
    }
}
Tarea *BuscaTareaPorPalabra(Tarea ** pendiente, Tarea ** hecho, char * clave, int cant)
{
    for (int i = 0; i < cant; i++)
    {
        if (pendiente[i] && strstr(pendiente[i]->Descripcion, clave))
        {
            return pendiente[i];
        }
        if (hecho[i] && strstr(hecho[i]->Descripcion, clave))
        {
            return hecho[i];
        }
    }
    return NULL;
}
Tarea *BuscaTareaPorId(Tarea ** pendiente, Tarea ** hecho, int id, int cant)
{
    for (int i = 0; i < cant; i++)
    {
        if (pendiente[i] && pendiente[i]->TareaID == id)
        {
            return pendiente[i];
        }
        if (hecho[i] && hecho[i]->TareaID == id)
        {
            return hecho[i];
        }
    }
    return NULL;
}
int menu()
{
    int num;
    printf("\nMENU");
    printf("\n1: Cambiar estado de las tareas pendientes ");
    printf("\n2: Listar las tareas ");
    printf("\n3: Buscar tarea por ID ");
    printf("\n4: Buscar tarea por palabra ");
    printf("\n0: Salir \n");
    scanf("%d", &num);
    return num;
}
void freeMemoria(Tarea *** pendiente, Tarea *** hecho, int cant)
{
    for (int i = 0; i < cant; i++)
    {
        if ((*pendiente)[i])
        {
            free((*pendiente)[i]->Descripcion);
            free((*pendiente)[i]);
        }
    }
    free(*pendiente);    
}