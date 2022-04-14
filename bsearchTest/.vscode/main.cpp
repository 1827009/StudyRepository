// crt_bsearch.c
#include <search.h>
#include <string.h>
#include <stdio.h>
#include <math.h>

bool MyBsearch(char *key, char **list, int listSize);
void MySort(char **list, int listSize);

void PrintList(char **list, int listSize);

int main(void)
{
   char *arr[] = {"A", "H", "G", "D", "C", "E", "F", "J", "B", "I", "K"}; //{"dog", "pig", "horse", "cat", "human", "rat", "cow", "goat"};
   int listSize = sizeof(arr) / sizeof(arr[0]);

   for (int i = 0; i < listSize; i++)
   {
      printf("%d: ", i);
      printf("これが: %s", arr[i]);
      if (MyBsearch(arr[i], arr, listSize))
         printf("あった\n");
      else
         printf("ない\n");
   }

   char *key = "NON";
   printf("これが: %s", key);
   if (MyBsearch(key, arr, listSize))
      printf("あった\n");
   else
      printf("ない\n");
}

bool MyBsearch(char *key, char *list[], int listSize)
{
   MySort(list, listSize);

   int l = -1;
   int r = listSize;
   while ((r-l)*0.5f>=1)
   {
      int index=l+(r-l)*0.5f;
      
      int cmp = strcmp(key, list[index]);
      if (cmp == -1)
         r = index;
      else if (cmp == 1)
         l = index;
      else
         return true;
   }

   return false;
}
void MySort(char **list, int listSize)
{
   /*for (int i = 0; i < listSize; i++)
   {
      printf(list[i]);
      printf(" ");
   }
   printf("\n");*/

   bool sortOk = false;
   do
   {
      sortOk = false;
      for (int i = 0; i < listSize - 1; i++)
      {
         if (strcmp(list[i], list[i + 1]) == 1)
         {
            char *temp = list[i];
            list[i] = list[i + 1];
            list[i + 1] = temp;

            sortOk = true;
            break;
         }
      }
   } while (sortOk);
}

void PrintList(char **list, int listSize)
{
   for (int i = 0; i < listSize; i++)
   {
      printf(list[i]);
      printf(" ");
   }
   printf("\n");
}