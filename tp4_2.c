#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

struct Tarea {
int TareaID; //Numerado en ciclo iterativo
char *Descripcion;
int Duracion; // entre 10 – 100
};

void main ()
{
    int cantidadTareas;
    printf("\nIngrese la cantidad de tareas a realizar: ");
    scanf("%d", &cantidadTareas);

    
    struct Tarea ** TareasPendientes = malloc(sizeof(struct Tarea *)*cantidadTareas);
    for (int i = 0; i < cantidadTareas; i++)
    {
        TareasPendientes[i] = NULL;
    }
    struct Tarea ** TareasRealizadas = malloc(sizeof(struct Tarea *)*cantidadTareas);
    for (int i = 0; i < cantidadTareas; i++)
    {
        TareasRealizadas[i] = NULL;
    }
    char *texto = malloc(sizeof(char)*100);
    srand(time(NULL));
    
    for (int i = 0; i < cantidadTareas; i++)
    {
        TareasPendientes[i] = malloc(sizeof(struct Tarea));
        TareasPendientes[i]->TareaID = i;
        printf("\n\nIngrese la descripcion de la tarea %d :", i+1);
        scanf("%s", texto);
        TareasPendientes[i]->Descripcion = malloc(sizeof(char)*(strlen(texto)+1));
        strcpy(TareasPendientes[i]->Descripcion, texto);
        TareasPendientes[i]->Duracion = 10 + rand()%91;
    }
    free(texto);
    // char respuesta[3];
    int positivo;
    for (int i = 0; i < cantidadTareas; i++)
    {
        if (TareasPendientes[i])
        {
            printf("\nHa realizado la tarea %d? ", i+1);
            // fflush(stdin);
            // gets(respuesta);
            // fflush(stdin);
            scanf("%d", &positivo);
            // if (respuesta == "si"|| respuesta == "SI"|| respuesta == "Si" || respuesta == "sI")
            if (positivo==1)
            {
                TareasRealizadas[i] = TareasPendientes[i];
                TareasPendientes[i] = NULL;
            }
        }
    }



    printf("\n\nTareas Realizadas: ");
    for (int i = 0; i < cantidadTareas; i++)
    {
        if (TareasRealizadas[i])
        {
            printf("\nTarea %d: ", i+1);
            printf("\n  ID: %d",TareasRealizadas[i]->TareaID);
            printf("\n  Descripcion: %s",TareasRealizadas[i]->Descripcion);
            printf("\n  Duracion: %d",TareasRealizadas[i]->Duracion);
            printf("\n---------------------------------------------------------------\n");
        }
    }
    printf("\n\nTareas Pendientes: ");
    for (int i = 0; i < cantidadTareas; i++)
    {
        if (TareasPendientes[i])
        {
            printf("\nTarea %d: ", i+1);
            printf("\n  ID: %d",TareasPendientes[i]->TareaID);
            printf("\n  Descripcion: %s",TareasPendientes[i]->Descripcion);
            printf("\n  Duracion: %d",TareasPendientes[i]->Duracion);
            printf("\n---------------------------------------------------------------\n");
        }
    }
        
}