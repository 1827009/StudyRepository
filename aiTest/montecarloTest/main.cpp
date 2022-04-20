#include <stdio.h>
#include <stdlib.h>
#include <time.h>
 
int main(void){
 
  int count = 0;
  const int max = 1000000;
 
  srand(time(NULL));
 
  // ランダムな座標を確認、円の中に入っているか調べる
  for(int i=0;i<max;i++){
    double x = (double)rand()/RAND_MAX;
    double y = (double)rand()/RAND_MAX;
    double z = x*x + y*y;
    if(z<=1)
      count++;
  }
 
  // 入っている割合を求め、今回はx,yがプラスの値しかないため、円の1/4しか測ってないので4倍する
  double pi = (double)count / max * 4;
  printf("%f\n", pi);
 
  return 0;
}
