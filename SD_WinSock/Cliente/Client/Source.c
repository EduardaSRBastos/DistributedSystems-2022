#include "Utils.h"

char* Data = "C:/Users/franc/Dropbox/SD/Teatro.csv";
Array Teatros_Rec; //Array de Teatro
Array Index_Teatros_Vistos; //Array de size_t
Array Index_Teatros_Rec; //Array de size_t


void Alloc_Mem();
void Free_Mem();
void Alloc_Main_Loop(Requirement* Req, Array* TotalCities, Array* TotalTemas);
void Free_Main_Loop(Requirement* Req, Array* TotalCities, Array* TotalTemas);
void GetInterest(Array* Requirment_Array, Array arr);
bool Apresentar_Teatros(Array* val);


int main() {
	WSADATA wsa;
	SOCKET s;
	struct sockaddr_in server;
	char IpAddress[17], end = 0;

	Alloc_Mem();

	// Initialise winsock
	printf("\nInitialising Winsock...");
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("Failed. Error Code : %d", WSAGetLastError());
		return 1;
	}

	printf("Initialised.\n");

	//Create a socket
	s = socket(AF_INET, SOCK_STREAM, 0);
	if (s == INVALID_SOCKET)
	{
		printf("Could not create socket : %d", WSAGetLastError());
	}

	printf("Socket created.\n");

	printf("\n\nServer ip address:");
	if (scanf("%16[0-9.]+", IpAddress) != 1)
		ERRO();
	IpAddress[strlen(IpAddress)] = '\0';

	// create the socket  address (ip address and port)
	server.sin_addr.s_addr = inet_addr(IpAddress);
	server.sin_family = AF_INET;
	server.sin_port = htons((u_short)68000);

	//Connect to remote server
	if (connect(s, (struct sockaddr*)&server, sizeof(server)))
	{
		puts("connect error");
		return 1;
	}

	puts("Connected");

	//Main Loop
	char Msg[MAX_SIZE];
	String strMsg, strRec;

	RECV(s, Msg, MAX_SIZE, 0);
	STRCOPY(strRec, Msg);
	puts(strRec.data);


	while (true) {
		int option = -1;
		ZeroMemory(Msg, MAX_SIZE);

		printf("\n\n\n1 - Obter Teatros\t2 - Apresentar Teatros\t 3 - Sair\n");
		printf("Mensagem:");
		if (scanf("%d", &option) != 1)
			ERRO();
		while (getchar() != '\n');

		if (option == 1) {
			Array TotalCities, TotalTemas;
			Requirement Req;
			size_t ToRecive;
			Alloc_Main_Loop(&Req, &TotalCities, &TotalTemas);


			STRCOPY(strMsg, "DATA");
			SEND(s, strMsg.data, strMsg.size + 1, 0);

			RECV(s, &TotalCities.size, sizeof(size_t), 0);
			RECV(s, TotalCities.data, sizeof(String) * TotalCities.size, 0);
			RECV(s, &TotalTemas.size, sizeof(size_t), 0);
			RECV(s, TotalTemas.data, TotalTemas.size * sizeof(String), 0);

			printf("\n\nQuantidade de teatros que deseja receber:");
			if (scanf("%zu", &(Req.size)) != 1)
				ERRO();
			while (getchar() != '\n');
			GetInterest(&(Req.Location), TotalCities);
			GetInterest(&(Req.Tema), TotalTemas);

			SEND(s, &Req.size, sizeof(size_t), 0);
			SEND(s, &(Req.Location.size), sizeof(size_t), 0);
			SEND(s, Req.Location.data, Req.Location.size * sizeof(String), 0);
			SEND(s, &(Req.Tema.size), sizeof(size_t), 0);
			SEND(s, Req.Tema.data, Req.Tema.size * sizeof(String), 0);

			RECV(s, &ToRecive, sizeof(size_t), 0);
			for (size_t i = 0; i < ToRecive; i++) {
				RECV(s, ((Teatro*)Teatros_Rec.data) + Teatros_Rec.size, sizeof(Teatro), 0);
				Teatros_Rec.size++;
			}
			RECV(s, &Index_Teatros_Rec.size, sizeof(size_t), 0);
			RECV(s, Index_Teatros_Rec.data, Index_Teatros_Rec.size * sizeof(size_t), 0);
			RECV(s, &Index_Teatros_Vistos.size, sizeof(size_t), 0);
			RECV(s, Index_Teatros_Vistos.data, Index_Teatros_Vistos.size * sizeof(size_t), 0);

			printf("\n\nTeatros Recebidos: %zu", Index_Teatros_Rec.size);
			printf("\n\nTeatros Vistos: %zu", Index_Teatros_Vistos.size);
			Free_Main_Loop(&Req, &TotalCities, &TotalTemas);
		}
		else if (option == 2) {
			Array val;
			val.data = malloc(MAX_SIZE * sizeof(size_t));
			if (Teatros_Rec.size == 0) {
				printf("\n\nAinda nao Contem a informação de nenhum teatro!\n");
				continue;
			}
			if (!Apresentar_Teatros(&val))
				continue;
			STRCOPY(strMsg, "WATCH");
			SEND(s, strMsg.data, strMsg.size + 1, 0);

			SEND(s, &val.size, sizeof(size_t), 0);
			SEND(s, val.data, val.size * sizeof(size_t), 0);

			RECV(s, Msg, MAX_SIZE, 0);
			STRCOPY(strRec, Msg);
			puts(strRec.data);

			RECV(s, &Index_Teatros_Vistos.size, sizeof(size_t), 0);
			RECV(s, Index_Teatros_Vistos.data, Index_Teatros_Vistos.size * sizeof(size_t), 0);

		}
		else if (option == 3) {
			STRCOPY(strMsg, "QUIT");
			SEND(s, strMsg.data, strMsg.size + 1, 0);
			RECV(s, Msg, MAX_SIZE, 0);
			STRCOPY(strRec, Msg);
			Free_Mem();
			// Close the socket
			closesocket(s);
			//Cleanup winsock
			WSACleanup();
			return 0;
		}
	}

}






