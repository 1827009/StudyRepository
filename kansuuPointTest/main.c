#include<stdio.h>
int Sample(char* text);
int Sample2(char* text);
int Sample3(char* text);
int main(int argc, char const *argv[])
{
    char* text="SampleText";
    int (*point)(char*)=Sample;
    int i = (*point)(text);

    int (*points[])(char*)={Sample,Sample2,Sample3};
    for (int i = 0; i < 3; i++)
    {
        (*points[i])(text);
    }
    


    return 0;
}

int Sample(char* text){
    printf(text);
    return 1;
}
int Sample2(char* text){
    printf("%s 2",text);
    return 1;
}
int Sample3(char* text){
    printf("%s 3",text);
    return 1;
}