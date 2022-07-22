#pragma once
#include <stdio.h>
#include <stdlib.h>
#include <winsock2.h>
#include <time.h>
#include <process.h>
#include <stdbool.h>
#include <errno.h>

#define DS_TEST_PORT 68000
#define MAX_SIZE 128
#define CITY_TEMA_MAX 10

#define ERRO() {ExitProcess(3);}

#define SEND(sock, buff, len, flags) {											\
	if ((len) >= 1){															\
		int rec;																\
		rec = send(sock, ((char*)(buff)), ((int)(len)), flags);					\
		if (rec < 0)															\
		{																		\
			puts("Send failed");												\
			ERRO();																\
		}																		\
	}																			\
}
#define RECV(sock, buff, len, flags) {											\
	int rec;																	\
	if((len) >= 1){																\
		rec = recv(sock, ((char*)(buff)), ((int)(len)), flags);					\
		if (rec == SOCKET_ERROR)												\
		{																		\
			puts("recv failed");												\
			ERRO();																\
		}																		\
		if (rec == 0) {															\
			printf("\nClient disconnected!\n");									\
			ERRO();																\
		}																		\
	}																			\
}
#define STRCOPY(dest, source) {							\
	(dest).size = strlen(source);						\
	strcpy((dest).data, source);						\
}
#define MALLOC_ARR(Arr, Size) {							\
	(Arr).data = malloc(Size);							\
	if((Arr).data == NULL)								\
		ERRO();											\
	(Arr).size = 0;										\
}

#pragma comment (lib, "ws2_32.lib")
#pragma warning(disable : 4996)
#pragma warning(disable : 6054)

typedef struct __ARRAY__ {
	void* data;
	size_t size;
}Array;

typedef struct __STRING__ {
	char data[MAX_SIZE];
	size_t size;
}String;

typedef struct __TEATRO__ {
	String Local;
	String Teatro;
	String Nome;
	String Tema;
}Teatro;

typedef struct __REQUIREMENTS__ {
	Array Location;
	Array Tema;
	size_t size;
}Requirement;

bool FindArrStr(Array arr, String str);
bool FindArrInt(Array arr, size_t i);
void AddStrArray(Array* arr, String str);
