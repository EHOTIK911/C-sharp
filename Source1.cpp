#include <iostream>
using namespace std;
int main()
{
    int x, L, M;
    cin >> x;
    L = x;
    M = 65;
    if (L % 2 == 0)
        M = 52;
    while (L != M) {
        if (L > M)
            L = L - M;
        else
            M = M - L;
    }
    cout << M << endl;
}
