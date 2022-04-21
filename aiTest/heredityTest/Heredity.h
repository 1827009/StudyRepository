#ifndef HEREDITY
#define HEREDITY
#include <list>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <decimal.hh>

const int GENOM_LENGTH=100;
const int MAX_GENOM_LIST=100;
const int SELECT_GENOM=20;
const int INDIVIDUAL_MUTATION=0.01;
const int GENOM_MUTATION=0.01;
const int MAX_GENERATION=40;

class Genom
{
public:
    std::list<bool> genomList;
    int genomListLenge;
    int evaluation;

public:
    Genom(std::list<bool> genomList, int evaluation);
    ~Genom();

    void CreateGenom(int length);
    void Evaluate(Genom genom);

};


#endif //!HEREDITY