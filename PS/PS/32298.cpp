#include <iostream>

using namespace std;

int main() {
	int n, m; cin >> n >> m;
	int output = m*2;
	while (n-- > 0) {
		printf("%d ", output);
		output += m;
	}
}