void Alloc_Mem() {
	Teatros_Rec.data = malloc(MAX_SIZE * sizeof(Teatro));
	Teatros_Rec.size = 0;
	Index_Teatros_Vistos.data = malloc(MAX_SIZE * sizeof(size_t));
	Index_Teatros_Vistos.size = 0;
	Index_Teatros_Rec.data = malloc(MAX_SIZE * sizeof(size_t));
	Index_Teatros_Rec.size = 0;
}
void Free_Mem() {
	free(Teatros_Rec.data);
	free(Index_Teatros_Vistos.data);
	free(Index_Teatros_Rec.data);
}

void Alloc_Main_Loop(Requirement* Req, Array* TotalCities, Array* TotalTemas) {
	Req->Location.data = malloc(sizeof(String) * CITY_TEMA_MAX);
	Req->Location.size = 0;
	Req->Tema.data = malloc(sizeof(String) * CITY_TEMA_MAX);
	Req->Tema.size = 0;

	TotalCities->data = malloc(MAX_SIZE * sizeof(String));
	TotalCities->size = 0;
	TotalTemas->data = malloc(MAX_SIZE * sizeof(String));
	TotalTemas->size = 0;
}
void Free_Main_Loop(Requirement* Req, Array* TotalCities, Array* TotalTemas) {
	free(Req->Location.data);
	free(Req->Tema.data);
	free(TotalCities->data);
	free(TotalTemas->data);
}



bool GetInput(Array* retVal, char Separator, size_t MaxIndex);

void GetInterest(Array* Requirment_Array, Array arr) {
	Array val;
	val.data = malloc(MAX_SIZE * sizeof(size_t));

	do {
		printf("\n\nEscolha no quais que esta interessado:\t(Val,Val,...)\n");
		for (int i = 0; i < arr.size; i++) {
			printf("%d - %s\n", i, ((String*)arr.data)[i].data);
		}
		printf("\n\nResposta:");
	}while(!GetInput(&val, ',', arr.size));

	for (int i = 0; i < val.size; i++) {
		STRCOPY(((String*)Requirment_Array->data)[Requirment_Array->size], ((String*)arr.data)[((size_t*)val.data)[i]].data);
		Requirment_Array->size++;
	}
	free(val.data);

}


bool Apresentar_Teatros(Array* val) {
	char Res;

	do {

		printf("\n\nTeatros:\n\n");
		for (size_t i = 0; i < Index_Teatros_Rec.size; i++)
			if (!FindArrInt(Index_Teatros_Vistos, ((size_t*)Index_Teatros_Rec.data)[i]))
				printf("Index:%zu\nLocal:%s\nNome:%s\nNome do Teatro:^%s\nTema:%s\n\n\n",
					i,
					((Teatro*)Teatros_Rec.data)[i].Local.data,
					((Teatro*)Teatros_Rec.data)[i].Nome.data,
					((Teatro*)Teatros_Rec.data)[i].Teatro.data,
					((Teatro*)Teatros_Rec.data)[i].Tema.data);


		printf("\nJa assistiu a algum teatro?[Y|N]:");
		if (scanf("%c", &Res) != 1) {
			ERRO();
		}
		while (getchar() != '\n');
		Res = toupper(Res);

		if (Res != 'Y' && Res != '\n')
			return false;
		printf("Qual o/os teatros que ja viu? (index,index...)\n");
		printf("Resposta:");
	} while (!GetInput(val, ',', Teatros_Rec.size));
	for (size_t i = 0; i < val->size; i++)
		((size_t*)val->data)[i] = ((size_t*)Index_Teatros_Rec.data)[((size_t*)val->data)[i]];

	return true;
}




bool GetInput(Array* retVal, char Separator, size_t MaxIndex) {
	retVal->size = 0;
	char buffer[MAX_SIZE];

	for (int i = 0; i < MAX_SIZE;) {
		char input = getc(stdin);
		if (input == Separator) {
			if (i == 0)
				continue;
			int val;
			buffer[i] = '\0';
			if ((val = (size_t)atoi(buffer)) >= MaxIndex) {
				printf("\nIndex fora de alcance\n");
				while (getchar() != '\n');
				return false;
			}
			i = 0;
			if (!FindArrInt(*retVal, val))
				((size_t*)retVal->data)[retVal->size++] = val;
			if (retVal->size == MaxIndex)
				return true;
		}
		if (input >= '0' && input <= '9')
			buffer[i++] = input;
		if (input == '\n') {
			if (i == 0 && retVal->size != 0)
				return true;
			if (i == 0 && retVal->size == 0)
				return false;

			size_t val;
			buffer[i] = '\0';
			if ((val = (size_t)atoi(buffer)) >= MaxIndex) {
				printf("\nIndex fora de alcance\n");
				return false;
			}
			if (!FindArrInt(*retVal, val))
				((size_t*)retVal->data)[retVal->size++] = val;
			return true;
		}
	}
	return true;
}