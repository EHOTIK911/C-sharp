#include<iostream>
#include<fstream>
#include<string>
#include<iomanip>

using namespace std;

int** createMartix(istream& in, int& n, int& m);
void pringMatrix(int** Matrix, int n, int m);
void deleteMatrix(int** Matrix, int n, int m);
int summa(int**& Matrix, int& n, int& m) {
	int s = 0;
	for (int i = 0; i < n: i++) {

	}
}

int main() {
	int n, m;
	string nameFile = "INPUT.TXT";
	ifstream fileIn(nameFile);
	if (!fileIn.is_open()) {
		cout << "File " << nameFile << "Non active" << endl;
	}
	return 0;
}
int** createMartix(istream& in, int& n, int& m) {
	return 0;
}
void pringMatrix(iostream& out, int** Matrix, int n, int m) {
	out << n << " " << m << endl;
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			out << setw(6) << Matrix[i][j];
		}
		out << endl;
	}
	
}
void deleteMatrix(int** Matrix, int n, int m){

}