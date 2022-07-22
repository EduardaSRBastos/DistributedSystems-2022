#include "Utils.h"	

char* Data = "C:/Users/franc/Dropbox/SD/Teatro.csv";
Array Cidades; //Array de string
Array Interesses; //Array de string
Array Teatros; //Array de Teatro

void Alloc_Mem();
void Free_Mem();
int ReadCsv();
void Alloc_Main_Loop(Requirement* Req, Array* RecomendedIndex, Array* WatchedIndex);
void Free_Main_Loop(Requirement* Req, Array* RecomendedIndex, Array* WatchedIndex);
void Filter(Requirement Req, Array* Recommended, Array Watched);
DWORD WINAPI Main_Loop(LPVOID lpParam);


int main() {
	Alloc_Mem();
	Teatros.size = ReadCsv();

	WSADATA wsData;
	WORD ver = MAKEWORD(2, 2);

	printf("\nInitialising Winsock...");
	if (WSAStartup(ver, &wsData)) {
		fprintf(stderr, "\nWinsock setup fail! Error Code : %d\n", WSAGetLastError());
		return 1;
	}

	// Create a socket
	SOCKET listening = socket(AF_INET, SOCK_STREAM, 0);
	if (listening == INVALID_SOCKET) {
		fprintf(stderr, "\nSocket creationg fail! Error Code : %d\n", WSAGetLastError());
		return 1;
	}

	printf("\nSocket created.");

	// Bind the socket (ip address and port)
	struct sockaddr_in hint;
	hint.sin_family = AF_INET;
	hint.sin_port = htons((u_short)DS_TEST_PORT);
	hint.sin_addr.S_un.S_addr = INADDR_ANY;

	bind(listening, (struct sockaddr*)&hint, sizeof(hint));

	// Setup the socket for listening
	listen(listening, SOMAXCONN);

	// Wait for connection
	struct sockaddr_in client;
	int clientSize = sizeof(client);
	HANDLE  hThread;
	DWORD dwThreadId;


	while (true) {
		SOCKET clientSocket = accept(listening, (struct sockaddr*)&client, &clientSize);

		hThread = CreateThread(
			NULL,                   // default security attributes
			0,                      // use default stack size  
			Main_Loop,				// thread function name
			&clientSocket,          // argument to thread function 
			0,                      // use default creation flags 
			&dwThreadId);   // returns the thread identifier 
		if (hThread == NULL)
		{
			printf("\nThread Creation error.");
			ERRO();
		}
	}

	Free_Mem();

	closesocket(listening);
	WSACleanup();
}

DWORD WINAPI Main_Loop(LPVOID lpParam) {

	// Main program loop

	char msg[MAX_SIZE];
	String strMsg, strRec;
	Requirement Req;
	Array RecomendedIndex, WatchedIndex;
	int num = 1, sent = 0;
	SOCKET clientSocket = *((SOCKET*)lpParam);

	Alloc_Main_Loop(&Req, &RecomendedIndex, &WatchedIndex);

	STRCOPY(strMsg, "\n100 OK\n");
	SEND(clientSocket, strMsg.data, strMsg.size + 1, 0);

	while (TRUE) {
		ZeroMemory(msg, MAX_SIZE);
		RECV(clientSocket, msg, MAX_SIZE, 0);
		STRCOPY(strRec, msg);

		printf("%i : %s\n", num++, strRec.data);

		if (!strcmp(strRec.data, "DATA")) {
			SEND(clientSocket, &Cidades.size, sizeof(size_t), 0);
			SEND(clientSocket, Cidades.data, sizeof(String) * Cidades.size, 0);
			SEND(clientSocket, &Interesses.size, sizeof(size_t), 0);
			SEND(clientSocket, Interesses.data, sizeof(String) * Interesses.size, 0);

			RECV(clientSocket, &Req.size, sizeof(size_t), 0);
			RECV(clientSocket, &Req.Location.size, sizeof(size_t), 0);
			RECV(clientSocket, Req.Location.data, sizeof(String) * Req.Location.size, 0);
			RECV(clientSocket, &Req.Tema.size, sizeof(size_t), 0);
			RECV(clientSocket, Req.Tema.data, sizeof(String) * Req.Tema.size, 0);

			Filter(Req, &RecomendedIndex, WatchedIndex);

			size_t To_Send = RecomendedIndex.size - sent;
			SEND(clientSocket, &To_Send, sizeof(size_t), 0);

			for (; sent < RecomendedIndex.size; sent++) {
				SEND(clientSocket, ((Teatro*)Teatros.data) + ((size_t*)RecomendedIndex.data)[sent], sizeof(Teatro), 0);
			}
			SEND(clientSocket, &RecomendedIndex.size, sizeof(size_t), 0);
			SEND(clientSocket, RecomendedIndex.data, sizeof(size_t) * RecomendedIndex.size, 0);
			SEND(clientSocket, &WatchedIndex.size, sizeof(size_t), 0);
			SEND(clientSocket, WatchedIndex.data, sizeof(size_t) * WatchedIndex.size, 0);
		}
		if (!strcmp(strRec.data, "WATCH")) {
			Array IndexRec;
			MALLOC_ARR(IndexRec, MAX_SIZE * sizeof(size_t));

			RECV(clientSocket, &IndexRec.size, sizeof(size_t), 0);
			RECV(clientSocket, IndexRec.data, IndexRec.size * sizeof(size_t), 0);
			for (size_t i = 0; i < IndexRec.size; i++) {
				if (!FindArrInt(WatchedIndex, ((size_t*)IndexRec.data)[i]))
					((size_t*)WatchedIndex.data)[WatchedIndex.size++] = ((size_t*)IndexRec.data)[i];
			}

			free(IndexRec.data);

			STRCOPY(strMsg, "\nOK\n");
			SEND(clientSocket, strMsg.data, strMsg.size + 1, 0);
			SEND(clientSocket, &WatchedIndex.size, sizeof(size_t), 0);
			SEND(clientSocket, WatchedIndex.data, sizeof(size_t) * WatchedIndex.size, 0);
		}
		if (!strcmp(strRec.data, "QUIT")) {
			STRCOPY(strMsg, "\n400BYE\n");
			SEND(clientSocket, strMsg.data, strMsg.size + 1, 0);
			Free_Main_Loop(&Req, &RecomendedIndex, &WatchedIndex);
			break;
		}
	}

	closesocket(clientSocket);
	return 0;
}

