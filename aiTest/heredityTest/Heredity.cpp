// 参考サイト:https://qiita.com/Azunyan1111/items/975c67129d99de33dc21
// バイナリエンコーディングを採用。int型の
#include<Heredity.h>

Genom::Genom(std::list<bool> genomList, int evaluation){
    this->genomList=genomList;
    this->evaluation=evaluation;

    srand(time(NULL));

}

void Genom::CreateGenom(int length){    
    for (int i = 0;i < length; i++)
    {
        this->genomList.push_front(rand()%2);
    }
}

void Genom::Evaluate(Genom genom){
    decimal::Decimal(10, 2) total;

    for (int i = 0; i < this->(int)genomList.size() ; i++)
    {
         total += this->genomList[i]
    }
    
    

}