#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

struct Tarea {
    int TareaID; //Numerado en ciclo iterativo
    char *Descripcion;
    int Duracion; // entre 10 – 100
};

void cantTareas(int *nroTareas);
void inicializar(struct Tarea *** lista, int cant);
void cargarTareas(struct Tarea ** lista, int cant);
void comprobarEstadoTareas(struct Tarea ** pendiente, struct Tarea ** hecho, int cant);
void mostrarAmbos(struct Tarea ** pendiente, struct Tarea ** hecho, int cant);
void mostrarLista(struct Tarea ** lista, int cant);
void mostrarTarea(struct Tarea * tarea);
struct Tarea *BuscarTarea(struct Tarea ** lista, int id, int cant);




void main ()
{
    int cantidadTareas, buscado=1;
    cantTareas(&cantidadTareas);
    struct Tarea ** TareasPendientes, ** TareasRealizadas;
    inicializar(&TareasPendientes, cantidadTareas);
    inicializar(&TareasRealizadas, cantidadTareas);
    cargarTareas(TareasPendientes, cantidadTareas);
    comprobarEstadoTareas(TareasPendientes, TareasRealizadas, cantidadTareas);
    mostrarAmbos(TareasPendientes, TareasRealizadas, cantidadTareas);
    printf("\nBusco la tarea %d en Tareas Pendientes", buscado);
    mostrarTarea(BuscarTarea(TareasPendientes, buscado, cantidadTareas));
}



void cantTareas(int *nroTareas)
{
    printf("\nIngrese la cantidad de tareas a realizar: ");
    scanf("%d", nroTareas);
}

void inicializar(struct Tarea *** lista, int cant) 
{
    *lista = malloc(sizeof(struct Tarea *)*cant);
    for (int i = 0; i < cant; i++)
    {
        (*lista)[i] = NULL;
    } 
}
void cargarTareas(struct Tarea ** lista, int cant)
{
    char *texto = malloc(sizeof(char)*100);
    srand(time(NULL));
    for (int i = 0; i < cant; i++)
    {
        lista[i] = malloc(sizeof(struct Tarea));
        lista[i]->TareaID = i;
        printf("\nIngrese la descripcion de la tarea %d :", i+1);
        scanf("%s", texto);
        lista[i]->Descripcion = malloc(sizeof(char)*(strlen(texto)+1));
        strcpy(lista[i]->Descripcion, texto);
        lista[i]->Duracion = 10 + rand()%91;
    }
    free(texto);
}
void comprobarEstadoTareas(struct Tarea ** pendiente, struct Tarea ** hecho, int cant)
{
    int positivo;
    for (int i = 0; i < cant; i++)
    {
        if (pendiente[i])
        {
            printf("\nHa realizado la tarea %d: \"%s\"? \n", pendiente[i]->TareaID, pendiente[i]->Descripcion);
            do
            {
                printf(" 1: SI \n 0: NO \n" );
                scanf("%d", &positivo);
            } while (positivo!= 1 && positivo!= 0);
            if (positivo)
            {
                hecho[i] = pendiente[i];
                pendiente[i] = NULL;
            }
        }
    }
}

void mostrarAmbos(struct Tarea ** pendiente, struct Tarea ** hecho, int cant)
{
    printf("\n\nTareas Realizadas: ");
    mostrarLista(hecho, cant);
    printf("\n\nTareas Pendientes: ");
    mostrarLista(pendiente, cant);
}
void mostrarLista(struct Tarea ** lista, int cant)
{
    for (int i = 0; i < cant; i++)
    {
        if (lista[i])
            mostrarTarea(lista[i]);
    }
}
void mostrarTarea(struct Tarea * tarea)
{
    printf("\n  ID: %d",tarea->TareaID);
    printf("\n  Descripcion: %s",tarea->Descripcion);
    printf("\n  Duracion: %d",tarea->Duracion);
    printf("\n---------------------------------------------------------------");
}
struct Tarea *BuscarTarea(struct Tarea ** lista, int id, int cant){
    for (int i = 0; i < cant; i++)
    {
        if (lista[i]->TareaID == id)
            return lista[i];
    }
    return NULL;
}