void Alloc_Mem() {
	MALLOC_ARR(Teatros, MAX_SIZE * sizeof(Teatro));
	MALLOC_ARR(Cidades, CITY_TEMA_MAX * sizeof(String));
	MALLOC_ARR(Interesses, CITY_TEMA_MAX * sizeof(String));
}
void Free_Mem() {
	free(Teatros.data);
	free(Cidades.data);
	free(Interesses.data);
}

void Alloc_Main_Loop(Requirement* Req, Array* RecomendedIndex, Array* WatchedIndex) {
	MALLOC_ARR(Req->Location, CITY_TEMA_MAX * sizeof(String));
	MALLOC_ARR(Req->Tema, CITY_TEMA_MAX * sizeof(String));

	MALLOC_ARR(*RecomendedIndex, MAX_SIZE * sizeof(size_t));
	MALLOC_ARR(*WatchedIndex, MAX_SIZE * sizeof(size_t));
}
void Free_Main_Loop(Requirement* Req, Array* RecomendedIndex, Array* WatchedIndex) {
	free(Req->Location.data);
	free(Req->Tema.data);
	free(RecomendedIndex->data);
	free(WatchedIndex->data);
}


void Filter(Requirement Req, Array* Recommended, Array Watched) {
	for (size_t i = 0; i < Teatros.size; i++) {
		if (FindArrStr(Req.Location, ((Teatro*)Teatros.data)[i].Local) &&
			FindArrStr(Req.Tema, ((Teatro*)Teatros.data)[i].Tema))
			if (!FindArrInt(*Recommended, i) && !FindArrInt(Watched, i))
				((size_t*)Recommended->data)[Recommended->size++] = i;
		if (Recommended->size >= Req.size)
			return;
	}
	for (size_t i = 0; i < Teatros.size; i++) {
		if (FindArrStr(Req.Location, ((Teatro*)Teatros.data)[i].Local) &&
			!FindArrStr(Req.Tema, ((Teatro*)Teatros.data)[i].Tema))
			if (!FindArrInt(*Recommended, i) && !FindArrInt(Watched, i))
				((size_t*)Recommended->data)[Recommended->size++] = i;
		if (Recommended->size >= Req.size)
			return;
	}
	for (size_t i = 0; i < Teatros.size; i++) {
		if (!FindArrStr(Req.Location, ((Teatro*)Teatros.data)[i].Local) &&
			FindArrStr(Req.Tema, ((Teatro*)Teatros.data)[i].Tema))
			if (!FindArrInt(*Recommended, i) && !FindArrInt(Watched, i))
				((size_t*)Recommended->data)[Recommended->size++] = i;
		if (Recommended->size >= Req.size)
			return;
	}
	for (size_t i = 0; i < Teatros.size; i++) {
		if (!FindArrStr(Req.Location, ((Teatro*)Teatros.data)[i].Local) &&
			!FindArrStr(Req.Tema, ((Teatro*)Teatros.data)[i].Tema))
			if (!FindArrInt(*Recommended, i) && !FindArrInt(Watched, i))
				((size_t*)Recommended->data)[Recommended->size++] = i;
		if (Recommended->size >= Req.size)
			return;
	}
}




int ReadCsv()
{
	int i = 0;
	char FILL[MAX_SIZE], local[MAX_SIZE], teatro[MAX_SIZE], nome[MAX_SIZE], tema[MAX_SIZE];
	ZeroMemory(local, MAX_SIZE);

	FILE* fd = fopen(Data, "r");
	if (!fd) {
		printf("Erro a abrir o ficheiro: %s\n", strerror(errno));
		ERRO();
	}
	while (fgetc(fd) != '\n');
	while (fgetc(fd) != EOF) {

		if (fscanf(fd, "%[^;];%[^;];%[^;];%[^;];%[^;];%[^\n]\n",
			local, teatro, nome, FILL, FILL, tema) != 6) {
			ERRO();
		}
		STRCOPY(((Teatro*)Teatros.data)[i].Local, local);
		STRCOPY(((Teatro*)Teatros.data)[i].Teatro, teatro);
		STRCOPY(((Teatro*)Teatros.data)[i].Nome, nome);
		STRCOPY(((Teatro*)Teatros.data)[i].Tema, tema);

		AddStrArray(&Cidades, ((Teatro*)Teatros.data)[i].Local);
		AddStrArray(&Interesses, ((Teatro*)Teatros.data)[i].Tema);
		if (++i == MAX_SIZE)
			break;

	}
	return i;
}