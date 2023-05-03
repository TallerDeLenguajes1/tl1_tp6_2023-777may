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
void mostrarLista(struct Tarea ** lista, int cant, char texto[]);
void mostrarTarea(struct Tarea * tarea);
struct Tarea *BuscaTareaPorPalabra(struct Tarea ** pendiente, struct Tarea ** hecho, char * clave, int cant);
struct Tarea *BuscaTareaPorId(struct Tarea ** pendiente, struct Tarea ** hecho, int id, int cant);
int menu();
void freeMemoria(struct Tarea *** pendiente, struct Tarea *** hecho, int cant);



void main ()
{
    int cantidadTareas, buscado, num;
    char clave[100];
    cantTareas(&cantidadTareas);
    struct Tarea ** TareasPendientes, ** TareasRealizadas;
    inicializar(&TareasPendientes, cantidadTareas);
    inicializar(&TareasRealizadas, cantidadTareas);
    cargarTareas(TareasPendientes, cantidadTareas);
    num = menu();
    while (num != 0)
    {
        switch (num)
        {
        case 1:
            comprobarEstadoTareas(TareasPendientes, TareasRealizadas, cantidadTareas);
            break;
        case 2:
            mostrarAmbos(TareasPendientes, TareasRealizadas, cantidadTareas);
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
        fflush(stdin);
        gets( texto);
        fflush(stdin);
        lista[i]->Descripcion = malloc(sizeof(char)*(strlen(texto)+1));
        strcpy(lista[i]->Descripcion, texto);
        lista[i]->Duracion = 10 + rand()%91;
    }
    free(texto);
}
void comprobarEstadoTareas(struct Tarea ** pendiente, struct Tarea ** hecho, int cant)
{
    int positivo, bandera=0;
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
            bandera=1;
        }
    }
    if (bandera == 0){
        printf("\n  No quedan tareas pendientes\n");
    }
}
void mostrarAmbos(struct Tarea ** pendiente, struct Tarea ** hecho, int cant)
{
    mostrarLista(hecho, cant, "Realizadas");
    mostrarLista(pendiente, cant, "Pendientes");
}
void mostrarLista(struct Tarea ** lista, int cant, char texto[])
{
    int bandera=0;
    printf("\n\nTareas %s: ", texto);
    for (int i = 0; i < cant; i++)
    {
        if (lista[i]){
            mostrarTarea(lista[i]);
            bandera = 1;
        }
    }

    if (bandera == 0)
    {
        printf("\n    No hay tareas %s \n", texto);
    }
}
void mostrarTarea(struct Tarea * tarea)
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
struct Tarea *BuscaTareaPorPalabra(struct Tarea ** pendiente, struct Tarea ** hecho, char * clave, int cant)
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
struct Tarea *BuscaTareaPorId(struct Tarea ** pendiente, struct Tarea ** hecho, int id, int cant)
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
void freeMemoria(struct Tarea *** pendiente, struct Tarea *** hecho, int cant)
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